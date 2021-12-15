using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_assignment_2_.model
{
    public enum Researcher_Type { Staff, Student };
    public enum Gender { M, F, X };
    public enum Campus { Hobart, Launceston, Cradle_Coast };
    public enum Level { A, B, C, D, E };

    public class Researcher
    {
        public int id { get; set; }
        public string family_name { get; set; }
        public string given_name { get; set; }
        public string title { get; set; }
        public string unit { get; set; }
        //public string degree { get; set; }
        public string photo { get; set; }
        public string email { get; set; }
        public int year { get; set; }


        public DateTime utas_start { get; set; }
        public DateTime current_start { get; set; }

        public List<Publication> publications { get; set; }
        public Gender gender { get; set; }
        public Campus campus { get; set; }
        public Researcher_Type type { get; set; }
        public Level level { get; set; }

        public List<Position> positions;

        /*
         * Task 2.2.3
         */
        public override string ToString()
        {
            return id + "\t" + family_name + " " + given_name + $"({title})";
        }

        public Position GetEarliestJob()
        {
            return new Position();
        }

        public Position GetCurrentJob()
        {
            return new Position();
        }

        public string CurrentJobTitle()
        {
            return null;
        }
        
        public DateTime CurrentJobStart()
        {
            DateTime data = new DateTime();
            return data;
        }

        public DateTime EarliestStart()
        {
            DateTime data = new DateTime();
            return data;
        }

        public float Tenure()
        {
            return 0.0f;
        }

        public int PublicationsCount()
        {
            return -1;
        }

    }
}
