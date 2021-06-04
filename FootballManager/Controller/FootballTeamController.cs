using System;
using System.Collections.Generic;
using System.Text;
using FootballManager.Entities;
using FootballManager.Service;
using FootballManager.Views;

namespace FootballManager.Controller
{
    public class FootballTeamController
    {
        private FootballTeamService _footballTeamService = new FootballTeamService();
        public void CreateNewFootballTeam()
        {
            Console.WriteLine("Nhập vào mã đội bóng");
            var teamCode = Console.ReadLine();
            Console.WriteLine("Nhập vào tên đội bóng");
            var teamName = Console.ReadLine();
            Console.WriteLine("Nhập vào tên huấn luyện viên");
            var coach = Console.ReadLine();
            Console.WriteLine("Bạn có muốn tiếp tục (Y/N)");
            var choice = Console.ReadLine();
            if (choice.ToLower().Equals("y"))
            {
                var footballTeam = new FootballTeam()
                {
                    TeamCode = teamCode,
                    TeamName = teamName,
                    Coach = coach
                };

                var result = _footballTeamService.InitFootballTeam(footballTeam);
                if (result)
                {
                    Console.WriteLine("Tạo mới thành công !!");
                }
                else
                {
                    Console.WriteLine("Mã đội bóng đã được sử dụng");
                }
            }
            else
            {
                Console.WriteLine("Đã hủy");
            }
        }


        public void ShowListFootballTeam()
        {
            var result = _footballTeamService.FootballTeams();
            if (result.Count <= 0)
            {
                Console.WriteLine("khong co doi tuyen nao");
            }
            else
            {
                Console.WriteLine("\n||========================================================================||");
                Console.WriteLine($"||\t TeamCode \t||\t Name \t\t||\t Coach \t\t");
                
                foreach (var footballTeam in result)
                {
                    Console.WriteLine("||========================================================================||");
                    footballTeam.ToString();
                }
                Console.WriteLine("||========================================================================||\n\n");
            }

        }



        public void UpdateFootballTeam()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("nhập vào mã đội bạn muốn thay đổi thông tin");
            var teamCode = Console.ReadLine();
            Console.WriteLine("nhập vào tên đội mới");
            var teamName = Console.ReadLine();
            Console.WriteLine("nhập vào tên huấn luyện viên mới");
            var coach = Console.ReadLine();

            Console.WriteLine("Bạn muốn tiếp tục (Y/N)");
            var choice = Console.ReadLine();
            if (choice.ToLower().Equals("y"))
            {
                var footballTeam = new FootballTeam()
                {
                    TeamCode = teamCode,
                    TeamName = teamName,
                    Coach = coach
                };
                var result = _footballTeamService.Update(footballTeam);
                if (result)
                {
                    Console.WriteLine("thay đổi thông tin thành công");
                }
                else
                {
                    Console.WriteLine("thay đổi thất bại có thể bạn đã nhập sai mã đội hoặc kết nối đã bị dán đoạn");
                }
            }
            else
            {
                Console.WriteLine("đã hủy");
            }
        }

        public List<FootballTeam> GetList()
        {
            return _footballTeamService.FootballTeams();
        }
    }
}