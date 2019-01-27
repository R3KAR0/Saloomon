using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PatientServiceModels.NewApproach
{
    public abstract class SubLevelDocument
    {
        [Key]
        public int Id { get; set; }

        public int IdInOtherService { get; set; }
    }
}
