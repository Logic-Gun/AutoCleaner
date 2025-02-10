using System.ComponentModel;

namespace AutoCleaner;

public class Config
{
    [Description("Cleaning Up: Cooldown (Minutes)")]
    public byte CleaningUpEach { get; set; } = 15;

    [Description("Destroy only items that have an owner?")]
    public bool OwnerCheck { get; set; } = true;
}
