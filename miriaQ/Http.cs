using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace miriaQ
{
    public class Http
    {
        //public static string user;
        //public static string name;
        //public static string pwd;
        //public static System.Net.CookieContainer cc;
        public static Dictionary<string, System.Net.CookieContainer> ccs = new Dictionary<string, CookieContainer>();

        public static string HttpPost(string Url, string postDataStr, string user)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postDataStr.Length;
            request.KeepAlive = true;
            if (ccs.ContainsKey(user))
            {
                request.CookieContainer = ccs[user];
            }

            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36";
            StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
            writer.Write(postDataStr);
            writer.Flush();
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return response.StatusCode.ToString();
                }
                string encoding = response.ContentEncoding;
                if (encoding == null || encoding.Length < 1)
                {
                    encoding = "UTF-8"; //默认编码 
                }

                string[] cookies = response.Headers.GetValues("Set-Cookie");
                if (cookies != null && cookies.Length > 0)
                {
                    foreach (string cookie in cookies)
                    {
                        string[] cs = cookie.Split(';');
                        foreach (string ca in cs)
                        {
                            string[] kv = ca.Split('=');
                            if (kv.Length == 2)
                            {
                                Cookie c = new Cookie(kv[0].TrimStart(' '), kv[1], "/", "english.ulearning.cn");
                                if (!ccs.ContainsKey(user))
                                {
                                    ccs[user] = new CookieContainer();
                                }
                                ccs[user].Add(c);
                            }
                        }
                    }
                }
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
                string retString = reader.ReadToEnd();
                return retString;
            }
            catch
            {
                return "";
            }
        }

        public static string HttpGet(string Url, string user)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "GET";
            request.KeepAlive = true;
            if (ccs.ContainsKey(user))
            {
                request.CookieContainer = ccs[user];
            }
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return response.StatusCode.ToString();
            }
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码 
            }

            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            string retString = reader.ReadToEnd();
            return retString;
        }

        public static bool CheckPwdAndLogin(string username, string pwd)
        {
            string postDataStr = "loginname=" + username  + "&password=" + pwd;
            string req = HttpPost("http://www.ulearning.cn/ulearning_web/login!checkUserForLogin.do", postDataStr, username);
            char res = req[0];
            if (res == '0')
            {
                return false;
            }
            postDataStr = "name=" + username + "&passwd=" + pwd;
            HttpPost("http://www.ulearning.cn/umooc/user/login.do", postDataStr, username);
            return true;
        }

    }
}
