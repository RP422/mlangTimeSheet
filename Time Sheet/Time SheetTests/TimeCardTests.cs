using Microsoft.VisualStudio.TestTools.UnitTesting;
using Time_Sheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Sheet.Tests
{
    [TestClass()]
    public class TimeCardTests
    {
        private static DateTime _startDate = new DateTime(2016, 7, 3);
        private static DateTime _theNextFriday = new DateTime(2016, 7, 8);

        [TestMethod()]
        public void ValidTimeCardTest()
        {
            TimeCard Card = new TimeCard(_startDate);

            Assert.AreEqual(_startDate, Card.GetStartDate());
        }
        [TestMethod()]
        public void InvalidTimeCardTest()
        {
            try
            {
                TimeCard Card = new TimeCard(_theNextFriday);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentOutOfRangeException));
            }
        }

        [TestMethod()]
        public void WorkingHoursTest()
        {
            TimeCard Card = new TimeCard(_startDate);

            Card.SetHours(_theNextFriday, Day.HourType.WORKING, 8);

            Assert.AreEqual(8, Card.GetHours(_theNextFriday, Day.HourType.WORKING));
        }
        [TestMethod()]
        public void SickHoursTest()
        {
            TimeCard Card = new TimeCard(_startDate);

            Card.SetHours(_theNextFriday, Day.HourType.SICK, 8);

            Assert.AreEqual(8, Card.GetHours(_theNextFriday, Day.HourType.SICK));
        }
        [TestMethod()]
        public void VacationHoursTest()
        {
            TimeCard Card = new TimeCard(_startDate);

            Card.SetHours(_theNextFriday, Day.HourType.VACATION, 8);

            Assert.AreEqual(8, Card.GetHours(_theNextFriday, Day.HourType.VACATION));
        }

        [TestMethod()]
        public void OvertimeTest()
        {
            TimeCard Card = new TimeCard(_startDate);

            DateTime TempDate = _startDate;

            for (int x = 0; x < 14; x++)
            {
                Card.SetHours(TempDate, Day.HourType.WORKING, 8);
                TempDate.AddDays(1);
            }

            Assert.AreEqual(32, Card.CalculateOvertime());
        }
        [TestMethod()]
        public void ZeroOvertimeTest()
        {
            TimeCard Card = new TimeCard(_startDate);

            DateTime TempDate = _startDate;

            for (int x = 0; x < 14; x++)
            {
                Card.SetHours(TempDate, Day.HourType.WORKING, 4);
                TempDate.AddDays(1);
            }

            Assert.AreEqual(0, Card.CalculateOvertime());
        }

        [TestMethod()]
        public void GetTotalWorkingHoursTest()
        {
            TimeCard Card = new TimeCard(_startDate);
        }
        [TestMethod()]
        public void GetTotalSickHoursTest()
        {
            TimeCard Card = new TimeCard(_startDate);
        }
        [TestMethod()]
        public void GetTotalVacationHoursTest()
        {
            TimeCard Card = new TimeCard(_startDate);
        }
    }
}