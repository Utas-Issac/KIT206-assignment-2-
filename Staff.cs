using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_assignment_2_.model
{

    class Staff : Researcher
    {


        /*
         * Task 2.2.3
         */
        public override string ToString()
        {
            return familyName + "\t" + id + "\t" + gender;
        }

    }
}
