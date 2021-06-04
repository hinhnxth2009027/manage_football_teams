using System;

namespace FootballManager.Entities
{
    public class FootballTeam
    {
        //chuỗi số gồm 6 kí tự
        //khóa chính trong database
        public string TeamCode { get; set; }
        public string TeamName { get; set; }
        public string Coach { get; set; }
        
        //trạng thái đội bóng : 1 = vẫn đang tham gia thi đấu // 0 = đã bị ban -_- 
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }


        public void ToString()
        {
            Console.WriteLine($"||\t {TeamCode} \t||\t {TeamName} \t||\t {Coach} \t");
        }
    }
}