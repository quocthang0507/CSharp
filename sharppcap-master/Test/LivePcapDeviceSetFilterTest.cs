using NUnit.Framework;
using SharpPcap;
using SharpPcap.LibPcap;
using System;

namespace Test
{
	[TestFixture]
	[NonParallelizable]
	public class LivePcapDeviceSetFilterTest
	{
		[Test]
		public void SimpleFilter()
		{
			var devices = LibPcapLiveDeviceList.Instance;
			if (devices.Count == 0)
			{
				throw new InvalidOperationException("No pcap supported devices found, are you running" +
														   " as a user with access to adapters (root on Linux)?");
			}

			devices[0].Open();
			devices[0].Filter = "tcp port 80";
			devices[0].Close(); // close the device
		}

		/// <summary>
		/// Test that we get the expected exception if PcapDevice.SetFilter()
		/// is called on a PcapDevice that has not been opened
		/// </summary>
		[Test]
		public void SetFilterExceptionIfDeviceIsClosed()
		{
			var devices = LibPcapLiveDeviceList.Instance;
			if (devices.Count == 0)
			{
				throw new InvalidOperationException("No pcap supported devices found, are you running" +
														   " as a user with access to adapters (root on Linux)?");
			}

			bool caughtExpectedException = false;
			try
			{
				devices[0].Filter = "tcp port 80";
			}
			catch (DeviceNotReadyException)
			{
				caughtExpectedException = true;
			}

			Assert.IsTrue(caughtExpectedException, "Did not catch the expected PcapDeviceNotReadyException");
		}

		[SetUp]
		public void SetUp()
		{
			TestHelper.ConfirmIdleState();
		}

		[TearDown]
		public void Cleanup()
		{
			TestHelper.ConfirmIdleState();
		}
	}
}
