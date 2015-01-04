using Common.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;
using System.Threading;

namespace Common
{
    public static class DataRequest
    {
        public static async Task<List<T>> PollBikeApiAsync<T>(string baseAddress, string query)
        {
            var results = new List<T>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    results = await response.Content.ReadAsAsync<List<T>>();
                }
                return results;
            }
        }
    }
}
