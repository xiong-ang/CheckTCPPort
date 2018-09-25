using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace TCPPort
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<int> ports = GetTCPConnectorPorts();
            List<int> ports = GetTCPListenerPorts();

            ports.ForEach( p => {
                Console.WriteLine(p);
            });
        }

        static List<int> GetTCPConnectorPorts()
        {
            List<int> ports = new List<int>();

            var ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            var tcpConnectInfoArray = ipGlobalProperties.GetActiveTcpConnections();

            tcpConnectInfoArray.ToList().ForEach(p => ports.Add(p.LocalEndPoint.Port));

            return ports;
        }

        static List<int> GetTCPListenerPorts()
        {
            List<int> ports = new List<int>();

            var ipGlobalProperties = IPGlobalProperties.GetIPGlobalProperties();
            var tcpListenInfoArray = ipGlobalProperties.GetActiveTcpListeners();

            tcpListenInfoArray.ToList().ForEach(p => ports.Add(p.Port));

            return ports;
        }
    }
}
