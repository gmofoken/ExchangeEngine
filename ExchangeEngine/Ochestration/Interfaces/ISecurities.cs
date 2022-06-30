using ExchangeEngine.Data.RequestResponseDTOs;

namespace ExchangeEngine.Ochestration.Interfaces
{
    public interface ISecurities
    {
        public ChartDTO[] HandleChartData(string symbol);

        public ChartDTO[] HandleVolumeData(string symbol);
    }
}
