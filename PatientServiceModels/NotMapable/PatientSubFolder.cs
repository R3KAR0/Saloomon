using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientServiceModels.NotMapable
{
    public class PatientSubFolder
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public ICollection<PatientSubFolderDocument> SubDocuments { get; set; }
    }
}
