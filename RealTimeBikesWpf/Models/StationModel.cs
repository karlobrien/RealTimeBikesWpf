using Common;
using Common.DataObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealTimeBikesWpf.Models
{
    public class StationModel
    {
        public ObservableCollection<Station> AllStations { get; set; }

        public async Task<Station> GetStation(string station)
        {
            var apiKey = "252cb0a2367da01896c41c9d6cd4c05d604bb6ba";
            var query = String.Format("?contract=dublin&apiKey={0}", apiKey);

            var test = await DataRequest.PollBikeApiAsync<Station>("https://api.jcdecaux.com/vls/v1/stations", query);

            var walk = test.Where(t => t.Name == station).FirstOrDefault();
            return walk;
        }

        public async Task<ObservableCollection<Station>> GetAllStations()
        {
            var apiKey = "252cb0a2367da01896c41c9d6cd4c05d604bb6ba";
            var query = String.Format("?contract=dublin&apiKey={0}", apiKey);
            var allStations = await DataRequest.PollBikeApiAsync<Station>("https://api.jcdecaux.com/vls/v1/stations", query);

            return new ObservableCollection<Station>(allStations);
        }
    }
}
