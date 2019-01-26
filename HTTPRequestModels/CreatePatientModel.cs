using System;
using System.Collections.Generic;
using System.Text;
using PatientService.Models;

namespace HTTPRequestModels
{
    public class CreatePatientModel
    {
        public Patient Patient { get; set; }
        public int FolderId { get; set; }
    }
}
