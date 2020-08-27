using IoT.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IoT.Service.Core.Service
{
    public interface IIoTService
    {
        Task<List<TelemetryDataModel>> GetTelemetryData(int deviceId);
        Task<bool> PostDeviceData(int id, int dataValue);
        Task<bool> SetupDeviceFilter(int id, string filterType, int filterVal);

    }
}
