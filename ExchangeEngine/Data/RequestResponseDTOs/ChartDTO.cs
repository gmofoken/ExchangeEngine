using System;

namespace ExchangeEngine.Data.RequestResponseDTOs
{
    public class ChartDTO
    {
        public DateTime x { get; set; }
        public decimal[] y { get; set; }
    }
}