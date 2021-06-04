using System;
using System.Collections.Generic;
using FootballManager.Entities;
using FootballManager.helper;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Cms;

namespace FootballManager.Model
{
    public class MatchScheduleModel
    {
        public bool CreateSchedule(Schedule schedule)
        {
            var cmd = new MySqlCommand() {Connection = ConnectionHelper.GetConnection()};
            try
            {
                cmd.CommandText =
                    $"INSERT into schedule(`Battle`,`MatchDay`,`Time`,`Pitch`,`CreatedAt`,`UpdateAt`) VALUES (@Battle, @MatchDay, @Time, @Pitch, @CreatedAt, @UpdateAt)";
                cmd.Parameters.AddWithValue("@Battle", schedule.Battle);
                cmd.Parameters.AddWithValue("@MatchDay", schedule.MatchDay);
                cmd.Parameters.AddWithValue("@Time", schedule.Time);
                cmd.Parameters.AddWithValue("@Pitch", schedule.Pitch);
                cmd.Parameters.AddWithValue("@CreatedAt", schedule.CreatedAt);
                cmd.Parameters.AddWithValue("@UpdateAt", schedule.UpdateAt);
                var result = cmd.ExecuteNonQuery();
                if (result != 0)
                {
                    return true;
                }

                return false;
            }
            catch (MySqlException e)
            {
                return false;
            }
        }

        public List<Schedule> FindAll()
        {
            var schedules = new List<Schedule>();
            var cmd = new MySqlCommand() {Connection = ConnectionHelper.GetConnection()};
            try
            {
                cmd.CommandText = $"Select * from schedule";
                var result = cmd.ExecuteReader();
                while (result.Read())
                {
                    schedules.Add(new Schedule()
                    {
                        Battle = result["Battle"].ToString(),
                        MatchDay = result["MatchDay"].ToString(),
                        Time = result["Time"].ToString(),
                        Pitch = result["Pitch"].ToString(),
                        Id = int.Parse(result["Id"].ToString()),
                    });
                }

                result.Close();
                return schedules;
            }
            catch (MySqlException e)
            {
                return schedules;
            }
        }


        public bool CreateNewRecodeForResultTable(CompetitionResults competitionResult)
        {
            var cmd = new MySqlCommand() {Connection = ConnectionHelper.GetConnection()};
            try
            {
                cmd.CommandText =
                    $"INSERT into matchresult(`TeamCode1`,`TeamCode2`,`ResultForTeam1`,`ResultForTeam2`,`Status`) VALUES (@TeamCode1,@TeamCode2,@ResultForTeam1,@ResultForTeam2,@Status)";
                cmd.Parameters.AddWithValue("@TeamCode1", competitionResult.TeamCode1);
                cmd.Parameters.AddWithValue("@TeamCode2", competitionResult.TeamCode2);
                cmd.Parameters.AddWithValue("@ResultForTeam1", competitionResult.ResultForTeam1);
                cmd.Parameters.AddWithValue("@ResultForTeam2", competitionResult.ResultForTeam2);
                cmd.Parameters.AddWithValue("@Status", competitionResult.Status);
                var result = cmd.ExecuteNonQuery();
                if (result != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException e)
            {
                return false;
            }
        }

        public List<CompetitionResults> GetResultsList()
        {
            var competitionResultsList = new List<CompetitionResults>();
            var cmd = new MySqlCommand() {Connection = ConnectionHelper.GetConnection()};
            try
            {
                cmd.CommandText = $"SELECT * from matchresult";
                var result = cmd.ExecuteReader();
                while (result.Read())
                {
                    competitionResultsList.Add(new CompetitionResults()
                    {
                        TeamCode1 = result["TeamCode1"].ToString(),
                        TeamCode2 = result["TeamCode2"].ToString(),
                        ResultForTeam1 = int.Parse(result["ResultForTeam1"].ToString()),
                        ResultForTeam2 = int.Parse(result["ResultForTeam2"].ToString()),
                        Status = int.Parse(result["Status"].ToString()),
                        Id = int.Parse(result["Id"].ToString())
                    });
                }

                result.Close();
                return competitionResultsList;
            }
            catch (MySqlException e)
            {
                return competitionResultsList;
            }
        }


        public bool UpdateResult(int id, int resultForTeam1, int resultForTeam2)
        {
            var cmd = new MySqlCommand() {Connection = ConnectionHelper.GetConnection()};
            try
            {
                cmd.CommandText =
                    $"UPDATE matchresult set ResultForTeam1 = {resultForTeam1} , ResultForTeam2 = {resultForTeam2} where id = {id}";
                var result = cmd.ExecuteNonQuery();
                if (result != 0)
                {
                    return true;
                }

                return false;
            }
            catch (MySqlException e)
            {
                return false;
            }
        }

        public bool UpdateMatch(int id ,Schedule schedule)
        {
            var cmd = new MySqlCommand() {Connection = ConnectionHelper.GetConnection()};
            try
            {
                cmd.CommandText =
                    $"UPDATE schedule set MatchDay = '{schedule.MatchDay}', Time = '{schedule.Time}' , Pitch = '{schedule.Pitch}' ,  UpdateAt = '{schedule.UpdateAt}' where Id = {id}";
                var result = cmd.ExecuteNonQuery();
                if (result != 0)
                {
                    return true;
                }
                return false;
            }
            catch (MySqlException e)
            {
                return false;
            }
        }
    }
}