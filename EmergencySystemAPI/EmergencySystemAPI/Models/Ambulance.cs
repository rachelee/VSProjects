using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmergencySystemAPI.Models
{
    public enum Status
    {
        idle, busy
    }
    public class Ambulance
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public Status? Status { get; set; }
        public virtual Hospital Hospital { get; set; }
    }
}