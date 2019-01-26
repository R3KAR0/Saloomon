using System;
using System.Collections.Generic;
using System.Text;

namespace DatentransformationsServiceMessages
{
    public interface GeneralIdDTO : ADTO
    {
        long requestId { get; }
    }
}
