using ExchangeEngine.Data.RequestResponseDTOs;
using ExchangeEngine.Ochestration.Interfaces;
using System;

namespace ExchangeEngine.Ochestration.Handlers
{
    public class SecuritiesHandler : ISecurities
    {
        private readonly IMapTimeSeries _MapTimeSeries;
        private readonly IAlphaVantage _AlphaVantageService;

        public SecuritiesHandler(IMapTimeSeries mapTimeSeries, IAlphaVantage alphaVantageService)
        {
            _MapTimeSeries = mapTimeSeries;
            _AlphaVantageService = alphaVantageService;
        }

        public ChartDTO[] HandleChartData(string symbol)
        {
            try
            {
                var data = _AlphaVantageService.AlphaVantageData(symbol);

                if (data.TimeSeries == null)
                    return new ChartDTO[0];
                return _MapTimeSeries.MapChartData(data);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ChartDTO[] HandleVolumeData(string symbol)
        {
            try
            {
                var data = _AlphaVantageService.AlphaVantageData(symbol);

                var test = _MapTimeSeries.MapVolumeData(data);

                if (data.TimeSeries == null)
                    return new ChartDTO[0];
                return _MapTimeSeries.MapVolumeData(data);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}