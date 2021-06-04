using System;
using System.Collections.Generic;
using FootballManager.Entities;
using FootballManager.Model;

namespace FootballManager.Service
{
    public class FootballTeamService
    {
        private FootballTeamModel _footballTeamModel = new FootballTeamModel();
        private FootballTeam _footballTeam = null;
        public bool InitFootballTeam(FootballTeam footballTeam)
        {
            _footballTeam = new FootballTeam()
            {
                TeamCode = footballTeam.TeamCode,
                TeamName = footballTeam.TeamName,
                Coach = footballTeam.Coach,
                CreatedAt = GetTime(),
                UpdatedAt = GetTime()
            };
            return _footballTeamModel.Store(_footballTeam);
        }

        public List<FootballTeam> FootballTeams()
        {
            return _footballTeamModel.FindAll();;
        }
        
        
        public bool Update(FootballTeam footballTeam)
        {
            _footballTeam = new FootballTeam()
            {
                TeamCode = footballTeam.TeamCode,
                TeamName = footballTeam.TeamName,
                Coach = footballTeam.Coach,
                UpdatedAt = GetTime()
            };
            return _footballTeamModel.Update(_footballTeam);
        }

        
        private DateTime GetTime()
        {
            return DateTime.Now;
        }
    }
}