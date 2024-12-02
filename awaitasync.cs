using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace awaitasync2
{
    class Program
    {
        static   async Task Main(string[] args)
        {
           //同步方法
            
           /* string filename = @"E:\Users\yong.huang\Desktop\C#\.net core\awaitasync基本使用\awaitasync1\awaitasync1\awaitasync1\test.txt";
            //同步写入方法
            File.WriteAllText(filename, "Hello world");
            //同步读取方法
           string s= File.ReadAllText(filename);
            Console.WriteLine(s);
            Console.ReadLine();
            */

            //异步方法
            string  filename= @"E:\Users\yong.huang\Desktop\C#\.net core\awaitasync基本使用\awaitasync1\awaitasync1\awaitasync1\test.txt";
            //异步方法写入
            //方法中包含await 关键字,这个方法必须修饰为async
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 1000; i++)
            {
                sb.AppendLine("Hello world1");
            }


             await  File.WriteAllTextAsync(filename, sb.ToString());
            //异步方法读取
            //string s
            //string s =await  File.ReadAllTextAsync(filename);

            Task<string> t = File.ReadAllTextAsync(filename);
            string s = await t;
            await Testasync("https://www.baidu.com", @"E:\Users\yong.huang\Desktop\C#\.net core\awaitasync基本使用\awaitasync1\awaitasync1\awaitasync1\test.txt");
           // Console.WriteLine(s);
            Console.ReadLine();

            //调用方法
       
    

            /*调用异步方法前面加await,创建异步方法前面修饰加async Task
             */

            static async Task Testasync(string url,string destFilePath)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string html = await httpClient.GetStringAsync(url);
                    Console.WriteLine(html);
                } ;
                string content = "hello async  and await";
                await File.WriteAllTextAsync(destFilePath, content);
                string content2 = await File.ReadAllTextAsync(destFilePath);
                Console.WriteLine(content2);
            }

        }
    }
}
