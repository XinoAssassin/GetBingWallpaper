using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace GetBingWallpaper
{
    class Program
    {
        static void Main(string[] args)
        {
            string API_URL = "https://bing.ioliu.cn/v1/?type=json&d=";
            string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.140 Safari/537.36";
            for (int i = 0; i < 65; i++)
            {
                HttpWebRequest hwr = (HttpWebRequest)WebRequest.Create(API_URL + i.ToString());
                hwr.UserAgent = userAgent;

                HttpWebResponse hwrs = (HttpWebResponse)hwr.GetResponse();
                using (StreamReader sr = new StreamReader(hwrs.GetResponseStream()))
                {
                    dynamic json = JObject.Parse(sr.ReadToEnd());
                    string url = json.data.url;
                    PicDownloader(url);
                    Console.WriteLine("Downloaded {0} Pic", i + 1);
                }
            }
        }

        static void PicDownloader(string url)
        {
            HttpWebRequest pic_request = (HttpWebRequest)WebRequest.Create(url);
            pic_request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.140 Safari/537.36";

            HttpWebResponse pic_response = (HttpWebResponse)pic_request.GetResponse();
            if (pic_response.StatusCode == HttpStatusCode.OK)
            {
                Stream stream = pic_response.GetResponseStream();
                var uri = new System.Uri(url);
                var filename = Path.GetFileName(uri.LocalPath);
                string foldName = Path.Combine(Environment.CurrentDirectory, "download");
                if (!Directory.Exists("download"))
                {
                    Directory.CreateDirectory("download");
                }

                FileStream fs = new FileStream(Environment.CurrentDirectory + "\\download\\" + filename, FileMode.OpenOrCreate, FileAccess.Write);
                byte[] buff = new byte[pic_response.ContentLength];
                int i = 0;
                while ((i = stream.Read(buff, 0, buff.Length)) > 0)
                {
                    fs.Write(buff, 0, i);
                }
                fs.Close();
                stream.Close();
                fs.Dispose();
                stream.Dispose();
            }
            else if (pic_response.StatusCode == HttpStatusCode.NotFound)
            {
            }

        }
    }

}
