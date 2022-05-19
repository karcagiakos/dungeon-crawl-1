using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;

namespace Assets.Source.Actors.Static
{
    public class ClosedDoor : Actor
    {

        public override int DefaultSpriteId => 146;

        public override string DefaultName => "ClosedDoor";

        public override bool OnCollision(Actor anotherActor)
        {

            if (anotherActor is Player && Player.Inventory["YellowKey"] == 2)
            {
                Debug.Log("closeddoor - ifág");
                ActorManager.Singleton.Spawn<OpenDoor>(this.Position);
                ActorManager.Singleton.DestroyActor(this);
            }

            return false;
        }
    }
}
