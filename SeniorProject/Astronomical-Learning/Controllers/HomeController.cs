using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Astronomical_Learning.DAL;
using Astronomical_Learning.Models;
using Newtonsoft.Json.Linq;
//using Astronomical_Learning.TempDAL;

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
            int chosenSpot = (dayOfYear % (factCount - 1)) + 1;
            var selectedFact = db.FactOfTheDays.Find(chosenSpot);

            if(selectedFact.LastDisplayed.Date != DateTime.Now.Date)
            {
                selectedFact.DisplayCount += 1;
                selectedFact.LastDisplayed = DateTime.Now;
                db.SaveChanges();
            }

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

            //try to get the information and if it fails return a default json string with an error picture and message
            try
            {


                using (WebResponse response = request.GetResponse())
                {
                    Stream stream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(stream);
                    jsonString = reader.ReadToEnd();
                    reader.Close();
                    stream.Close();
                }
            }
            catch
            {
                jsonString = "{'copyright':'Astronomical','date':'2020 - 30 - 04','explanation':'There is currently an error with the system. Check again later ','hdurl':'https://www.publicdomainpictures.net/pictures/40000/velka/question-mark.jpg','media_type':'image','service_version':'v1','title':'Sorry there was an error with the picture','url':'https://www.publicdomainpictures.net/pictures/40000/velka/question-mark.jpg'}";
            }

            

            return jsonString;
        }
        public ActionResult Credits()
        {
            return View();
        }


        public ActionResult CustomError (string errorName, string errorMessage)
        {

            ViewBag.Name = errorName;
            ViewBag.Message = errorMessage;


            return View();
        }
#region Filling list of regions
        public List<List<string>> GetListOfRegions()
        {
            List<List<string>> temp = new List<List<string>>();
            /*
            temp.Add(new List<string> { "Melbourne", "Sydney" });
            temp.Add(new List<string> { "Beijing", "Shanghai" });
            temp.Add(new List<string> { "Apia", "Pago Pago" });*/
            
            //Afghanistan
            temp.Add(new List<string> { "Badakhshan"," Badghis"," Baghlan"," Balkh"," Bamyan"," Daykundi"," Farah"," Faryab"," Ghazni"," Ghor"," Helmand"," Herat"," Jowzjan"," Kabul"," Kandahar"," Kapisa"," Khost"," Kunar"," Kunduz"," Laghman"," Logar"," Nangarhar"," Nimroz"," Nuristan"," Paktika"," Paktiya"," Panjshir"," Parwan"," Samangan"," Sar - e Pul"," Takhar"," Uruzgan"," Wardak"," Zabul" });
            //Albania
            temp.Add(new List<string> { "Berat"," Diber"," Durres"," Elbasan"," Fier"," Gjirokaster"," Korce"," Kukes"," Lezhe"," Shkoder"," Tirane"," Vlore" });
            //Algeria
            temp.Add(new List<string> { "Adrar"," Ain Defla"," Ain Temouchent"," Alger"," Annaba"," Batna"," Bechar"," Bejaia"," Biskra"," Blida"," Bordj Bou Arreridj"," Bouira"," Boumerdes"," Chlef"," Constantine"," Djelfa"," El Bayadh"," El Oued"," El Tarf"," Ghardaia"," Guelma"," Illizi"," Jijel"," Khenchela"," Laghouat"," Mascara"," Medea"," Mila"," Mostaganem"," M'Sila"," Naama"," Oran"," Ouargla"," Oum el Bouaghi"," Relizane"," Saida"," Setif"," Sidi Bel Abbes"," Skikda"," Souk Ahras"," Tamanrasset"," Tebessa"," Tiaret"," Tindouf"," Tipaza"," Tissemsilt"," Tizi Ouzou"," Tlemcen" });
            //Andorra
            temp.Add(new List<string> { "Andorra la Vella"," Canillo"," Encamp"," Escaldes-Engordany"," La Massana"," Ordino"," Sant Julia de Loria" });
            //Angola
            temp.Add(new List<string> { "Bengo"," Benguela"," Bie"," Cabinda"," Cunene"," Huambo"," Huila"," Kwando Kubango"," Kwanza Norte"," Kwanza Sul"," Luanda"," Lunda Norte"," Lunda Sul"," Malanje"," Moxico"," Namibe"," Uige"," Zaire" });
            //Antigua and Barbuda
            temp.Add(new List<string> { "Barbuda*"," Redonda*"," Saint George"," Saint John"," Saint Mary"," Saint Paul"," Saint Peter"," Saint Philip" });
            //Argentina
            temp.Add(new List<string> { "Buenos Aires"," Catamarca"," Chaco"," Chubut"," Ciudad Autonoma de Buenos Aires*"," Cordoba"," Corrientes"," Entre Rios"," Formosa"," Jujuy"," La Pampa"," La Rioja"," Mendoza"," Misiones"," Neuquen"," Rio Negro"," Salta"," San Juan"," San Luis"," Santa Cruz"," Santa Fe"," Santiago del Estero"," Tierra del Fuego - Antartida e Islas del Atlantico Sur (Tierra del Fuego - Antarctica and the South Atlantic Islands)"," Tucuman" });
            //Armenia
            temp.Add(new List<string> { "Aragatsotn"," Ararat"," Armavir"," Geghark'unik'"," Kotayk'"," Lorri"," Shirak"," Syunik'"," Tavush"," Vayots' Dzor"," Yerevan" });
            //Australia
            temp.Add(new List<string> { "Australian Capital Territory*"," New South Wales"," Northern Territory*"," Queensland"," South Australia"," Tasmania"," Victoria"," Western Australia" });
            //Austria
            temp.Add(new List<string> { "Burgenland"," Kaernten (Carinthia)"," Niederoesterreich (Lower Austria)"," Oberoesterreich (Upper Austria)"," Salzburg"," Steiermark (Styria)"," Tirol (Tyrol)"," Vorarlberg"," Wien (Vienna)" });
            //Azerbijan
            temp.Add(new List<string> { "Abseron"," Agcabadi"," Agdam"," Agdas"," Agstafa"," Agsu"," Astara"," Babak"," Balakan"," Barda"," Beylaqan"," Bilasuvar"," Cabrayil"," Calilabad"," Culfa"," Daskasan"," Fuzuli"," Gadabay"," Goranboy"," Goycay"," Goygol"," Haciqabul"," Imisli"," Ismayilli"," Kalbacar"," Kangarli"," Kurdamir"," Lacin"," Lankaran"," Lerik"," Masalli"," Neftcala"," Oguz"," Ordubad"," Qabala"," Qax"," Qazax"," Qobustan"," Quba"," Qubadli"," Qusar"," Saatli"," Sabirabad"," Sabran"," Sadarak"," Sahbuz"," Saki"," Salyan"," Samaxi"," Samkir"," Samux"," Sarur"," Siyazan"," Susa"," Tartar"," Tovuz"," Ucar"," Xacmaz"," Xizi"," Xocali"," Xocavand"," Yardimli"," Yevlax"," Zangilan"," Zaqatala"," Zardab" });


            //Bahamas
            temp.Add(new List<string> { "Acklins Islands"," Berry Islands"," Bimini"," Black Point"," Cat Island"," Central Abaco"," Central Andros"," Central Eleuthera"," City of Freeport"," Crooked Island and Long Cay"," East Grand Bahama"," Exuma"," Grand Cay"," Harbour Island"," Hope Town"," Inagua"," Long Island"," Mangrove Cay"," Mayaguana"," Moore's Island"," North Abaco"," North Andros"," North Eleuthera"," Ragged Island"," Rum Cay"," San Salvador"," South Abaco"," South Andros"," South Eleuthera"," Spanish Wells"," West Grand Bahama"});
            //Bahrain
            temp.Add(new List<string> { "Asimah (Capital)"," Janubiyah (Southern)"," Muharraq"," Shamaliyah (Northern)" });
            //Bangladesh
            temp.Add(new List<string> { "Barisal"," Chittagong"," Dhaka"," Khulna"," Mymensingh"," Rajshahi"," Rangpur"," Sylhet" });
            //Barbados
            temp.Add(new List<string> { "Bridgetown*"," Christ Church"," Saint Andrew"," Saint George"," Saint James"," Saint John"," Saint Joseph"," Saint Lucy"," Saint Michael"," Saint Peter"," Saint Philip"," Saint Thomas" });
            //Belarus                   ""
            temp.Add(new List<string> { "Brest"," Homyel' (Gomel')"," Horad Minsk* (Minsk City)"," Hrodna (Grodno)"," Mahilyow (Mogilev)"," Minsk"," Vitsyebsk (Vitebsk)" });
            //Belgium                   ""
            temp.Add(new List<string> { "Brussels Capitol Region", "Flemish Region", "Walloon Region"});
            //Belize                    ""
            temp.Add(new List<string> { "Belize"," Cayo"," Corozal"," Orange Walk"," Stann Creek"," Toledo" });
            //Benin                     ""
            temp.Add(new List<string> { "Alibori"," Atacora"," Atlantique"," Borgou"," Collines"," Couffo"," Donga"," Littoral"," Mono"," Oueme"," Plateau"," Zou" });
            //Bermuda                   ""
            temp.Add(new List<string> { "Devonshire"," Hamilton"," Hamilton*"," Paget"," Pembroke"," Saint George*"," Saint George's"," Sandys"," Smith's"," Southampton"," Warwick" });
            //Bhutan                    ""
            temp.Add(new List<string> { "Bumthang"," Chhukha"," Dagana"," Gasa"," Haa"," Lhuentse"," Mongar"," Paro"," Pemagatshel"," Punakha"," Samdrup Jongkhar"," Samtse"," Sarpang"," Thimphu"," Trashigang"," Trashi Yangtse"," Trongsa"," Tsirang"," Wangdue Phodrang"," Zhemgang" });
            //Bolivia                   ""
            temp.Add(new List<string> { "Beni"," Chuquisaca"," Cochabamba"," La Paz"," Oruro"," Pando"," Potosi"," Santa Cruz"," Tarija" });
            //Bosnia and Herzegovina    ""
            temp.Add(new List<string> { "Brcko District (Brcko Distrikt)"," Federation of Bosnia and Herzegovina (Federacija Bosne i Hercegovine)"," Republika Srpska" });
            //Botswana                  ""
            temp.Add(new List<string> { "Central"," Chobe"," Francistown*"," Gaborone*"," Ghanzi"," Jwaneng*"," Kgalagadi"," Kgatleng"," Kweneng"," Lobatse*"," North East"," North West"," Selebi-Phikwe*"," South East"," Southern"," Sowa Town*" });
            //Brazil                    ""
            temp.Add(new List<string> { "Acre"," Alagoas"," Amapa"," Amazonas"," Bahia"," Ceara"," Distrito Federal*"," Espirito Santo"," Goias"," Maranhao"," Mato Grosso"," Mato Grosso do Sul"," Minas Gerais"," Para"," Paraiba"," Parana"," Pernambuco"," Piaui"," Rio de Janeiro"," Rio Grande do Norte"," Rio Grande do Sul"," Rondonia"," Roraima"," Santa Catarina"," Sao Paulo"," Sergipe"," Tocantins" });
            //Brunei                    ""
            temp.Add(new List<string> { "Belait"," Brunei dan Muara"," Temburong"," Tutong" });
            //Bulgaria                  ""
            temp.Add(new List<string> { "Blagoevgrad"," Burgas"," Dobrich"," Gabrovo"," Haskovo"," Kardzhali"," Kyustendil"," Lovech"," Montana"," Pazardzhik"," Pernik"," Pleven"," Plovdiv"," Razgrad"," Ruse"," Shumen"," Silistra"," Sliven"," Smolyan"," Sofia"," Sofia-Grad (Sofia City)"," Stara Zagora"," Targovishte"," Varna"," Veliko Tarnovo"," Vidin"," Vratsa"," Yambol" });
            //Burkina Faso              ""
            temp.Add(new List<string> { "Boucle du Mouhoun"," Cascades"," Centre"," Centre-Est"," Centre-Nord"," Centre-Ouest"," Centre-Sud"," Est"," Hauts-Bassins"," Nord"," Plateau-Central"," Sahel"," Sud-Ouest" });
            //Burma                     ""
            temp.Add(new List<string> { "Ayeyarwady (Irrawaddy)"," Bago"," Magway"," Mandalay"," Sagaing"," Tanintharyi"," Yangon (Rangoon)","Chin"," Kachin"," Kayah"," Kayin"," Mon"," Rakhine"," Shan","Nay Pyi Taw" });
            //Burundi                   ""
            temp.Add(new List<string> { "Bubanza"," Bujumbura Mairie"," Bujumbura Rural"," Bururi"," Cankuzo"," Cibitoke"," Gitega"," Karuzi"," Kayanza"," Kirundo"," Makamba"," Muramvya"," Muyinga"," Mwaro"," Ngozi"," Rumonge"," Rutana"," Ruyigi" });

            //Cabo Verde
            temp.Add(new List<string> { "Boa Vista"," Brava"," Maio"," Mosteiros"," Paul"," Porto Novo"," Praia"," Ribeira Brava"," Ribeira Grande"," Ribeira Grande de Santiago"," Sal"," Santa Catarina"," Santa Catarina do Fogo"," Santa Cruz"," Sao Domingos"," Sao Filipe"," Sao Lourenco dos Orgaos"," Sao Miguel"," Sao Salvador do Mundo"," Sao Vicente"," Tarrafal"," Tarrafal de Sao Nicolau" });
            //Cambodia
            temp.Add(new List<string> { "Banteay Meanchey"," Battambang"," Kampong Cham"," Kampong Chhnang"," Kampong Speu"," Kampong Thom"," Kampot"," Kandal"," Kep"," Koh Kong"," Kratie"," Mondolkiri"," Oddar Meanchey"," Pailin"," Phnom Penh (Phnum Penh)"," Preah Sihanouk"," Preah Vihear"," Prey Veng"," Pursat"," Ratanakiri"," Siem Reap"," Stung Treng"," Svay Rieng"," Takeo"," Tbong Khmum" });
            //Cameroon
            temp.Add(new List<string> { "Adamaoua"," Centre"," East (Est)"," Far North (Extreme-Nord)"," Littoral"," North (Nord)"," North-West (Nord-Ouest)"," West (Ouest)"," South (Sud)"," South-West (Sud-Ouest)" });
            //Canada
            temp.Add(new List<string> { "Alberta"," British Columbia"," Manitoba"," New Brunswick"," Newfoundland and Labrador"," Northwest Territories*"," Nova Scotia"," Nunavut*"," Ontario"," Prince Edward Island"," Quebec"," Saskatchewan"," Yukon*" });
            //Cayman Islands
            temp.Add(new List<string> { "Bodden Town"," Cayman Brac and Little Cayman"," East End"," George Town"," North Side"," West Bay" });
            //Central African Republic
            temp.Add(new List<string> { "Bamingui-Bangoran"," Bangui**"," Basse-Kotto"," Haute-Kotto"," Haut-Mbomou"," Kemo"," Lobaye"," Mambere-Kadei"," Mbomou"," Nana-Grebizi*"," Nana-Mambere"," Ombella-Mpoko"," Ouaka"," Ouham"," Ouham-Pende"," Sangha-Mbaere*"," Vakaga" });
            //Chad
            temp.Add(new List<string> { "Barh el Gazel"," Batha"," Borkou"," Chari-Baguirmi"," Ennedi-Est"," Ennedi-Ouest"," Guera"," Hadjer-Lamis"," Kanem"," Lac"," Logone Occidental"," Logone Oriental"," Mandoul"," Mayo-Kebbi Est"," Mayo-Kebbi Ouest"," Moyen-Chari"," Ouaddai"," Salamat"," Sila"," Tandjile"," Tibesti"," Ville de N'Djamena"," Wadi Fira" });
            //Chile
            temp.Add(new List<string> { "Aysen"," Antofagasta"," Araucania"," Arica y Parinacota"," Atacama"," Biobio"," Coquimbo"," Libertador General Bernardo O'Higgins"," Los Lagos"," Los Rios"," Magallanes y de la Antartica Chilena (Magallanes and Chilean Antarctica)"," Maule"," Nuble"," Region Metropolitana (Santiago)"," Tarapaca"," Valparaiso" });
            //China
            temp.Add(new List<string> { "Anhui"," Beijing"," Chongqing"," Fujian"," Gansu"," Guangdong"," Guangxi"," Guizhou"," Hainan"," Hebei"," Heilongjiang"," Henan"," Hubei"," Hunan"," Jiangsu"," Jiangxi"," Jilin"," Liaoning"," Nei Mongol"," Ningxia"," Qinghai"," Shaanxi"," Shandong"," Shanghai"," Shanxi"," Sichuan"," Tianjian"," Xinjiang Uygur"," Xizang"," Yunnan"," Zhejiang" });
            //Colombia
            temp.Add(new List<string> { "Amazonas"," Antioquia"," Arauca"," Atlantico"," Bogota*"," Bolivar"," Boyaca"," Caldas"," Caqueta"," Casanare"," Cauca"," Cesar"," Choco"," Cordoba"," Cundinamarca"," Guainia"," Guaviare"," Huila"," La Guajira"," Magdalena"," Meta"," Narino"," Norte de Santander"," Putumayo"," Quindio"," Risaralda"," Archipielago de San Andres"," Providencia y Santa Catalina (colloquially San Andres y Providencia)"," Santander"," Sucre"," Tolima"," Valle del Cauca"," Vaupes"," Vichada" });
            //Comoros
            temp.Add(new List<string> { "Anjouan (Ndzuwani)"," Grande Comore (N'gazidja)"," Moheli (Mwali)" });
            //Costa Rica
            temp.Add(new List<string> { "Alajuela"," Cartago"," Guanacaste"," Heredia"," Limon"," Puntarenas"," San Jose" });
            //Cote d'Ivoire
            temp.Add(new List<string> { "Abidjan*"," Bas-Sassandra"," Comoe"," Denguele"," Goh-Djiboua"," Lacs"," Lagunes"," Montagnes"," Sassandra-Marahoue"," Savanes"," Vallee du Bandama"," Woroba"," Yamoussoukro*"," Zanzan" });
            //Croatia
            temp.Add(new List<string> { "Bjelovarsko-Bilogorska (Bjelovar-Bilogora)"," Brodsko-Posavska (Brod-Posavina)"," Dubrovacko-Neretvanska (Dubrovnik-Neretva)"," Istarska (Istria)"," Karlovacka (Karlovac)"," Koprivnicko-Krizevacka (Koprivnica-Krizevci)"," Krapinsko-Zagorska (Krapina-Zagorje)"," Licko-Senjska (Lika-Senj)"," Medimurska (Medimurje)"," Osjecko-Baranjska (Osijek-Baranja)"," Pozesko-Slavonska (Pozega-Slavonia)"," Primorsko-Goranska (Primorje-Gorski Kotar)"," Sibensko-Kninska (Sibenik-Knin)"," Sisacko-Moslavacka (Sisak-Moslavina)"," Splitsko-Dalmatinska (Split-Dalmatia)"," Varazdinska (Varazdin)"," Viroviticko-Podravska (Virovitica-Podravina)"," Vukovarsko-Srijemska (Vukovar-Syrmia)"," Zadarska (Zadar)"," Zagreb*"," Zagrebacka (Zagreb county)" });
            //Cuba
            temp.Add(new List<string> { "Artemisa"," Camaguey"," Ciego de Avila"," Cienfuegos"," Granma"," Guantanamo"," Holguin"," Isla de la Juventud*"," La Habana"," Las Tunas"," Matanzas"," Mayabeque"," Pinar del Rio"," Sancti Spiritus"," Santiago de Cuba"," Villa Clara" });
            //Cyprus
            temp.Add(new List<string> { "Ammochostos", "Keryneia", "Larnaka", " Lefkosia", "Lemesos", "Pafos" });
            //Czechia
            temp.Add(new List<string> { "Jihocesky (South Bohemia)"," Jihomoravsky (South Moravia)"," Karlovarsky (Karlovy Vary)"," Kralovehradecky (Hradec Kralove)"," Liberecky (Liberec)"," Moravskoslezsky (Moravia-Silesia)"," Olomoucky (Olomouc)"," Pardubicky (Pardubice)"," Plzensky (Pilsen)"," Praha (Prague)*"," Stredocesky (Central Bohemia)"," Ustecky (Usti)"," Vysocina (Highlands)"," Zlinsky (Zlin)" });

            //Democratic Republic of Congo
            temp.Add(new List<string> { "Bas-Uele (Lower Uele)"," Equateur"," Haut-Katanga (Upper Katanga)"," Haut-Lomami (Upper Lomami)"," Haut-Uele (Upper Uele)"," Ituri"," Kasai"," Kasai-Central"," Kasai-Oriental (East Kasai)"," Kinshasa"," Kongo Central"," Kwango"," Kwilu"," Lomami"," Lualaba"," Mai-Ndombe"," Maniema"," Mongala"," Nord-Kivu (North Kivu)"," Nord-Ubangi (North Ubangi)"," Sankuru"," Sud-Kivu (South Kivu)"," Sud-Ubangi (South Ubangi)"," Tanganyika"," Tshopo"," Tshuapa"});
            //Denmark
            temp.Add(new List<string> { "Hovedstaden (Capital)"," Midtjylland (Central Jutland)"," Nordjylland (North Jutland)"," Sjaelland (Zealand)"," Syddanmark (Southern Denmark)" });
            //Djibouti
            temp.Add(new List<string> { "Ali Sabieh"," Arta"," Dikhil"," Djibouti"," Obock"," Tadjourah" });
            //Dominica
            temp.Add(new List<string> { "Saint Andrew"," Saint David"," Saint George"," Saint John"," Saint Joseph"," Saint Luke"," Saint Mark"," Saint Patrick"," Saint Paul"," Saint Peter" });
            //Dominican Republic
            temp.Add(new List<string> { "Cibao Nordeste"," Cibao Noroeste"," Cibao Norte"," Cibao Sur"," El Valle"," Enriquillo"," Higuamo"," Ozama"," Valdesia"," Yuma" });

            //Ecuador
            temp.Add(new List<string> { "Azuay"," Bolivar"," Canar"," Carchi"," Chimborazo"," Cotopaxi"," El Oro"," Esmeraldas"," Galapagos"," Guayas"," Imbabura"," Loja"," Los Rios"," Manabi"," Morona-Santiago"," Napo"," Orellana"," Pastaza"," Pichincha"," Santa Elena"," Santo Domingo de los Tsachilas"," Sucumbios"," Tungurahua"," Zamora-Chinchipe" });
            //Egypt
            temp.Add(new List<string> { "Ad Daqahliyah"," Al Bahr al Ahmar (Red Sea)"," Al Buhayrah"," Al Fayyum"," Al Gharbiyah"," Al Iskandariyah (Alexandria)"," Al Isma'iliyah (Ismailia)"," Al Jizah (Giza)"," Al Minufiyah"," Al Minya"," Al Qahirah (Cairo)"," Al Qalyubiyah"," Al Uqsur (Luxor)"," Al Wadi al Jadid (New Valley)"," As Suways (Suez)"," Ash Sharqiyah"," Aswan"," Asyut"," Bani Suwayf"," Bur Sa'id (Port Said)"," Dumyat (Damietta)"," Janub Sina' (South Sinai)"," Kafr ash Shaykh"," Matruh"," Qina"," Shamal Sina' (North Sinai)"," Suhaj" });
            //El Salvador
            temp.Add(new List<string> { "Ahuachapan"," Cabanas"," Chalatenango"," Cuscatlan"," La Libertad"," La Paz"," La Union"," Morazan"," San Miguel"," San Salvador"," San Vicente"," Santa Ana"," Sonsonate"," Usulutan" });
            //Equatorial Guinea
            temp.Add(new List<string> { "Annobon"," Bioko Norte"," Bioko Sur"," Centro Sur"," Kie-Ntem"," Litoral"," Wele-Nzas" });
            //Eritrea
            temp.Add(new List<string> { "Anseba"," Debub (South)"," Debubawi K'eyih Bahri (Southern Red Sea)"," Gash Barka"," Ma'akel (Central)"," Semenawi K'eyih Bahri (Northern Red Sea)" });
            //Estonia
            temp.Add(new List<string> { "Harjumaa (Tallinn)"," Hiiumaa (Kardla)"," Ida-Virumaa (Johvi)"," Jarvamaa (Paide)"," Jogevamaa (Jogeva)"," Laanemaa (Haapsalu)"," Laane-Virumaa (Rakvere)"," Parnumaa (Parnu)"," Polvamaa (Polva)"," Raplamaa (Rapla)"," Saaremaa (Kuressaare)"," Tartumaa (Tartu)"," Valgamaa (Valga)"," Viljandimaa (Viljandi)"," Vorumaa (Voru)" });
            //Eswatini
            temp.Add(new List<string> { "Hhohho"," Lubombo"," Manzini"," Shiselweni" });
            //Ethiopia
            temp.Add(new List<string> { "Adis Abeba* (Addis Ababa)"," Afar"," Amara (Amhara)"," Binshangul Gumuz"," Dire Dawa*"," Gambela Hizboch (Gambela Peoples)"," Hareri Hizb (Harari People)"," Oromiya (Oromia)"," Sumale (Somali)"," Tigray"," Ye Debub Biheroch Bihereseboch na Hizboch (Southern Nations"," Nationalities and Peoples)" });

            //Faroe Islands
            temp.Add(new List<string> { "Eidhis"," Eystur"," Famjins"," Fuglafjardhar"," Fugloyar"," Hovs"," Husavikar"," Hvalbiar"," Hvannasunds"," Klaksvikar"," Kunoyar"," Kvivik"," Nes"," Porkeris"," Runavikar"," Sands"," Sjovar"," Skalavikar"," Skopunar"," Skuvoyar"," Sorvags"," Sumbiar"," Sunda"," Torshavnar"," Tvoroyrar"," Vaga"," Vags"," Vestmanna"," Vidhareidhis" });
            //Fiji
            temp.Add(new List<string> { "Ba"," Bua"," Cakaudrove"," Kadavu"," Lau"," Lomaiviti"," Macuata"," Nadroga and Navosa"," Naitasiri"," Namosi"," Ra"," Rewa"," Rotuma*"," Serua"," Tailevu" });
            //Finland
            temp.Add(new List<string> { "Etela-Karjala", "Etela-Pohjanmaa", "Etela-Savo", "Kanta-Hame", "Kainuu", "Keski-Pohjanmaa", "Keski-Suomi", "Kymenlaakso", "Lappi", "Paijat-Hame", "Pirkanmaa", "Pohjanmaa", "Pohjois-Karjala", "Pohjois-Pohjanmaa", "Pohjois-Savo", "Satakunta", "Uusimaa", "Varsinais-Suomi"});
            //France
            temp.Add(new List<string> { "Auvergne-Rhone-Alpes"," Bourgogne-Franche-Comte (Burgundy-Free County)"," Bretagne (Brittany)"," Centre-Val de Loire (Center-Loire Valley)"," Corse (Corsica)"," Grand Est (Grand East)"," Guadeloupe"," Guyane (French Guiana)"," Hauts-de-France (Upper France)"," Ile-de-France"," Martinique"," Mayotte"," Normandie (Normandy)"," Nouvelle-Aquitaine (New Aquitaine)"," Occitanie (Occitania)"," Pays de la Loire (Lands of the Loire)"," Provence-Alpes-Cote d'Azur"," Reunion" });
            //French Polynesia
            temp.Add(new List<string> { "Iles Australes (Austral Islands)"," Iles du Vent (Windward Islands)"," Iles Marquises (Marquesas Islands)"," Iles Sous-le-Vent (Leeward Islands)"," Iles Tuamotu-Gambier" });

            //Gabon
            temp.Add(new List<string> { "Estuaire"," Haut-Ogooue"," Moyen-Ogooue"," Ngounie"," Nyanga"," Ogooue-Ivindo"," Ogooue-Lolo"," Ogooue-Maritime"," Woleu-Ntem" });
            //Gambia
            temp.Add(new List<string> { "Banjul*"," Central River"," Kanifing**"," Lower River"," North Bank"," Upper River"," West Coast" });
            //Georgia
            temp.Add(new List<string> { "Guria"," Imereti"," Kakheti"," Kvemo Kartli"," Mtskheta Mtianeti"," Racha-Lechkhumi and Kvemo Svaneti"," Samegrelo and Zemo Svaneti"," Samtskhe-Javakheti"," Shida Kartli" });
            //Germany
            temp.Add(new List<string> { "Baden-Wuerttemberg"," Bayern (Bavaria)"," Berlin"," Brandenburg"," Bremen"," Hamburg"," Hessen (Hesse)"," Mecklenburg-Vorpommern (Mecklenburg-Western Pomerania)"," Niedersachsen (Lower Saxony)"," Nordrhein-Westfalen (North Rhine-Westphalia)"," Rheinland-Pfalz (Rhineland-Palatinate)"," Saarland"," Sachsen (Saxony)"," Sachsen-Anhalt (Saxony-Anhalt)"," Schleswig-Holstein"," Thueringen (Thuringia)" });
            //Ghana
            temp.Add(new List<string> { "Ahafo"," Ashanti"," Bono"," Bono East"," Central"," Eastern"," Greater Accra"," North East"," Northern"," Oti"," Savannah"," Upper East"," Upper West"," Volta"," Western"," Western North" });
            //Greece
            temp.Add(new List<string> { "Agion Oros* (Mount Athos)"," Anatoliki Makedonia kai Thraki (East Macedonia and Thrace)"," Attiki (Attica)"," Dytiki Ellada (West Greece)"," Dytiki Makedonia (West Macedonia)"," Ionia Nisia (Ionian Islands)"," Ipeiros (Epirus)"," Kentriki Makedonia (Central Macedonia)"," Kriti (Crete)"," Notio Aigaio (South Aegean)"," Peloponnisos (Peloponnese)"," Sterea Ellada (Central Greece)"," Thessalia (Thessaly)"," Voreio Aigaio (North Aegean)" });
            //Greenland
            temp.Add(new List<string> { "Avannaata"," Kujalleq"," Qeqertalik"," Qeqqata"," Sermersooq" });
            //Grenada
            temp.Add(new List<string> { "Carriacou and Petite Martinique*"," Saint Andrew"," Saint David"," Saint George"," Saint John"," Saint Mark"," Saint Patrick" });
            //Guatemala
            temp.Add(new List<string> { "Alta Verapaz"," Baja Verapaz"," Chimaltenango"," Chiquimula"," El Progreso"," Escuintla"," Guatemala"," Huehuetenango"," Izabal"," Jalapa"," Jutiapa"," Peten"," Quetzaltenango"," Quiche"," Retalhuleu"," Sacatepequez"," San Marcos"," Santa Rosa"," Solola"," Suchitepequez"," Totonicapan"," Zacapa" });
            //Guinea
            temp.Add(new List<string> { "Boke"," Conakry*"," Faranah"," Kankan"," Kindia"," Labe"," Mamou"," N'Zerekore" });
            //Guinea Bissau
            temp.Add(new List<string> { "Bafata"," Biombo"," Bissau"," Bolama/Bijagos"," Cacheu"," Gabu"," Oio"," Quinara"," Tombali" });
            //Guyana
            temp.Add(new List<string> { "Barima-Waini"," Cuyuni-Mazaruni"," Demerara-Mahaica"," East Berbice-Corentyne"," Essequibo Islands-West Demerara"," Mahaica-Berbice"," Pomeroon-Supenaam"," Potaro-Siparuni"," Upper Demerara-Berbice"," Upper Takutu-Upper Essequibo" });

            //Haiti
            temp.Add(new List<string> { "Artibonite"," Centre"," Grand'Anse"," Nippes"," Nord"," Nord-Est"," Nord-Ouest"," Ouest"," Sud"," Sud-Est" });
            //Holy See
            temp.Add(new List<string> { ""});
            //Honduras
            temp.Add(new List<string> { "Atlantida"," Choluteca"," Colon"," Comayagua"," Copan"," Cortes"," El Paraiso"," Francisco Morazan"," Gracias a Dios"," Intibuca"," Islas de la Bahia"," La Paz"," Lempira"," Ocotepeque"," Olancho"," Santa Barbara"," Valle"," Yoro" });
            //Hungary
            temp.Add(new List<string> { "Bacs-Kiskun"," Baranya"," Bekes"," Borsod-Abauj-Zemplen", "Budapest"," Csongrad"," Fejer"," Gyor-Moson-Sopron"," Hajdu-Bihar"," Heves"," Jasz-Nagykun-Szolnok"," Komarom-Esztergom"," Nograd"," Pest"," Somogy"," Szabolcs-Szatmar-Bereg"," Tolna"," Vas"," Veszprem"," Zala" });

            //Iceland
            temp.Add(new List<string> { "Akrahreppur"," Akraneskaupstadhur"," Akureyrarkaupstadhur"," Arneshreppur"," Asahreppur"," Blaskogabyggdh"," Blonduosbaer"," Bolungarvikurkaupstadhur"," Borgarbyggdh"," Borgarfjardharhreppur"," Breidhdalshreppur"," Dalabyggdh"," Dalvikurbyggdh"," Djupavogshreppur"," Eyjafjardharsveit"," Eyja-og Miklaholtshreppur"," Fjallabyggdh"," Fjardhabyggdh"," Fljotsdalsheradh"," Fljotsdalshreppur"," Floahreppur"," Gardhabaer"," Grimsnes-og Grafningshreppur"," Grindavikurbaer"," Grundarfjardharbaer"," Grytubakkahreppur"," Hafnarfjardharkaupstadhur"," Helgafellssveit"," Horgarsveit"," Hrunamannahreppur"," Hunathing Vestra"," Hunavatnshreppur"," Hvalfjardharsveit"," Hveragerdhisbaer"," Isafjardharbaer"," Kaldrananeshreppur"," Kjosarhreppur"," Kopavogsbaer"," Langanesbyggdh"," Mosfellsbaer"," Myrdalshreppur"," Nordhurthing"," Rangarthing Eystra"," Rangarthing Ytra"," Reykholahreppur"," Reykjanesbaer"," Reykjavikurborg"," Sandgerdhisbaer"," Seltjarnarnesbaer"," Seydhisfjardharkaupstadhur"," Skaftarhreppur"," Skagabyggdh"," Skeidha-og Gnupverjahreppur"," Skorradalshreppur"," Skutustadhahreppur"," Snaefellsbaer"," Strandabyggdh"," Stykkisholmsbaer"," Sudhavikurhreppur"," Svalbardhshreppur"," Svalbardhsstrandarhreppur"," Sveitarfelagidh Arborg"," Sveitarfelagidh Gardhur"," Sveitarfelagidh Hornafjordhur"," Sveitarfelagidh Olfus"," Sveitarfelagidh Skagafjordhur"," Sveitarfelagidh Skagastrond"," Sveitarfelagidh Vogar"," Talknafjardharhreppur"," Thingeyjarsveit"," Tjorneshreppur"," Vestmannaeyjabaer"," Vesturbyggdh"," Vopnafjardharhreppur" });
            //India
            temp.Add(new List<string> { "Andaman and Nicobar Islands*"," Andhra Pradesh"," Arunachal Pradesh"," Assam"," Bihar"," Chandigarh*"," Chhattisgarh"," Dadra and Nagar Haveli and Daman and Diu*"," Delhi*"," Goa"," Gujarat"," Haryana"," Himachal Pradesh"," Jammu and Kashmir*"," Jharkhand"," Karnataka"," Kerala"," Ladakh*"," Lakshadweep*"," Madhya Pradesh"," Maharashtra"," Manipur"," Meghalaya"," Mizoram"," Nagaland"," Odisha"," Puducherry*"," Punjab"," Rajasthan"," Sikkim"," Tamil Nadu"," Telangana"," Tripura"," Uttar Pradesh"," Uttarakhand"," West Bengal" });
            //Indonesia
            temp.Add(new List<string> { "Aceh*"," Bali"," Banten"," Bengkulu"," Gorontalo"," Jakarta***"," Jambi"," Jawa Barat (West Java)"," Jawa Tengah (Central Java)"," Jawa Timur (East Java)"," Kalimantan Barat (West Kalimantan)"," Kalimantan Selatan (South Kalimantan)"," Kalimantan Tengah (Central Kalimantan)"," Kalimantan Timur (East Kalimantan)"," Kalimantan Utara (North Kalimantan)"," Kepulauan Bangka Belitung (Bangka Belitung Islands)"," Kepulauan Riau (Riau Islands)"," Lampung"," Maluku"," Maluku Utara (North Maluku)"," Nusa Tenggara Barat (West Nusa Tenggara)"," Nusa Tenggara Timur (East Nusa Tenggara)"," Papua"," Papua Barat (West Papua)"," Riau"," Sulawesi Barat (West Sulawesi)"," Sulawesi Selatan (South Sulawesi)"," Sulawesi Tengah (Central Sulawesi)"," Sulawesi Tenggara (Southeast Sulawesi)"," Sulawesi Utara (North Sulawesi)"," Sumatera Barat (West Sumatra)"," Sumatera Selatan (South Sumatra)"," Sumatera Utara (North Sumatra)"," Yogyakarta**" });
            //Iran
            temp.Add(new List<string> { "Alborz"," Ardabil"," Azarbayjan-e Gharbi (West Azerbaijan)"," Azarbayjan-e Sharqi (East Azerbaijan)"," Bushehr"," Chahar Mahal va Bakhtiari"," Esfahan"," Fars"," Gilan"," Golestan"," Hamadan"," Hormozgan"," Ilam"," Kerman"," Kermanshah"," Khorasan-e Jonubi (South Khorasan)"," Khorasan-e Razavi (Razavi Khorasan)"," Khorasan-e Shomali (North Khorasan)"," Khuzestan"," Kohgiluyeh va Bowyer Ahmad"," Kordestan"," Lorestan"," Markazi"," Mazandaran"," Qazvin"," Qom"," Semnan"," Sistan va Baluchestan"," Tehran"," Yazd"," Zanjan" });
            //Iraq
            temp.Add(new List<string> { "Al Anbar", " Al Basrah", " Al Muthanna", " Al Qadisiyah (Ad Diwaniyah)", " An Najaf", " Arbil (Erbil) (Arabic), Hewler (Kurdish)", " As Sulaymaniyah (Arabic), Slemani (Kurdish)", " Babil", " Baghdad", " Dahuk (Arabic), Dihok (Kurdish)", " Dhi Qar", " Diyala", " Karbala'", " Kirkuk", " Kurdistan Regional Government*", " Maysan", " Ninawa", " Salah ad Din", " Wasit" });
            //Ireland
            temp.Add(new List<string> { "Carlow"," Cavan"," Clare"," Cork"," Cork*"," Donegal"," Dublin*"," Dun Laoghaire-Rathdown"," Fingal"," Galway"," Galway*"," Kerry"," Kildare"," Kilkenny"," Laois"," Leitrim"," Limerick"," Longford"," Louth"," Mayo"," Meath"," Monaghan"," Offaly"," Roscommon"," Sligo"," South Dublin"," Tipperary"," Waterford"," Westmeath"," Wexford"," Wicklow" });
            //Israel
            temp.Add(new List<string> { "Central"," Haifa"," Jerusalem"," Northern"," Southern"," Tel Aviv" });
            //Italy
            temp.Add(new List<string> { "Abruzzo"," Basilicata"," Calabria"," Campania"," Emilia-Romagna"," Lazio (Latium)"," Liguria"," Lombardia"," Marche"," Molise"," Piemonte (Piedmont)"," Puglia (Apulia)"," Toscana (Tuscany)"," Umbria"," Veneto" });

            //Jamaica
            temp.Add(new List<string> { "Clarendon"," Hanover"," Kingston"," Manchester"," Portland"," Saint Andrew"," Saint Ann"," Saint Catherine"," Saint Elizabeth"," Saint James"," Saint Mary"," Saint Thomas"," Trelawny"," Westmoreland" });
            //Japan
            temp.Add(new List<string> { "Aichi"," Akita"," Aomori"," Chiba"," Ehime"," Fukui"," Fukuoka"," Fukushima"," Gifu"," Gunma"," Hiroshima"," Hokkaido"," Hyogo"," Ibaraki"," Ishikawa"," Iwate"," Kagawa"," Kagoshima"," Kanagawa"," Kochi"," Kumamoto"," Kyoto"," Mie"," Miyagi"," Miyazaki"," Nagano"," Nagasaki"," Nara"," Niigata"," Oita"," Okayama"," Okinawa"," Osaka"," Saga"," Saitama"," Shiga"," Shimane"," Shizuoka"," Tochigi"," Tokushima"," Tokyo"," Tottori"," Toyama"," Wakayama"," Yamagata"," Yamaguchi"," Yamanashi" });
            //Jordan
            temp.Add(new List<string> { "'Ajlun"," Al 'Aqabah"," Al Balqa'"," Al Karak"," Al Mafraq"," Al ‘Asimah (Amman)"," At Tafilah"," Az Zarqa'"," Irbid"," Jarash"," Ma'an"," Madaba" });

            //Kazakhstan
            temp.Add(new List<string> { "Almaty (Taldyqorghan)"," Almaty*"," Aqmola (Kokshetau)"," Aqtobe"," Astana*"," Atyrau"," Batys Qazaqstan [West Kazakhstan] (Oral)"," Bayqongyr*"," Mangghystau (Aqtau)"," Pavlodar"," Qaraghandy"," Qostanay"," Qyzylorda"," Shyghys Qazaqstan [East Kazakhstan] (Oskemen)"," Shymkent*"," Soltustik Qazaqstan [North Kazakhstan] (Petropavl)"," Turkistan"," Zhambyl (Taraz)" });
            //Kenya
            temp.Add(new List<string> { "Baringo"," Bomet"," Bungoma"," Busia"," Elgeyo/Marakwet"," Embu"," Garissa"," Homa Bay"," Isiolo"," Kajiado"," Kakamega"," Kericho"," Kiambu"," Kilifi"," Kirinyaga"," Kisii"," Kisumu"," Kitui"," Kwale"," Laikipia"," Lamu"," Machakos"," Makueni"," Mandera"," Marsabit"," Meru"," Migori"," Mombasa"," Murang'a"," Nairobi City"," Nakuru"," Nandi"," Narok"," Nyamira"," Nyandarua"," Nyeri"," Samburu"," Siaya"," Taita/Taveta"," Tana River"," Tharaka-Nithi"," Trans Nzoia"," Turkana"," Uasin Gishu"," Vihiga"," Wajir"," West Pokot" });
            //Kiribati
            temp.Add(new List<string> { "Gilbert Islands"," Line Islands"," Phoenix Islands" });
            //South Korea
            temp.Add(new List<string> { "Busan (Pusan)","Chungbuk (North Chungcheong)"," Chungnam (South Chungcheong)"," Daegu (Taegu)"," Gaejon (Taejon)"," Gangwon"," Gwangju (Kwanju)"," Gyeongbuk (North Gyeongsang)"," Gyeonggi"," Gyeongnam (South Gyeongsang)"," Incheon (Inch'on)"," Jeju"," Jeonbuk (North Jeolla)"," Jeonnam (South Jeolla)"," Seoul"," Ulsan" });
            //Kosovo
            temp.Add(new List<string> { "Decan (Decani)"," Dragash (Dragas)"," Ferizaj (Urosevac)"," Fushe Kosove (Kosovo Polje)"," Gjakove (Dakovica)"," Gjilan (Gnjilane)"," Gllogovc (Glogovac)"," Gracanice (Gracanica)"," Hani i Elezit (Deneral Jankovic)"," Istog (Istok)"," Junik"," Kacanik"," Kamenice (Kamenica)"," Kline (Klina)"," Kllokot (Klokot)"," Leposaviq (Leposavic)"," Lipjan (Lipljan)"," Malisheve (Malisevo)"," Mamushe (Mamusa)"," Mitrovice e Jugut (Juzna Mitrovica) [South Mitrovica]"," Mitrovice e Veriut (Severna Mitrovica) [North Mitrovica]"," Novoberde (Novo Brdo)"," Obiliq (Obilic)"," Partesh (Partes)"," Peje (Pec)"," Podujeve (Podujevo)"," Prishtine (Pristina)"," Prizren"," Rahovec (Orahovac)"," Ranillug (Ranilug)"," Shterpce (Strpce)"," Shtime (Stimlje)"," Skenderaj (Srbica)"," Suhareke (Suva Reka)"," Viti (Vitina)"," Vushtrri (Vucitrn)"," Zubin Potok"," Zvecan" });
            //Kuwait
            temp.Add(new List<string> { "Al Ahmadi"," Al 'Asimah"," Al Farwaniyah"," Al Jahra'"," Hawalli"," Mubarak al Kabir" });
            //Kyrgyzstan
            temp.Add(new List<string> { "Batken Oblusu"," Bishkek Shaary*"," Chuy Oblusu (Bishkek)"," Jalal-Abad Oblusu"," Naryn Oblusu"," Osh Oblusu"," Osh Shaary*"," Talas Oblusu"," Ysyk-Kol Oblusu (Karakol)" });

            //Laos
            temp.Add(new List<string> { " Attapu"," Bokeo"," Bolikhamxai"," Champasak"," Houaphan"," Khammouan"," Louangnamtha"," Louangphabang"," Oudomxai"," Phongsali"," Salavan"," Savannakhet"," Viangchan (Vientiane)*"," Viangchan"," Xaignabouli"," Xaisomboun"," Xekong"," Xiangkhouang" });
            //Latvia
            temp.Add(new List<string> { "Adazu Novads"," Aglonas Novads"," Aizkraukles Novads"," Aizputes Novads"," Aknistes Novads"," Alojas Novads"," Alsungas Novads"," Aluksnes Novads"," Amatas Novads"," Apes Novads"," Auces Novads"," Babites Novads"," Baldones Novads"," Baltinavas Novads"," Balvu Novads"," Bauskas Novads"," Beverinas Novads"," Brocenu Novads"," Burtnieku Novads"," Carnikavas Novads"," Cesu Novads"," Cesvaines Novads"," Ciblas Novads"," Dagdas Novads"," Daugavpils Novads"," Dobeles Novads"," Dundagas Novads"," Durbes Novads"," Engures Novads"," Erglu Novads"," Garkalnes Novads"," Grobinas Novads"," Gulbenes Novads"," Iecavas Novads"," Ikskiles Novads"," Ilukstes Novads"," Incukalna Novads"," Jaunjelgavas Novads"," Jaunpiebalgas Novads"," Jaunpils Novads"," Jekabpils Novads"," Jelgavas Novads"," Kandavas Novads"," Karsavas Novads"," Keguma Novads"," Kekavas Novads"," Kocenu Novads"," Kokneses Novads"," Kraslavas Novads"," Krimuldas Novads"," Krustpils Novads"," Kuldigas Novads"," Lielvardes Novads"," Ligatnes Novads"," Limbazu Novads"," Livanu Novads"," Lubanas Novads"," Ludzas Novads"," Madonas Novads"," Malpils Novads"," Marupes Novads"," Mazsalacas Novads"," Mersraga Novads"," Nauksenu Novads"," Neretas Novads"," Nicas Novads"," Ogres Novads"," Olaines Novads"," Ozolnieku Novads"," Pargaujas Novads"," Pavilostas Novads"," Plavinu Novads"," Preilu Novads"," Priekules Novads"," Priekulu Novads"," Raunas Novads"," Rezeknes Novads"," Riebinu Novads"," Rojas Novads"," Ropazu Novads"," Rucavas Novads"," Rugaju Novads"," Rujienas Novads"," Rundales Novads"," Salacgrivas Novads"," Salas Novads"," Salaspils Novads"," Saldus Novads"," Saulkrastu Novads"," Sejas Novads"," Siguldas Novads"," Skriveru Novads"," Skrundas Novads"," Smiltenes Novads"," Stopinu Novads"," Strencu Novads"," Talsu Novads"," Tervetes Novads"," Tukuma Novads"," Vainodes Novads"," Valkas Novads"," Varaklanu Novads"," Varkavas Novads"," Vecpiebalgas Novads"," Vecumnieku Novads"," Ventspils Novads"," Viesites Novads"," Vilakas Novads"," Vilanu Novads"," Zilupes Novads" });
            //Lebanon
            temp.Add(new List<string> { "Aakkar"," Baalbek-Hermel"," Beqaa (Bekaa)"," Beyrouth (Beirut)"," Liban-Nord (North Lebanon)"," Liban-Sud (South Lebanon)"," Mont-Liban (Mount Lebanon)"," Nabatiye" });
            //Lesotho
            temp.Add(new List<string> { "Berea"," Butha-Buthe"," Leribe"," Mafeteng"," Maseru"," Mohale's Hoek"," Mokhotlong"," Qacha's Nek"," Quthing"," Thaba-Tseka" });
            //Liberia
            temp.Add(new List<string> { "Bomi"," Bong"," Gbarpolu"," Grand Bassa"," Grand Cape Mount"," Grand Gedeh"," Grand Kru"," Lofa"," Margibi"," Maryland"," Montserrado"," Nimba"," River Cess"," River Gee"," Sinoe" });
            //Libya
            temp.Add(new List<string> { "Al Butnan"," Al Jabal al Akhdar"," Al Jabal al Gharbi"," Al Jafarah"," Al Jufrah"," Al Kufrah"," Al Marj"," Al Marqab"," Al Wahat"," An Nuqat al Khams"," Az Zawiyah"," Banghazi (Benghazi)"," Darnah"," Ghat"," Misratah"," Murzuq"," Nalut"," Sabha"," Surt"," Tarabulus (Tripoli)"," Wadi al Hayat"," Wadi ash Shati" });
            //Liechtenstein
            temp.Add(new List<string> { "Balzers"," Eschen"," Gamprin"," Mauren"," Planken"," Ruggell"," Schaan"," Schellenberg"," Triesen"," Triesenberg"," Vaduz" });
            //Lithuania
            temp.Add(new List<string> { "Akmene"," Alytaus Miestas"," Alytus"," Anksciai"," Birstono"," Birzai"," Druskininkai"," Elektrenai"," Ignalina"," Jonava"," Joniskis"," Jurbarkas"," Kaisiadorys"," Kalvarijos"," Kauno Miestas"," Kaunas"," Kazlu Rudos"," Kedainiai"," Kelme"," Klaipedos Miestas"," Klaipeda"," Kretinga"," Kupiskis"," Lazdijai"," Marijampole"," Mazeikiai"," Moletai"," Neringa"," Pagegiai"," Pakruojis"," Palangos Miestas"," Panevezio Miestas"," Panevezys"," Pasvalys"," Plunge"," Prienai"," Radviliskis"," Raseiniai"," Rietavo"," Rokiskis"," Sakiai"," Salcininkai"," Siauliu Miestas"," Siauliai"," Silale"," Silute"," Sirvintos"," Skuodas"," Svencionys"," Taurage"," Telsiai"," Trakai"," Ukmerge"," Utena"," Varena"," Vilkaviskis"," Vilniaus Miestas"," Vilnius"," Visaginas"," Zarasai" });
            //Luxembourg
            temp.Add(new List<string> { "Capellen"," Clervaux"," Diekirch"," Echternach"," Esch-sur-Alzette"," Grevenmacher"," Luxembourg"," Mersch"," Redange"," Remich"," Vianden"," Wiltz" });

            //Madagascar
            temp.Add(new List<string> { "Antananarivo"," Antsiranana"," Fianarantsoa"," Mahajanga"," Toamasina"," Toliara" });
            //Malawi
            temp.Add(new List<string> { "Balaka"," Blantyre"," Chikwawa"," Chiradzulu"," Chitipa"," Dedza"," Dowa"," Karonga"," Kasungu"," Likoma"," Lilongwe"," Machinga"," Mangochi"," Mchinji"," Mulanje"," Mwanza"," Mzimba"," Neno"," Ntcheu"," Nkhata Bay"," Nkhotakota"," Nsanje"," Ntchisi"," Phalombe"," Rumphi"," Salima"," Thyolo"," Zomba" });
            //Malaysia
            temp.Add(new List<string> { "Johor"," Kedah"," Kelantan"," Melaka"," Negeri Sembilan"," Pahang"," Perak"," Perlis"," Pulau Pinang"," Sabah"," Sarawak"," Selangor"," Terengganu" });
            //Maldives
            temp.Add(new List<string> { "Addu (Addu City)"," Ariatholhu Dhekunuburi (South Ari Atoll)"," Ariatholhu Uthuruburi (North Ari Atoll)"," Faadhippolhu"," Felidhuatholhu (Felidhu Atoll)"," Fuvammulah"," Hahdhunmathi"," Huvadhuatholhu Dhekunuburi (South Huvadhu Atoll)"," Huvadhuatholhu Uthuruburi (North Huvadhu Atoll)"," Kolhumadulu"," Maale (Male)"," Maaleatholhu (Male Atoll)"," Maalhosmadulu Dhekunuburi (South Maalhosmadulu)"," Maalhosmadulu Uthuruburi (North Maalhosmadulu)"," Miladhunmadulu Dhekunuburi (South Miladhunmadulu)"," Miladhunmadulu Uthuruburi (North Miladhunmadulu)"," Mulakatholhu (Mulaku Atoll)"," Nilandheatholhu Dhekunuburi (South Nilandhe Atoll)"," Nilandheatholhu Uthuruburi (North Nilandhe Atoll)"," Thiladhunmathee Dhekunuburi (South Thiladhunmathi)"," Thiladhunmathee Uthuruburi (North Thiladhunmathi)" });
            //Mali
            temp.Add(new List<string> { "District de Bamako*"," Gao"," Kayes"," Kidal"," Koulikoro"," Menaka"," Mopti"," Segou"," Sikasso"," Taoudenni"," Tombouctou (Timbuktu" });
            //Malta
            temp.Add(new List<string> { "Attard"," Balzan"," Birgu"," Birkirkara"," Birzebbuga"," Bormla"," Dingli"," Fgura"," Floriana"," Fontana"," Ghajnsielem"," Gharb"," Gharghur"," Ghasri"," Ghaxaq"," Gudja"," Gzira"," Hamrun"," Iklin"," Imdina"," Imgarr"," Imqabba"," Imsida"," Imtarfa"," Isla"," Kalkara"," Kercem"," Kirkop"," Lija"," Luqa"," Marsa"," Marsaskala"," Marsaxlokk"," Mellieha"," Mosta"," Munxar"," Nadur"," Naxxar"," Paola"," Pembroke"," Pieta"," Qala"," Qormi"," Qrendi"," Rabat"," Rabat (Ghawdex)"," Safi"," San Giljan/Saint Julian"," San Gwann/Saint John"," San Lawrenz/Saint Lawrence"," Sannat"," San Pawl il-Bahar/Saint Paul's Bay"," Santa Lucija/Saint Lucia"," Santa Venera/Saint Venera"," Siggiewi"," Sliema"," Swieqi"," Tarxien"," Ta' Xbiex"," Valletta"," Xaghra"," Xewkija"," Xghajra"," Zabbar"," Zebbug"," Zebbug (Ghawdex)"," Zejtun"," Zurrieq" });
            //Marshall Islands
            temp.Add(new List<string> { "Ailinglaplap"," Ailuk"," Arno"," Aur"," Bikini & Kili"," Ebon"," Enewetak & Ujelang"," Jabat"," Jaluit"," Kwajalein"," Lae"," Lib"," Likiep"," Majuro"," Maloelap"," Mejit"," Mili"," Namorik"," Namu"," Rongelap"," Ujae"," Utrik"," Wotho"," Wotje" });
            //Mauritania
            temp.Add(new List<string> { "Adrar"," Assaba"," Brakna"," Dakhlet Nouadhibou"," Gorgol"," Guidimaka"," Hodh ech Chargui"," Hodh El Gharbi"," Inchiri"," Nouakchott Nord"," Nouakchott Ouest"," Nouakchott Sud"," Tagant"," Tiris Zemmour"," Trarza" });
            //Mauritius
            temp.Add(new List<string> { "Agalega Islands*"," Black River"," Cargados Carajos Shoals*"," Flacq"," Grand Port"," Moka"," Pamplemousses"," Plaines Wilhems"," Port Louis"," Riviere du Rempart"," Rodrigues*"," Savanne" });
            //Mexico
            temp.Add(new List<string> { "Aguascalientes"," Baja California"," Baja California Sur"," Campeche"," Chiapas"," Chihuahua"," Coahuila"," Colima"," Cuidad de Mexico"," Durango"," Guanajuato"," Guerrero"," Hidalgo"," Jalisco"," Mexico"," Michoacan"," Morelos"," Nayarit"," Nuevo Leon"," Oaxaca"," Puebla"," Queretaro"," Quintana Roo"," San Luis Potosi"," Sinaloa"," Sonora"," Tabasco"," Tamaulipas"," Tlaxcala"," Veracruz"," Yucatan"," Zacatecas" });
            //Micronesia
            temp.Add(new List<string> { "Chuuk (Truk)"," Kosrae (Kosaie)"," Pohnpei (Ponape)"," Yap" });
            //Moldova
            temp.Add(new List<string> { "Anenii Noi", "Balti", " Basarabeasca", "Bender", " Briceni"," Cahul"," Cantemir"," Calarasi"," Causeni"," Cimislia", "Chisinau"," Criuleni"," Donduseni"," Drochia"," Dubasari"," Edinet"," Falesti"," Floresti", "Gagauzia"," Glodeni"," Hincesti"," Ialoveni"," Leova"," Nisporeni"," Ocnita"," Orhei"," Rezina"," Riscani"," Singerei"," Soldanesti"," Soroca", "Stinga Nistrului"," Stefan Voda"," Straseni"," Taraclia"," Telenesti"," Ungheni" });
            //Monaco
            temp.Add(new List<string> { "Fontvieille"," La Condamine"," Monaco-Ville"," Monte-Carlo" });
            //Mongolia
            temp.Add(new List<string> { "Arhangay"," Bayanhongor"," Bayan-Olgiy"," Bulgan"," Darhan-Uul"," Dornod"," Dornogovi"," Dundgovi"," Dzavhan (Zavkhan)"," Govi-Altay"," Govisumber"," Hentiy"," Hovd"," Hovsgol"," Omnogovi"," Orhon"," Ovorhangay"," Selenge"," Suhbaatar"," Tov"," Ulaanbaatar*"," Uvs" });
            //Montenegro
            temp.Add(new List<string> { "Andrijevica"," Bar"," Berane"," Bijelo Polje"," Budva"," Cetinje"," Danilovgrad"," Gusinje"," Herceg Novi"," Kolasin"," Kotor"," Mojkovac"," Niksic"," Petnijica"," Plav"," Pljevlja"," Pluzine"," Podgorica"," Rozaje"," Savnik"," Tivat"," Tuzi"," Ulcinj"," Zabljak" });
            //Monserrat
            temp.Add(new List<string> { "Saint Anthony"," Saint Georges"," Saint Peter" });
            //Morocco
            temp.Add(new List<string> { "Beni Mellal-Khenifra"," Casablanca-Settat"," Draa-Tafilalet"," Fes-Meknes"," Guelmim-Oued Noun"," Laayoune-Sakia al Hamra"," Oriental"," Marrakech-Safi"," Rabat-Sale-Kenitra"," Souss-Massa"," Tanger-Tetouan-Al Hoceima" });
            //Mozambique
            temp.Add(new List<string> { "Cabo Delgado"," Gaza"," Inhambane"," Manica"," Maputo"," Cidade de Maputo*"," Nampula"," Niassa"," Sofala"," Tete"," Zambezia" });

            //Namibia
            temp.Add(new List<string> { "Erongo"," Hardap"," //Karas"," Kavango East"," Kavango West"," Khomas"," Kunene"," Ohangwena"," Omaheke"," Omusati"," Oshana"," Oshikoto"," Otjozondjupa"," Zambezi" });
            //Nauru
            temp.Add(new List<string> { "Aiwo"," Anabar"," Anetan"," Anibare"," Baitsi"," Boe"," Buada"," Denigomodu"," Ewa"," Ijuw"," Meneng"," Nibok"," Uaboe"," Yaren" });
            //Nepal
            temp.Add(new List<string> { "Gandaki Pradesh"," Karnali Pradesh"," Province No. One"," Province No. Two"," Province No. Three"," Province No. Five"," Sudurpashchim Pradesh" });
            //Netherlands
            temp.Add(new List<string> { "Bonaire*"," Drenthe"," Flevoland"," Fryslan (Friesland)"," Gelderland"," Groningen"," Limburg"," Noord-Brabant (North Brabant)"," Noord-Holland (North Holland)"," Overijssel"," Saba*"," Sint Eustatius*"," Utrecht"," Zeeland (Zealand)"," Zuid-Holland (South Holland)" });
            //New Caledonia
            temp.Add(new List<string> { "Province Iles (Islands Province)"," Province Nord (North Province)"," and Province Sud (South Province)" });
            //New Zealand
            temp.Add(new List<string> { "Auckland"," Bay of Plenty"," Canterbury"," Chatham Islands*"," Gisborne"," Hawke's Bay"," Manawatu-Wanganui"," Marlborough"," Nelson"," Northland"," Otago"," Southland"," Taranaki"," Tasman"," Waikato"," Wellington"," West Coast" });
            //Nicaragua
            temp.Add(new List<string> { "Boaco"," Carazo"," Chinandega"," Chontales"," Costa Caribe Norte*"," Costa Caribe Sur*"," Esteli"," Granada"," Jinotega"," Leon"," Madriz"," Managua"," Masaya"," Matagalpa"," Nueva Segovia"," Rio San Juan"," Rivas" });
            //Niger
            temp.Add(new List<string> { "Agadez"," Diffa"," Dosso"," Maradi"," Niamey*"," Tahoua"," Tillaberi"," Zinder" });
            //Nigeria
            temp.Add(new List<string> { "Abia"," Adamawa"," Akwa Ibom"," Anambra"," Bauchi"," Bayelsa"," Benue"," Borno"," Cross River"," Delta"," Ebonyi"," Edo"," Ekiti"," Enugu"," Federal Capital Territory*"," Gombe"," Imo"," Jigawa"," Kaduna"," Kano"," Katsina"," Kebbi"," Kogi"," Kwara"," Lagos"," Nasarawa"," Niger"," Ogun"," Ondo"," Osun"," Oyo"," Plateau"," Rivers"," Sokoto"," Taraba"," Yobe"," Zamfara" });
            //North Macedonia
            temp.Add(new List<string> { "Aracinovo"," Berovo"," Bitola"," Bogdanci"," Bogovinje"," Bosilovo"," Brvenica"," Caska"," Centar Zupa"," Cesinovo-Oblesevo"," Cucer Sandevo"," Debar"," Debarca"," Delcevo"," Demir Hisar"," Demir Kapija"," Dojran"," Dolneni"," Gevgelija"," Gostivar"," Gradsko"," Ilinden"," Jegunovce"," Karbinci"," Kavadarci"," Kicevo"," Kocani"," Konce"," Kratovo"," Kriva Palanka"," Krivogastani"," Krusevo"," Kumanovo"," Lipkovo"," Lozovo"," Makedonska Kamenica"," Makedonski Brod"," Mavrovo i Rostusa"," Mogila"," Negotino"," Novaci"," Novo Selo"," Ohrid"," Pehcevo"," Petrovec"," Plasnica"," Prilep"," Probistip"," Radovis"," Rankovce"," Resen"," Rosoman"," Skopje*"," Sopiste"," Staro Nagoricane"," Stip"," Struga"," Strumica"," Studenicani"," Sveti Nikole"," Tearce"," Tetovo"," Valandovo"," Vasilevo"," Veles"," Vevcani"," Vinica"," Vrapciste"," Zelenikovo"," Zelino"," Zrnovci" });
            //Norway
            temp.Add(new List<string> { "Akershus"," Aust-Agder"," Buskerud"," Finnmark"," Hedmark"," Hordaland"," More og Romsdal"," Nordland"," Oppland"," Oslo"," Ostfold"," Rogaland"," Sogn og Fjordane"," Telemark"," Troms"," Trondelag"," Vest-Agder"," Vestfold" });

            //Oman
            temp.Add(new List<string> { "Ad Dakhiliyah"," Al Buraymi"," Al Wusta"," Az Zahirah"," Janub al Batinah (Al Batinah South)"," Janub ash Sharqiyah (Ash Sharqiyah South)"," Masqat (Muscat)"," Musandam"," Shamal al Batinah (Al Batinah North)"," Shamal ash Sharqiyah (Ash Sharqiyah North)"," Zufar (Dhofar)" });
            
            //Pakistan
            temp.Add(new List<string> { "Azad Kashmir*"," Balochistan"," Gilgit-Baltistan*"," Islamabad Capital Territory**"," Khyber Pakhtunkhwa"," Punjab"," Sindh" });
            //Palau
            temp.Add(new List<string> { "Aimeliik"," Airai"," Angaur"," Hatohobei"," Kayangel"," Koror"," Melekeok"," Ngaraard"," Ngarchelong"," Ngardmau"," Ngatpang"," Ngchesar"," Ngeremlengui"," Ngiwal"," Peleliu"," Sonsorol" });
            //Panama
            temp.Add(new List<string> { "Bocas del Toro"," Chiriqui"," Cocle"," Colon"," Darien"," Embera-Wounaan*"," Herrera"," Guna Yala*"," Los Santos"," Ngobe-Bugle*"," Panama"," Panama Oeste"," Veraguas" });
            //Papua New Guinea
            temp.Add(new List<string> { "Bougainville*"," Central"," Chimbu"," Eastern Highlands"," East New Britain"," East Sepik"," Enga"," Gulf"," Hela"," Jiwaka"," Madang"," Manus"," Milne Bay"," Morobe"," National Capital**"," New Ireland"," Northern"," Southern Highlands"," Western"," Western Highlands"," West New Britain"," West Sepik" });
            //Paraguay
            temp.Add(new List<string> { "Alto Paraguay"," Alto Parana"," Amambay"," Asuncion*"," Boqueron"," Caaguazu"," Caazapa"," Canindeyu"," Central"," Concepcion"," Cordillera"," Guaira"," Itapua"," Misiones"," Neembucu"," Paraguari"," Presidente Hayes"," San Pedro" });
            //Peru
            temp.Add(new List<string> { "Amazonas"," Ancash"," Apurimac"," Arequipa"," Ayacucho"," Cajamarca"," Callao"," Cusco"," Huancavelica"," Huanuco"," Ica"," Junin"," La Libertad"," Lambayeque"," Lima"," Lima*"," Loreto"," Madre de Dios"," Moquegua"," Pasco"," Piura"," Puno"," San Martin"," Tacna"," Tumbes"," Ucayali" });
            //Philippines
            temp.Add(new List<string> { "Abra"," Agusan del Norte"," Agusan del Sur"," Aklan"," Albay"," Antique"," Apayao"," Aurora"," Basilan"," Bataan"," Batanes"," Batangas"," Biliran"," Benguet"," Bohol"," Bukidnon"," Bulacan"," Cagayan"," Camarines Norte"," Camarines Sur"," Camiguin"," Capiz"," Catanduanes"," Cavite"," Cebu"," Compostela"," Cotabato"," Davao del Norte"," Davao del Sur"," Davao Occidental"," Davao Oriental"," Dinagat Islands"," Eastern Samar"," Guimaras"," Ifugao"," Ilocos Norte"," Ilocos Sur"," Iloilo"," Isabela"," Kalinga"," Laguna"," Lanao del Norte"," Lanao del Sur"," La Union"," Leyte"," Maguindanao"," Marinduque"," Masbate"," Mindoro Occidental"," Mindoro Oriental"," Misamis Occidental"," Misamis Oriental"," Mountain"," Negros Occidental"," Negros Oriental"," Northern Samar"," Nueva Ecija"," Nueva Vizcaya"," Palawan"," Pampanga"," Pangasinan"," Quezon"," Quirino"," Rizal"," Romblon"," Samar"," Sarangani"," Siquijor"," Sorsogon"," South Cotabato"," Southern Leyte"," Sultan Kudarat"," Sulu"," Surigao del Norte"," Surigao del Sur"," Tarlac"," Tawi-Tawi"," Zambales"," Zamboanga del Norte"," Zamboanga del Sur"," Zamboanga Sibugay" });
            //Poland
            temp.Add(new List<string> { "Dolnoslaskie (Lower Silesia)"," Kujawsko-Pomorskie (Kuyavia-Pomerania)"," Lodzkie (Lodz)"," Lubelskie (Lublin)"," Lubuskie (Lubusz)"," Malopolskie (Lesser Poland)"," Mazowieckie (Masovia)"," Opolskie (Opole)"," Podkarpackie (Subcarpathia)"," Podlaskie"," Pomorskie (Pomerania)"," Slaskie (Silesia)"," Swietokrzyskie (Holy Cross)"," Warminsko-Mazurskie (Warmia-Masuria)"," Wielkopolskie (Greater Poland)"," Zachodniopomorskie (West Pomerania)" });
            //Portugal
            temp.Add(new List<string> { "Aveiro"," Acores (Azores)*"," Beja"," Braga"," Braganca"," Castelo Branco"," Coimbra"," Evora"," Faro"," Guarda"," Leiria"," Lisboa (Lisbon)"," Madeira*"," Portalegre"," Porto"," Santarem"," Setubal"," Viana do Castelo"," Vila Real"," Viseu" });
            //Puerto Rico
            temp.Add(new List<string> { "Adjuntas"," Aguada"," Aguadilla"," Aguas Buenas"," Aibonito"," Anasco"," Arecibo"," Arroyo"," Barceloneta"," Barranquitas"," Bayamon"," Cabo Rojo"," Caguas"," Camuy"," Canovanas"," Carolina"," Catano"," Cayey"," Ceiba"," Ciales"," Cidra"," Coamo"," Comerio"," Corozal"," Culebra"," Dorado"," Fajardo"," Florida"," Guanica"," Guayama"," Guayanilla"," Guaynabo"," Gurabo"," Hatillo"," Hormigueros"," Humacao"," Isabela"," Jayuya"," Juana Diaz"," Juncos"," Lajas"," Lares"," Las Marias"," Las Piedras"," Loiza"," Luquillo"," Manati"," Maricao"," Maunabo"," Mayaguez"," Moca"," Morovis"," Naguabo"," Naranjito"," Orocovis"," Patillas"," Penuelas"," Ponce"," Quebradillas"," Rincon"," Rio Grande"," Sabana Grande"," Salinas"," San German"," San Juan"," San Lorenzo"," San Sebastian"," Santa Isabel"," Toa Alta"," Toa Baja"," Trujillo Alto"," Utuado"," Vega Alta"," Vega Baja"," Vieques"," Villalba"," Yabucoa"," Yauco" });

            //Qatar
            temp.Add(new List<string> { "Ad Dawhah"," Al Khawr wa adh Dhakhirah"," Al Wakrah"," Ar Rayyan"," Ash Shamal"," Ash Shihaniyah"," Az Za'ayin"," Umm Salal" });
            
            //Romania
            temp.Add(new List<string> { "Alba"," Arad"," Arges"," Bacau"," Bihor"," Bistrita-Nasaud"," Botosani"," Braila"," Brasov"," Bucuresti (Bucharest)*"," Buzau"," Calarasi"," Caras-Severin"," Cluj"," Constanta"," Covasna"," Dambovita"," Dolj"," Galati"," Gorj"," Giurgiu"," Harghita"," Hunedoara"," Ialomita"," Iasi"," Ilfov"," Maramures"," Mehedinti"," Mures"," Neamt"," Olt"," Prahova"," Salaj"," Satu Mare"," Sibiu"," Suceava"," Teleorman"," Timis"," Tulcea"," Vaslui"," Valcea"," Vrancea" });
            //Russia
            temp.Add(new List<string> { "-- Oblasts --", "Amur (Blagoveshchensk)"," Arkhangel'sk"," Astrakhan'"," Belgorod"," Bryansk"," Chelyabinsk"," Irkutsk"," Ivanovo"," Kaliningrad"," Kaluga"," Kemerovo"," Kirov"," Kostroma"," Kurgan"," Kursk"," Leningrad"," Lipetsk"," Magadan"," Moscow"," Murmansk"," Nizhniy Novgorod"," Novgorod"," Novosibirsk"," Omsk"," Orenburg"," Orel"," Penza"," Pskov"," Rostov"," Ryazan'"," Sakhalin (Yuzhno-Sakhalinsk)"," Samara"," Saratov"," Smolensk"," Sverdlovsk (Yekaterinburg)"," Tambov"," Tomsk"," Tula"," Tver'"," Tyumen'"," Ul'yanovsk"," Vladimir"," Volgograd"," Vologda"," Voronezh"," Yaroslavl'", "-- Republics --", "Adygeya (Maykop)"," Altay (Gorno-Altaysk)"," Bashkortostan (Ufa)"," Buryatiya (Ulan-Ude)"," Chechnya (Groznyy)"," Chuvashiya (Cheboksary)"," Dagestan (Makhachkala)"," Ingushetiya (Magas)"," Kabardino-Balkariya (Nal'chik)"," Kalmykiya (Elista)"," Karachayevo-Cherkesiya (Cherkessk)"," Kareliya (Petrozavodsk)"," Khakasiya (Abakan)"," Komi (Syktyvkar)"," Mariy-El (Yoshkar-Ola)"," Mordoviya (Saransk)"," North Ossetia (Vladikavkaz)"," Sakha [Yakutiya] (Yakutsk)"," Tatarstan (Kazan')"," Tyva (Kyzyl)"," Udmurtiya (Izhevsk)" });
            //Rwanda
            temp.Add(new List<string> { "Est (Eastern)"," Kigali*"," Nord (Northern)"," Ouest (Western)"," Sud (Southern)" });

            //Saint Helena
            temp.Add(new List<string> { "Ascension"," Saint Helena"," Tristan da Cunha" });
            //Saint Kitts
            temp.Add(new List<string> { "Christ Church Nichola Town"," Saint Anne Sandy Point"," Saint George Basseterre"," Saint George Gingerland"," Saint James Windward"," Saint John Capesterre"," Saint John Figtree"," Saint Mary Cayon"," Saint Paul Capesterre"," Saint Paul Charlestown"," Saint Peter Basseterre"," Saint Thomas Lowland"," Saint Thomas Middle Island"," Trinity Palmetto Point" });
            //Saint Lucia
            temp.Add(new List<string> { "Anse-la-Raye"," Canaries"," Castries"," Choiseul"," Dennery"," Gros-Islet"," Laborie"," Micoud"," Soufriere"," Vieux-Fort" });
            //Saint Vincent
            temp.Add(new List<string> { "Charlotte"," Grenadines"," Saint Andrew"," Saint David"," Saint George"," Saint Patrick" });
            //Samoa
            temp.Add(new List<string> { "A'ana"," Aiga-i-le-Tai"," Atua"," Fa'asaleleaga"," Gaga'emauga"," Gagaifomauga"," Palauli"," Satupa'itea"," Tuamasaga"," Va'a-o-Fonoti"," Vaisigano" });
            //San Marino
            temp.Add(new List<string> { "Acquaviva"," Borgo Maggiore"," Chiesanuova"," Domagnano"," Faetano"," Fiorentino"," Montegiardino"," San Marino Citta"," Serravalle" });
            //Sao tome and Principe
            temp.Add(new List<string> { "Agua Grande"," Cantagalo"," Caue"," Lemba"," Lobata"," Me-Zochi"," Principe*" });
            //Saudi Arabia
            temp.Add(new List<string> { "Al Bahah"," Al Hudud ash Shamaliyah (Northern Border)"," Al Jawf"," Al Madinah al Munawwarah (Medina)"," Al Qasim"," Ar Riyad (Riyadh)"," Ash Sharqiyah (Eastern)"," 'Asir"," Ha'il"," Jazan"," Makkah al Mukarramah (Mecca)"," Najran"," Tabuk" });
            //Senegal
            temp.Add(new List<string> { "Dakar"," Diourbel"," Fatick"," Kaffrine"," Kaolack"," Kedougou"," Kolda"," Louga"," Matam"," Saint-Louis"," Sedhiou"," Tambacounda"," Thies"," Ziguinchor" });
            //Serbia
            temp.Add(new List<string> { "Ada*"," Aleksandrovac"," Aleksinac"," Alibunar*"," Apatin*"," Arandelovac"," Arilje"," Babusnica"," Bac*"," Backa Palanka*"," Backa Topola*"," Backi Petrovac*"," Bajina Basta"," Batocina"," Becej*"," Bela Crkva*"," Bela Palanka"," Beocin*"," Blace"," Bogatic"," Bojnik"," Boljevac"," Bor"," Bosilegrad"," Brus"," Bujanovac"," Cajetina"," Cicevac"," Coka*"," Crna Trava"," Cuprija"," Despotovac"," Dimitrov"," Doljevac"," Gadzin Han"," Golubac"," Gornji Milanovac"," Indija*"," Irig*"," Ivanjica"," Kanjiza*"," Kladovo"," Knic"," Knjazevac"," Koceljeva"," Kosjeric"," Kovacica*"," Kovin*"," Krupanj"," Kucevo"," Kula*"," Kursumlija"," Lajkovac"," Lapovo"," Lebane"," Ljig"," Ljubovija"," Lucani"," Majdanpek"," Mali Idos*"," Mali Zvornik"," Malo Crnice"," Medveda"," Merosina"," Mionica"," Negotin"," Nova Crnja*"," Nova Varos"," Novi Becej*"," Novi Knezevac*"," Odzaci*"," Opovo*"," Osecina"," Paracin"," Pecinci*"," Petrovac na Mlavi"," Plandiste*"," Pozega"," Presevo"," Priboj"," Prijepolje"," Prokuplje"," Raca"," Raska"," Razanj"," Rekovac"," Ruma*"," Secanj*"," Senta*"," Sid*"," Sjenica"," Smederevska Palanka"," Sokobanja"," Srbobran*"," Sremski Karlovci*"," Stara Pazova*"," Surdulica"," Svilajnac"," Svrljig"," Temerin*"," Titel*"," Topola"," Trgoviste"," Trstenik"," Tutin"," Ub"," Varvarin"," Velika Plana"," Veliko Gradiste"," Vladicin Han"," Vladimirci"," Vlasotince"," Vrbas*"," Vrnjacka Banja"," Zabalj*"," Zabari"," Zagubica"," Zitiste*"," Zitorada" });
            //Seychelles
            temp.Add(new List<string> { "Anse aux Pins"," Anse Boileau"," Anse Etoile"," Anse Royale"," Au Cap"," Baie Lazare"," Baie Sainte Anne"," Beau Vallon"," Bel Air"," Bel Ombre"," Cascade"," Glacis"," Grand Anse Mahe"," Grand Anse Praslin"," Inner Islands"," La Riviere Anglaise"," Les Mamalles"," Mont Buxton"," Mont Fleuri"," Plaisance"," Pointe Larue"," Port Glaud"," Roche Caiman"," Saint Louis"," Takamaka" });
            //Sierra Leone
            temp.Add(new List<string> { "Eastern"," Northern"," North Western"," Southern"," Western*" });
            //singapore
            temp.Add(new List<string> { "Central Singapore Development Council"," North East Development Council"," North West Development Council"," South East Development Council"," South West Development Council" });
            //Slovakia
            temp.Add(new List<string> { "Banskobystricky"," Bratislavsky"," Kosicky"," Nitriansky"," Presovsky"," Trenciansky"," Trnavsky"," Zilinsky" });
            //Slovenia
            temp.Add(new List<string> { "Ajdovscina"," Ankaran"," Apace"," Beltinci"," Benedikt"," Bistrica ob Sotli"," Bled"," Bloke"," Bohinj"," Borovnica"," Bovec"," Braslovce"," Brda"," Brezice"," Brezovica"," Cankova"," Cerklje na Gorenjskem"," Cerknica"," Cerkno"," Cerkvenjak"," Cirkulane"," Crensovci"," Crna na Koroskem"," Crnomelj"," Destrnik"," Divaca"," Dobje"," Dobrepolje"," Dobrna"," Dobrova-Polhov Gradec"," Dobrovnik/Dobronak"," Dolenjske Toplice"," Dol pri Ljubljani"," Domzale"," Dornava"," Dravograd"," Duplek"," Gorenja Vas-Poljane"," Gorisnica"," Gorje"," Gornja Radgona"," Gornji Grad"," Gornji Petrovci"," Grad"," Grosuplje"," Hajdina"," Hoce-Slivnica"," Hodos"," Horjul"," Hrastnik"," Hrpelje-Kozina"," Idrija"," Ig"," Ilirska Bistrica"," Ivancna Gorica"," Izola/Isola"," Jesenice"," Jezersko"," Jursinci"," Kamnik"," Kanal"," Kidricevo"," Kobarid"," Kobilje"," Kocevje"," Komen"," Komenda"," Kosanjevica na Krki"," Kostel"," Kozje"," Kranjska Gora"," Krizevci"," Krsko"," Kungota"," Kuzma"," Lasko"," Lenart"," Lendava/Lendva"," Litija"," Ljubno"," Ljutomer"," Log-Dragomer"," Logatec"," Loska Dolina"," Loski Potok"," Lovrenc na Pohorju"," Luce"," Lukovica"," Majsperk"," Makole"," Markovci"," Medvode"," Menges"," Metlika"," Mezica"," Miklavz na Dravskem Polju"," Miren-Kostanjevica"," Mirna"," Mirna Pec"," Mislinja"," Mokronog-Trebelno"," Moravce"," Moravske Toplice"," Mozirje"," Muta"," Naklo"," Nazarje"," Odranci"," Oplotnica"," Ormoz"," Osilnica"," Pesnica"," Piran/Pirano"," Pivka"," Podcetrtek"," Podlehnik"," Podvelka"," Poljcane"," Polzela"," Postojna"," Prebold"," Preddvor"," Prevalje"," Puconci"," Race-Fram"," Radece"," Radenci"," Radlje ob Dravi"," Radovljica"," Ravne na Koroskem"," Razkrizje"," Recica ob Savinji"," Rence-Vogrsko"," Ribnica"," Ribnica na Pohorju"," Rogaska Slatina"," Rogasovci"," Rogatec"," Ruse"," Selnica ob Dravi"," Semic"," Sevnica"," Sezana"," Slovenska Bistrica"," Slovenske Konjice"," Sodrazica"," Solcava"," Sredisce ob Dravi"," Starse"," Straza"," Sveta Ana"," Sveta Trojica v Slovenskih Goricah"," Sveti Andraz v Slovenskih Goricah"," Sveti Jurij ob Scavnici"," Sveti Jurij v Slovenskih Goricah"," Sveti Tomaz"," Salovci"," Sempeter-Vrtojba"," Sencur"," Sentilj"," Sentjernej"," Sentjur"," Sentrupert"," Skocjan"," Skofja Loka"," Skofljica"," Smarje pri Jelsah"," Smarjeske Toplice"," Smartno ob Paki"," Smartno pri Litiji"," Sostanj"," Store"," Tabor"," Tisina"," Tolmin"," Trbovlje"," Trebnje"," Trnovska Vas"," Trzic"," Trzin"," Turnisce"," Velika Polana"," Velike Lasce"," Verzej"," Videm"," Vipava"," Vitanje"," Vodice"," Vojnik"," Vransko"," Vrhnika"," Vuzenica"," Zagorje ob Savi"," Zalec"," Zavrc"," Zelezniki"," Zetale"," Ziri"," Zirovnica"," Zrece"," Zuzemberk"});
            //Solomon Islands
            temp.Add(new List<string> { "Central"," Choiseul"," Guadalcanal"," Honiara*"," Isabel"," Makira and Ulawa"," Malaita"," Rennell and Bellona"," Temotu"," Western" });
            //Somalia
            temp.Add(new List<string> { "Awdal"," Bakool"," Banaadir"," Bari"," Bay"," Galguduud"," Gedo"," Hiiraan"," Jubbada Dhexe (Middle Jubba)"," Jubbada Hoose (Lower Jubba)"," Mudug"," Nugaal"," Sanaag"," Shabeellaha Dhexe (Middle Shabeelle)"," Shabeellaha Hoose (Lower Shabeelle)"," Sool"," Togdheer"," Woqooyi Galbeed" });
            //South Africa
            temp.Add(new List<string> { "Eastern Cape"," Free State"," Gauteng"," KwaZulu-Natal"," Limpopo"," Mpumalanga"," Northern Cape"," North West"," Western Cape" });
            //South Sudan
            temp.Add(new List<string> { " Central Equatoria"," Eastern Equatoria"," Jonglei"," Lakes"," Northern Bahr el Ghazal"," Unity"," Upper Nile"," Warrap"," Western Bahr el Ghazal"," Western Equatoria" });
            //Spain
            temp.Add(new List<string> { "Andalucia", " Aragon", " Asturias", " Canarias (Canary Islands)", " Cantabria", " Castilla-La Mancha", " Castilla-Leon", " Cataluna (Castilian)", " Catalunya (Catalan)", " Catalonha (Aranese) [Catalonia]", " Ceuta*", " Comunidad Valenciana (Castilian)", " Comunitat Valenciana (Valencian) [Valencian Community]", " Extremadura", " Galicia", " Illes Baleares (Balearic Islands)", " La Rioja", " Madrid", " Melilla*", " Murcia", " Navarra (Castilian)", " Nafarroa (Basque) [Navarre]", " Pais Vasco (Castilian)", " Euskadi (Basque) [Basque Country]" });
            //Sri Lanka
            temp.Add(new List<string> { "Central"," Eastern"," North Central"," Northern"," North Western"," Sabaragamuwa"," Southern"," Uva"," Western" });
            //sudan
            temp.Add(new List<string> { "Blue Nile"," Central Darfur"," East Darfur"," Gedaref"," Gezira"," Kassala"," Khartoum"," North Darfur"," North Kordofan"," Northern"," Red Sea"," River Nile"," Sennar"," South Darfur"," South Kordofan"," West Darfur"," West Kordofan"," White Nile" });
            //suriname
            temp.Add(new List<string> { "Brokopondo"," Commewijne"," Coronie"," Marowijne"," Nickerie"," Para"," Paramaribo"," Saramacca"," Sipaliwini"," Wanica" });
            //Sweden
            temp.Add(new List<string> { "Blekinge"," Dalarna"," Gavleborg"," Gotland"," Halland"," Jamtland"," Jonkoping"," Kalmar"," Kronoberg"," Norrbotten"," Orebro"," Ostergotland"," Skane"," Sodermanland"," Stockholm"," Uppsala"," Varmland"," Vasterbotten"," Vasternorrland"," Vastmanland"," Vastra Gotaland" });
            //Switzerland
            temp.Add(new List<string> { "Aargau"," Appenzell Ausserrhoden"," Appenzell Innerrhoden"," Basel-Landschaft"," Basel-Stadt"," Berne/Bern"," Fribourg/Freiburg"," Geneve (Geneva)"," Glarus"," Graubuenden/Grigioni/Grischun"," Jura"," Luzern"," Neuchatel"," Nidwalden"," Obwalden"," Sankt Gallen"," Schaffhausen"," Schwyz"," Solothurn"," Thurgau"," Ticino"," Uri"," Valais/Wallis"," Vaud"," Zug"," Zuerich" });
            //Syria
            temp.Add(new List<string> { "Al Hasakah"," Al Ladhiqiyah (Latakia)"," Al Qunaytirah"," Ar Raqqah"," As Suwayda'"," Dar'a"," Dayr az Zawr"," Dimashq (Damascus)"," Halab (Aleppo)"," Hamah"," Hims (Homs)"," Idlib"," Rif Dimashq (Damascus Countryside)"," Tartus" });

            //Taiwan
            temp.Add(new List<string> { "Changhua"," Chiayi"," Hsinchu"," Hualien"," Kinmen"," Lienchiang"," Miaoli"," Nantou"," Penghu"," Pingtung"," Taitung"," Yilan"," Yunlin" });
            //Tajikistan
            temp.Add(new List<string> { "Dushanbe**"," Khatlon (Bokhtar)"," Kuhistoni Badakhshon [Gorno-Badakhshan]* (Khorugh)"," Nohiyahoi Tobei Jumhuri***"," Sughd (Khujand)" });
            //Tanzania
            temp.Add(new List<string> { "Arusha"," Dar es Salaam"," Dodoma"," Geita"," Iringa"," Kagera"," Kaskazini Pemba (Pemba North)"," Kaskazini Unguja (Zanzibar North)"," Katavi"," Kigoma"," Kilimanjaro"," Kusini Pemba (Pemba South)"," Kusini Unguja (Zanzibar Central/South)"," Lindi"," Manyara"," Mara"," Mbeya"," Mjini Magharibi (Zanzibar Urban/West)"," Morogoro"," Mtwara"," Mwanza"," Njombe"," Pwani (Coast)"," Rukwa"," Ruvuma"," Shinyanga"," Simiyu"," Singida"," Songwe"," Tabora"," Tanga" });
            //Thailand
            temp.Add(new List<string> { "Amnat Charoen"," Ang Thong"," Bueng Kan"," Buri Ram"," Chachoengsao"," Chai Nat"," Chaiyaphum"," Chanthaburi"," Chiang Mai"," Chiang Rai"," Chon Buri"," Chumphon"," Kalasin"," Kamphaeng Phet"," Kanchanaburi"," Khon Kaen"," Krabi"," Krung Thep* (Bangkok)"," Lampang"," Lamphun"," Loei"," Lop Buri"," Mae Hong Son"," Maha Sarakham"," Mukdahan"," Nakhon Nayok"," Nakhon Pathom"," Nakhon Phanom"," Nakhon Ratchasima"," Nakhon Sawan"," Nakhon Si Thammarat"," Nan"," Narathiwat"," Nong Bua Lamphu"," Nong Khai"," Nonthaburi"," Pathum Thani"," Pattani"," Phangnga"," Phatthalung"," Phayao"," Phetchabun"," Phetchaburi"," Phichit"," Phitsanulok"," Phra Nakhon Si Ayutthaya"," Phrae"," Phuket"," Prachin Buri"," Prachuap Khiri Khan"," Ranong"," Ratchaburi"," Rayong"," Roi Et"," Sa Kaeo"," Sakon Nakhon"," Samut Prakan"," Samut Sakhon"," Samut Songkhram"," Saraburi"," Satun"," Sing Buri"," Si Sa Ket"," Songkhla"," Sukhothai"," Suphan Buri"," Surat Thani"," Surin"," Tak"," Trang"," Trat"," Ubon Ratchathani"," Udon Thani"," Uthai Thani"," Uttaradit"," Yala"," Yasothon" });
            //timor - Leste
            temp.Add(new List<string> { "Aileu"," Ainaro"," Baucau"," Bobonaro (Maliana)"," Covalima (Suai)"," Dili"," Ermera (Gleno)"," Lautem (Lospalos)"," Liquica"," Manatuto"," Manufahi (Same)"," Oe-Cusse Ambeno* (Pante Macassar)"," Viqueque" });
            //Togo
            temp.Add(new List<string> { "Centrale"," Kara"," Maritime"," Plateaux"," Savanes" });
            //Tonga
            temp.Add(new List<string> { "'Eua"," Ha'apai"," Ongo Niua"," Tongatapu"," Vava'u" });
            //Trinidad and Tobego
            temp.Add(new List<string> { "Couva/Tabaquite/Talparo"," Diego Martin"," Mayaro/Rio Claro"," Penal/Debe"," Princes Town"," Sangre Grande"," San Juan/Laventille"," Siparia"," Tunapuna/Piarco" });
            //tunisia
            temp.Add(new List<string> { "Beja (Bajah)"," Ben Arous (Bin 'Arus)"," Bizerte (Banzart)"," Gabes (Qabis)"," Gafsa (Qafsah)"," Jendouba (Jundubah)"," Kairouan (Al Qayrawan)"," Kasserine (Al Qasrayn)"," Kebili (Qibili)"," Kef (Al Kaf)"," L'Ariana (Aryanah)"," Mahdia (Al Mahdiyah)"," Manouba (Manubah)"," Medenine (Madanin)"," Monastir (Al Munastir)"," Nabeul (Nabul)"," Sfax (Safaqis)"," Sidi Bouzid (Sidi Bu Zayd)"," Siliana (Silyanah)"," Sousse (Susah)"," Tataouine (Tatawin)"," Tozeur (Tawzar)"," Tunis"," Zaghouan (Zaghwan)" });
            //turkey
            temp.Add(new List<string> { "Adana"," Adiyaman"," Afyonkarahisar"," Agri"," Aksaray"," Amasya"," Ankara"," Antalya"," Ardahan"," Artvin"," Aydin"," Balikesir"," Bartin"," Batman"," Bayburt"," Bilecik"," Bingol"," Bitlis"," Bolu"," Burdur"," Bursa"," Canakkale"," Cankiri"," Corum"," Denizli"," Diyarbakir"," Duzce"," Edirne"," Elazig"," Erzincan"," Erzurum"," Eskisehir"," Gaziantep"," Giresun"," Gumushane"," Hakkari"," Hatay"," Igdir"," Isparta"," Istanbul"," Izmir (Smyrna)"," Kahramanmaras"," Karabuk"," Karaman"," Kars"," Kastamonu"," Kayseri"," Kilis"," Kirikkale"," Kirklareli"," Kirsehir"," Kocaeli"," Konya"," Kutahya"," Malatya"," Manisa"," Mardin"," Mersin"," Mugla"," Mus"," Nevsehir"," Nigde"," Ordu"," Osmaniye"," Rize"," Sakarya"," Samsun"," Sanliurfa"," Siirt"," Sinop"," Sirnak"," Sivas"," Tekirdag"," Tokat"," Trabzon (Trebizond)"," Tunceli"," Usak"," Van"," Yalova"," Yozgat"," Zonguldak" });
            //turkmenistan
            temp.Add(new List<string> { "Ahal Welayaty (Anew)"," Ashgabat*"," Balkan Welayaty (Balkanabat)"," Dasoguz Welayaty"," Lebap Welayaty (Turkmenabat)"," Mary Welayaty" });
            //Tuvalu
            temp.Add(new List<string> { "Funafuti*"," Nanumaga"," Nanumea"," Niutao"," Nui"," Nukufetau"," Nukulaelae"," Vaitupu" });

            //Uganda
            temp.Add(new List<string> { "Abim"," Adjumani"," Agago"," Alebtong"," Amolatar"," Amudat"," Amuria"," Amuru"," Apac"," Arua"," Budaka"," Bududa"," Bugiri"," Bugweri"," Buhweju"," Buikwe"," Bukedea"," Bukomansimbi"," Bukwo"," Bulambuli"," Buliisa"," Bundibugyo"," Bunyangabu"," Bushenyi"," Busia"," Butaleja"," Butambala"," Butebo"," Buvuma"," Buyende"," Dokolo"," Gomba"," Gulu"," Hoima"," Ibanda"," Iganga"," Isingiro"," Jinja"," Kaabong"," Kabale"," Kabarole"," Kaberamaido"," Kagadi"," Kakumiro"," Kalaki"," Kalangala"," Kaliro"," Kalungu"," Kampala*"," Kamuli"," Kamwenge"," Kanungu"," Kapchorwa"," Kapelebyong"," Karenga"," Kasese"," Kasanda"," Katakwi"," Kayunga"," Kazo"," Kibaale"," Kiboga"," Kibuku"," Kikuube"," Kiruhura"," Kiryandongo"," Kisoro"," Kitagwenda"," Kitgum"," Koboko"," Kole"," Kotido"," Kumi"," Kwania"," Kween"," Kyankwanzi"," Kyegegwa"," Kyenjojo"," Kyotera"," Lamwo"," Lira"," Luuka"," Luwero"," Lwengo"," Lyantonde"," Madi-Okollo"," Manafwa"," Maracha"," Masaka"," Masindi"," Mayuge"," Mbale"," Mbarara"," Mitooma"," Mityana"," Moroto"," Moyo"," Mpigi"," Mubende"," Mukono"," Nabilatuk"," Nakapiripirit"," Nakaseke"," Nakasongola"," Namayingo"," Namisindwa"," Namutumba"," Napak"," Nebbi"," Ngora"," Ntoroko"," Ntungamo"," Nwoya"," Obongi"," Omoro"," Otuke"," Oyam"," Pader"," Pakwach"," Pallisa"," Rakai"," Rubanda"," Rubirizi"," Rukiga"," Rukungiri"," Rwampara"," Sembabule"," Serere"," Sheema"," Sironko"," Soroti"," Tororo"," Wakiso"," Yumbe"," Zombo" });
            //Ukraine
            temp.Add(new List<string> { "Cherkasy"," Chernihiv"," Chernivtsi"," Crimea or Avtonomna Respublika Krym* (Simferopol)"," Dnipropetrovsk (Dnipro)"," Donetsk"," Ivano-Frankivsk"," Kharkiv"," Kherson"," Khmelnytskyi"," Kirovohrad (Kropyvnytskyi)"," Kyiv**"," Kyiv"," Luhansk"," Lviv"," Mykolaiv"," Odesa"," Poltava"," Rivne"," Sevastopol**"," Sumy"," Ternopil"," Vinnytsia"," Volyn (Lutsk)"," Zakarpattia (Uzhhorod)"," Zaporizhzhia"," Zhytomyr" });
            //United Arab
            temp.Add(new List<string> { "Abu Zaby (Abu Dhabi)"," 'Ajman"," Al Fujayrah"," Ash Shariqah (Sharjah)"," Dubayy (Dubai)"," Ra's al Khaymah"," Umm al Qaywayn" });
            //United Kingdom
            temp.Add(new List<string> { "Buckinghamshire", " Cambridgeshire", " Cumbria", " Derbyshire", " Devon", " Dorset", " East Sussex", " Essex", " Gloucestershire", " Hampshire", " Hertfordshire", " Kent", " Lancashire", " Leicestershire", " Lincolnshire", " Norfolk", " Northamptonshire", " North Yorkshire", " Nottinghamshire", " Oxfordshire", " Somerset", " Staffordshire", " Suffolk", " Surrey", " Warwickshire", " West Sussex", " Worcestershire", " Barking and Dagenham", " Barnet", " Bexley", " Brent", " Bromley", " Camden", " Croydon", " Ealing", " Enfield", " Greenwich", " Hackney", " Hammersmith and Fulham", " Haringey", " Harrow", " Havering", " Hillingdon", " Hounslow", " Islington", " Kensington and Chelsea", " Kingston upon Thames", " Lambeth", " Lewisham", " City of London", " Merton", " Newham", " Redbridge", " Richmond upon Thames", " Southwark", " Sutton", " Tower Hamlets", " Waltham Forest", " Wandsworth", " Westminster", " Barnsley", " Birmingham", " Bolton", " Bradford", " Bury", " Calderdale", " Coventry", " Doncaster", " Dudley", " Gateshead", " Kirklees", " Knowlsey", " Leeds", " Liverpool", " Manchester", " Newcastle upon Tyne", " North Tyneside", " Oldham", " Rochdale", " Rotherham", " Salford", " Sandwell", " Sefton", " Sheffield", " Solihull", " South Tyneside", " St. Helens", " Stockport", " Sunderland", " Tameside", " Trafford", " Wakefield", " Walsall", " Wigan", " Wirral", " Wolverhampton", " Bath and North East Somerset", " Bedford", " Blackburn with Darwen", " Blackpool", " Bournemouth", " Christchurch and Poole", " Bracknell Forest", " Brighton and Hove", " City of Bristol", " Central Bedfordshire", " Cheshire East", " Cheshire West and Chester", " Cornwall", " Darlington", " Derby", " Dorset", " Durham County*", " East Riding of Yorkshire", " Halton", " Hartlepool", " Herefordshire*", " Isle of Wight*", " Isles of Scilly", " City of Kingston upon Hull", " Leicester", " Luton", " Medway", " Middlesbrough", " Milton Keynes", " North East Lincolnshire", " North Lincolnshire", " North Somerset", " Northumberland*", " Nottingham", " Peterborough", " Plymouth", " Portsmouth", " Reading", " Redcar and Cleveland", " Rutland", " Shropshire", " Slough", " South Gloucestershire", " Southampton", " Southend-on-Sea", " Stockton-on-Tees", " Stoke-on-Trent", " Swindon", " Telford and Wrekin", " Thurrock", " Torbay", " Warrington", " West Berkshire", " Wiltshire", " Windsor and Maidenhead", " Wokingham", " York", " Antrim and Newtownabbey", " Ards and North Down", " Armagh City", " Banbridge", " and Craigavon", " Causeway Coast and Glens", " Mid and East Antrim", " Derry City and Strabane", " Fermanagh and Omagh", " Mid Ulster", " Newry", " Murne", " and Down", " Aberdeen City", " Aberdeenshire", " Angus", " Argyll and Bute", " Clackmannanshire", " Dumfries and Galloway", " Dundee City", " East Ayrshire", " East Dunbartonshire", " East Lothian", " East Renfrewshire", " City of Edinburgh", " Eilean Siar (Western Isles)", " Falkirk", " Fife", " Glasgow City", " Highland", " Inverclyde", " Midlothian", " Moray", " North Ayrshire", " North Lanarkshire", " Orkney Islands", " Perth and Kinross", " Renfrewshire", " Shetland Islands", " South Ayrshire", " South Lanarkshire", " Stirling", " The Scottish Borders", " West Dunbartonshire", " West Lothian", " Blaenau Gwent", " Bridgend", " Caerphilly", " Cardiff", " Carmarthenshire", " Ceredigion", " Conwy", " Denbighshire", " Flintshire", " Gwynedd", " Isle of Anglesey", " Merthyr Tydfil", " Monmouthshire", " Neath Port Talbot", " Newport", " Pembrokeshire", " Powys", " Rhondda Cynon Taff", " Swansea", " The Vale of Glamorgan", " Torfaen", " Wrexham" });
            //United States
            temp.Add(new List<string> { "Alabama"," Alaska"," Arizona"," Arkansas"," California"," Colorado"," Connecticut"," Delaware"," District of Columbia*"," Florida"," Georgia"," Hawaii"," Idaho"," Illinois"," Indiana"," Iowa"," Kansas"," Kentucky"," Louisiana"," Maine"," Maryland"," Massachusetts"," Michigan"," Minnesota"," Mississippi"," Missouri"," Montana"," Nebraska"," Nevada"," New Hampshire"," New Jersey"," New Mexico"," New York"," North Carolina"," North Dakota"," Ohio"," Oklahoma"," Oregon"," Pennsylvania"," Rhode Island"," South Carolina"," South Dakota"," Tennessee"," Texas"," Utah"," Vermont"," Virginia"," Washington"," West Virginia"," Wisconsin"," Wyoming" });
            //Uruguay
            temp.Add(new List<string> { "Artigas"," Canelones"," Cerro Largo"," Colonia"," Durazno"," Flores"," Florida"," Lavalleja"," Maldonado"," Montevideo"," Paysandu"," Rio Negro"," Rivera"," Rocha"," Salto"," San Jose"," Soriano"," Tacuarembo"," Treinta y Tres" });
            //Uzbekistan
            temp.Add(new List<string> { "Andijon Viloyati"," Buxoro Viloyati [Bukhara Province]"," Farg'ona Viloyati [Fergana Province]"," Jizzax Viloyati"," Namangan Viloyati"," Navoiy Viloyati"," Qashqadaryo Viloyati (Qarshi)"," Qoraqalpog'iston Respublikasi [Karakalpakstan Republic]* (Nukus)"," Samarqand Viloyati [Samarkand Province]"," Sirdaryo Viloyati (Guliston)"," Surxondaryo Viloyati (Termiz)"," Toshkent Shahri [Tashkent City]**"," Toshkent Viloyati [Tashkent Province]"," Xorazm Viloyati (Urganch)" });

            //Vanuatu
            temp.Add(new List<string> { "Malampa"," Penama"," Sanma"," Shefa"," Tafea"," Torba" });
            //Venezuela
            temp.Add(new List<string> { "Amazonas"," Anzoategui"," Apure"," Aragua"," Barinas"," Bolivar"," Carabobo"," Cojedes"," Delta Amacuro"," Dependencias Federales (Federal Dependencies)**"," Distrito Capital (Capital District)*"," Falcon"," Guarico"," Lara"," Merida"," Miranda"," Monagas"," Nueva Esparta"," Portuguesa"," Sucre"," Tachira"," Trujillo"," Vargas"," Yaracuy"," Zulia" });
            //Vietnam
            temp.Add(new List<string> { "An Giang"," Bac Giang"," Bac Kan"," Bac Lieu"," Bac Ninh"," Ba Ria-Vung Tau"," Ben Tre"," Binh Dinh"," Binh Duong"," Binh Phuoc"," Binh Thuan"," Ca Mau"," Cao Bang", "Can Tho", "Da Nang", " Dak Lak"," Dak Nong"," Dien Bien"," Dong Nai"," Dong Thap"," Gia Lai"," Ha Giang"," Ha Nam", "Hanoi", " Ha Tinh"," Hai Duong", "Hai Phong", " Hau Giang", "Ho chi Minh City (Saigon)", " Hoa Binh"," Hung Yen"," Khanh Hoa"," Kien Giang"," Kon Tum"," Lai Chau"," Lam Dong"," Lang Son"," Lao Cai"," Long An"," Nam Dinh"," Nghe An"," Ninh Binh"," Ninh Thuan"," Phu Tho"," Phu Yen"," Quang Binh"," Quang Nam"," Quang Ngai"," Quang Ninh"," Quang Tri"," Soc Trang"," Son La"," Tay Ninh"," Thai Binh"," Thai Nguyen"," Thanh Hoa"," Thua Thien-Hue"," Tien Giang"," Tra Vinh"," Tuyen Quang"," Vinh Long"," Vinh Phuc"," Yen Bai" });

            //Yemen
            temp.Add(new List<string> { "Abyan"," 'Adan (Aden)"," Ad Dali'"," Al Bayda'"," Al Hudaydah"," Al Jawf"," Al Mahrah"," Al Mahwit"," Amanat al 'Asimah (Sanaa City)"," 'Amran"," Arkhabil Suqutra (Socotra Archipelago)"," Dhamar"," Hadramawt"," Hajjah"," Ibb"," Lahij"," Ma'rib"," Raymah"," Sa'dah"," San'a' (Sanaa)"," Shabwah"," Ta'izz" });
            
            //Zambia
            temp.Add(new List<string> { "Central"," Copperbelt"," Eastern"," Luapula"," Lusaka"," Muchinga"," Northern"," North-Western"," Southern"," Western" });
            //Zimbabwe
            temp.Add(new List<string> { "Bulawayo*"," Harare*"," Manicaland"," Mashonaland Central"," Mashonaland East"," Mashonaland West"," Masvingo"," Matabeleland North"," Matabeleland South"," Midlands" });

            //temp.Add(new List<string> { "" });
            return temp;
        }
        #endregion

        public ActionResult ListOfCountries()
        {
            List<string> temp = new List<string>();

            temp.Add("Australia");
            temp.Add("China");
            temp.Add("Samoa");

            return Json(temp, JsonRequestBehavior.AllowGet);
        }

        List<string> countryList = new List<string>();

        #region Filling list of countries
        public List<string> GetCountries(ref List<string> temp)
        {
            //A11
            temp.Add("Afghanistan");
            temp.Add("Albania");
            temp.Add("Algeria");
            temp.Add("Andorra");
            temp.Add("Angola");
            temp.Add("Antigua and Barbuda");
            temp.Add("Argentina");
            temp.Add("Armenia");
            temp.Add("Australia");
            temp.Add("Austria");
            temp.Add("Azerbaijan");

            //B19
            temp.Add("Bahamas, The");
            temp.Add("Bahrain");
            temp.Add("Bangladesh");
            temp.Add("Barbados");
            temp.Add("Belarus");
            temp.Add("Belgium");
            temp.Add("Belize");
            temp.Add("Benin(Dahomey)");
            temp.Add("Bermuda");
            temp.Add("Bhutan");
            temp.Add("Bolivia");
            temp.Add("Bosnia and Herzegovina");
            temp.Add("Botswana");
            temp.Add("Brazil");
            temp.Add("Brunei");
            temp.Add("Bulgaria");
            temp.Add("Burkina Faso");
            temp.Add("Burma");
            temp.Add("Burundi");

            //C17
            temp.Add("Cabo Verde");
            temp.Add("Cambodia");
            temp.Add("Cameroon");
            temp.Add("Canada");
            temp.Add("Cayman Islands, The");
            temp.Add("Central African Republic");
            temp.Add("Chad");
            temp.Add("Chile");
            temp.Add("China");
            temp.Add("Colombia");
            temp.Add("Comoros");
            temp.Add("Costa Rica");
            temp.Add("Cote d’Ivoire(Ivory Coast)");
            temp.Add("Croatia");
            temp.Add("Cuba");
            temp.Add("Cyprus");
            temp.Add("Czechia");

            //D5
            temp.Add("Democratic Republic of the Congo");
            temp.Add("Denmark");
            temp.Add("Djibouti");
            temp.Add("Dominica");
            temp.Add("Dominican Republic");

            //E9
            temp.Add("Ecuador");
            temp.Add("Egypt");
            temp.Add("El Salvador");
            temp.Add("Equatorial Guinea");
            temp.Add("Eritrea");
            temp.Add("Estonia");
            temp.Add("Eswatini");
            temp.Add("Ethiopia");

            //F3
            temp.Add("Faroe Islands (Isls Malvinas)");
            temp.Add("Fiji");
            temp.Add("Finland");
            temp.Add("France");
            temp.Add("French Polynesia");

            //G12
            temp.Add("Gabon");
            temp.Add("Gambia, The");
            temp.Add("Georgia");
            temp.Add("Germany");
            temp.Add("Ghana");
            temp.Add("Greece");
            temp.Add("Greenland");
            temp.Add("Grenada");
            temp.Add("Guatemala");
            temp.Add("Guinea");
            temp.Add("Guinea - Bissau");
            temp.Add("Guyana");

            //H4
            temp.Add("Haiti");
            temp.Add("Holy See");
            temp.Add("Honduras");
            temp.Add("Hungary");

            //I8
            temp.Add("Iceland");
            temp.Add("India");
            temp.Add("Indonesia");
            temp.Add("Iran");
            temp.Add("Iraq");
            temp.Add("Ireland");
            temp.Add("Israel");
            temp.Add("Italy");

            //J3
            temp.Add("Jamaica");
            temp.Add("Japan");
            temp.Add("Jordan");

            //K7
            temp.Add("Kazakhstan");
            temp.Add("Kenya");
            temp.Add("Kiribati");
            temp.Add("South Korea");
            temp.Add("Kosovo");
            temp.Add("Kuwait");
            temp.Add("Kyrgyzstan");

            //L
            temp.Add("Laos");
            temp.Add("Latvia");
            temp.Add("Lebanon");
            temp.Add("Lesotho");
            temp.Add("Liberia");
            temp.Add("Libya");
            temp.Add("Liechtenstein");
            temp.Add("Lithuania");
            temp.Add("Luxembourg");

            //M
            temp.Add("Madagascar");
            temp.Add("Malawi");
            temp.Add("Malaysia");
            temp.Add("Maldives");
            temp.Add("Mali");
            temp.Add("Malta");
            temp.Add("Marshall Islands");
            temp.Add("Mauritania");
            temp.Add("Mauritius");
            temp.Add("Mexico");
            temp.Add("Micronesia");
            temp.Add("Moldova");
            temp.Add("Monaco");
            temp.Add("Mongolia");
            temp.Add("Montenegro");
            temp.Add("Montserrat");
            temp.Add("Morocco");
            temp.Add("Mozambique");

            //N
            temp.Add("Namibia");
            temp.Add("Nauru");
            temp.Add("Nepal");
            temp.Add("Netherlands, The");
            temp.Add("New Caledonia");
            temp.Add("New Zealand");
            temp.Add("Nicaragua");
            temp.Add("Niger");
            temp.Add("Nigeria");
            temp.Add("North Macedonia");
            temp.Add("Norway");

            //O
            temp.Add("Oman");

            //P
            temp.Add("Pakistan");
            temp.Add("Palau");
            temp.Add("Panama");
            temp.Add("Papua New Guinea");
            temp.Add("Paraguay");
            temp.Add("Peru");
            temp.Add("Philippines");
            temp.Add("Poland");
            temp.Add("Portugal");
            temp.Add("Puerto Rico");

            //Q
            temp.Add("Qatar");

            //R
            temp.Add("Romania");
            temp.Add("Russia");
            temp.Add("Rwanda");

            //S26
            temp.Add("Saint Helena, Ascension, and Tristan da Cunha");
            temp.Add("Saint Kitts and Nevis");
            temp.Add("Saint Lucia");
            temp.Add("Saint Vincent and the Grenadines");
            temp.Add("Samoa");
            temp.Add("San Marino");
            temp.Add("Sao Tome and Principe");
            temp.Add("Saudi Arabia");
            temp.Add("Senegal");
            temp.Add("Serbia");
            temp.Add("Seychelles");
            temp.Add("SierraLeone");
            temp.Add("Singapore");
            temp.Add("Slovakia");
            temp.Add("Slovenia");
            temp.Add("Solomon Islands, The");
            temp.Add("Somalia");
            temp.Add("South Africa");
            temp.Add("South Sudan");
            temp.Add("Spain");
            temp.Add("Sri Lanka");
            temp.Add("Sudan");
            temp.Add("Suriname");
            temp.Add("Sweden");
            temp.Add("Switzerland");
            temp.Add("Syria");

            //T
            temp.Add("Taiwan");
            temp.Add("Tajikistan");
            temp.Add("Tanzania");
            temp.Add("Thailand");
            temp.Add("Timor - Leste");
            temp.Add("Togo");
            temp.Add("Tonga");
            temp.Add("Trinidad and Tobago");
            temp.Add("Tunisia");
            temp.Add("Turkey");
            temp.Add("Turkmenistan");
            temp.Add("Tuvalu");

            //U7
            temp.Add("Uganda");
            temp.Add("Ukraine");
            temp.Add("United Arab Emirates, The");
            temp.Add("United Kingdom, The");
            temp.Add("United States, The");
            temp.Add("Uruguay");
            temp.Add("Uzbekistan");

            //V3
            temp.Add("Vanuatu");
            temp.Add("Venezuela");
            temp.Add("Vietnam");

            //Y1
            temp.Add("Yemen");

            //Z2
            temp.Add("Zambia");
            temp.Add("Zimbabwe");
            return temp;
        }
        #endregion

        public ActionResult GetPlaces(string countryName)
        {
            if(countryName == "-- Select --")
            {
                countryName = "Afghanistan";
            }
            countryList = GetCountries(ref countryList);
            int index = countryList.IndexOf(countryName);
            List<List<string>> full = GetListOfRegions();
            Debug.WriteLine(index);
            var names = full[index];
            /* Used For testing ajax call
            Debug.WriteLine("Function can get to here");
            List<string> test = new List<string>
            {
                "Data 1",
                "Data 2"
            };
            */
            return Json(names, JsonRequestBehavior.AllowGet);
            /*
            return new ContentResult
            {
                Content = "Something",
                ContentType = "application/json",
                ContentEncoding = System.Text.Encoding.UTF8
            };
            */
        }


    }



}