using AutoCleaner.Events;
using LabApi.Events.CustomHandlers;
using LabApi.Loader.Features.Plugins;
using MEC;
using System;

namespace AutoCleaner;

public class Plugin : Plugin<Config>
{
    public override string Name => "Auto Cleaner";
    public override string Description => "Allows you to clear the map every given n seconds.";
    public override string Author => "Logic_Gun";
    public override Version Version => new(1, 0, 2);
    public override Version RequiredApiVersion => new(0, 0, 0); // idk labapi version lol

    public ServerHandler ServerHandler => new();

    public static Plugin Instance;
    public static CoroutineHandle Coroutine;

    public override void Disable()
    {
        UnregisterHandlers();

        Instance = null;
    }

    public override void Enable()
    {
        Instance = this;

        RegisterHandlers();
    }

    private void RegisterHandlers()
    {
        CustomHandlersManager.RegisterEventsHandler(ServerHandler);
    }

    private void UnregisterHandlers()
    {
        CustomHandlersManager.UnregisterEventsHandler(ServerHandler);
    }
}
