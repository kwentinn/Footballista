using Itenso.TimePeriod;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Footballista.Game.Domain.Fixtures.TimeSlots
{
    public class TimeSlotConfiguration
    {
        public DayOfWeek FirstDayOfWeek { get; private set; }
        public IEnumerable<DayOfWeek> AvailaibleDaysOfWeek => this.availableTimeSlots.Select(ts => ts.DayOfWeek).Distinct();
        public IReadOnlyCollection<TimeSlot> AvailableTimeSlots => this.availableTimeSlots.AsReadOnly();

        private List<TimeSlot> availableTimeSlots = new List<TimeSlot>();
        //{
        //    new TimeSlot(DayOfWeek.Friday, hour: 20),

        //    new TimeSlot(DayOfWeek.Saturday, hour: 14),
        //    new TimeSlot(DayOfWeek.Saturday, hour: 17),
        //    new TimeSlot(DayOfWeek.Saturday, hour: 21, allowMultiple: false),

        //    new TimeSlot(DayOfWeek.Sunday, hour: 17),
        //    new TimeSlot(DayOfWeek.Sunday, hour: 21, allowMultiple: false),
        //};
        public TimeSlotConfiguration()
        {

        }

        public TimeSlotConfiguration WithFirstDayOfWeek(DayOfWeek firstDayOfWeek)
        {
            this.FirstDayOfWeek = firstDayOfWeek;
            return this;
        }
        public TimeSlotConfiguration WithAvailableTimeSlots(IEnumerable<TimeSlot> availableTimeSlots)
        {
            this.availableTimeSlots = availableTimeSlots.ToList();
            return this;
        }

        public record AvailableDatesForWeek(Week Week, IEnumerable<DateTime> availableDates);

        public static IEnumerable<Week> GetWeeksFromPeriod(ITimeRange period)
        {
            Week week = new Week(period.Start.Date);
            do
            {
                yield return week;
                week = week.AddWeeks(1);
            }
            while (week.End <= period.End.Date);
        }

        public IEnumerable<AvailableDatesForWeek> GetAllAvailableDatesForWeeks(ITimeRange period)
        {
            Week week = new Week(period.Start.Date);
            do
            {
                yield return new AvailableDatesForWeek(week, this.GetAvailableDatesForWeek(week));
                week = week.AddWeeks(1);
            }
            while (week.Start < period.End.Date);
        }
        public IEnumerable<DateTime> GetAllAvailableDates(ITimeRange period)
        {
            Week week = new Week(period.Start.Date);
            List<DateTime> availableDates = new List<DateTime>();
            do
            {
                availableDates.AddRange(this.GetAvailableDatesForWeek(week));
                week = week.AddWeeks(1);
            }
            while (week.Start < period.End.Date);
            return availableDates;
        }

        private IEnumerable<DateTime> GetAvailableDatesForWeek(Week week)
        {
            foreach (ITimePeriod dayPeriod in week.GetDays())
            {
                foreach (TimeSlot timeslot in this.AvailableTimeSlots)
                {
                    if (timeslot.DayOfWeek == dayPeriod.Start.DayOfWeek)
                    {
                        Date startDate = new Date(dayPeriod.Start.Year, dayPeriod.Start.Month, dayPeriod.Start.Day);
                        yield return timeslot.GetDateTimeFrom(startDate);
                    }
                }
            }
        }
    }
}
