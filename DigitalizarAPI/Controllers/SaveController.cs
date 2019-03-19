using DigitalizarAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DigitalizarAPI.Controllers
{
    public class SaveController : ApiController
    {
        // POST api/<controller>
        public IHttpActionResult Post(ImageData request)
        {
            if(request != null)
            {
                try
                {
                    using (var db = new DBModelcs())
                    {
                        request.Created = DateTime.Now;
                        db.ImageDatas.Add(request);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {

                    return InternalServerError();
                }
                return Ok();
            }
            return BadRequest();
        }
        
    }
}