using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_CRUD.Models;
using MySql.Data.MySqlClient;

namespace ASP_CRUD
{
    public class LocationRepository
{
        public static string connectionString { get; set; }

        public static List<Location> GetLocations()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT LocationId, Name, CostRate, Availability FROM location;";
                MySqlDataReader reader = cmd.ExecuteReader();


                List<Location> locations = new List<Location>();
                while (reader.Read())
                {
                    Location loc = new Location();
                    loc.LocationID = (int)reader["LocationID"];
                    loc.Name = reader["Name"].ToString();
                    loc.CostRate = (double)reader["CostRate"];
                    loc.Availability = (decimal)reader["Availability"];
                    loc.ModifiedDate = (DateTime)reader["ModifiedDate"];

                    locations.Add(loc);
                }
                return locations;
            }



        }
    }
}
