using System;
using System.Linq;
using ReefCode.Reefi;

namespace TestHarness
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // Setup the connector with ip address of one light on the network.
            var connector = new ReeFiConnector("192.168.4.51");

            // Clear display on all lights in all groups
            connector.Groups.ClearDisplayTextAsync().Wait();

            // Set three lines of text on all lights.
            var text = $"Line 1{Environment.NewLine}Line 2{Environment.NewLine}Line 3";
            connector.Groups.SetDisplayTextAsync(text).Wait();

            Console.WriteLine("Connector Ready");
            Console.WriteLine("Press Key to set Photo Mode on Group 2");
            Console.ReadKey();

            // Get the Photo_Full lighting profile from the connector
            var profile = connector.Profiles.Where(p => p.Name == "Photo_FULL").FirstOrDefault()
                ?? throw new Exception("Missing Photo mode profile");

            // Set Group 2 lights to the Photo_Full profile.
            connector.Groups.Where(g => g.GroupId == 2).FirstOrDefault()?.SetAsync(profile).Wait();

            Console.WriteLine("Press Key to set Custom Mode on light 192.168.4.58");
            Console.ReadKey();

            // Set light at IP 192.168.4.58 using a custom profile not defined on the ReeFi lights. Run at 20% power.
            profile = new Profile
            {
                Channel_0 = 200,
                Channel_1 = 200
            };

            connector.Lights.Where(l => l.IPAddress == "192.168.4.58").FirstOrDefault()?.SetAsync(profile, 20).Wait();

            Console.WriteLine("Press Key to Resume all lights");
            Console.ReadKey();

            // All lights in all groups resume normal program operations.
            connector.Groups.ResumeAsync().Wait();
        }
    }
}
