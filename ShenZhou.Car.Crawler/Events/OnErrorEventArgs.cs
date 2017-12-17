using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wesley.Crawler.SimpleCrawler.Events
{
    public class OnErrorEventArgs: EventArgs
    {
        public string Uri { get; set; }

        public Exception Exception { get; set; }

        public OnErrorEventArgs(string uri,Exception exception) {
            Uri = uri;
            Exception = exception;
        }
    }
}
