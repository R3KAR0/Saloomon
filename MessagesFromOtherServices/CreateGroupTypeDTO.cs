using System;
using System.Collections.Generic;
using System.Text;

namespace DatentransformationsServiceMessages
{
    public interface CreateGroupTypeDTO : ADTO
    {
        long findingTypeId { get; }
        string name { get;  }
    }
}
