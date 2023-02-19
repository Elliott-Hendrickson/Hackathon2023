using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Automation;
using System.Diagnostics;

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
                        Trace.WriteLine(ae.Current.Name);
                    }
                }
            }
            return "ding";
        }
    }
}
