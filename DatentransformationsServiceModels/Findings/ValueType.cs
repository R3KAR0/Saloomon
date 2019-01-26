using System;
using System.Collections.Generic;
using System.Text;

namespace DatentransformationsServiceModels.Findings
{
    public class ValueType : AEntity
    {
        public string name { get; set; }
        public string unit { get; set; }
        public double minValue { get; set; }
        public double maxValue { get; set; }
        public ValueGroup group { get; set; }
        public bool expired { get; set; }
    }
}
