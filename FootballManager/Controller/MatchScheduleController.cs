using System;
using System.Collections.Generic;
using FootballManager.Entities;
using FootballManager.Service;
using FootballManager.Views;

namespace FootballManager.Controller
{
    public class MatchScheduleController
    {
        private MatchScheduleService _matchScheduleService = new MatchScheduleService();

        public void CreateMatchSchedule()
        {
            var teamList = _matchScheduleService.GetFootballTeams();
            var listTeamCode1 = new List<string>();
            var listTeamCode2 = new List<string>();
            var objectTxt = new List<string>();

            for (var i = 0; i < teamList.Count; i++)
            {
                var team1 = teamList[i];
                for (var j = 0; j < teamList.Count; j++)
                {
                    if (team1.TeamName.Equals(teamList[j].TeamName))
                    {
                        //nếu tên hai đội mà chùng nhau thì bỏ qua
                        continue;
                    }
                    else
                    {
                        var team2 = teamList[j];
                        var isDlc = false;

                        //check trong list đã tồn tại trận này chưa
                        for (int k = 0; k < objectTxt.Count; k++)
                        {
                            var check = objectTxt[k];
                            var check1 = $"{team1.TeamName} -VS- {team2.TeamName}";
                            var check2 = $"{team2.TeamName} -VS- {team1.TeamName}";
                            if (check.Equals(check1) || check.Equals(check2))
                            {
                                isDlc = true;
                                break;
                            }
                            else
                            {
                                isDlc = false;
                            }
                        }

                        if (!isDlc)
                        {
                            objectTxt.Add($"{team1.TeamName} -VS- {team2.TeamName}");
                            listTeamCode1.Add(team1.TeamCode);
                            listTeamCode2.Add(team2.TeamCode);
                        }
                    }
                }
            }

            Console.WriteLine("\n");
            Console.WriteLine("========|| tao lich thi dau ||=========");
            for (var i = 0; i < objectTxt.Count; i++)
            {
                Console.WriteLine($" .{i + 1} - \t{objectTxt[i]}");
            }

            Console.WriteLine("=======================================");
            Console.WriteLine("\n");

            Console.WriteLine($"vui lòng chọn 1 trận đấu để khởi tạo trong khoảng từ 1 - {objectTxt.Count}");
            var choice = int.Parse(Console.ReadLine());
            if (choice <= 0 || choice > objectTxt.Count)
            {
                Console.WriteLine("Lua chon khong ton tai");
            }
            else
            {
                Console.WriteLine($"Bạn đã chọn ({objectTxt[choice - 1]})");
                Console.WriteLine("Nhập vào ngày thi đấu định dạng ( ngày / tháng / năm )");
                var day = Console.ReadLine();
                Console.WriteLine("Nhập vào giờ thi đấu theo định dạng ( 00 h 00 )");
                var time = Console.ReadLine();
                Console.WriteLine("Nhập vào sân thi đấu");
                var pitch = Console.ReadLine();
                var schedule = new Schedule()
                {
                    Battle = objectTxt[choice - 1],
                    MatchDay = day,
                    Time = time,
                    Pitch = pitch
                };
                Console.WriteLine("Ban co muon tiep tuc (Y/N)");
                var confirm = Console.ReadLine();
                if (confirm.ToLower().Equals("y"))
                {
                    var result = _matchScheduleService.CreateNewSchedule(schedule);
                    if (result)
                    {
                        _matchScheduleService.NewResult(new CompetitionResults()
                        {
                            TeamCode1 = listTeamCode1[choice - 1],
                            TeamCode2 = listTeamCode2[choice - 1],
                            ResultForTeam1 = 0,
                            ResultForTeam2 = 0,
                            Status = 1
                        });

                        Console.WriteLine("Tạo mới thành công");
                    }
                    else
                    {
                        Console.WriteLine("Tạo mới thất bại");
                    }
                }
                else
                {
                    Console.WriteLine("Đẫ hủy tạo mới");
                }
            }
        }

        public void ShowMatch()
        {
            var schedules = _matchScheduleService.GetSchedules();

            if (schedules.Count != 0)
            {
                Console.WriteLine(
                    "\n==================================================================================================||");
                Console.WriteLine("||\t Trận đấu giữa \t\t||\t ngày thi đấu \t||\t giờ \t||\t sân");
                Console.WriteLine(
                    "==================================================================================================||");
                foreach (var result in schedules)
                {
                    Console.WriteLine(
                        $"||\t {result.Battle} \t||\t {result.MatchDay} \t||\t {result.Time} \t||\t {result.Pitch}");
                    Console.WriteLine(
                        "==================================================================================================||");
                }

                Console.WriteLine("\n\n");
            }
            else
            {
                Console.WriteLine("Chua co lich thi dau nao duoc tao");
            }
        }

        public List<CompetitionResults> ShowResult()
        {
            var competitionResultsList = _matchScheduleService.GetListCompetitionResultsList();

            return competitionResultsList;
        }

        public void UpdateResult(int id, string team1, string team2)
        {
            Console.WriteLine($"Nhập vào số bàn thắng của đội {team1}");
            var resultForTeam1 = int.Parse(Console.ReadLine());
            Console.WriteLine($"Nhập vào số bàn thắng của đội {team2}");
            var resultForTeam2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Bạn muốn tiếp tục ( Y/N )");
            var choice = Console.ReadLine();
            if (choice.ToLower().Equals("y"))
            {
                var result = _matchScheduleService.UpdateResult(id, resultForTeam1, resultForTeam2);
                if (result)
                {
                    Console.WriteLine("Update thành công");
                }
                else
                {
                    Console.WriteLine("Update không thành công vui lòng kiểm tra lại kết nối");
                }
            }
            else
            {
                Console.WriteLine("Đã hủy cập nhật");
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

        public void UpdateMatch()
        {
            Console.WriteLine(
                "\n=================================================================================================================||");
            Console.WriteLine("|| Stt \t||\t Trận đấu giữa \t\t||\t ngày thi đấu \t||\t giờ \t||\t sân");
            Console.WriteLine(
                "=================================================================================================================||");
            var schedules = _matchScheduleService.GetSchedules();
            for (var i = 0; i < schedules.Count; i++)
            {
                Console.WriteLine(
                    $"|| {i + 1} \t||\t {schedules[i].Battle} \t||\t {schedules[i].MatchDay} \t||\t {schedules[i].Time} \t||\t {schedules[i].Pitch}");
            }

            Console.WriteLine(
                "=================================================================================================================||");
            Console.WriteLine($"Chọn trận đấu bạn muốn sửa theo số thứ tự từ 1 đến {schedules.Count}");
            Console.WriteLine("Hoặc chọn 0 để bỏ qua");
            var choice = int.Parse(Console.ReadLine());
            if (choice == 0)
            {
                Console.WriteLine("Đã hủy thao tác");
            }
            else
            {
                Console.WriteLine($"Đã chọn chỉnh sửa {schedules[choice - 1].Battle} trận đấu lúc {schedules[choice - 1].Time}\n");
                Console.WriteLine($"Nhập vào ngày thi đấu mới - ngày thi đấu hiện tại là ( {schedules[choice - 1].MatchDay} )");
                var newMatchDay = Console.ReadLine();
                Console.WriteLine($"Nhập vào giờ thi đấu mới - giờ thi đấu hiện tại là ( {schedules[choice - 1].Time} )");
                var newTime = Console.ReadLine();
                Console.WriteLine($"Nhập vào sân thi đấu thay thế sân thi đấu hiện tại là sân ( {schedules[choice - 1].Pitch} )");
                var newPitch = Console.ReadLine();

                var result = _matchScheduleService.UpdateMatch(schedules[choice - 1].Id , new Schedule()
                {
                    MatchDay = newMatchDay,
                    Time = newTime,
                    Pitch = newPitch
                });

                if (result)
                {
                    Console.WriteLine("Update thành công");
                }
                else
                {
                    Console.WriteLine("Update không thành công vui lòng kiểm tra lại kết nối");
                }
            }
        }



        public void ShowCharts()
        {
            var listFootballTeam = _matchScheduleService.GetFootballTeams();
            var tableResultMatch = _matchScheduleService.GetListCompetitionResultsList();
            

            Console.WriteLine("=========================================================================================================");
            Console.WriteLine("|\t MÃ đội \t|\t Tên đội \t| Trận \t| Thắng \t| Hòa \t| Thua \t| Điểm  \t|");
            Console.WriteLine("=========================================================================================================");
            for (var i = 0; i < listFootballTeam.Count; i++)
            {
                
                var team = listFootballTeam[i];
                var match = countMatch(tableResultMatch, team.TeamCode);
                var winMatch = countWinMatch(tableResultMatch, team.TeamCode);
                var loseMatch = countLostMatch(tableResultMatch, team.TeamCode);
                var equalMatch = match - winMatch - loseMatch;
                var scores = equalMatch + winMatch*3;
                Console.WriteLine($"|\t {team.TeamCode} \t|\t {team.TeamName} \t| {match} \t| {winMatch} \t\t| {equalMatch} \t| {loseMatch} \t| {scores}  \t\t|");

            }
            Console.WriteLine("=========================================================================================================");
        }
        
        //hàm đếm tổng số trận của đội
        public int countMatch(List<CompetitionResults> matchs , string teamCode)
        { 
            var count = 0;
            foreach (var result in matchs)
            {
                if (teamCode.Equals(result.TeamCode1) || teamCode.Equals(result.TeamCode2))
                {
                    count++;
                }
            }
            return count;
        }
        
        //hàm đếm số trận thắng của đội
        public int countWinMatch(List<CompetitionResults> matchs , string teamCode)
        {
            var count = 0;

            foreach (var result in matchs)
            {
                if (result.TeamCode1.Equals(teamCode))
                {
                    if (result.ResultForTeam1 > result.ResultForTeam2)
                    {
                        count++;
                    }
                }
                else if(result.TeamCode2.Equals(teamCode))
                {
                    if (result.ResultForTeam1 < result.ResultForTeam2)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
        
        //hàm đếm số trận thua của đội
        public int countLostMatch(List<CompetitionResults> matchs , string teamCode)
        {
            var count = 0;

            foreach (var result in matchs)
            {
                if (result.TeamCode1.Equals(teamCode))
                {
                    if (result.ResultForTeam1 < result.ResultForTeam2)
                    {
                        count++;
                    }
                }
                else if(result.TeamCode2.Equals(teamCode))
                {
                    if (result.ResultForTeam1 > result.ResultForTeam2)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
    
    
    
    
    
}