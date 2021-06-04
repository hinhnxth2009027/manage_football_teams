using System;
using FootballManager.Controller;

namespace FootballManager.Views
{
    public class ExamScheduleManagementMenu
    {
        private MatchScheduleController _matchScheduleController = new MatchScheduleController();
        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("||====|| Quan ly lich thi dau ||====||");
                Console.WriteLine("||- 1. Xem lịch thi đấu             ||");
                Console.WriteLine("||- 2. Cập nhật lịch thi đấu        ||");
                Console.WriteLine("||- 3. Tạo lịch thi đấu             ||");
                Console.WriteLine("||- 0. Trờ về menu chính            ||");
                Console.WriteLine("||==================================||");
                var choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        _matchScheduleController.ShowMatch();
                        break;
                    case 2:
                        _matchScheduleController.UpdateMatch();
                        break;
                    case 3:
                        _matchScheduleController.CreateMatchSchedule();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("vui lòng nhâp trong khoảng từ 0 - 3");
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