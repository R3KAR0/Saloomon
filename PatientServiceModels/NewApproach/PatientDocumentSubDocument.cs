using System;
using System.Collections.Generic;
using System.Text;

namespace PatientServiceModels.NewApproach
{
    public class PatientDocumentSubDocument : SubLevelDocument
    {
        public PatientTopDocument Parent { get; set; }
    }
}
