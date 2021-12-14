using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using KIT206_assignment_2_.model;

namespace KIT206_assignment_2_
{
    abstract class Agency
    {
        //These would not be hard coded in the source file normally, but read from the application's settings (and, ideally, with some amount of basic encryption applied)
        private const string db = "kit206";
        private const string user = "kit206";
        private const string pass = "kit206";
        private const string server = "alacritas.cis.utas.edu.au";

        private static MySqlConnection conn = null;

        //This method is a gift to you because .NET's approach to converting strings to enums is so horribly broken
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        /// <summary>
        /// Creates and returns (but does not open) the connection to the database.
        /// </summary>
        private static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                //Note: This approach is not thread-safe
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }


        public static List<Researcher> LoadAll()
        {
            List<Researcher> staff = new List<Researcher>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select id, given_name, family_name from researcher", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Note that in your assignment you will need to inspect the *type* of the
                    //Researcher/researcher before deciding which kind of concrete class to create.


                    //staff.Add(new Researcher { ID = rdr.GetInt32(0), Name = rdr.GetString(1) + " " + rdr.GetString(2) });
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return staff;
        }

        public static List<Publication> LoadAllPublication()
        {
            List<Publication> publications = new List<Publication>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select * from publication", conn);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //Note that in your assignment you will need to inspect the *type* of the
                    //Researcher/researcher before deciding which kind of concrete class to create.

                    // GetInt32(0), GetString(1)
                    publications.Add(new Publication
                    {
                        doi = rdr.GetString(0),
                        title = rdr.GetString(1),
                        authors = rdr.GetString(2),
                        year = rdr.GetInt32(3),
                        //pubType = rdr.GetString(4) Mode = ParseEnum<Mode>(rdr.GetString(2)),
                        pubType = ParseEnum<Publication_Type>(rdr.GetString(4))
                    });
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return publications;
        }

        public static List<Researcher> LoadTrainingSessions(int id)
        {
            List<Researcher> work = new List<Researcher>();

            MySqlConnection conn = GetConnection();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select title, year, type, available " +
                                                    "from publication as pub, researcher_publication as respub " +
                                                    "where pub.doi=respub.doi and researcher_id=?id", conn);

                cmd.Parameters.AddWithValue("id", id);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    work.Add(new Researcher
                    {
                        title = rdr.GetString(0),
                        year = rdr.GetInt32(1),
                        Mode = ParseEnum<Mode>(rdr.GetString(2)),
                        Certified = rdr.GetDateTime(3)
                    });
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error connecting to database: " + e);
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return work;
        }

        //This is useful if the necessary data has not been loaded into memory yet.
        public static int ResearcherTrainingCount(Researcher e, int startYear, int endYear)
        {
            MySqlConnection conn = GetConnection();
            int count = 0;

            try
            {
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("select count(*) from publication as pub, researcher_publication as respub " +
                                                    "where pub.doi = respub.doi and researcher_id = ?id and year >= ?start and year <= ?end", conn);
                cmd.Parameters.AddWithValue("id", e.id);
                cmd.Parameters.AddWithValue("start", startYear);
                cmd.Parameters.AddWithValue("end", endYear);
                count = Int32.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error connecting to database: " + ex);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return count;
        }

        //This method is now obsolete.
        public static List<Researcher> Generate()
        {
            return new List<Researcher>() {
                new Researcher { family_name = "Jane", id = 1, gender = Gender.F },
                new Researcher { family_name = "John", id = 3, gender = Gender.M },
                new Researcher { family_name = "Mary", id = 7, gender = Gender.F },
                new Researcher { family_name = "Lindsay", id = 5, gender = Gender.X },
                new Researcher { family_name = "Meilin", id = 2, gender = Gender.F }
            };
        }
    }
}
