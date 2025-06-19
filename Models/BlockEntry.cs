using HolyEyesApp.Interfaces;

namespace HolyEyesApp.Models;

public class BlockEntry
{
    public string Domain { get; set; }
    public string DateBlocked { get; set; }
    public string Reason { get; set; }

    public BlockEntry(BlockedEntry blockedEntry)
    {
        this.Domain = blockedEntry.Domain;
        this.DateBlocked = blockedEntry.DateBlocked;
        this.Reason = blockedEntry.Reason;
    }
}