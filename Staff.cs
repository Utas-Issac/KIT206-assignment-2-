using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP
{

    class Staff : Researcher
    {
        public float ThreeYearAverage(List<Publication> publications, int year)
        {


            return 0.0f;
        }

        public float Performance()
        {
            return 0.0f;
        }
        /*
         * Task 2.2.3
         */
        public override string ToString()
        {
            return family_name + "\t" + id + "\t" + gender;
        }

    }
}
