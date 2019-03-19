using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DigitalizarAPI.Models
{
    public class DBModelcs : DbContext
    {
        public DbSet<ImageData> ImageDatas { get; set; }
    }
}