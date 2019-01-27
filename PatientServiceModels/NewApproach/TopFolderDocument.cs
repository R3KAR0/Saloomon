using System;
using System.Collections.Generic;
using System.Text;

namespace PatientServiceModels.NewApproach
{
    public class TopFolderDocument : TopLevelDocument
    {
        public TopLevelFolder Parent { get; set; }
        public ICollection<FolderDocumentSubDocument> SubDocuments { get; set; }
    }
}
