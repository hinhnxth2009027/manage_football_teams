using System;

namespace FootballManager.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public string Battle { get; set; }
        public string MatchDay { get; set; }
        public string Time { get; set; }
        public string Pitch { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public DateTime DeleteAt { get; set; }
    }
}