using System;
using System.Collections.Generic;
using System.Linq;
using KursYonetimSistemi.Models;

namespace KursYonetimSistemi.Services
{
    public class CalendarService
    {
        private readonly DataService _data;
        public CalendarService(DataService data)
        {
            _data = data;
        }

        public IEnumerable<(DateTime Tarih, IEnumerable<ScheduleEntry> Dersler)> HaftalikTakvim(DateTime tarih)
        {
            var start = tarih.Date.AddDays(-(int)tarih.DayOfWeek + (int)DayOfWeek.Monday);
            for (int i = 0; i < 7; i++)
            {
                var gun = start.AddDays(i);
                yield return (gun, _data.Schedules.Where(s => s.Gun == gun.DayOfWeek && s.Aktif));
            }
        }

        public IEnumerable<(DateTime Tarih, IEnumerable<ScheduleEntry> Dersler)> AylikTakvim(int yil, int ay)
        {
            var daysInMonth = DateTime.DaysInMonth(yil, ay);
            for (int day = 1; day <= daysInMonth; day++)
            {
                var tarih = new DateTime(yil, ay, day);
                yield return (tarih, _data.Schedules.Where(s => s.Gun == tarih.DayOfWeek && s.Aktif));
            }
        }
    }
}
