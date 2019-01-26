using System;
using System.Collections.Generic;
using System.Text;

namespace DatentransformationsServiceMessages.finding
{
    public interface AllFindingsDTO : ADTO
    {
        HashSet<ModifiedFindingDTO> findings { get; }
    }
}
