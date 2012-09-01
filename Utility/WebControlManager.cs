using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace ModernSteward
{
    public class WebControlManager
    {
        private static string server = "http://www.modernsteward.com:3001";

        private CookieContainer cookies;
        public WebControlManager() { }

        public WebControlManager(string email, string password)
        {
            Login(email, password);
        }

        public void Login(string email, string password)
        {
            Logout();
            string post_data = string.Format("email={0}&password={1}", email, password);
            string uri = server + "/auth/page/email/login";

            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(uri);
            request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version11;
            request.Method = "POST";
            request.AllowWriteStreamBuffering = true;
            request.AllowAutoRedirect = true;
            request.CookieContainer = cookies;
 
            byte[] postBytes = Encoding.ASCII.GetBytes(post_data);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postBytes.Length;

            Stream requestStream = request.GetRequestStream();
            requestStream.Write(postBytes, 0, postBytes.Length);
            requestStream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //Console.WriteLine(response.Cookies.Count);
            //Console.WriteLine(response.StatusCode);
        }

        public void Logout()
        {
            cookies = new CookieContainer();
        }
    }
}
