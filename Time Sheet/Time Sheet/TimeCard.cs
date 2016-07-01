using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Sheet
{
    public class TimeCard
    {
        private Day[] _days = new Day[14];

        public TimeCard(DateTime StartDate)
        {
            if(StartDate.DayOfWeek != System.DayOfWeek.Sunday)
            {
                throw new ArgumentOutOfRangeException("StartDate", "StartDate must be a Sunday");
            }

            DateTime TempDate = TrimDay(StartDate);

            for (int x = 0; x < 14; x++)
            {
                _days[x] = new Day(TempDate);
                TempDate = TempDate.AddDays(1);
            }
        }

        public DateTime GetStartDate()
        {
            return _days[0].GetDate();
        }

        private DateTime TrimDay(DateTime Date)
        {
            return new DateTime(Date.Year, Date.Month, Date.Day);
        }

        public void SetHours(DateTime date, HourType type, float hours)
        {
            Boolean SomethingSet = false;
            DateTime TempDate = TrimDay(date);

            for (int x = 0; x < 14; x++)
            {
                if (TempDate.Equals(_days[x].GetDate()))
                {
                    _days[x].SetHours(type, hours);
                    SomethingSet = true;
                }
                TempDate.AddDays(1);
            }
            if (!SomethingSet)
            {
                throw new ArgumentOutOfRangeException("date", "The provided date was not found within the TimeCard");
            }
        }
        public float GetHours(DateTime date, HourType type)
        {
            DateTime TempDate = TrimDay(date);

            for (int x = 0; x < 14; x++)
            {
                if (TempDate.Equals(_days[x].GetDate()))
                {
                    return _days[x].GetHours(type);
                }
                TempDate.AddDays(1);
            }
            throw new ArgumentOutOfRangeException("date", "The provided date was not found within the TimeCard");
        }

        public float CalculateOvertime()
        {
            float RegularHours = 0;
            float OvertimeHours = 0;

            for (int x = 0; x < 7; x++)
            {
                RegularHours += _days[x].GetHours(HourType.WORKING);
            }
            if(RegularHours > 40)
            {
                OvertimeHours += RegularHours - 40;
            }

            RegularHours = 0;
            for (int x = 7; x < 14; x++)
            {
                RegularHours += _days[x].GetHours(HourType.WORKING);
            }
            if (RegularHours > 40)
            {
                OvertimeHours += RegularHours - 40;
            }

            return OvertimeHours;
        }

        public float GetTotalHours(HourType type)
        {
            float RunningTotal = 0;

            for (int x = 0; x < 14; x++)
            {
                RunningTotal += _days[x].GetHours(type);
            }

            return RunningTotal;
        }
    }
}
