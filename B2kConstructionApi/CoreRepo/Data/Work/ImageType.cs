using System;
using System.Collections.Generic;
using System.Text;

namespace CoreRepo.Data.Work
{
    public class ImageType : BaseData
    {
        public ImageType()
        {
            IsReciept = false;
            IsSignature = false;
        }
        public string Description { get; set; }

        public bool IsReciept { get; set; }
        public bool IsSignature { get; set; }

        public ICollection<WorkImage> WorkImages { get; set; }
    }
}
