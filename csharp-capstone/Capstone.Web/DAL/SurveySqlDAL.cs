using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAL : ISurveySqlDAL
    {

        private readonly string connectionString;

        public SurveySqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Survey> GetAllSurveys()
        {
            IList<Survey> surveys = new List<Survey>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select survey_result.parkCode, park.parkName, Count(survey_result.parkCode) as stuff from survey_result inner join park ON survey_result.parkCode = park.parkCode group by survey_result.parkCode, park.parkName order by stuff DESC", conn);


                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var survey = new Survey()
                        {
                            Count = Convert.ToInt32(reader["stuff"]),
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            ParkName = Convert.ToString(reader["parkName"])
                            //EmailAddress = Convert.ToString(reader["emailAddress"]),
                            //State = Convert.ToString(reader["state"]),
                            //ActivityLevel = Convert.ToString(reader["activityLevel"])

                        };

                        surveys.Add(survey);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return surveys;
        }

        public void SaveNewSurvey(Survey survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("Insert Into survey_result Values (@parkCode, @emailAddress, @state, @activityLevel);", conn);
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                    cmd.ExecuteNonQuery();

                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }


    }

}
