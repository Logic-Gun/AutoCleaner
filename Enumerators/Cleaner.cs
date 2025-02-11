using LabApi.Features.Wrappers;
using MEC;
using System.Collections.Generic;
using System.Linq;

namespace AutoCleaner.Enumerators;

internal static class Cleaner
{
    internal static int Cooldown { get; } = Plugin.Instance.Config.CleaningUpEach * 60;

    internal static IEnumerator<float> Processing()
    {
        while (!Round.IsRoundEnded)
        {
            yield return Timing.WaitForSeconds(Cooldown);

            foreach (var pickup in Map.Pickups.Where(r => !Plugin.Instance.Config.OwnerCheck || (r.LastOwner != null)))
            {
                pickup.Destroy();
            }
        }

        yield break;
    }
}
