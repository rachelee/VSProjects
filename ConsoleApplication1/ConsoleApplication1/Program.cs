using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            String strResult;
            var url = "https://maps.googleapis.com/maps/api/geocode/xml?address=" + "3242 Kimber Ct, San Jose, CA" + "&key=AIzaSyA-1WrgrK-s9zq3VSJYkxJS4y1uxTG_u9k";

            using (var client = new WebClient())
            {
                strResult = client.DownloadString(url);
            }
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(strResult); // suppose that myXmlString contains "<Names>...</Names>"

            XmlNodeList xnList = xml.SelectNodes("GeocodeResponse/result/geometry/location");
            XmlNode xn = xnList[0];

            String lat = xn["lat"].InnerText;
            Console.WriteLine(lat);
            String lng = xn["lng"].InnerText;
            Console.WriteLine(lng);
        }
    }
}
