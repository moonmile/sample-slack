using System;
using System.Net.Http;
using System.Text;

namespace postslack
{
    class Program
    {
        static string WEBHOOK_URL = "https://hooks.slack.com/services/XXX/XXX/XXX";
        static void Main(string[] args)
        {
            var hc = new HttpClient();
            var json = Codeplex.Data.DynamicJson.Serialize( new 
            {
                text = args.Length == 0 ? 
                        DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"):
                        args[0],
                icon_emoji = ":ghost:", //アイコンを動的に変更する
                username = "slackpost"  //名前を動的に変更する
            });
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var res = hc.PostAsync(WEBHOOK_URL, content).Result;
            Console.WriteLine("投稿しました");
        }
    }
}
