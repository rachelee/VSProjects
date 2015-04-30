using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EmergencySystemAPI.Models;

namespace EmergencySystemAPI.DAL
{
    public class EmergencyInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EmergencyContext>
    {
        protected override void Seed(EmergencyContext context)
        {
            var hospitals = new List<Hospital>
            {
            new Hospital{Name="Childrens Recovery Center of Northern California", Website= "http://www.pedisubacute.com", 
                AddressNo="3777", AddressStreet="S Bascom Ave", AddressCity="Campbell", AddressState="CA", AddressZip="95008", Emergency=false},
            new Hospital{Name="El Camino Hospital", Website= "http://www.elcaminohospital.org ", 
                AddressNo="2500", AddressStreet="Grant Rd", AddressCity="Mountain View", AddressState="CA", AddressZip="94040", Emergency=true},
            new Hospital{Name="El Camino Hospital Los Gatos", Website= "http://www.elcaminohospital.org", 
                AddressNo="815", AddressStreet="Pollard Rd", AddressCity="Los Gatos", AddressState="CA", AddressZip="95032", Emergency=true},
            new Hospital{Name="Good Samaritan Hospital-San Jose", Website= "http://www.goodsamsanjose.com", 
                AddressNo="2425", AddressStreet="Samaritan Dr", AddressCity="San Jose", AddressState="CA", AddressZip="95124", Emergency=true},
            new Hospital{Name="Kaiser Fnd Hosp - San Jose", Website= "http://www.kaiserpermanente.org", 
                AddressNo="250", AddressStreet="Hospital Pkwy", AddressCity="San Jose", AddressState="CA", AddressZip="95119", Emergency=true},
            new Hospital{Name="Kaiser Fnd Hosp - Santa Clara", Website= "http://www.kaiserpermanente.org", 
                AddressNo="700", AddressStreet="Lawrence Expy", AddressCity="San Clara", AddressState="CA", AddressZip="95051", Emergency=true},
            new Hospital{Name="Kaiser Permanente P.H.F - Santa Clara", Website= "N/A", 
                AddressNo="3598", AddressStreet="Homestead Rd", AddressCity="San Clara", AddressState="CA", AddressZip="95051", Emergency=false},
            new Hospital{Name="Lucile Salter Packard Children's Hosp. At Stanford", Website= "http://www.lpch.org ", 
                AddressNo="725", AddressStreet="Welch Rd", AddressCity="Palo Alto", AddressState="CA", AddressZip="94304", Emergency=false},
            new Hospital{Name="Stanford Hospital", Website= "http://www.stanfordhospital.com", 
                AddressNo="300", AddressStreet="Pasteur", AddressCity="Palo Alto", AddressState="CA", AddressZip="94305", Emergency=true},
            new Hospital{Name="Santa Clara Valley Medical Center", Website= "http://www.scvmed.org", 
                AddressNo="751", AddressStreet="751 S Bascom Ave", AddressCity="San Jose", AddressState="CA", AddressZip="95128", Emergency=true},
            new Hospital{Name="Regional Medical of San Jose", Website= "http://www.regionalmedicalsanjose.com", 
                AddressNo="225", AddressStreet="N Jackson Ave", AddressCity="San Jose", AddressState="CA", AddressZip="95116", Emergency=true},
            };

            hospitals.ForEach(h => context.Hospitals.Add(h));
            context.SaveChanges(); //help to locate error when exception occurs
            var ambulances = new List<Ambulance>
            {
            new Ambulance{HospitalId=2,Status=Status.idle},
            new Ambulance{HospitalId=2,Status=Status.idle},
            new Ambulance{HospitalId=3,Status=Status.idle},
            new Ambulance{HospitalId=4,Status=Status.idle},
            new Ambulance{HospitalId=5,Status=Status.idle},
            new Ambulance{HospitalId=5,Status=Status.idle},
            new Ambulance{HospitalId=5,Status=Status.idle},
            new Ambulance{HospitalId=8,Status=Status.idle},
            new Ambulance{HospitalId=9,Status=Status.idle},
            new Ambulance{HospitalId=9,Status=Status.idle},
            new Ambulance{HospitalId=9,Status=Status.idle},
            new Ambulance{HospitalId=10,Status=Status.idle},
            new Ambulance{HospitalId=10,Status=Status.idle}
            };
            ambulances.ForEach(a => context.Ambulances.Add(a));
            context.SaveChanges();//help to locate error when exception occurs
            
        }
    }
}