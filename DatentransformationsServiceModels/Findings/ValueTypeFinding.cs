using System;
using System.Collections.Generic;
using System.Text;

namespace DatentransformationsServiceModels.Findings
{
    public class ValueTypeFinding : AEntity
    {
        public Finding finding { get; set; }
        public ValueType type { get; set; }
        public string value { get; set; }
    }
}
