using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP
{

    class Student : Researcher
    {
        public string degree { get; set; }

        public int supervisor_id { get; set; }

        /*
         * Task 2.2.3
         */
        public override string ToString()
        {
            return family_name + "\t" + id + "\t" + gender;
        }

    }
}
