﻿using Exiled.API.Features.Items;
using Exiled.CustomItems.API;
using Exiled.CustomItems.API.Features;
using Exiled.CustomItems.API.Spawn;
using Exiled.Events.EventArgs;
using System.Collections.Generic;

namespace SCRAMBLE_Gear
{
    public class ci_gear : CustomItem
    {

        public override uint Id { get; set; } = 32;

        public override string Name { get; set; } = "SCRAMBLE Gear";
        public override string Description { get; set; } = "You now can't get targeted by 096, but you can't deal damage to him either";
        public override float Weight { get; set; } = 1f;
        public override SpawnProperties SpawnProperties { get; set; } = new SpawnProperties
        {
            Limit = 5,
            DynamicSpawnPoints = new List<DynamicSpawnPoint>
            {
                new DynamicSpawnPoint
                {
                    Chance = 50,
                    Location = SpawnLocation.InsideLczArmory,
                },

                new DynamicSpawnPoint
                {
                    Chance = 50,
                    Location = SpawnLocation.InsideNukeArmory,
                },

                new DynamicSpawnPoint
                {
                    Chance = 50,
                    Location = SpawnLocation.Inside049Armory,
                },

                new DynamicSpawnPoint
                {
                    Chance = 100,
                    Location = SpawnLocation.InsideSurfaceNuke,
                },
            },
        };
        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();
            Exiled.Events.Handlers.Player.DroppingItem += OnDropping;
            Exiled.Events.Handlers.Scp096.AddingTarget += BecomingTarget;
            Exiled.Events.Handlers.Player.Hurting += Hurting;
        }
        protected override void UnsubscribeEvents()
        {
            base.UnsubscribeEvents();
            Exiled.Events.Handlers.Player.DroppingItem -= OnDropping;
            Exiled.Events.Handlers.Scp096.AddingTarget -= BecomingTarget;
            Exiled.Events.Handlers.Player.Hurting -= Hurting;
        }

        protected override void OnDropping(DroppingItemEventArgs ev)
        {
            if (Check(ev.Item))
            {
                base.OnDropping(ev);
                ev.Player.ShowHint("You took off Scramble Gear");
            }
                
        }
        public void BecomingTarget(AddingTargetEventArgs ev)
        {
            foreach (Item item in ev.Target.Items)
            {
                if (Check(item))
                {
                    ev.IsAllowed = false;
                    ev.Target.ShowHint("You looked at SCP-096, but you had Scramble Gear equipped");
                }
            }
        }

        public void Hurting(HurtingEventArgs ev)
        {
            if (ev.Target.Role == RoleType.Scp096)
            {
                foreach (Item item in ev.Attacker.Items)
                {
                    if (Check(item))
                    {
                        ev.IsAllowed = false;
                        ev.Target.ShowHint("You can't damage SCP-096 while having Scramble Gear");
                    }
                }
            }
        }
    }
}