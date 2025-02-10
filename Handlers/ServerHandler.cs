using LabApi.Events.CustomHandlers;
using MEC;

namespace AutoCleaner.Events;

public class ServerHandler : CustomEventsHandler
{
    public override void OnServerRoundStarted()
    {
        if (Plugin.Coroutine != null) Timing.KillCoroutines(Plugin.Coroutine);

        Plugin.Coroutine = Timing.RunCoroutine(Enumerators.Cleaner.Processing());

        base.OnServerRoundStarted();
    }
}
