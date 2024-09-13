using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesToEventHandler {
    public class ExpeditionEventArgs : EventArgs{
        public List<TrackingHistory> TrackingHistories { get; set; }
    }
}
