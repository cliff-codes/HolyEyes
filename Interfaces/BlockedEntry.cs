namespace HolyEyesApp.Interfaces;

public interface BlockedEntry
{
    string Domain { get; set; }
    string DateBlocked { get; set; }
    string Reason { get; set; }
}