using ExchangeEngine.Data.RequestResponseDTOs;
using ExchangeEngine.Ochestration.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeEngine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SecuritiesController : ControllerBase
    {
        private readonly ISecurities _Handler;

        public SecuritiesController(ISecurities securities)
        {
            _Handler = securities;
        }

        [HttpGet("getchartdata")]
        public ActionResult<object> GetChartData(string symbol)
        {
            try
            {
                var result = new {symbol = symbol, data = _Handler.HandleChartData(symbol) };

                return Ok(result);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("getvolumedata")]
        public ActionResult<object> GetChartVolumeData(string symbol)
        {
            try
            {
                var result = new { symbol = symbol, data = _Handler.HandleVolumeData(symbol) };

                return Ok(result);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}