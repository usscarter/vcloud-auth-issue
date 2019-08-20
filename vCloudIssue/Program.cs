using com.vmware.vcloud.sdk;
using System;
using System.Configuration;

namespace Itopia.vCloudIssue
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = ConfigurationManager.AppSettings["vcloud.user"];
            string password = ConfigurationManager.AppSettings["vcloud.pass"];
            string url = ConfigurationManager.AppSettings["vcloud.url"];

            var vcloudClient = new vCloudClient(url, com.vmware.vcloud.sdk.constants.Version.V5_5);

            try
            {
                vcloudClient.Login(username, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.ReadKey();
        }
    }
}
