using HolyEyesApp.Interfaces;
using HolyEyesApp.Services;

namespace HolyEyesApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("----holy eyes is watching you----------");
        
        //start application automatically on boot :todo
        
        //load blocked lists
        List<BlockedEntry>blockedList = BlockListService.LoadBlockList();
        
        

    }
}