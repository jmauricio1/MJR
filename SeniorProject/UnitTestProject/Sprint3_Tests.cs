using Astronomical_Learning.Controllers;
using Astronomical_Learning.Models.Launches;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class Sprint3_Tests
    {
        //Matthew's Test
        [TestMethod]
        public void MHibner_Add1to1ShouldEqual2()
        {
            int x = 1;
            int y = x + 1;
            Assert.AreEqual(x + 1, y); 
        }

        //Rob's Tests
        [TestMethod]
        public void RLochbaum_Square100_IsEqual10000()
        {
            //Arrange
            int x = 100;
            int y;

            //Act
            y = x * x;

            //Assert
            Assert.AreEqual(y, 10000);
        }

        [TestMethod]
        public void RLochbaum_Square100_IsNotEqual100()
        {
            //Arrange
            int x = 100;
            int y;

            //Act
            y = x * x;

            //Assert
            Assert.AreNotEqual(y, 100);
        }

        [TestMethod]
        public void RLochbaum_Square100_AnswerExists()
        {
            //Arrange
            int x = 100;
            int y;

            //Act
            y = x * x;

            //Assert
            Assert.IsNotNull(y);
        }

        /*
         * Joshua Jacob Mauricio
         * About: Testing for multiple scenarios when acquiring data from the SpaceX API.
         *        Each test has a JArray object that acts as the data acquired from API.
         */
        [TestMethod]
        public void JMauricio_SpaceCompanies_TimelineHelper_WebcastExists_Test()
        {
            SpaceCompaniesController controller = new SpaceCompaniesController();

            JArray data = new JArray();

            data.Add(new JObject(
                new JProperty("timeline",
                    new JObject(
                        new JProperty("webcast_liftoff", 14)))));

            /*
            JObject current = new JObject(
                new JProperty("timeline", new JObject(
                    new JProperty("webcast_liftoff", 14))));
            */

            int? expectedOutput = 14;
            int? id = 0;

            int? testOutput = controller.TimelineHelper(ref data, id, "webcast_liftoff");
            Assert.AreEqual(expectedOutput, testOutput);
        }

        [TestMethod]
        public void JMauricio_SpaceCompanies_TimelineHelper_WebcastNotExists_Test()
        {
            SpaceCompaniesController controller = new SpaceCompaniesController();

            JArray data = new JArray();
            data.Add(new JObject(
                new JProperty("timeline",
                    new JObject(
                        new JProperty("webcast_liftoff", null)))));

            int? expectedOutput = null;
            int? id = 0;

            int? testOutput = controller.TimelineHelper(ref data, id, "webcast_liftoff");
            Assert.AreEqual(expectedOutput, testOutput);
        }

        [TestMethod]
        public void JMauricio_SpaceCompanies_GetRocketInformation_RocketIDExists_Test()
        {
            SpaceCompaniesController controller = new SpaceCompaniesController();
            JArray data = new JArray();
            data.Add(new JObject(
                new JProperty("rocket",
                    new JObject(
                        new JProperty("rocket_id", "falcon1")))));

            string expectedOutput = "falcon1";
            int? id = 0;

            RocketInformation temp = controller.GetRocketInformation(ref data, id);

            string testOutput = temp.rocketID;
            Assert.AreEqual(expectedOutput, testOutput);
        }

        [TestMethod]
        public void JMauricio_SpaceCompanies_GetRocketInformation_RocketIDNotExists_Test()
        {
            SpaceCompaniesController controller = new SpaceCompaniesController();
            JArray data = new JArray();
            data.Add(new JObject(
                new JProperty("rocket",
                    new JObject(
                        new JProperty("rocket_id", null)))));

            string expectedOutput = null;
            int? id = 0;

            RocketInformation temp = controller.GetRocketInformation(ref data, id);

            string testOutput = temp.rocketID;
            Assert.AreEqual(expectedOutput, testOutput);
        }

        [TestMethod]
        public void JMauricio_SpaceCompanies_GetFirstStageString_CoreSerialExists_Test()
        {
            SpaceCompaniesController controller = new SpaceCompaniesController();
            JArray data = new JArray();
            data.Add(new JObject(
                new JProperty("rocket",
                    new JObject(
                        new JProperty("first_stage", 
                            new JObject(
                                new JProperty("cores",
                                    new JArray(
                                        new JObject(
                                            new JProperty("core_serial", "Merlin1A"))))))))));

            string expectedOutput = "Merlin1A";
            int? id = 0;

            string testOutput = controller.GetFirstStageString(ref data, id, "core_serial");
            Assert.AreEqual(expectedOutput, testOutput);
        }

        [TestMethod]
        public void JMauricio_SpaceCompanies_GetFirstStageString_CoreSerialNotExists_Test()
        {
            SpaceCompaniesController controller = new SpaceCompaniesController();
            JArray data = new JArray();
            data.Add(new JObject(
                new JProperty("rocket",
                    new JObject(
                        new JProperty("first_stage",
                            new JObject(
                                new JProperty("cores",
                                    new JArray(
                                        new JObject(
                                            new JProperty("core_serial", null))))))))));

            string expectedOutput = "-";
            int? id = 0;

            string testOutput = controller.GetFirstStageString(ref data, id, "core_serial");
            Assert.AreEqual(expectedOutput, testOutput);
        }

        [TestMethod]
        public void JMauricio_SpaceCompanies_GetOrbitStringValue_GeocentricExists_Test()
        {
            SpaceCompaniesController controller = new SpaceCompaniesController();
            JArray data = new JArray();
            data.Add(new JObject(
                new JProperty("rocket",
                    new JObject(
                        new JProperty("second_stage",
                            new JObject(
                                new JProperty("payloads",
                                    new JArray(
                                        new JObject(
                                            new JProperty("orbit_params",
                                                new JObject(
                                                    new JProperty("reference_system", "geocentric"))))))))))));

            string expectedOutput = "geocentric";
            int? id = 0;
            int payloadIndex = 0;

            string testOutput = controller.GetOrbitStringValue(ref data, id, payloadIndex, "reference_system");
            Assert.AreEqual(expectedOutput, testOutput);
        }

        [TestMethod]
        public void JMauricio_SpaceCompanies_GetOrbitStringValue_GeocentricNotExists_Test()
        {
            SpaceCompaniesController controller = new SpaceCompaniesController();
            JArray data = new JArray();
            data.Add(new JObject(
                new JProperty("rocket",
                    new JObject(
                        new JProperty("second_stage",
                            new JObject(
                                new JProperty("payloads",
                                    new JArray(
                                        new JObject(
                                            new JProperty("orbit_params",
                                                new JObject(
                                                    new JProperty("reference_system", null))))))))))));

            string expectedOutput = "-";
            int? id = 0;
            int payloadIndex = 0;

            string testOutput = controller.GetOrbitStringValue(ref data, id, payloadIndex, "reference_system");
            Assert.AreEqual(expectedOutput, testOutput);
        }

        [TestMethod]
        public void JMauricio_SpaceCompanies_GetLinkString_WikipediaExists_Test()
        {
            SpaceCompaniesController controller = new SpaceCompaniesController();
            JArray data = new JArray();
            data.Add(new JObject(
                new JProperty("links",
                    new JObject(
                        new JProperty("wikipedia", "https://en.wikipedia.org/wiki/Falcon_9_flight_20")))));

            string expectedOutput = "https://en.wikipedia.org/wiki/Falcon_9_flight_20";
            int? id = 0;

            string testOutput = controller.GetLinkString(ref data, id, "wikipedia");
            Assert.AreEqual(expectedOutput, testOutput);
        }

        [TestMethod]
        public void JMauricio_SpaceCompanies_GetLinkString_WikipediaNotExists_Test()
        {
            SpaceCompaniesController controller = new SpaceCompaniesController();
            JArray data = new JArray();
            data.Add(new JObject(
                new JProperty("links",
                    new JObject(
                        new JProperty("wikipedia", null)))));

            string expectedOutput = "#";
            int? id = 0;

            string testOutput = controller.GetLinkString(ref data, id, "wikipedia");
            Assert.AreEqual(expectedOutput, testOutput);
        }
    }
}
