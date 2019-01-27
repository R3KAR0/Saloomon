using System;
using System.Collections.Generic;
using System.Text;

namespace PatientServiceModels.NewApproach
{
    public class PatientFolderDocumentSubDocument : SubLevelDocument
    {
        public PatientFolderDocument Parent { get; set; }
    }
}
