String strResult;
WebResponse objResponse;
WebRequest objRequest = HttpWebRequest.Create(strURL);
objResponse = objRequest.GetResponse();
using (StreamReader sr = new StreamReader(objResponse.GetResponseStream())) {
   strResult = sr.ReadToEnd();
   sr.Close();
}
return strResult;
       