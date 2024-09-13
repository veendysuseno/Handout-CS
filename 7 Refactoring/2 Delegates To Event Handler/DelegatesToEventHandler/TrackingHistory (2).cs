using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesToEventHandler {

    public class TrackingHistory {

        public string Location { get; set; }
        public DateTime TrackingDate { get; set; }
        public string Description { get; set; }

        public TrackingHistory(string location, DateTime trackingDate, string description) {
            this.Location = location;
            this.TrackingDate = trackingDate;
            this.Description = description;
        }

    }
}
