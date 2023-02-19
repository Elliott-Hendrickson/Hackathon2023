using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DuckAPP.Properties.InternetChecker
{
    internal class BrowserSearcherClass
    {
        private readonly Dictionary<string, string> tabs = new Dictionary<string, string>
                                                {
                                                      {
                                                          "chrome", "Google Chrome"
                                                      }
                                                    // add other browsers
                                                };

        public bool BrowserIsOpen()
        {
            return Process.GetProcesses().Any(this.IsBrowserWithWindow);
        }

        private bool IsBrowserWithWindow(Process process)
        {
            return this.tabs.TryGetValue(process.ProcessName, out var browserTitle) && process.MainWindowTitle.Contains(browserTitle);
        }
    }
}
