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
            var rand = new Random();
            int number = rand.Next() % 10;
            switch (number)
            {
                case 0:
                    return "Im proud of you!";
                case 1:
                    return "When I was your age I was sponsored by dawn";
                case 2:
                    return "Only a little bit further!";
                case 3:
                    return "Did I ever tell you about the time I was in a hackathon?";
                case 4:
                    return "You could be doing better";
                case 5:
                    return "0_0";
                case 6:
                    return "You call yourself a stem major?";
                case 7:
                    return "The MLC is always open to help";
                case 8:
                    return "Go to Owen library";
                case 9:
                    return "AAAAHHHHHH";
                case 10:
                    return "We are working together";
            }
            return "HEEHEEHAAHAA Literally Insane";
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
