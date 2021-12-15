using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using KIT206_assignment_2_;

namespace KIT206_assignment_2_.model
{
    class DB
    {
        //Note that ordinarily these would (1) be stored in a settings file and (2) have some basic encryption applied
        private const string db = "kit206";
        private const string user = "kit206";
        private const string pass = "kit206";
        private const string server = "alacritas.cis.utas.edu.au";
        

        private MySqlConnection conn;

        public DB()
        {
            /*
             * Create the connection object (does not actually make the connection yet)
             * Note that the RAP case study database has the same values for its name, user name and password (to keep things simple)
             */
            string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
            conn = new MySqlConnection(connectionString);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("testing has begun");

            DB demo = new DB();

            int count = demo.GetNumberOfRecords();
            Console.WriteLine("Number of researcher records: {0}", count);
            Console.WriteLine();
            Console.WriteLine("Names from researcher table:");
            demo.ReadData();
            Console.WriteLine();
            Console.WriteLine("Names read into a DataSet (should be the same as above):");
            demo.ReadIntoDataSet();

            Console.WriteLine();
           
            List<Researcher> list_researchers = Agency.LoadAll();
            Console.WriteLine($"Name: {list_researchers[0].family_name}");
            Console.WriteLine($"Name: {list_researchers[0].type}");
            //Console.WriteLine($"Name: {list_researchers[0].level}");
            List<Researcher> f_list_researchers = FilteredSessions("student", list_researchers);
            foreach (var r in f_list_researchers)
            {
                Console.WriteLine($"Name: {r.family_name}");
            }

            if (true)
            {
                Student s = new Student();
                s.degree = "IT";
            }
            else
            {
                Researcher s = new Staff();
            }
            

            Console.WriteLine();
            Console.ReadLine();
        }

        /*
         * Using the ExecuteReader method to select from a single table
         */
        public void ReadData()
        {
            MySqlDataReader rdr = null;

            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command with a query and connection
                MySqlCommand cmd = new MySqlCommand("select given_name, family_name, title from researcher", conn);

                // 2. Call Execute reader to get query results
                rdr = cmd.ExecuteReader();

                // print the CategoryName of each record
                while (rdr.Read())
                {
                    //This illustrates how the raw data can be obtained using an indexer [] or a particular data type can be obtained using a GetTYPENAME() method.
                    Console.WriteLine("{0} {1} ({2})", rdr[0], rdr.GetString(1), rdr.GetString(2));
                }
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

       
        /*
         * Using the ExecuteReader method to select from a single table
         */
        public void ReadIntoDataSet()
        {
            try
            {
                var researcherDataSet = new DataSet();
                var researcherAdapter = new MySqlDataAdapter("select * from researcher", conn);
                researcherAdapter.Fill(researcherDataSet, "researcher");

                foreach (DataRow row in researcherDataSet.Tables["researcher"].Rows)
                {
                    //Again illustrating that indexer (based on column name) gives access to whatever data
                    //type was obtained from a given column, but can call ToString() on an entry if needed.
                    Console.WriteLine("Name: {0} {1}", row["given_name"], row["family_name"].ToString());
                }

                //foreach (DataRow row in researcherDataSet.Tables["researcher"].Rows)
                //{
                //    for (int i = 0; i < researcherDataSet.Tables["researcher"].Columns.Count; i++)
                //    {
                //        Console.WriteLine(researcherDataSet.Tables["researcher"].Columns[i].ColumnName, row[researcherDataSet.Tables["researcher"].Columns[i].ColumnName].ToString());
                //    }
                //}

            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }


        /*
         * Using the ExecuteScalar method
         * returns number of records
         */
        public int GetNumberOfRecords()
        {
            int count = -1;
            try
            {
                // Open the connection
                conn.Open();

                // 1. Instantiate a new command
                MySqlCommand cmd = new MySqlCommand("select COUNT(*) from researcher", conn);

                // 2. Call ExecuteScalar to send command
                // This convoluted approach is safe since cannot predict actual return type
                count = int.Parse(cmd.ExecuteScalar().ToString());
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return count;
        }

        static List<Researcher> FilteredSessions(String researcher_type, List<Researcher> researchers)
        {
            var filtered = from Researcher researcher in researchers
                           where researcher.type.ToString() == researcher_type
                           select researcher;

            return new List<Researcher>(filtered);
        }

        static List<Researcher> FilteredSessions(int fYear, int tYear, List<Researcher> researchers)
        {
            var filtered = from Researcher researcher in researchers
                           where researcher.utas_start.Year <= fYear && researcher.current_start.Year > tYear
                           select researcher;

            return new List<Researcher>(filtered);
        }
    }
}
