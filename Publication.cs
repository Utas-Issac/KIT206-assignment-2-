using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAP
{
    public enum Publication_Type { Any, Conference, Journal, Other };
    public class Publication
    {
        public string doi { get; set; }
        public string title { get; set; }
        public string authors { get; set; }

        public string cite_as { get; set; }
        public DateTime availabilityDate { get; set; }
        public int year { get; set; }
        public Publication_Type pubType { get; set; }
        public DateTime available { get; set; }



        /*
         * Task 2.2.3
         */
        public override string ToString()
        {
            return doi + "\t" + title + "\t" + authors;
        }

    }
}
