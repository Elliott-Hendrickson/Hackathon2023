using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Automation;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace DuckAPP
{
    internal static class GetBrowserData
    {
        public static string GetBrowserResponse()
        {
            Process[] procsChrome = Process.GetProcessesByName("chrome");
            if ((procsChrome?.Length ?? 0) <= 0)
            {
                Console.WriteLine("Chrome is not running");
            }
            else
            {
                foreach (Process proc in procsChrome)
                {
                    // the chrome process must have a window 
                    if (proc.MainWindowHandle == IntPtr.Zero)
                    {
                        continue;
                    }
                    // to find the tabs we first need to locate something reliable - the 'New Tab' button 
                    AutomationElement root = AutomationElement.FromHandle(proc.MainWindowHandle);
                    Condition condition = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TabItem);
                    AutomationElementCollection tabs = root?.FindAll(TreeScope.Descendants, condition);
                    foreach (AutomationElement ae in tabs)
                    {
                        var holder = warantedSite(ae.Current.Name);
                        if(holder != "Nothing")
                        {
                            return holder;
                        }
                    }
                }
            }
            return "dink!";
        }
        private static string warantedSite (string siteName)
        {
            string[,] bannedSites = new string[,]
                {{"Chess", "Playing Chess Again?\nEver Played Duck Chess?"}, {"Reddit", "Get Off Reddit!"}, {"YouTube", "Uncle Bob Teaches Great Coding Videos!"}, {"Overflow", "Dont Copy The Code!" } };
            for(int i = bannedSites.Length/2-1; i< bannedSites.Length/2; i++)
            {
                if (siteName.Contains(bannedSites[i,0])) { return bannedSites[i, 1]; }
            }
            return "Nothing";
        }
    }
}
