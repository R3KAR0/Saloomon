using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PatientServiceModels.NewApproach
{
    public class PatientFolder 
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public ICollection<PatientFolderDocument> SubDocuments { get; set; }

        public Patient Parent { get; set; }
    }
}
