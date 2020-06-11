using NUnit.Framework;
using SharpPcap;
using System;

namespace Test.Performance
{
	[TestFixture]
	public class PacketReading
	{
		private readonly int packetsToRead = 50000000;

		[Category("Performance")]
		[Test]
		public void Benchmark()
		{
			int packetsRead = 0;
			var startTime = DateTime.Now;
			while (packetsRead < packetsToRead)
			{
				var captureDevice = new SharpPcap.LibPcap.CaptureFileReaderDevice(TestHelper.GetFile("10k_packets.pcap"));
				captureDevice.Open();

				RawCapture rawCapture = null;
				do
				{
					rawCapture = captureDevice.GetNextPacket();
					packetsRead++;
				}
				while (rawCapture != null);

				captureDevice.Close();
			}

			var endTime = DateTime.Now;

			var rate = new Rate(startTime, endTime, packetsRead, "packets captured");

			Console.WriteLine("{0}", rate.ToString());
		}

		[Category("Performance")]
		[Test]
		public void BenchmarkICaptureDevice()
		{
			int packetsRead = 0;
			var startTime = DateTime.Now;
			while (packetsRead < packetsToRead)
			{
				ICaptureDevice captureDevice = new SharpPcap.LibPcap.CaptureFileReaderDevice(TestHelper.GetFile("10k_packets.pcap"));
				captureDevice.Open();

				RawCapture rawCapture = null;
				do
				{
					rawCapture = captureDevice.GetNextPacket();
					packetsRead++;
				}
				while (rawCapture != null);

				captureDevice.Close();
			}

			var endTime = DateTime.Now;

			var rate = new Rate(startTime, endTime, packetsRead, "packets captured");

			Console.WriteLine("{0}", rate.ToString());
		}

		[Category("Performance")]
		[Test]
		public unsafe void BenchmarkICaptureDeviceUnsafe()
		{
			int packetsRead = 0;
			var startTime = DateTime.Now;
			while (packetsRead < packetsToRead)
			{
				ICaptureDevice captureDevice = new SharpPcap.LibPcap.CaptureFileReaderDevice(TestHelper.GetFile("10k_packets.pcap"));
				captureDevice.Open();

				RawCapture rawCapture = null;
				do
				{
					rawCapture = captureDevice.GetNextPacket();
					packetsRead++;
				}
				while (rawCapture != null);

				captureDevice.Close();
			}

			var endTime = DateTime.Now;

			var rate = new Rate(startTime, endTime, packetsRead, "packets captured");

			Console.WriteLine("{0}", rate.ToString());
		}
	}
}

