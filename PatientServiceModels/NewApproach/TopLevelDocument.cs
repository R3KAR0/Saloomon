using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PatientServiceModels.NewApproach
{
    public abstract class TopLevelDocument
    {
        [Key]
        public int Id { get; set; }
        public int IdOfOtherService { get; set; }

    }
}
