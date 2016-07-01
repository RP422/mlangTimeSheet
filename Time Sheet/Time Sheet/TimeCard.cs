using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Sheet
{
    class TimeCard
    {
        private Day[] _days = new Day[14];

        public TimeCard(DateTime StartDate)
        {
            if(StartDate.DayOfWeek != System.DayOfWeek.Sunday)
            {
                throw new ArgumentOutOfRangeException("StartDate", "StartDate must be a Sunday");
            }

            for(int x = 0; x < 14; x++)
            {
                _days[x] = new Day(StartDate);
                StartDate.AddDays(1);
            }
        }

        private Boolean SameDay(DateTime FirstDate, DateTime SecondDate)
        {
            return FirstDate.Year == SecondDate.Year
                && FirstDate.Month == SecondDate.Month
                && FirstDate.Day == SecondDate.Day;
        }

        public void SetHours(DateTime date, Day.HourType type, float hours)
        {
            for (int x = 0; x < 14; x++)
            {
                if (SameDay(date, _days[x].GetDate()))
                {
                    _days[x].SetHours(type, hours);
                    break;
                }
            }
            throw new ArgumentOutOfRangeException("date", "The provided date was not found within the TimeCard");
        }
        public float GetHours(DateTime date, Day.HourType type, float hours)
        {
            for (int x = 0; x < 14; x++)
            {
                if (SameDay(date, _days[x].GetDate()))
                {
                    return _days[x].GetHours(type);
                }
            }
            throw new ArgumentOutOfRangeException("date", "The provided date was not found within the TimeCard");
        }

        public float CalculateOvertime()
        {
            float RegularHours = 0;
            float OvertimeHours = 0;

            for (int x = 0; x < 7; x++)
            {
                RegularHours += _days[x].GetHours(Day.HourType.WORKING);
            }
            if(RegularHours > 40)
            {
                OvertimeHours += RegularHours - 40;
            }

            RegularHours = 0;
            for (int x = 7; x < 14; x++)
            {
                RegularHours += _days[x].GetHours(Day.HourType.WORKING);
            }
            if (RegularHours > 40)
            {
                OvertimeHours += RegularHours - 40;
            }

            return OvertimeHours;
        }

        public float GetTotalHours(Day.HourType type)
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
