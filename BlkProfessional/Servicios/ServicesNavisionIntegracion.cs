using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace BlkProfessional.Servicios
{
    public class ServicesNavisionIntegracion
    {
        public static string InvokeService(string metodo,string Object)
        {
            //string url = "https://localhost:44332/api/Navision/"+metodo; //"https://qastopjeansatparc.azurewebsites.net/atplim/api/v2/documentLines";
            string url = "http://www.bulkmatic.com.mx/WebApi_Bulkmatic_Colombia/api/Navision/" + metodo;
            string key = "";// keyDocumentLine.ValueCode; //"a7359199e0ad4c06928a04adb16ab97a"
            string responseText = "";
            using (WebClient client = new WebClient())
            {
                try
                {
                    client.Encoding = System.Text.Encoding.UTF8;
                    client.Headers.Add(HttpRequestHeader.ContentType, "application/json"); //"text/plain; charset=utf-8"                   
                    client.Headers.Add("x-api-key", key); //"x-api-key"
                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    responseText = client.UploadString(url, Object);
                }
                catch (WebException exception)
                {
                    using (var reader = new StreamReader(exception.Response.GetResponseStream()))
                    {
                        responseText = reader.ReadToEnd();
                        responseText = "error:" + responseText;
                    }
                }
            }
            return responseText;
        }


      

    }
}