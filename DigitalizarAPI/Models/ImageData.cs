using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigitalizarAPI
{
    public class ImageData
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
    }
}