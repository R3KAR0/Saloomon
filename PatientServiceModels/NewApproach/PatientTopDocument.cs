using System;
using System.Collections.Generic;
using System.Text;

namespace PatientServiceModels.NewApproach
{
    public class PatientTopDocument : TopLevelDocument
    {
        public Patient Parent { get; set; }
        public ICollection<PatientDocumentSubDocument> SubDocuments { get; set; }
    }
}
