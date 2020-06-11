using NUnit.Framework;
using PacketDotNet;
using static System.TimeSpan;
/* Unmerged change from project 'Test (net461)'
Before:
using static System.TimeSpan;
After:
using static Test.TestHelper;
*/


namespace Test
{
	[TestFixture]
	[NonParallelizable]
	[Category("SendPacket")]
	public class SendPacketTest
	{
		private const string Filter = "ether proto 0x1234";

		[Test]
		public void TestSendPacketTest()
		{
			var packet = EthernetPacket.RandomPacket();
			packet.Type = (EthernetType)0x1234;
			var received = RunCapture(Filter, (device) =>
			{
				device.SendPacket(packet);
			});
			Assert.That(received, Has.Count.EqualTo(1));
			CollectionAssert.AreEquivalent(packet.Bytes, received[0].Data);
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
