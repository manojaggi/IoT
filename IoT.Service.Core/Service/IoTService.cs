using IoT.Core.Constant;
using IoT.Core.Entity;
using IoT.Core.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoT.Service.Core.Service
{
    public class IoTService : IIoTService
    {
        private readonly IoTDbContext _dbContext;

        public IoTService(IoTDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<TelemetryDataModel>> GetTelemetryData(int deviceId)
        {
            var device = _dbContext.Devices.FirstOrDefault(x => x.Id == deviceId);

            List<TelemetryDataModel> data = new List<TelemetryDataModel>();
            if (device != null)
            {
                List<TelemetryData> result=new List<TelemetryData>();
                if (device.FilterType == Constant.gt)
                {
                    result = _dbContext.TelemetryDatas
                        .Where(x => x.DeviceConfigId == device.Id && x.DataValue > device.FilterValue).ToList();
                }
                else if (device.FilterType == Constant.lt)
                {
                    result = _dbContext.TelemetryDatas
                        .Where(x => x.DeviceConfigId == device.Id && x.DataValue < device.FilterValue).ToList();
                }

                data = result.Select(td => new TelemetryDataModel
                {
                    DataValue = td.DataValue
                }).ToList();
            }

            return Task.FromResult(data);
        }

        public Task<bool> PostDeviceData(int deviceId, int dataValue)
        {
            var telemetryData = new TelemetryData
            {
                DeviceConfigId = deviceId,
                DataValue = dataValue
            };
            _dbContext.TelemetryDatas.Add(telemetryData);
            _dbContext.SaveChanges();

            return Task.FromResult(true);
        }

        public Task<bool> SetupDeviceFilter(int id, string filterType, int filterVal)
        {
            Device device = _dbContext.Devices.FirstOrDefault(x => x.Id == id);

            if (device == null)
            {
                device = new Device
                {
                    FilterType = filterType,
                    FilterValue = filterVal
                };
                _dbContext.Devices.Add(device);
            }
            else
            {
                device.FilterType = filterType;
                device.FilterValue = filterVal;
            }

            _dbContext.SaveChanges();
            return Task.FromResult(true);
        }
    }
}
