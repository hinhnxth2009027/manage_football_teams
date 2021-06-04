using System;
using System.Text;
using FootballManager.Controller;

namespace FootballManager.Views
{
    public class ApplicationMenu
    {
        private FootballTeamListManagementMenu _footballTeamListManagementMenu = new FootballTeamListManagementMenu();
        private ExamScheduleManagementMenu _examScheduleManagementMenu = new ExamScheduleManagementMenu();
        private MenuToManagexamResults _menuToManagexamResults = new MenuToManagexamResults();
        private MatchScheduleController _matchScheduleController = new MatchScheduleController();
        
        public void ShowMenu()
        {
            Console.OutputEncoding = Encoding.UTF8;
            while (true)
            {
                Console.WriteLine("\n||=======|| Chào mừng đến với V--League 2021 ||=======||\n");
                Console.WriteLine("||=====================|| MENU ||=====================||");
                Console.WriteLine("|| - 1. Quản lý danh sách đội bóng.                   ||");
                Console.WriteLine("|| - 2. Quản lý lịch thi đấu.                         ||");
                Console.WriteLine("|| - 3. Quản lý kết quả thi đấu.                      ||");
                Console.WriteLine("|| - 4. Thống kê.                                     ||");
                Console.WriteLine("|| - 0. Thoát                                         ||");
                Console.WriteLine("||====================================================||\n");
                var choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        _footballTeamListManagementMenu.ShowMenu();
                        break
                            ;
                    case 2:
                        _examScheduleManagementMenu.ShowMenu();
                        break
                            ;
                    case 3:
                        _menuToManagexamResults.ShowMenu();
                        break
                            ;
                    case 4:
                        _matchScheduleController.ShowCharts();
                        break
                            ;
                    case 0:
                        Console.WriteLine("Bye bye !");
                        break
                            ;
                    default:
                        Console.WriteLine("vui long chon trong khoang 0 - 4");
                        break;
                }

                if (choice == 0)
                {
                    break;
                }
            }
        }
    }
}