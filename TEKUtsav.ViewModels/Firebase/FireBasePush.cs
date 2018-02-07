using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using TEKUtsav.Infrastructure.Constants;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TEKUtsav.Models.FireBase
{


    public class FireBasePush
    {
        private string FireBase_URL = "https://fcm.googleapis.com/fcm/send";
        private string key_server;

        private void ReadWebRequestCallback(IAsyncResult callbackResult)
        {

            HttpWebRequest myRequest = default(HttpWebRequest);
            HttpWebResponse myResponse = default(HttpWebResponse);
            myRequest = (HttpWebRequest)callbackResult.AsyncState;
            myResponse = (HttpWebResponse)myRequest.EndGetResponse(callbackResult);
            using (StreamReader httpwebStreamReader = new StreamReader(myResponse.GetResponseStream()))
            {
                //Here you can get data
                string results = httpwebStreamReader.ReadToEnd();
            }
            //myResponse.Close();
        }

        public void SendPush(PushMessage message)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(FireBase_URL);
                request.Method = "POST";
                request.Headers["Authorization"] = "key=" + this.key_server;
                request.ContentType = "application/json";
                string json = JsonConvert.SerializeObject(message);
                //json = json.Replace("content_available", "content-available");
                byte[] byteArray = Encoding.UTF8.GetBytes(json);

                //request.Headers[HttpRequestHeader.ContentLength] = byteArray.Length.ToString();
                Task<Stream> dataStream = request.GetRequestStreamAsync();
                dataStream.Result.Write(byteArray, 0, byteArray.Length);
                //dataStream.Close();
                //HttpWebResponse respuesta = (HttpWebResponse)request.GetResponse();
                request.BeginGetResponse(new AsyncCallback(ReadWebRequestCallback), request);

                //if (respuesta.StatusCode == HttpStatusCode.Accepted || respuesta.StatusCode == HttpStatusCode.OK || respuesta.StatusCode == HttpStatusCode.Created)
                //{
                //    StreamReader read = new StreamReader(respuesta.GetResponseStream());
                //    String result = read.ReadToEnd();
                //    read.Close();
                //    respuesta.Close();
                //    dynamic stuff = JsonConvert.DeserializeObject(result);

                //    return stuff;
                //}
                //else
                //{
                //    throw new Exception("Ocurrio un error al obtener la respuesta del servidor: " + respuesta.StatusCode);
                //}
            }
            catch(Exception ex)
            {
                var test = ex.Message;
            }
        }

       
        public FireBasePush(String Key_Server)
        {
            this.key_server = Key_Server;
        }

    }
  
    public class PushMessage
    {
        private string _to;
        private PushMessageData _notification;

        private dynamic _data;
        private dynamic _click_action;
        public dynamic data
        {
            get { return _data; }
            set { _data = value; }
        }

        public string to
        {
            get { return _to; }
            set { _to = value; }
        }
        public PushMessageData notification
        {
            get { return _notification; }
            set { _notification = value; }
        }

        public dynamic click_action
        {
            get
            {
                return _click_action;
            }

            set
            {
                _click_action = value;
            }
        }
    }

    public class PushMessageData
    {
        private string _title;
        private string _text;
        private string _sound = "default";
        //private dynamic _content_available;
        private string _click_action;
        public string sound
        {
            get { return _sound; }
            set { _sound = value; }
        }

        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string text
        {
            get { return _text; }
            set { _text = value; }
        }

        public string click_action
        {
            get
            {
                return _click_action;
            }

            set
            {
                _click_action = value;
            }
        }

        //public dynamic content_available
        //{
        //    get
        //    {
        //        return _content_available;
        //    }

        //    set
        //    {
        //        _content_available = value;
        //    }
        //}
    }
}