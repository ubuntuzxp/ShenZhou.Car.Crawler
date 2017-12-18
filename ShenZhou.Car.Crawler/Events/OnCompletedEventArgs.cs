using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShenZhou.Car.Crawler.Events
{
    /// <summary>
    /// 爬虫完成事件
    /// </summary>
    public class OnCompletedEventArgs : EventArgs
    {
        public string Uri { get; private set; }// 爬虫URL地址
        public int ThreadId { get; private set; }// 任务线程ID
        public long Milliseconds { get; private set; }// 爬虫请求执行事件
        public ChromeDriver ChromeDriver { get; private set; }// 爬虫请求执行事件
        public OnCompletedEventArgs(string uri, int threadId, long milliseconds, ChromeDriver chromeDriver)
        {
            Uri = uri;
            ThreadId = threadId;
            Milliseconds = milliseconds;
            ChromeDriver = chromeDriver;
        }
    }
}
