using System.Text.Json;
using HolyEyesApp.Interfaces;
using HolyEyesApp.Models;

namespace HolyEyesApp.Services;

public class BlockListService
{
    private static List<BlockedEntry>? lists;
    
    public static List<BlockedEntry> LoadBlockList()
    {
        //read from disk blockedList.json if one exists
        string content = File.ReadAllText("Data/blocklist.json");
        lists = (content.Length != 0) ? JsonSerializer.Deserialize<List<BlockedEntry>>(content) : new  List<BlockedEntry>();
        return lists;
    }

    public static void AddSiteToList(BlockedEntry entry)
    {
        BlockEntry newEntry = new BlockEntry(entry);
        lists?.Add(entry);
        
        //write to blockedList.json file
        string json = JsonSerializer.Serialize(lists);
        File.WriteAllText("Data/blocklist.json", json);
        Console.WriteLine($"{entry.Domain} successfully added to the list");
    }
}