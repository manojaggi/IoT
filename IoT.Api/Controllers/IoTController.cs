using IoT.Service.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IoT.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IoTController : ControllerBase
    {
        private readonly IIoTService _ioTService;
        public IoTController(IIoTService ioTService)
        {
            _ioTService = ioTService;
        }

        [HttpPost("device/{deviceId}/setupfilter/{filtertype}/{filterval}")]
        public async Task<IActionResult> SetUpDeviceFilter(int deviceId, string filterType = "gt", int filterVal = 0)
        {
            var result = await _ioTService.SetupDeviceFilter(deviceId, filterType, filterVal);
            return Ok(result);
        }

        [HttpPost("device/{deviceId}/data/{dataValue}")]
        public async Task<IActionResult> AddDeviceData(int deviceId, int dataValue)
        {
            var result = await _ioTService.PostDeviceData(deviceId, dataValue);
            return Ok(result);
        }

        [HttpGet("device/{id}/data")]
        public async Task<IActionResult> GetTelemetryData(int id)
        {
            var result = await _ioTService.GetTelemetryData(id);
            return Ok(result);
        }
    }
}