using System;
using System.Collections.Generic;
using FootballManager.Controller;
using FootballManager.Entities;

namespace FootballManager.Views
{
    public class MenuToManagexamResults
    {
        private MatchScheduleController _matchScheduleController = new MatchScheduleController();
        private FootballTeamController _footballTeamController = new FootballTeamController();

        public void ShowMenu()
        {
            var competitionResultsList = _matchScheduleController.ShowResult();
            var footballTeams = _footballTeamController.GetList();

            while (true)
            {
                Console.WriteLine("\n||===============================================================================||");
                Console.WriteLine("|| stt \t||\t đội 1 \t\t || \t kết quả \t || \t đội 2 \t\t ||");
                Console.WriteLine("||===============================================================================||");
                for (var i = 0; i < competitionResultsList.Count; i++)
                {
                    var team1 = getTeam(footballTeams, competitionResultsList[i].TeamCode1);
                    var team2 = getTeam(footballTeams, competitionResultsList[i].TeamCode2);
                    Console.WriteLine($"|| {i+1} \t||\t {team1.TeamName} \t || \t {competitionResultsList[i].ResultForTeam1} - {competitionResultsList[i].ResultForTeam2} \t\t || \t {team2.TeamName}\t ||");
                }
                Console.WriteLine("||===============================================================================||");
                Console.WriteLine($"Chọn 0 để về menu chính");
                Console.WriteLine($"Hoặc chọn theo thứ tự tương ứng trong bảng kết quả để thay đổi\n");
                
                var choice = int.Parse(Console.ReadLine());
                if (choice == 0)
                {
                    break;
                }
                else
                {
                    var team1 = getTeam(footballTeams, competitionResultsList[choice-1].TeamCode1);
                    var team2 = getTeam(footballTeams, competitionResultsList[choice-1].TeamCode2);
                    _matchScheduleController.UpdateResult(competitionResultsList[choice-1].Id,team1.TeamName,team2.TeamName);
                    break;
                }
            }
        }


        public FootballTeam getTeam(List<FootballTeam> footballTeams, string teamCode)
        {
            FootballTeam footballTeam = null;
            for (var i = 0; i < footballTeams.Count; i++)
            {
                if (footballTeams[i].TeamCode.Equals(teamCode))
                {
                    footballTeam = footballTeams[i];
                }
            }
            return footballTeam;
        }
    }
}