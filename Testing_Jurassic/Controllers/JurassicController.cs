using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Testing_Jurassic.BussinessLogic;
using Newtonsoft.Json;

namespace Testing_Jurassic.Controllers
{
    public class JurassicController : ApiController
    {
        private static JurassicService _jurassicService = new JurassicService();
        // GET: api/Jurassic
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(new string[] { "value1", "value2" }))
            };
        }

        // GET: api/Jurassic/abc
        public HttpResponseMessage Get(string id)
        {
            var param = id.Split(',').ToList();
            var servicio = _jurassicService.UseJurassic(param);
            var ret = JsonConvert.SerializeObject(servicio);
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(ret)
            };
        }

        // POST: api/Jurassic
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Jurassic/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Jurassic/5
        public void Delete(int id)
        {
        }
    }
}
