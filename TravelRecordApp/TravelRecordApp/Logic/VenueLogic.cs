﻿using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelRecordApp.Model;

namespace TravelRecordApp.Logic
{
    class VenueLogic
    {
        public async static Task<List<Venue>> GetVenues(double longitude, double latitude) 
        {
            List<Venue> venues = new List<Venue>();

            var url = Venue.GenerateURL(longitude, latitude);

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
            }


            return venues;
        }
    }
}

