using ExchangeEngine.Data.DataObject;
using ExchangeEngine.Data.RequestResponseDTOs;
using ExchangeEngine.Ochestration.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExchangeEngine.Ochestration.Mapping
{
    public class MapTimeSeriesData : IMapTimeSeries
    {
        PerfomanceData IMapTimeSeries.MapTimeSeriesData(string data)
        {
            try
            {
            }
            catch (Exception)
            {
                throw;
            }

            var result = JsonConvert.DeserializeObject<PerfomanceData>(data);
            result.TimeSeries = new List<TimeSeries>();

            dynamic json = JsonConvert.DeserializeObject(data);

            foreach (var item in json["Time Series (Daily)"])
            {
                result.TimeSeries.Add(new TimeSeries()
                {
                    Time = item.Name,
                    Values = JsonConvert.DeserializeObject<Values>(item.Value.ToString())
                });
            }

            return result;
        }

        ChartDTO[] IMapTimeSeries.MapChartData(PerfomanceData data)
        {
            return data.TimeSeries.Select(result => new ChartDTO()
            {
                x = DateTime.Parse(result.Time),
                y = new decimal[4] { decimal.Parse(result.Values.Open), decimal.Parse(result.Values.High), decimal.Parse(result.Values.Low), decimal.Parse(result.Values.Close) }
            }).ToArray();
        }

        ChartDTO[] IMapTimeSeries.MapVolumeData(PerfomanceData data)
        {
            return data.TimeSeries.Select(result => new ChartDTO()
            {
                x = DateTime.Parse(result.Time),
                y = new decimal[1] { decimal.Parse(result.Values.Volume)}
            }).ToArray();
        }
    }
}