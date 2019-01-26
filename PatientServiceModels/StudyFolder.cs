using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using PatientService.Models;

namespace PatientServiceModels
{
    public class StudyFolder : IStudyFolderParent, IDocumentParent
    {
        [Key]
        public int Id { get; private set; }

        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<StudyFolder> SubFolders { get; set; }

        public IStudyFolderParent Parent { get; set; }

    }
}
