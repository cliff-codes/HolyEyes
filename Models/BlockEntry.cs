using HolyEyesApp.Interfaces;

namespace HolyEyesApp.Models;

public class BlockEntry
{
    public string Domain { get; set; }
    public string DateBlocked { get; set; }
    public string Reason { get; set; }

    // Add parameterless constructor for JSON deserialization
    public BlockEntry()
    {
        Domain = string.Empty;
        DateBlocked = string.Empty;
        Reason = string.Empty;
    }

    public BlockEntry(BlockedEntry blockedEntry)
    {
        this.Domain = blockedEntry.Domain;
        this.DateBlocked = blockedEntry.DateBlocked;
        this.Reason = blockedEntry.Reason;
    }

    public override string ToString()
    {
        return $"Domain: {this.Domain}, DateBlocked: {this.DateBlocked}, Reason: {this.Reason}";
    }
}