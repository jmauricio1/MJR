using Astronomical_Learning.DAL;
using Astronomical_Learning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;

namespace Astronomical_Learning.Controllers
{
    public class TripPlannerController : Controller
    {
        private ALContext db = new ALContext();

        // GET: TripPlanner
        public ActionResult OurSolarSystem()
        {
            return View();
        }

        [HttpPost]
        public JsonResult CalculateDistances(string Start, string StopOne, string StopTwo, string StopThree, string StopFour, string Destination)
        {
            List<TripPlanModel> Distances = new List<TripPlanModel>();
            TripPlanModel tempOne = new TripPlanModel();
            TripPlanModel tempTwo = new TripPlanModel();
            TripPlanModel tempThree = new TripPlanModel();
            TripPlanModel tempFour = new TripPlanModel();
            TripPlanModel tempFive = new TripPlanModel();


            int startId = db.Locations.Where(x => x.LocationName == Start).Select(x => x.Id).FirstOrDefault();
            int stopOneId = db.Locations.Where(x => x.LocationName == StopOne).Select(x => x.Id).FirstOrDefault();
            int stopTwoId = db.Locations.Where(x => x.LocationName == StopTwo).Select(x => x.Id).FirstOrDefault();
            int stopThreeId = db.Locations.Where(x => x.LocationName == StopThree).Select(x => x.Id).FirstOrDefault();
            int stopFourId = db.Locations.Where(x => x.LocationName == StopFour).Select(x => x.Id).FirstOrDefault();
            int destinationId = db.Locations.Where(x => x.LocationName == Destination).Select(x => x.Id).FirstOrDefault();

            if (StopFour != null)
            {
                //calculate route for start>stop1>stop2>stop3>stop4>end
                int startToOneDistanceId = db.LocationDistances.Where(x => x.LocationOneId == startId && x.LocationTwoId == stopOneId).Select(x => x.DistanceId).FirstOrDefault();
                long startToOneDistance = db.Distances.Where(x => x.Id == startToOneDistanceId).Select(x => x.DistanceMiles).FirstOrDefault();
                tempOne.Start = Start;
                tempOne.Destination = StopOne;
                tempOne.Distance = startToOneDistance;
                Distances.Add(tempOne);

                int oneToTwoDistanceId = db.LocationDistances.Where(x => x.LocationOneId == stopOneId && x.LocationTwoId == stopTwoId).Select(x => x.DistanceId).FirstOrDefault();
                long oneToTwoDistance = db.Distances.Where(x => x.Id == oneToTwoDistanceId).Select(x => x.DistanceMiles).FirstOrDefault();
                tempTwo.Start = StopOne;
                tempTwo.Destination = StopTwo;
                tempTwo.Distance = oneToTwoDistance;
                Distances.Add(tempTwo);

                int twoToThreeDistanceId = db.LocationDistances.Where(x => x.LocationOneId == stopTwoId && x.LocationTwoId == stopThreeId).Select(x => x.DistanceId).FirstOrDefault();
                long twoToThreeDistance = db.Distances.Where(x => x.Id == twoToThreeDistanceId).Select(x => x.DistanceMiles).FirstOrDefault();
                tempThree.Start = StopTwo;
                tempThree.Destination = StopThree;
                tempThree.Distance = twoToThreeDistance;
                Distances.Add(tempThree);

                int threeToFourDistanceId = db.LocationDistances.Where(x => x.LocationOneId == stopThreeId && x.LocationTwoId == stopFourId).Select(x => x.DistanceId).FirstOrDefault();
                long threeToFourDistance = db.Distances.Where(x => x.Id == threeToFourDistanceId).Select(x => x.DistanceMiles).FirstOrDefault();
                tempFour.Start = StopThree;
                tempFour.Destination = StopFour;
                tempFour.Distance = threeToFourDistance;
                Distances.Add(tempFour);

                int fourToDestinationDistanceId = db.LocationDistances.Where(x => x.LocationOneId == stopFourId && x.LocationTwoId == destinationId).Select(x => x.DistanceId).FirstOrDefault();
                long fourToDestinationDistance = db.Distances.Where(x => x.Id == fourToDestinationDistanceId).Select(x => x.DistanceMiles).FirstOrDefault();
                tempFive.Start = StopFour;
                tempFive.Destination = Destination;
                tempFive.Distance = fourToDestinationDistance;
                Distances.Add(tempFive);
            }

            else if (StopThree != null)
            {
                //calculate route for start>stop1>stop2>stop3>end
                int startToOneDistanceId = db.LocationDistances.Where(x => x.LocationOneId == startId && x.LocationTwoId == stopOneId).Select(x => x.DistanceId).FirstOrDefault();
                long startToOneDistance = db.Distances.Where(x => x.Id == startToOneDistanceId).Select(x => x.DistanceMiles).FirstOrDefault();
                tempOne.Start = Start;
                tempOne.Destination = StopOne;
                tempOne.Distance = startToOneDistance;
                Distances.Add(tempOne);

                int oneToTwoDistanceId = db.LocationDistances.Where(x => x.LocationOneId == stopOneId && x.LocationTwoId == stopTwoId).Select(x => x.DistanceId).FirstOrDefault();
                long oneToTwoDistance = db.Distances.Where(x => x.Id == oneToTwoDistanceId).Select(x => x.DistanceMiles).FirstOrDefault();
                tempTwo.Start = StopOne;
                tempTwo.Destination = StopTwo;
                tempTwo.Distance = oneToTwoDistance;
                Distances.Add(tempTwo);

                int twoToThreeDistanceId = db.LocationDistances.Where(x => x.LocationOneId == stopTwoId && x.LocationTwoId == stopThreeId).Select(x => x.DistanceId).FirstOrDefault();
                long twoToThreeDistance = db.Distances.Where(x => x.Id == twoToThreeDistanceId).Select(x => x.DistanceMiles).FirstOrDefault();
                tempThree.Start = StopTwo;
                tempThree.Destination = StopThree;
                tempThree.Distance = twoToThreeDistance;
                Distances.Add(tempThree);

                int threeToDestinationDistanceId = db.LocationDistances.Where(x => x.LocationOneId == stopThreeId && x.LocationTwoId == destinationId).Select(x => x.DistanceId).FirstOrDefault();
                long threeToDestinationDistance = db.Distances.Where(x => x.Id == threeToDestinationDistanceId).Select(x => x.DistanceMiles).FirstOrDefault();
                tempFour.Start = StopThree;
                tempFour.Destination = Destination;
                tempFour.Distance = threeToDestinationDistance;
                Distances.Add(tempFour);
            }

            else if (StopTwo != null)
            {
                //calculate route for start>stop1>stop2>>end
                int startToOneDistanceId = db.LocationDistances.Where(x => x.LocationOneId == startId && x.LocationTwoId == stopOneId).Select(x => x.DistanceId).FirstOrDefault();
                long startToOneDistance = db.Distances.Where(x => x.Id == startToOneDistanceId).Select(x => x.DistanceMiles).FirstOrDefault();
                tempOne.Start = Start;
                tempOne.Destination = StopOne;
                tempOne.Distance = startToOneDistance;
                Distances.Add(tempOne);

                int oneToTwoDistanceId = db.LocationDistances.Where(x => x.LocationOneId == stopOneId && x.LocationTwoId == stopTwoId).Select(x => x.DistanceId).FirstOrDefault();
                long oneToTwoDistance = db.Distances.Where(x => x.Id == oneToTwoDistanceId).Select(x => x.DistanceMiles).FirstOrDefault();
                tempTwo.Start = StopOne;
                tempTwo.Destination = StopTwo;
                tempTwo.Distance = oneToTwoDistance;
                Distances.Add(tempTwo);

                int twoToDestinationDistanceId = db.LocationDistances.Where(x => x.LocationOneId == stopTwoId && x.LocationTwoId == destinationId).Select(x => x.DistanceId).FirstOrDefault();
                long twoToDestinationDistance = db.Distances.Where(x => x.Id == twoToDestinationDistanceId).Select(x => x.DistanceMiles).FirstOrDefault();
                tempThree.Start = StopTwo;
                tempThree.Destination = Destination;
                tempThree.Distance = twoToDestinationDistance;
                Distances.Add(tempThree); ;
            }

            else if (StopOne != null)
            {
                //calculate route for start>stop1>end
                int startToOneDistanceId = db.LocationDistances.Where(x => x.LocationOneId == startId && x.LocationTwoId == stopOneId).Select(x => x.DistanceId).FirstOrDefault();
                long startToOneDistance = db.Distances.Where(x => x.Id == startToOneDistanceId).Select(x => x.DistanceMiles).FirstOrDefault();
                tempOne.Start = Start;
                tempOne.Destination = StopOne;
                tempOne.Distance = startToOneDistance;
                Distances.Add(tempOne);

                int oneToDestinationDistanceId = db.LocationDistances.Where(x => x.LocationOneId == stopOneId && x.LocationTwoId == destinationId).Select(x => x.DistanceId).FirstOrDefault();
                long oneToDestinationDistance = db.Distances.Where(x => x.Id == oneToDestinationDistanceId).Select(x => x.DistanceMiles).FirstOrDefault();
                tempTwo.Start = StopOne;
                tempTwo.Destination = Destination;
                tempTwo.Distance = oneToDestinationDistance;
                Distances.Add(tempTwo);
            }

            else
            {
                //calculate route for start>end
                int startToDestinationDistanceId = db.LocationDistances.Where(x => x.LocationOneId == startId && x.LocationTwoId == destinationId).Select(x => x.DistanceId).FirstOrDefault();
                long startToDestinationDistance = db.Distances.Where(x => x.Id == startToDestinationDistanceId).Select(x => x.DistanceMiles).FirstOrDefault();
                tempOne.Start = Start;
                tempOne.Destination = Destination;
                tempOne.Distance = startToDestinationDistance;
                Distances.Add(tempOne);
            }

            return Json(Distances);
        }

        [HttpPost]
        public JsonResult GetNewLocations(string Location)
        {
            List<string> LocationList = db.Locations.Where(x => x.LocationName != Location).Select(x => x.LocationName).ToList();

            return Json(LocationList);
        }

        [HttpPost]
        public JsonResult GetFilterData(string FilterOne, string FilterTwo, string FilterThree)
        {
            List<string> FilteredPlanets = new List<string>();

            if (FilterOne == null && FilterTwo == null)
            {
                FilteredPlanets = db.PlanetFilters.Where(String.Format("{0} == true", FilterThree)).Select(x => x.PlanetName).ToList();
            }
            else if (FilterOne == null && FilterThree == null)
            {
                FilteredPlanets = db.PlanetFilters.Where(String.Format("{0} == true", FilterTwo)).Select(x => x.PlanetName).ToList();
            }
            else if (FilterTwo == null && FilterThree == null)
            {
                FilteredPlanets = db.PlanetFilters.Where(String.Format("{0} == true", FilterOne)).Select(x => x.PlanetName).ToList();
            }
            else if (FilterOne == null)
            {
                FilteredPlanets = db.PlanetFilters.Where(String.Format("{0} == true", FilterTwo)).Where(String.Format("{0} == true", FilterThree)).Select(x => x.PlanetName).ToList();
            }
            else if (FilterTwo == null)
            {
                FilteredPlanets = db.PlanetFilters.Where(String.Format("{0} == true", FilterOne)).Where(String.Format("{0} == true", FilterThree)).Select(x => x.PlanetName).ToList();
            }
            else if (FilterThree == null)
            {
                FilteredPlanets = db.PlanetFilters.Where(String.Format("{0} == true", FilterOne)).Where(String.Format("{0} == true", FilterTwo)).Select(x => x.PlanetName).ToList();
            }
            else //No filters are null
            {
                FilteredPlanets = db.PlanetFilters.Where(String.Format("{0} == true", FilterOne)).Where(String.Format("{0} == true", FilterTwo)).Where(String.Format("{0} == true", FilterThree)).Select(x => x.PlanetName).ToList();
            }

            return Json(FilteredPlanets);
        }
    }
}