using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            String strResult;
            var url = "http://localhost:64514/api/HospitalsAPI/NearestHospital?address=" + "3242 Kimber Ct, San Jose, CA";
            
            using (var client = new WebClient())
            {
                strResult = client.DownloadString(url);
            }
            String Name = "";
            String destination = "";
            String temp = "";
            for (int i = 1; i < strResult.Length; i++)
            {
                if (strResult[i] != '/')
                {
                    temp = temp + strResult[i];
                }
                else
                {
                    Name = temp;
                    temp = "";
                }

                if (i == strResult.Length - 2)
                {
                    destination = temp;
                    break;
                }

            }
            Console.WriteLine(Name);
            Console.WriteLine(destination);
           
        }
    }
}
