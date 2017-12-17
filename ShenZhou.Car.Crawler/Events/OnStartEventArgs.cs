using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wesley.Crawler.SimpleCrawler.Events
{
    /// <summary>
    /// 爬虫启动事件
    /// </summary>
    public class OnStartEventArgs:EventArgs
    {
        public string Uri { get; set; }// 爬虫URL地址

        public OnStartEventArgs(string uri)
        {
            this.Uri = uri;
        }
    }
}
