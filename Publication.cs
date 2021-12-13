using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_assignment_2_.model
{

    public class Publication
    {
        public string doi { get; set; }
        public string title { get; set; }
        public string author { get; set; }

        public string citation { get; set; }
        public DateTime availabilityDate { get; set; }
        public DateTime publicationYear { get; set; }
        public string pubType { get; set; }


        /*
         * Task 2.2.3
         */
        public override string ToString()
        {
            return doi + "\t" + title + "\t" + author;
        }

    }
}
