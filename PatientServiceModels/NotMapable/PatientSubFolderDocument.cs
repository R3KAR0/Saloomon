using System.Collections.Generic;
using PatientServiceModels.NewApproach;

namespace PatientServiceModels.NotMapable
{
    public class PatientSubFolderDocument : TopLevelDocument
    {
        public PatientSubFolder Parent { get; set; }
        public ICollection<PatientSubFolderDocumentSubDocument> SubDocuments { get; set; }
    }
}
