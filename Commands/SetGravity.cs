using CommandSystem;
using LabApi.Features.Wrappers;
using System;

namespace AutoCleaner.Commands;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
internal class SetGravity : ICommand
{
    public string Command => "setgravity";

    public string[] Aliases => [];

    public string Description => "";

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        Player pl = Player.Get(sender);

        response = "Usage: .setgravity <x> <y> <z>";

        if (arguments.Count != 3) return false;
        if (!float.TryParse(arguments.At(0), out float x)) return false;
        if (!float.TryParse(arguments.At(1), out float y)) return false;
        if (!float.TryParse(arguments.At(2), out float z)) return false;

        pl.Gravity = new(x, y, z);

        response = "Successfully!";
        return true;
    }
}
