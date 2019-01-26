using System;
using System.Collections.Generic;
using System.Text;

namespace DatentransformationsServiceMessages
{
    public interface ValueTypeFindingDTO : ADTO
    {
        long valueType { get; }
        long finding { get; }
        string value { get; }
    }
}
