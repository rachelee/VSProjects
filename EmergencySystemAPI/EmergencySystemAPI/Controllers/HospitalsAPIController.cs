using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EmergencySystemAPI.DAL;
using EmergencySystemAPI.Models;
using System.Xml;
using System.Web.Http.Cors;

namespace EmergencySystemAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HospitalsAPIController : ApiController
    {
        private EmergencyContext db = new EmergencyContext();

        // GET: api/HospitalsAPI
        [Route("api/HospitalsAPI"), HttpGet]
        public IQueryable<Hospital> GetHospitals()
        {
            return db.Hospitals;
        }
        // GET: api/HospitalsAPI/HospitalWithER
        [Route("api/HospitalsAPI/HospitalWithER"), HttpGet]
        public IQueryable<Hospital> HospitalWithER()
        {
            var hospitals = from h in db.Hospitals
                            //where h.Emergency == true
                            select h;
            hospitals = hospitals.Where(h => h.Emergency.Equals(true));
            return hospitals;
        }

        // GET: Hospitals/NearestHospital
        [Route("api/HospitalsAPI/NearestHospital"), HttpGet]
        [ResponseType(typeof(Hospital))]
        public IHttpActionResult NearestHospital(double lat, double lng)
        {
            var hospitals = from h in db.Hospitals
                            where h.Emergency == true
                            select h;
            //hospitals = hospitals.Where(h => h.Emergency.Equals(true));
            String startPoint = lat + "," + lng;
            Hospital nearest = null;
            try
            {
                int nearestTime = Int32.MaxValue;
                foreach (var item in hospitals)
                {
                    String endPoint = item.AddressNo + item.AddressStreet + "," +
                        item.AddressCity + "," + item.AddressState;

                    if (int.Parse(getTravelTime(startPoint, endPoint)) < nearestTime)
                    {
                        nearestTime = int.Parse(getTravelTime(startPoint, endPoint));
                        nearest = item;
                    }
                }
            }
            catch (Exception e)
            {
                //
            }
            return Ok(nearest);
        }

        // GET: 
        [Route("api/HospitalsAPI/NearestHospital"), HttpGet]
        [ResponseType(typeof(Hospital))]
        public String NearestHospital(string address)
        {
            string lat;
            string lng;
            try
            {
                String strResult;
                var url = "https://maps.googleapis.com/maps/api/geocode/xml?address=" + address + "&key=AIzaSyA-1WrgrK-s9zq3VSJYkxJS4y1uxTG_u9k";

                using (var client = new WebClient())
                {
                    strResult = client.DownloadString(url);
                }
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(strResult); // suppose that myXmlString contains "<Names>...</Names>"

                XmlNodeList xnList = xml.SelectNodes("GeocodeResponse/result/geometry/location");
                XmlNode xn = xnList[0];

                lat = xn["lat"].InnerText;
                lng = xn["lng"].InnerText;
            }
            catch (Exception e)
            {
                lat = "0";
                lng = "0";
            }
            var hospitals = from h in db.Hospitals
                            where h.Emergency == true
                            select h;
            //hospitals = hospitals.Where(h => h.Emergency.Equals(true));
            String startPoint = lat + "," + lng;
            Hospital nearest = null;
            try
            {
                int nearestTime = Int32.MaxValue;
                foreach (var item in hospitals)
                {
                    String endPoint = item.AddressNo + item.AddressStreet + "," +
                        item.AddressCity + "," + item.AddressState;

                    if (int.Parse(getTravelTime(startPoint, endPoint)) < nearestTime)
                    {
                        nearestTime = int.Parse(getTravelTime(startPoint, endPoint));
                        nearest = item;
                    }
                }
            }
            catch (Exception e)
            {
                //
            }
            
            String Name = nearest.Name;
            String Address = nearest.AddressNo + " " + nearest.AddressStreet + "," + nearest.AddressCity + "," + nearest.AddressState;
            String returnResult = Name + "/" + Address;
            return returnResult;
        }

        //helper function for get nearest hospital
        protected String getTravelTime(String startLocation, String endLocation)
        {
            String result = null;
            try
            {
                String strResult;
                DateTime dt = DateTime.UtcNow;
                DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                int s = (int)(dt - epoch).TotalSeconds;
                String now = s.ToString();
                var url = "https://maps.googleapis.com/maps/api/directions/xml?origin=" + startLocation + "&destination=" + endLocation + "&key=AIzaSyBBRvdqkbesH8r1nWFuvF5sbBPu5i-bE-I&departure_time=" + now;

                using (var client = new WebClient())
                {
                    strResult = client.DownloadString(url);
                }
                XmlDocument xml = new XmlDocument();
                xml.LoadXml(strResult); // suppose that myXmlString contains "<Names>...</Names>"

                XmlNodeList xnList = xml.SelectNodes("DirectionsResponse/route/leg/duration");
                XmlNode xn = xnList[0];
                result = xn["value"].InnerText;
            }
            catch
            {
                //this.TextBox1.Text = "offline";
                //String[] start = startLocation.Split(',');
                //String[] end = endLocation.Split(',');
                //result = (Math.Sqrt((int.Parse(start[0]) - int.Parse(end[0])) ^ 2 + (int.Parse(start[1]) - int.Parse(end[1])) ^ 2) / 2400).ToString();
            }
            return result;
        }
        // GET: api/HospitalsAPI/5
        //[Route("api/HospitalsAPI/GetHospital/{id}"), HttpGet]
        [ResponseType(typeof(Hospital))]
        public IHttpActionResult GetHospital(int? id)
        {
            Hospital hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return NotFound();
            }

            return Ok(hospital);
        }

        // PUT: api/HospitalsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHospital(string id, Hospital hospital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hospital.Name)
            {
                return BadRequest();
            }

            db.Entry(hospital).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/HospitalsAPI
        [ResponseType(typeof(Hospital))]
        public IHttpActionResult PostHospital(Hospital hospital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Hospitals.Add(hospital);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HospitalExists(hospital.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hospital.Name }, hospital);
        }

        // DELETE: api/HospitalsAPI/5
        [ResponseType(typeof(Hospital))]
        public IHttpActionResult DeleteHospital(string id)
        {
            Hospital hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return NotFound();
            }

            db.Hospitals.Remove(hospital);
            db.SaveChanges();

            return Ok(hospital);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HospitalExists(string id)
        {
            return db.Hospitals.Count(e => e.Name == id) > 0;
        }
    }
}