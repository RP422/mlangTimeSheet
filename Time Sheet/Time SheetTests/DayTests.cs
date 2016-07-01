using Microsoft.VisualStudio.TestTools.UnitTesting;
using Time_Sheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Sheet.Tests
{
    [TestClass]
    public class DayTests
    {
        private DateTime _date = new DateTime(2016, 6, 30);

        [TestMethod]
        public void DateTest()
        {
            Day d = new Day(_date);

            Assert.AreEqual(_date, d.GetDate());
        }

        [TestMethod]
        public void WorkingTest()
        {
            Day d = new Day(_date);

            d.SetHours(Day.HourType.WORKING, 8);

            Assert.AreEqual(8, d.GetHours(Day.HourType.WORKING));
        }
        [TestMethod]
        public void SickTest()
        {
            Day d = new Day(_date);

            d.SetHours(Day.HourType.SICK, 8);

            Assert.AreEqual(8, d.GetHours(Day.HourType.SICK));
        }
        [TestMethod]
        public void VacationTest()
        {
            Day d = new Day(_date);

            d.SetHours(Day.HourType.VACATION, 8);

            Assert.AreEqual(8, d.GetHours(Day.HourType.VACATION));
        }

        [TestMethod]
        public void ZeroTest()
        {
            Day d = new Day(_date);

            try
            {
                d.SetHours(Day.HourType.WORKING, 0);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentOutOfRangeException));
            }
        }
        [TestMethod]
        public void NegativeTest()
        {
            Day d = new Day(_date);

            try
            {
                d.SetHours(Day.HourType.WORKING, -8);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentOutOfRangeException));
            }
        }
        [TestMethod]
        public void Exactly24Test()
        {
            Day d = new Day(_date);
            
            d.SetHours(Day.HourType.WORKING, 8);
            d.SetHours(Day.HourType.SICK, 8);
            d.SetHours(Day.HourType.VACATION, 8);

            Assert.AreEqual(24, d.GetTotalHours());
        }
        [TestMethod]
        public void Over24Test()
        {
            Day d = new Day(_date);

            try
            {
                d.SetHours(Day.HourType.WORKING, 9);
                d.SetHours(Day.HourType.SICK, 8);
                d.SetHours(Day.HourType.VACATION, 8);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentOutOfRangeException));
            }
        }

        [TestMethod]
        public void QuarterHourTest()
        {
            Day d = new Day(_date);

            d.SetHours(Day.HourType.WORKING, 8.25f);

            Assert.AreEqual(8.25f, d.GetHours(Day.HourType.WORKING));
        }
        [TestMethod]
        public void EighthHourTest()
        {
            Day d = new Day(_date);

            try
            {
                d.SetHours(Day.HourType.WORKING, 8.125f);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentOutOfRangeException));
            }
        }
    }
}