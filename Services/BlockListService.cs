using System.Runtime.InteropServices;
using System.Text.Json;
using HolyEyesApp.Interfaces;
using HolyEyesApp.Models;

namespace HolyEyesApp.Services;

public class BlockListService
{
    private static List<BlockEntry>? lists;
    
    public static List<BlockEntry> LoadBlockList()
    {
        string path = Path.Combine(Directory.GetCurrentDirectory(), "Data/blocklist.json");
        
        //read from disk blockedList.json if one exists
        bool exists = File.Exists(path);
        Console.WriteLine($"File exists: {exists}");
        if (!exists)
        {
            lists = new List<BlockEntry>();
        }
        else
        {
            string content = File.ReadAllText("Data/blocklist.json");
            lists = (content.Length != 0) ? JsonSerializer.Deserialize<List<BlockEntry>>(content) : new  List<BlockEntry>();
        }
        return lists;
    }

    public static void AddSiteToList(BlockedEntry entry)
    {
        BlockEntry newEntry = new BlockEntry(entry);
        lists.Add(newEntry);
        
        //write to blockedList.json file
        string json = JsonSerializer.Serialize(lists);
        File.WriteAllText("Data/blocklist.json", json);
        Console.WriteLine($"{entry.Domain} successfully added to the list");
    }

    public static string ApplyBlockedHostRules(BlockEntry entry)
    {
        return $"127.0.0.1 {entry.Domain} # blocked-by-holyEyes";
    }
}