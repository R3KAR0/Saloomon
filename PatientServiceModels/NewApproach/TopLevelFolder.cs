using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PatientServiceModels.NewApproach
{
    public class TopLevelFolder
    {
        [Key]
        public int Id { get; set; }

        public string Description;

        public ICollection<TopLevelFolder> SubFolders { get; set; }
        public ICollection<TopFolderDocument> SubDocuments { get; set; }
        public ICollection<Patient> Patients { get; set; }

        public TopLevelFolder ParentFolder { get; set; }
    }
}
