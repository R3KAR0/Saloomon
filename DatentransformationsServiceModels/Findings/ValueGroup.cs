using System;
using System.Collections.Generic;
using System.Text;

namespace DatentransformationsServiceModels.Findings
{
    public class ValueGroup : AEntity
    {
        public string name { get; set; }
        public HashSet<ValueType> types { get; set; }
        public FindingType findingType { get; set; }
        public bool expired { get; set; }
    }
}
