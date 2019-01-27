using System;
using System.Collections.Generic;
using System.Text;

namespace PatientServiceModels.NewApproach
{
    public class PatientFolderDocument : TopLevelDocument
    {
        public PatientFolder Parent { get; set; }
        public ICollection<PatientFolderDocumentSubDocument> SubDocuments { get; set; }
    }
}
