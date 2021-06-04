using System;
using System.Text;
using FootballManager.Controller;

namespace FootballManager.Views
{
    public class FootballTeamListManagementMenu
    {
        private FootballTeamController _footballTeamController = new FootballTeamController();
        public void ShowMenu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                Console.WriteLine("||===========|| Quan ly danh sach ||==========||");
                Console.WriteLine("||- 1. Xem danh sách đội bóng                 ||");
                Console.WriteLine("||- 2. Cập nhật danh sách đội bóng            ||");
                Console.WriteLine("||- 3. Thêm mới một đội bóng                  ||");
                Console.WriteLine("||- 0. Trờ về menu chính                      ||");
                Console.WriteLine("||============================================||");
                var choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    default:
                        Console.WriteLine("vui long chon trong khoang 0 - 3");
                        break;
                    case 1:
                        _footballTeamController.ShowListFootballTeam();
                        break
                            ;
                    case 2:
                        _footballTeamController.UpdateFootballTeam();
                        break
                            ;
                    case 3:
                        _footballTeamController.CreateNewFootballTeam();
                        break;
                    case 0:
                        break
                            ;
                }

                if (choice == 0 )
                {
                    break;
                }
            }
        }
    }
}