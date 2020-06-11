using SharpPcap;
using SharpPcap.LibPcap;
using SharpPcap.Npcap;
using System;

namespace Example3
{
	/// <summary>
	/// Basic capture example
	/// </summary>
	public class BasicCap
	{
		public static void Main(string[] args)
		{
			// Print SharpPcap version
			string ver = SharpPcap.Version.VersionString;
			Console.WriteLine("SharpPcap {0}, Example3.BasicCap.cs", ver);

			// Retrieve the device list
			var devices = CaptureDeviceList.Instance;

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
			Console.Write("-- Please choose a device to capture: ");
			i = int.Parse(Console.ReadLine());

			var device = devices[i];

			// Register our handler function to the 'packet arrival' event
			device.OnPacketArrival +=
				new PacketArrivalEventHandler(device_OnPacketArrival);

			// Open the device for capturing
			int readTimeoutMilliseconds = 1000;
			if (device is NpcapDevice)
			{
				var nPcap = device as NpcapDevice;
				nPcap.Open(SharpPcap.Npcap.OpenFlags.DataTransferUdp | SharpPcap.Npcap.OpenFlags.NoCaptureLocal, readTimeoutMilliseconds);
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
			Console.WriteLine("-- Listening on {0} {1}, hit 'Enter' to stop...",
				device.Name, device.Description);

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

		/// <summary>
		/// Prints the time and length of each received packet
		/// </summary>
		private static void device_OnPacketArrival(object sender, CaptureEventArgs e)
		{
			var time = e.Packet.Timeval.Date;
			var len = e.Packet.Data.Length;
			Console.WriteLine("{0}:{1}:{2},{3} Len={4}",
				time.Hour, time.Minute, time.Second, time.Millisecond, len);
			Console.WriteLine(e.Packet.ToString());
		}
	}
}
