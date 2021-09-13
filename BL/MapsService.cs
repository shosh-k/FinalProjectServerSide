using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static BL.LocationBase;

namespace BL
{
    public class MapsService
    {
        public MapsService()
        {

        }
        public async Task<string> GetDistance(string origin, string destination)
        {
            string[] locationUrls = { BuildUrlForLocationId(origin), BuildUrlForLocationId(destination) },
                idLocations = new string[2];

            HttpClient http = new HttpClient();
            try
            {
                for (int i = 0; i < idLocations.Length; i++)
                {
                    var responseId = Task.Run(() => http.GetAsync(locationUrls[i]));

                    if (responseId.Result != null)
                    {
                        var result = await responseId.Result.Content.ReadAsStringAsync();

                        RootLocationBase root = JsonConvert.DeserializeObject<RootLocationBase>(result);
                        idLocations[i] = root.results[0].place_id;
               
                    }
                }
            }
            catch (Exception)
            {

            }

            var responseDistance = Task.Run(() => http.GetAsync(BuildUrlForDistance(idLocations[0], idLocations[1])));

            if (responseDistance.Result != null)
            {
                var result = await responseDistance.Result.Content.ReadAsStringAsync();
                DistanceBase root = JsonConvert.DeserializeObject<DistanceBase>(result);
                return root.rows[0].elements[0].distance.text;
            }
            return "";
        }
        static string BuildUrlForLocationId(string address)
        {
            string location = "";
            string [] locationAsArray;
            locationAsArray = address.Split(' ');

            for (int i = 0; i < locationAsArray.Length; i++)
            {
                if (i < locationAsArray.Length - 1)
                    location += locationAsArray[i] + "+";
                else
                    location += locationAsArray[i];
            }
            return "https://maps.googleapis.com/maps/api/place/textsearch/json?key=AIzaSyD9Ki7n3lc3b3o63q0Kb9vaB_iEz12Jnic&query="
             + location;
        }

        static string BuildUrlForDistance(string place1, string place2)
        {
            string url = "https://maps.googleapis.com/maps/api/distancematrix/json?key=AIzaSyD9Ki7n3lc3b3o63q0Kb9vaB_iEz12Jnic&units=imperial&origins=";
            return url + "place_id:" + place1 + "&destinations=place_id:" + place2;
           
        }

    }
}
//AIzaSyD9Ki7n3lc3b3o63q0Kb9vaB_iEz12Jnic