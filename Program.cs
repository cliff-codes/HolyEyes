using HolyEyesApp.Interfaces;
using HolyEyesApp.Models;
using HolyEyesApp.Services;

namespace HolyEyesApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("----holy eyes is watching you----------");
        bool isRuning = true;       
        //start application automatically on boot :todo
        
        while (isRuning)
        {
            //load blocked lists
            List<BlockEntry>blockedList = BlockListService.LoadBlockList();
            if (blockedList.Count > 0)
            {
                foreach (var entry in blockedList)
                {
                    Console.WriteLine(entry.ToString());
                }
            }
            else
            {
                Console.WriteLine("No blocklist found");
            }
        }
    }
}