using System;
using System.Collections.Generic;
using System.Text;

namespace DatentransformationsServiceModels.Findings
{
    public class FindingType : AEntity
    {
        public string name { get; set; }

        public HashSet<ValueGroup> valueGroups { get; set; }

    }
}
