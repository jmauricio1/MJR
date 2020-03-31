using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace Astronomical_Learning.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string apodKey = ConfigurationManager.AppSettings["APOD_Key"]; ;

            string pictureOfTheDayData = getAPOD(apodKey);
            JObject potdData = JObject.Parse(pictureOfTheDayData);



            ViewBag.pictureUrl = potdData["url"];
            ViewBag.pictureTitle = potdData["title"];
            
            string explanation = (string)potdData["explanation"];
            explanation = explanation.Remove(explanation.Length - "Activities: NASA Science at Home".Length);
            ViewBag.pictureExplanation = explanation;


            return View();
        }


        private string getAPOD(string key)
        {
            string url = "https://api.nasa.gov/planetary/apod?api_key=";

            url = url + key;
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            

            string jsonString = null;
            // TODO: You should handle exceptions here
            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            return jsonString;
        }


    }


}