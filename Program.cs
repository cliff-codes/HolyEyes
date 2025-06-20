using HolyEyesApp.Interfaces;
using HolyEyesApp.Models;
using HolyEyesApp.Services;

namespace HolyEyesApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("----holy eyes is watching you----------");
        var isRunning = true;

        //start application automatically on boot :todo

        //read /etc/hosts
        string[] hosts = File.ReadAllLines("/etc/hosts");
        var blockedHosts = hosts.Where(line => line.Contains("# blocked-by-holyEyes")).ToList();
        foreach (var host in blockedHosts)
        {
            Console.WriteLine(host);
        }


        List<BlockEntry>blockedList = BlockListService.LoadBlockList();
        while (isRunning)
        {
            //load blocked lists
            if (blockedList.Count > 0)
            {
                //creating new host entries by applying blocking rules
                var newHostEntries = blockedList.Select(BlockListService.ApplyBlockedHostRules).ToList();
                
                //remove old blocked entries
                var updatedHosts = hosts.Where(line => !line.Contains("# blocked-by-holyEyes")).ToList();
                
                //add new entries
                updatedHosts.AddRange(newHostEntries);
                
                //write new hosts
                try
                {
                    File.WriteAllLines("/etc/hosts", updatedHosts);
                    
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine("Error: " + e.Message + "");
                    Console.WriteLine("Please run the application as root");
                    isRunning = false;
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message + "");
                    isRunning = false; 
                    break;
                }
            }
            else
            {
                Console.WriteLine("No blocklist found");
            }
            Thread.Sleep(60000);
        }
    }
}