using System;
using System.Collections.Generic;
using System.Text;

namespace IoT.Core.Model
{
    public class DeviceConfigModel
    {
        public int Id { get; set; }
        public ICollection<TelemetryDataModel> TelemetryDataDetails { get; set; }
    }
}
