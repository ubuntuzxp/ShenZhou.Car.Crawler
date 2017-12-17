using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wesley.Crawler.SimpleCrawler.Events;

namespace Wesley.Crawler.SimpleCrawler
{
    public interface ICrawler
    {
        event EventHandler<OnStartEventArgs> OnStart;//启动事件

        event EventHandler<OnCompletedEventArgs> OnCompleted;//完成事件

        event EventHandler<OnErrorEventArgs> OnError;//异常事件

        Task<ChromeDriver> GetChromDriver(string uri); //异步初始化Chrome
    }
}
