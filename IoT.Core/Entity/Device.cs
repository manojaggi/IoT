using System;
using System.Collections.Generic;
using System.Text;

namespace IoT.Core.Entity
{
   public class Device
    {
        public int Id { get; set; }
        public string FilterType { get; set; }
        public int FilterValue { get; set; }

        public virtual ICollection<TelemetryData> TelemetryDatas { get; set; }
    }
}
