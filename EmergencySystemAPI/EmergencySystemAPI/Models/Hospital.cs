using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmergencySystemAPI.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string AddressNo { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public string AddressState { get; set; }
        public string AddressZip { get; set; }
        public Boolean Emergency { get; set; }
        public virtual ICollection<Ambulance> Ambulances { get; set; }
    }
}