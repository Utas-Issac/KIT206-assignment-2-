using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_assignment_2_.model
{

    class Student : Researcher
    {
        public string degree { get; set; }

        public int supervisor_id { get; set; }

        public List<Researcher> researchers;
        /*
         * Task 2.2.3
         */
        public override string ToString()
        {
            return family_name + "\t" + id + "\t" + gender;
        }

        public List<Researcher> To_List()
        {
            Student student = new Student();
            researchers.Append(student);
            return researchers;
        }

    }
}
