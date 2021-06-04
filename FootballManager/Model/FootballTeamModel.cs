using System;
using System.Collections.Generic;
using FootballManager.Entities;
using FootballManager.helper;
using MySql.Data.MySqlClient;

namespace FootballManager.Model
{
    public class FootballTeamModel
    {
        public bool Store(FootballTeam footballTeam)
        {
            var connection = ConnectionHelper.GetConnection();
            var cmd = new MySqlCommand() {Connection = connection};
            try
            {
                cmd.CommandText =
                    $"INSERT into footballteam(`TeamCode`,`TeamName`,`Coach`,`CreatedAt`,`UpdatedAt`) VALUES (@TeamCode,@TeamName,@Coach,@CreatedAt,@UpdatedAt)";
                cmd.Parameters.AddWithValue("@TeamCode", footballTeam.TeamCode);
                cmd.Parameters.AddWithValue("@TeamName", footballTeam.TeamName);
                cmd.Parameters.AddWithValue("@Coach", footballTeam.Coach);
                cmd.Parameters.AddWithValue("@CreatedAt", footballTeam.CreatedAt);
                cmd.Parameters.AddWithValue("@UpdatedAt", footballTeam.UpdatedAt);
                var result = cmd.ExecuteNonQuery();
                if (result != 0)
                {
                    return true;
                }
            }
            catch (MySqlException e)
            {
                return false;
            }

            return false;
        }

        public List<FootballTeam> FindAll()
        {
            var footballTeams = new List<FootballTeam>();
            var connection = ConnectionHelper.GetConnection();
            var cmd = new MySqlCommand() {Connection = connection};
            try
            {
                cmd.CommandText = $"SELECT * from footballteam WHERE Status = 1";
                var result = cmd.ExecuteReader();

                while (result.Read())
                {
                    var teamCode = result["TeamCode"].ToString();
                    var teamName = result["TeamName"].ToString();
                    var coach = result["Coach"].ToString();
                    footballTeams.Add(new FootballTeam()
                    {
                        TeamCode = teamCode,
                        TeamName = teamName,
                        Coach = coach
                    });
                }
                result.Close();
                return footballTeams;
            }
            catch (MySqlException e)
            {
                return footballTeams;
            }
        }


        public bool Update(FootballTeam footballTeam)
        {
            var connection = ConnectionHelper.GetConnection();
            var cmd = new MySqlCommand(){ Connection = connection};
            try
            {
                cmd.CommandText = $"UPDATE footballteam set TeamName='{footballTeam.TeamName}' , Coach='{footballTeam.Coach}', UpdatedAt='{footballTeam.UpdatedAt}' where TeamCode = '{footballTeam.TeamCode}' ";
                var result = cmd.ExecuteNonQuery();
                if (result != 0)
                {
                    return true;
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e);
            }
            return false;
        }
    }
}