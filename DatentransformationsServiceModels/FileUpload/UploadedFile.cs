using System;
using System.Collections.Generic;
using System.Text;

namespace DatentransformationsServiceModels.FileUpload
{
    public class UploadedFile: AEntity
    {
        public byte[] file { get; set; }
        public DateTime uploadDate { get; set; }
        public string userId { get; set; }
        public string permission { get; set; }
    }
}
