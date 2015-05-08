using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmergencySystemAPI.DAL;
using EmergencySystemAPI.Models;
using System.Xml;
using System.Web.Http.Cors;


namespace EmergencySystemAPI.Controllers
{
    [EnableCors(origins: "*", headers:"*", methods: "*")]
    public class HospitalsController : Controller
    {
        private EmergencyContext db = new EmergencyContext();
        public IEnumerable<String> test()
        {
            return new List<String> { "test1", "test2" };
        }

        // GET: Hospitals
        public ActionResult Index()
        {
            return View(db.Hospitals.ToList());
        }

        // GET: Hospitals/HospitalWithER
        public ActionResult HospitalWithER()
        {
            var hospitals = from h in db.Hospitals
                            where h.Emergency==true
                            select h;
            //hospitals = hospitals.Where(h => h.Emergency.Equals(true));
            return View(hospitals.ToList());
        }

        // GET: Hospitals/NearestHospital
        public ActionResult NearestHospital(double lat, double lng)
        {
            var hospitals = from h in db.Hospitals
                            where h.Emergency==true
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
            return View(nearest);
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



        // GET: Hospitals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospital hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return HttpNotFound();
            }
            return View(hospital);
        }

        // GET: Hospitals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hospitals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Website,AddressNo,AddressStreet,AddressCity,AddressState,AddressZip,Emergency")] Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                db.Hospitals.Add(hospital);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hospital);
        }

        // GET: Hospitals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospital hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return HttpNotFound();
            }
            return View(hospital);
        }

        // POST: Hospitals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Website,AddressNo,AddressStreet,AddressCity,AddressState,AddressZip,Emergency")] Hospital hospital)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospital).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hospital);
        }

        // GET: Hospitals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hospital hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return HttpNotFound();
            }
            return View(hospital);
        }

        // POST: Hospitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hospital hospital = db.Hospitals.Find(id);
            db.Hospitals.Remove(hospital);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
