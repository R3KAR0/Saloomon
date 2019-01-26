using System;
using System.Collections.Generic;
using System.Text;

namespace DatentransformationsServiceMessages.finding
{
    public interface ModifiedFindingDTO : ADTO
    {
        long id { get; }
        string name { get; }
        long findingTypeId { get; set; }
    }
}
