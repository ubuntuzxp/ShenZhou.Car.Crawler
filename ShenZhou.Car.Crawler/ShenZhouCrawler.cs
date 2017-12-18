using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ShenZhou.Car.Crawler.Events;

namespace ShenZhou.Car.Crawler
{
    public class ShenZhouCrawler : ICrawler
    {
        public event EventHandler<OnStartEventArgs> OnStart;//爬虫启动事件

        public event EventHandler<OnCompletedEventArgs> OnCompleted;//爬虫完成事件

        public event EventHandler<OnErrorEventArgs> OnError;//爬虫出错事件

        public CookieContainer CookiesContainer { get; set; }//定义Cookie容器

        public ShenZhouCrawler() { }



        /// <summary>
        /// 异步获取Chrome
        /// </summary>
        /// <param name="url">爬虫URL地址</param>
        /// <returns>ChromeDriver</returns>
        public Task<ChromeDriver> GetChromDriver(string url)
        {
            return Task.Factory.StartNew(() =>
            {
                var driver = new ChromeDriver();
                try
                {

                    OnStart?.Invoke(this, new OnStartEventArgs(url));
                    var watch = new Stopwatch();
                    watch.Start();

                    driver.Url = url;
                    Thread.Sleep(3000);//等待3s


                    var threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;//获取当前任务线程ID
                    var milliseconds = watch.ElapsedMilliseconds;//获取请求执行时间
                    OnCompleted?.Invoke(this, new OnCompletedEventArgs(url, threadId, milliseconds, driver));
                }
                catch (Exception ex)
                {
                    OnError?.Invoke(this, new OnErrorEventArgs(url, ex));
                }
                return driver;
            });
        }
    }


}
