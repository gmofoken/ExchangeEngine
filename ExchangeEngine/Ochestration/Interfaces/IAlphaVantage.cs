using ExchangeEngine.Data.DataObject;

namespace ExchangeEngine.Ochestration.Interfaces
{
    public interface IAlphaVantage
    {
        public PerfomanceData AlphaVantageData(string symbol);
    }
}