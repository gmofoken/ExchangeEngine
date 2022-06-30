using ExchangeEngine.Data.DataObject;
using ExchangeEngine.Data.RequestResponseDTOs;

namespace ExchangeEngine.Ochestration.Interfaces
{
    public interface IMapTimeSeries
    {
        public PerfomanceData MapTimeSeriesData(string data);

        public ChartDTO[] MapChartData(PerfomanceData data);

        public ChartDTO[] MapVolumeData(PerfomanceData data);
    }
}