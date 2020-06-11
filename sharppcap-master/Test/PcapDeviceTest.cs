/*
This file is part of SharpPcap.

SharpPcap is free software: you can redistribute it and/or modify
it under the terms of the GNU Lesser General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

SharpPcap is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public License
along with SharpPcap.  If not, see <http://www.gnu.org/licenses/>.
*/
/*
 * Copyright 2010 Chris Morgan <chmorgan@gmail.com>
 */

using NUnit.Framework;
using SharpPcap;
using System;
using static Test.TestHelper;

namespace Test
{
	[TestFixture]
	[NonParallelizable]
	public class PcapDeviceTest
	{
		/// <summary>
		/// Calling PcapDevice.GetNextPacket() while a capture loop is running
		/// in another thread causes errors inside of libpcap where at some point the
		/// capture will simply stop even though the capture thread appears to be running
		/// normally. This appears to be due to corruption of the pcap device structure
		/// allocated by libpcap.
		/// 
		/// Discovering the cause of this bug took me (Chris M.) two and half days of
		/// poking around and looking at strace output.
		/// 
		/// Test that the proper exception is thrown if a user tries to
		/// call GetNextPacket() while a capture loop is running.
		/// </summary>
		[NonParallelizable]
		[Test]
		public void GetNextPacketExceptionIfCaptureLoopRunning()
		{
			var device = GetPcapDevice();

			Assert.IsFalse(device.Started, "Expected device not to be Started");

			device.Open();
			device.OnPacketArrival += HandleOnPacketArrival;

			// start background capture
			device.StartCapture();

			Assert.IsTrue(device.Started, "Expected device to be Started");

			// attempt to get the next packet via GetNextPacket()
			// to ensure that we get the exception we expect
			Assert.Throws<InvalidOperationDuringBackgroundCaptureException>(
				() => device.GetNextPacket()
			);

			device.Close();
		}

		/// <summary>
		/// Test that we get the appropriate exception from PcapDevice.StartCapture() if
		/// there hasn't been any delegates assigned to PcapDevice.OnPacketArrival
		/// </summary>
		[Test]
		public void DeviceNotReadyExceptionWhenStartingACaptureWithoutAddingDelegateToOnPacketArrival()
		{
			var device = GetPcapDevice();

			device.Open();

			Assert.Throws<DeviceNotReadyException>(
				() => device.StartCapture()
			);

			device.Close();
		}

		void HandleOnPacketArrival(object sender, CaptureEventArgs e)
		{

		}

		[SetUp]
		public void SetUp()
		{
			ConfirmIdleState();
		}

		[TearDown]
		public void Cleanup()
		{
			ConfirmIdleState();
		}
	}
}

