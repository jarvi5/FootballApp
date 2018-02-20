﻿using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System;

namespace FootballApp.Data
{
    public class DataManager
    {
        public HttpClient httpClient { get; set; }
        const string url = "http://www.football-data.org/v1/";
        private int season = DateTime.Now.Month > 7 ? DateTime.Now.Year : DateTime.Now.Year - 1;

        public DataManager() {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<IEnumerable<League>> GetAllLeagues()
        {
            string result = await httpClient.GetStringAsync(url + "competitions/?season=" + season);
            return JsonConvert.DeserializeObject<IEnumerable<League>>(result);
        }
    }
}