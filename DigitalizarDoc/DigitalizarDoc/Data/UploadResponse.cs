using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalizarDoc
{
    public class UploadResponse
    {
        public string RequestId { get; set; }
        public string StatusDesc { get; set; }
        public int StatusCode { get; set; }
        public ImageData ImageInfo { get; set; }
        public List<Error> Errors { get; set; }
    }
}