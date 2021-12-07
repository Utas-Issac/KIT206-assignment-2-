using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_assignment_2_.model
{

    class Publication
    {
        public string doi;
        public string title;
        public string author;
        public string citation;
        public DateTime availabilityDate;
        public DateTime publicationYear;
        public string pubType;


        /*
         * Task 2.2.3
         */
        public override string ToString()
        {
            return doi + "\t" + title + "\t" + author;
        }

    }
}
