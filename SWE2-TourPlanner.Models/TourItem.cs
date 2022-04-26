using System;

namespace SWE2_TourPlanner.Models
{
    public class TourItem
    {
        public int TourId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string ImagePath { get; set; }
        public double Distance { get; set; }

        public TourItem(int tourId, string name, string description, string from , string to, string imagePath, double distance)
        {
            this.TourId = tourId;
            this.Name = name;
            this.Description = description;
            this.From = from;
            this.To = to;
            this.ImagePath = imagePath;
            this.Distance = distance;
        }
    }
}
