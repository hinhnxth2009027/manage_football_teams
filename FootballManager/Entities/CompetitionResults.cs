using System;

namespace FootballManager.Entities
{
    public class CompetitionResults
    {
        public int Id { get; set; }
        public string TeamCode1 { get; set; }
        public string TeamCode2 { get; set; }
        public int ResultForTeam1 { get; set; }
        public int ResultForTeam2 { get; set; }
        //status 1 là trận đấu chưa có kết quả
        //status 0 là đã có kết quả 
        //status -1 là trận đấu đã bị hủy
        //default là 1
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}