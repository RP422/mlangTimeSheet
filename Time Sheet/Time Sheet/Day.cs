using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Sheet
{
    public class Day
    {
        private float _workingHours = 0;
        private float _sickHours = 0;
        private float _vacationHours = 0;

        public enum HourType { WORKING, SICK, VACATION }

        private DateTime _date { get; set; }

        public Day(DateTime date)
        {
            this._date = date;
        }

        public DateTime GetDate()
        {
            return _date;
        }

        public float GetTotalHours()
        {
            return _workingHours + _sickHours + _vacationHours;
        }

        public void set(HourType type, float hours)
        {
            if(hours <= 0)
            {
                throw new ArgumentOutOfRangeException("hours", "hours must be a positive value");
            }
            else if (hours % .25 != 0)
            {
                throw new ArgumentOutOfRangeException("hours", "hours must be a value in increments of .25");
            }

            switch (type)
            {
                case HourType.WORKING:
                    if (GetTotalHours() - _workingHours + hours > 24)
                    {
                        throw new ArgumentOutOfRangeException("hours", "Total number of hours cannot exceed 24");
                    }
                    _workingHours = hours;
                    break;
                case HourType.SICK:
                    if (GetTotalHours() - _sickHours + hours > 24)
                    {
                        throw new ArgumentOutOfRangeException("hours", "Total number of hours cannot exceed 24");
                    }
                    _sickHours = hours;
                    break;
                case HourType.VACATION:
                    if (GetTotalHours() - _vacationHours + hours > 24)
                    {
                        throw new ArgumentOutOfRangeException("hours", "Total number of hours cannot exceed 24");
                    }
                    _vacationHours = hours;
                    break;
            }
        }
    }

}
