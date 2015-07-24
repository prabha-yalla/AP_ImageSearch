using APM.WebAPI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.OData;

namespace APM.WebAPI.Controllers
{
    [RoutePrefix("api/Image")]
    [EnableCorsAttribute("*", "*", "*")]
    public class ImageController : ApiController
    {
        
        string apikey = "AsGd3Ib2TXOfkPL3idZ24LO0vB7ksrHa";
        //GET: api/GetPhoto
        [Route("GetPhoto")]
       
        public HttpResponseMessage GetPhoto()
        {
                string imageUrl = HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.QueryString["href"]);
                string imgURL = (imageUrl + "&apikey=AsGd3Ib2TXOfkPL3idZ24LO0vB7ksrHa");
                WebClient lWebClient = new WebClient();
                byte[] lImageBytes = lWebClient.DownloadData(imgURL);
                MemoryStream imgStream = new MemoryStream(lImageBytes);
                var resp = new HttpResponseMessage()
                {
                    Content = new StreamContent(imgStream)
                };
                // Find the MIME type      
               resp.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
               return resp;                   
        }

        // GET: api/Image?search=test
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get(string search)
        {
            string str = "";
            try
            {

                string URL = string.Format(@"http://api.ap.org/v2/search?&apikey={0}&q={1}&format={2}",
                apikey, System.Web.HttpUtility.UrlEncode(search), "json");
                using (var webClient = new System.Net.WebClient())
                {
                    str = webClient.DownloadString(URL);
                }
                JObject json = JObject.Parse(str);
                return Ok(json);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
