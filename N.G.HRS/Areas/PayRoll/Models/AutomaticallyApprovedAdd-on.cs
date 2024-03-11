﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using N.G.HRS.Areas.AttendanceAndDeparture.Models;
using N.G.HRS.Areas.Employees.Models;
using N.G.HRS.Areas.OrganizationalChart.Models;
using System.ComponentModel.DataAnnotations;

namespace N.G.HRS.Areas.PayRoll.Models
{
    public class AutomaticallyApprovedAdd_on
    {
        private double _numberOfHours;
        private int _numerOfMinutes;


        public int Id { get; set; }
        public int? SectionsId { get; set; }
        public Sections? Sections { get; set; }
        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        [DataType(DataType.Date)]
        public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [DataType(DataType.Date)]
        public DateOnly FromDate { get; set; }

        [DataType(DataType.Date)]
        public DateOnly ToDate { get; set; }
        [DataType(DataType.Time)]
        public TimeOnly FromTime { get; set; }
        [DataType(DataType.Time)]
        public TimeOnly ToTime { get; set; }
        public double? Hours
        {
            get
            {
                return _numberOfHours;
            }
            set
            {
                _numberOfHours = CalculateHours();
            }
        }
        public int? Minutes
        {
            get
            {
                return _numerOfMinutes;
            }
            set
            {
                _numerOfMinutes = CalculateMinutesBetween();
            }
        }

        public double CalculateHours()
        {
            //if (FromTime > ToTime)
            //{

            //    throw new ArgumentException("وقت البدء بعد وقت النهاية.");

            //}

            DateTime startTime = DateTime.Parse(FromTime.ToString());
            DateTime endTime = DateTime.Parse(ToTime.ToString());
            if (startTime.Hour < 12)
            {
                startTime = startTime.AddHours(12);
            }
            string startTwentyFourHourTime = startTime.ToString("HH");
            if (endTime.Hour < 12)
            {
                endTime = endTime.AddHours(12);
            }
            string endTwentyFourHourTime = endTime.ToString("HH");

            var totalHours =Math.Abs( int.Parse(endTwentyFourHourTime) - int.Parse(startTwentyFourHourTime));
            return totalHours;
        }

        public int CalculateMinutesBetween()
        {
            // Calculate total minutes between times
            var totalTimeSpan = ToTime - FromTime;
            var totalMinutes = totalTimeSpan.TotalMinutes;

            return (int)totalMinutes;
        }

        //private static int GetStandardHours(DateOnly fromDate, DateOnly toDate)
        //{
        //    // Assuming 8 hours per day, adjust as needed
        //    var workingDays = toDate.Day - fromDate.Day + 1;
        //    var standardHours = workingDays * 8;

        //    return standardHours;
        //}
       
        
    }
}