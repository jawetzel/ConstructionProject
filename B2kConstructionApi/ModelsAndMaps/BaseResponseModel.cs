using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsAndMaps
{
    public class BaseResponseModel
    {
        public bool Success { get; set; }
        public string NoSuccessReason { get; set; }
    }
}
