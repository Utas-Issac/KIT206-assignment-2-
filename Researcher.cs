using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_assignment_2_.model
{
    enum Type { Staff, Student };
    enum Gender { M, F, X };
    enum Campus { Hobart, Launceston, Cradle_Coast };
    enum Level { A, B, C, D, E };

    public abstract class Researcher
    {
        public int id;
        public string family_name;
        public string given_name;
        public string title;
        public string unit;
        public string degree;
        public string photo;
        public string email;


        public DateTime utas_start;
        public DateTime current_start;

        public Publication publications;
        Gender gender;
        Campus campus;

        /*
         * Task 2.2.3
         */
        public override string ToString()
        {
            return family_name + "\t" + id + "\t" + gender;
        }

    }
}
