using Common;
using Common.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeBikesWpf
{
    public class Model
    {
        public Station station { get; set; }

        public Model()
        {
            station = new Station { 
                Name = "Stephens Green", Available_Bikes = "0", Available_Bike_Stands = "0", 
                Bike_Stands = "0", TimeStamp = DateTime.Now,
                Address = "Dublin", Banking = true
            };
        }

        public async Task<Station> GetStation(string station)
        {
            var apiKey = "252cb0a2367da01896c41c9d6cd4c05d604bb6ba";
            var query = String.Format("?contract=dublin&apiKey={0}", apiKey);

            var test = await DataRequest.PollBikeApiAsync<Station>("https://api.jcdecaux.com/vls/v1/stations", query);

            var walk = test.Where(t => t.Name == station).FirstOrDefault();
            return walk;
        }

        

    }
}
