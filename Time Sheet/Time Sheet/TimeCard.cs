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
    }
}
