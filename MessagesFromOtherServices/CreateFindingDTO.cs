using System.Collections.Generic;

namespace DatentransformationsServiceMessages
{
    interface CreateFindingDTO : ADTO
    {
        long findingTypeId  { get; }

        List<ValueTypeFindingDTO>  values { get; }


    }
}
