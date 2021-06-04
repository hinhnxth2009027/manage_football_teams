using System;
using System.Collections.Generic;
using FootballManager.Entities;
using FootballManager.Model;

namespace FootballManager.Service
{
    public class MatchScheduleService
    {
        private MatchScheduleModel _matchScheduleModel = new MatchScheduleModel();
        private FootballTeamModel _footballTeamModel = new FootballTeamModel();


        public List<Schedule> GetSchedules()
        {
            return _matchScheduleModel.FindAll();
        }


        public List<FootballTeam> GetFootballTeams()
        {
            return _footballTeamModel.FindAll();
        }


        public bool CreateNewSchedule(Schedule schedule)
        {
            var newSchedule = new Schedule()
            {
                Battle = schedule.Battle,
                MatchDay = schedule.MatchDay,
                Time = schedule.Time,
                Pitch = schedule.Pitch,
                CreatedAt = GetTime(),
                UpdateAt = GetTime()
            };

            return _matchScheduleModel.CreateSchedule(newSchedule);
        }

        public bool NewResult(CompetitionResults competition)
        {
            _matchScheduleModel.CreateNewRecodeForResultTable(competition);
            return false;
        }


        public List<CompetitionResults> GetListCompetitionResultsList()
        {
            return _matchScheduleModel.GetResultsList();
        }

        public bool UpdateResult(int id, int resultForTeam1, int resultForTeam2)
        {
            return _matchScheduleModel.UpdateResult(id,resultForTeam1,resultForTeam2);
        }


        public DateTime GetTime()
        {
            return DateTime.Now;
        }



        public bool UpdateMatch(int id,Schedule schedule)
        {
            var newSchedule = new Schedule()
            {
                MatchDay = schedule.MatchDay,
                Time = schedule.Time,
                Pitch = schedule.Pitch,
                UpdateAt = GetTime()
            };
            
            return _matchScheduleModel.UpdateMatch(id ,newSchedule);
        }
        
        
        
    }
}