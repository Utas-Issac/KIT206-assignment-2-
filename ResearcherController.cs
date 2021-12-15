using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIT206_assignment_2_.model;

namespace KIT206_assignment_2_.controller
{
    
    public class ResearcherController
    {
        public List<Researcher> researchers;

        public List<Researcher> filtered_researchers;

        public List<Researcher> FilterBy(Level level)
        {
            return new List<Researcher> { };
        }

        public List<Researcher> FilterByName(string name)
        {
            return new List<Researcher> { };
        }

        public Researcher LoadResearcherDetails()
        {
            return new Researcher();
        }
    }
    
}
