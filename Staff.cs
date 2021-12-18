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
            var average_number = from Publication pub in publications
                             where pub.year >= year - 3
                             select pub;

            return average_number.Count() / 3;
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
