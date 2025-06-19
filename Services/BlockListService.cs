using System.Text.Json;
using HolyEyesApp.Interfaces;
using HolyEyesApp.Models;

namespace HolyEyesApp.Services;

public class BlockListService
{
    private static List<BlockEntry>? lists;
    
    public static List<BlockEntry> LoadBlockList()
    {
        const string path = "Data/BlockList.json";
        //read from disk blockedList.json if one exists
        bool exists = File.Exists(path);
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
}