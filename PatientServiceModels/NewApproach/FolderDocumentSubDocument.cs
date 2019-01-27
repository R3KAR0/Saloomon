using System;
using System.Collections.Generic;
using System.Text;

namespace PatientServiceModels.NewApproach
{
    public class FolderDocumentSubDocument : SubLevelDocument
    {
        public TopFolderDocument Parent { get; set; }
    }
}
