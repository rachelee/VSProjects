using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace FindShortestPath
{
    public partial class _Default : Page
    {
        private String destination;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            String strResult;
            var url = "http://emergencysystemapi.azurewebsites.net/api/HospitalsAPI/NearestHospital?address=" + address.Text;
            
            using (var client = new WebClient())
            {
                strResult = client.DownloadString(url);
            }
            String Name = "";
            String temp = "";
            for (int i = 1; i < strResult.Length; i++ )
            {
                if(strResult[i] != '/')
                {
                    temp = temp + strResult[i];
                }
                else
                {
                    Name = temp;
                    temp = "";
                }

                if(i == strResult.Length-2)
                {
                    destination = temp;
                }

            }
            HospitalName.Text = Name;
            iframe();
            


    
        }

        protected void iframe()
        {
            LiteralControl literal = new LiteralControl();
            var url = "'https://www.google.com/maps/embed/v1/directions" +
                      "?key=AIzaSyA-1WrgrK-s9zq3VSJYkxJS4y1uxTG_u9k" +
                      "&origin=" + address.Text +
                      "&destination=" + destination + "'";
            
            literal.Text = "<iframe width='600' height='450' frameborder='0' style='border:0'" +
                            "src=" + url + "></iframe>";
            div1.Controls.Add(literal);
        }
    }
}