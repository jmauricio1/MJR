using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Astronomical_Learning.DAL;
using Astronomical_Learning.Models;
using Newtonsoft.Json.Linq;
using Astronomical_Learning.TempDAL;

namespace Astronomical_Learning.Controllers
{
    public class HomeController : Controller
    {
        // private FactOfTheDayContext db = new FactOfTheDayContext();
        //private ALContext db = new ALContext();
        private ALContext db = new ALContext();
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
            ViewBag.pictureExplanation = explanation;
            
            
            //get the number of facts in the database
            var factCount = db.FactOfTheDays.Count();
       
            //select one based on the current day of the year
            DateTime currentDate = DateTime.Now;
            int dayOfYear = currentDate.DayOfYear;

            //the fact-1 and the final +1 is so the answer is from 1 to the final amount of facts and would not return 0
            int chosenSpot = (dayOfYear % (factCount-1)) + 1;
            var selectedFact = db.FactOfTheDays.Find(chosenSpot);
            
            ViewBag.fact = selectedFact.Text;
            ViewBag.factSource = selectedFact.Source;



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