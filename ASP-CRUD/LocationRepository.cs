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

        /// <summary>
        ///     This method return the records from the location table.
        ///     Query: SELECT * FROM location 
        /// </summary>
        public static List<Location> GetLocations()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using ( conn )
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = cmd.CommandText = "SELECT LocationId, Name, CostRate, Availability, ModifiedDate FROM location;"; 
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

        /// <summary>
        ///     CreateLocation method takes four parameters  (n = Name, c = CostRate, a = Availability)
        ///     And creates a Location within our database with that Name,CostRate, Availability.
        /// </summary>
        public static int CreateLocation(Location l)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using ( conn )
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO location (Name, CostRate, Availability) " +
                                   "VALUES (@name, @costrate,@availability)";
                cmd.Parameters.AddWithValue("name", l.Name);
                cmd.Parameters.AddWithValue("costrate", l.CostRate);
                cmd.Parameters.AddWithValue("availability", l.Availability);

                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     DeleteLocation method deletes and record from the location table
        ///     takes one parameters  (LocationID)
        ///     Deletes and record with a specific LocationId .
        /// </summary>
        public static int DeleteLocation(int LocationId)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = "DELETE FROM Location WHERE LocationId = @lId;";
                cmd.Parameters.AddWithValue("lId", LocationId);

               return cmd.ExecuteNonQuery();
            }

        }

        /// <summary>
        ///     UpdateLocation method updates all field in the location table
        ///     takes Location object parameters 
        ///     And updates a Location within our database with that all fields.
        /// </summary>
        public static void UpdateLocation(Location l)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE location SET Name = @name, CostRate = @costrate, " +
                                  "Availability = @availability,ModifiedDate =  @modifiedate " +
                                  "WHERE LocationID = @locationID";
                cmd.Parameters.AddWithValue("name", l.Name);
                cmd.Parameters.AddWithValue("costrate", l.CostRate);
                cmd.Parameters.AddWithValue("availability", l.Availability);
                cmd.Parameters.AddWithValue("modifiedate", DateTime.Now);
                cmd.Parameters.AddWithValue("LocationID", l.LocationID);
                cmd.ExecuteNonQuery();
            }
        }

        
    }
}
