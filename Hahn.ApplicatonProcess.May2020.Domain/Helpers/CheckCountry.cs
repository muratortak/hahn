using FluentValidation;
using FluentValidation.Results;
using FluentValidation.Validators;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.May2020.Domain.Helpers
{
    public static class CheckCountry
    {
        public static bool isCountryValid(string country)
        {
            HttpClient client = new HttpClient();

            var uri = new Uri($"https://restcountries.eu/rest/v2/name/{country}?fullText=true");
            var response = client.GetAsync(uri).Result;
    
            return response.IsSuccessStatusCode;
        }

    }
}
