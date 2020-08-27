using System;
using System.Collections.Generic;
using System.Text;

namespace IoT.Core.Entity
{
   public class TelemetryData
    {
        public int Id { get; set; }
        public int DataValue { get; set; }
        public int DeviceConfigId { get; set; }
    }
}
