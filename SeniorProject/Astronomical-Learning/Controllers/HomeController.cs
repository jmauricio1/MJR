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
            //get the picture of the day key from the web config
            string apodKey = ConfigurationManager.AppSettings["APOD_Key"]; ;

            //get the data using the key and parse the data that is returned
            string pictureOfTheDayData = getAPOD(apodKey);
            JObject potdData = JObject.Parse(pictureOfTheDayData);

            //get the information from the data
            ViewBag.pictureUrl = potdData["url"];
            ViewBag.pictureTitle = potdData["title"];
            
            //get the information and remove the end that is not relevant
            string explanation = (string)potdData["explanation"];
            explanation = explanation.Remove(explanation.Length - "Activities: NASA Science at Home".Length);
            ViewBag.pictureExplanation = explanation;

            return View();
        }

        //the method the gets the nasa picture of the day information using the web config key
        public string getAPOD(string key)
        {
            //create the url and request the information
            string url = "https://api.nasa.gov/planetary/apod?api_key=";
            url = url + key;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            
            //read in the information
            string jsonString = null;
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