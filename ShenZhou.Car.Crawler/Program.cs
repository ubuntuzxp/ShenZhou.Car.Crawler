using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Net;
using Wesley.Crawler.SimpleCrawler.Models;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Wesley.Crawler.SimpleCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            //开始抓取
            ZucheCrawler();

            Console.ReadKey();
        }

        /// <summary>
        /// 神州
        /// </summary>
        public static void ZucheCrawler()
        {

            var carUrl = "https://order.zuche.com/smfw/index.do?flag=1";//入口URL
            var cityCrawler = new ShenZhouCrawler();
            cityCrawler.OnStart += (s, e) =>
            {
                Console.WriteLine("开始抓取，地址：" + e.Uri.ToString());
            };
            cityCrawler.OnError += (s, e) =>
            {
                Console.WriteLine("出现错误：" + e.Uri.ToString() + "，异常消息：" + e.Exception.Message);
            };
            cityCrawler.OnCompleted += (s, e) =>
            {

                var names = e.ChromeDriver.FindElementsByClassName("name");

                var prices = e.ChromeDriver.FindElementsByClassName("car_price");
                for (int i = 0; i < names.Count; i++)
                {
                    if (!string.IsNullOrEmpty(names[i].Text))
                    {
                        Console.WriteLine(string.Format("{0 }：{1}", names[i].Text, prices[i].Text.Replace("\r\n", string.Empty)));
                    }
                }
                e.ChromeDriver.Close();//关闭浏览器
                Console.WriteLine("----------------------------------");
                Console.WriteLine("数据抓取完成！共 " + names.Count + " 条数据。");
                Console.WriteLine("耗时：" + e.Milliseconds + "毫秒");
                Console.WriteLine("线程：" + e.ThreadId);
                Console.WriteLine("地址：" + e.Uri.ToString());
            };
            cityCrawler.GetChromDriver(carUrl).Wait();
        }
    }












}


