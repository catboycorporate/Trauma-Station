using Content.Shared.Containers.ItemSlots;
using Content.Shared.Power.EntitySystems;
using Content.Shared.Weapons.Ranged.Components;

namespace Content.Trauma.Shared.Power;

/// <summary>
/// Allows energy gun magazines to be used as batteries for IPC power eating.
/// </summary>
public sealed class MagazineBatterySystem : EntitySystem
{
    [Dependency] private readonly ItemSlotsSystem _slots = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<MagazineAmmoProviderComponent, FindBatteryEvent>(OnFindBattery);
        SubscribeLocalEvent<ChamberMagazineAmmoProviderComponent, FindBatteryEvent>(OnFindBattery);
    }

    private void OnFindBattery(Entity<MagazineAmmoProviderComponent> ent, ref FindBatteryEvent args)
    {
        // shitcode has the slot hardcoded everywhere i think so this is "fine"
        args.FoundBattery ??= _slots.GetItemOrNull(ent.Owner, "gun_magazine");
    }
}
