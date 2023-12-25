﻿using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace N.G.HRS.Areas.AttendanceAndDeparture.Models
{
    public class PermanenceModels
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string PermanenceName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateOnly FromDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateOnly ToDate { get; set; }
        public bool FlexibleWorkingHours { get; set; }
        public bool WorkBetweenTwoShifts { get; set; }
        public bool ShiftTime { get; set; }
        public bool Working24Hours { get; set; }
        [DataType(DataType.Time)]
        public DateTime FromTime { get; set; }
        [DataType(DataType.Time)]
        public DateTime ToTime { get; set; }
        [Range(0, 50)]
        public int HoursOfWorks { get; set; }
        public bool AddAttendanceAndDeparturePermission { get; set; }
        public bool AllowanceForLateAttendance { get; set; }
        public bool EarlyDeparturePermission { get; set; }
        [StringLength(255)]
        public string? Notes {  get; set; }


    }
}
