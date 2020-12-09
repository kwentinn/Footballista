using Itenso.TimePeriod;
using System;

namespace Footballista.Game.Domain.Fixtures
{
    public class TimeSlot
    {
        public DayOfWeek DayOfWeek { get; }
        public Time TimeOfWeek { get; }
        public bool AllowMultiple { get; }

        public TimeSlot(DayOfWeek dayOfWeek, short hour, short minute = 0, bool allowMultiple = true)
        {
            this.DayOfWeek = dayOfWeek;
            this.TimeOfWeek = new Time(hour, minute);
            this.AllowMultiple = allowMultiple;
        }

        public DateTime GetDateTimeFrom(Date date)
        {
            return date.ToDateTime(0)
                .AddHours(this.TimeOfWeek.Hour)
                .AddMinutes(this.TimeOfWeek.Minute);
        }
    }
}
