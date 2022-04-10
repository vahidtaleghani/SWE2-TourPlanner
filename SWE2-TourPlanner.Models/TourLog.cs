﻿using System;


namespace SWE2_TourPlanner.Models
{
    public class TourLog
    {
        public int LogId { get; set; }
        public DateTime DateTime { get; set; }
        public string Report { get; set; }
        public Double Distance { get; set; }
        public TimeSpan TotalTime { get; set; }
        public double Rating { get; set; }
        public TourItem LogTourItem { get; set; }

        public TourLog(int logId, DateTime dateTime , string report, Double distance , TimeSpan totalTime , double rating , TourItem LogTourItem)
        {
            this.LogId = logId;
            this.DateTime = dateTime;
            this.Report = report;
            this.Distance = distance;
            this.TotalTime = totalTime;
            this.Rating = rating;
            this.LogTourItem = LogTourItem;
        }
    }
}
