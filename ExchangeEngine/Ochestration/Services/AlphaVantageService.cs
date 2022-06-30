using ExchangeEngine.Data.DataObject;
using ExchangeEngine.Ochestration.Interfaces;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;

namespace ExchangeEngine.Ochestration.Services
{
    public class AlphaVantageService : IAlphaVantage
    {
        private readonly IConfiguration _Configuration;
        private readonly IMapTimeSeries _MapTimeSeries;

        public AlphaVantageService(IConfiguration configuration, IMapTimeSeries mapTimeSeries)
        {
            _Configuration = configuration;
            _MapTimeSeries = mapTimeSeries;
        }

        public PerfomanceData AlphaVantageData(string symbol)
        {
            try
            {
                var client = new RestClient($"https://alpha-vantage.p.rapidapi.com/query?function=TIME_SERIES_DAILY&symbol={symbol}&outputsize=compact&datatype=json");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("X-RapidAPI-Key", _Configuration.GetSection("X-RapidAPI-Key").Value);
                IRestResponse response = client.Execute(request);

                if (response.Content.Contains("Error Message"))
                    throw new Exception("Invalid API call.");

                if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                    throw new Exception("You have exceeded the rate limit per minute for your plan, BASIC, by the API provider");

                return _MapTimeSeries.MapTimeSeriesData(response.Content);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}