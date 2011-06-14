using System;
using System.IO;
using System.Net;

namespace tdd_demo.Services
{
    public class WeatherSvc : IWeatherSvc
    {

//        private string url = "http://192.168.0.100:4567/Weather/";
        private string url = "http://172.17.32.108:4567/Weather/";
        public string GetWeatherForCounty(string countyName) {
            string strResult;
            WebResponse objResponse;
            string strURL = String.Format("{0}{1}", url, countyName);
            WebRequest objRequest = HttpWebRequest.Create(strURL);
            objResponse = objRequest.GetResponse();
            using (StreamReader sr = new StreamReader(objResponse.GetResponseStream())) {
               strResult = sr.ReadToEnd();
               sr.Close();
            }
            return strResult;
//            return("sunny");
        }
    }
}