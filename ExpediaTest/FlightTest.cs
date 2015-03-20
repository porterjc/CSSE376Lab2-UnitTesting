using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(new DateTime(2000, 12, 1), new DateTime(2000, 12, 5), 607);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDayFlight()
        {
            var target = new Flight(new DateTime(2000, 12, 1), new DateTime(2000, 12, 2), 607);
            Assert.AreEqual(220, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTwoDayFlight()
        {
            var target = new Flight(new DateTime(2000, 12, 1), new DateTime(2000, 12, 3), 900);
            Assert.AreEqual(240, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTenDayFlight()
        {
            var target = new Flight(new DateTime(2000, 12, 1), new DateTime(2000, 12, 11), 9001);
            Assert.AreEqual(400, target.getBasePrice());
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadLength()
        {
            new Flight(new DateTime(2000, 12, 1), new DateTime(2000, 12, 11), -9001);
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnBadDates()
        {
            new Flight(new DateTime(1999, 12, 1), new DateTime(1911, 12, 11), 9001);
        }
	}
}
