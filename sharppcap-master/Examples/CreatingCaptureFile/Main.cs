using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using SharpPcap.Npcap;
using System;

namespace CreatingCaptureFile
{
	class MainClass
	{
		private static CaptureFileWriterDevice captureFileWriter;

		public static void Main(string[] args)
		{
			// Print SharpPcap version
			string ver = SharpPcap.Version.VersionString;
			Console.WriteLine("SharpPcap {0}, CreatingCaptureFile", ver);

			// Retrieve the device list
			var devices = LibPcapLiveDeviceList.Instance;

			// If no devices were found print an error
			if (devices.Count < 1)
			{
				Console.WriteLine("No devices were found on this machine");
				return;
			}

			Console.WriteLine();
			Console.WriteLine("The following devices are available on this machine:");
			Console.WriteLine("----------------------------------------------------");
			Console.WriteLine();

			int i = 0;

			// Print out the devices
			foreach (var dev in devices)
			{
				/* Description */
				Console.WriteLine("{0}) {1} {2}", i, dev.Name, dev.Description);
				i++;
			}

			Console.WriteLine();
			Console.Write("-- Please choose a device to capture on: ");
			i = int.Parse(Console.ReadLine());
			Console.Write("-- Please enter the output file name: ");
			string capFile = Console.ReadLine();

			var device = devices[i];

			// Register our handler function to the 'packet arrival' event
			device.OnPacketArrival +=
				new PacketArrivalEventHandler(device_OnPacketArrival);

			// Open the device for capturing
			int readTimeoutMilliseconds = 1000;
			if (device is NpcapDevice)
			{
				var npcap = device as NpcapDevice;
				npcap.Open(SharpPcap.Npcap.OpenFlags.DataTransferUdp | SharpPcap.Npcap.OpenFlags.NoCaptureLocal, readTimeoutMilliseconds);
			}
			else if (device is LibPcapLiveDevice)
			{
				var livePcapDevice = device as LibPcapLiveDevice;
				livePcapDevice.Open(DeviceMode.Promiscuous, readTimeoutMilliseconds);
			}
			else
			{
				throw new InvalidOperationException("unknown device type of " + device.GetType().ToString());
			}

			Console.WriteLine();
			Console.WriteLine("-- Listening on {0} {1}, writing to {2}, hit 'Enter' to stop...",
							  device.Name, device.Description,
							  capFile);

			// open the output file
			captureFileWriter = new CaptureFileWriterDevice(device, capFile);

			// Start the capturing process
			device.StartCapture();

			// Wait for 'Enter' from the user.
			Console.ReadLine();

			// Stop the capturing process
			device.StopCapture();

			Console.WriteLine("-- Capture stopped.");

			// Print out the device statistics
			Console.WriteLine(device.Statistics.ToString());

			// Close the pcap device
			device.Close();
		}

		private static int packetIndex = 0;

		/// <summary>
		/// Prints the time and length of each received packet
		/// </summary>
		private static void device_OnPacketArrival(object sender, CaptureEventArgs e)
		{
			//var device = (ICaptureDevice)sender;

			// write the packet to the file
			captureFileWriter.Write(e.Packet);
			Console.WriteLine("Packet dumped to file.");

			if (e.Packet.LinkLayerType == PacketDotNet.LinkLayers.Ethernet)
			{
				var packet = PacketDotNet.Packet.ParsePacket(e.Packet.LinkLayerType, e.Packet.Data);
				var ethernetPacket = (EthernetPacket)packet;

				Console.WriteLine("{0} At: {1}:{2}: MAC:{3} -> MAC:{4}",
								  packetIndex,
								  e.Packet.Timeval.Date.ToString(),
								  e.Packet.Timeval.Date.Millisecond,
								  ethernetPacket.SourceHardwareAddress,
								  ethernetPacket.DestinationHardwareAddress);
				packetIndex++;
			}
		}
	}
}

