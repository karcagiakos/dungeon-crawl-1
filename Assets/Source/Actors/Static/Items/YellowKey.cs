using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Source.Core;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;

namespace Assets.Source.Actors.Static.Items
{
    public class YellowKey : Actor
    {
        public override int DefaultSpriteId => 559;
        public override string DefaultName => "YellowKey";
        public override int Z => -1;

        public override bool OnCollision(Actor anotherActor)
        {
            if (!Player.Inventory.ContainsKey(this))
            {
                Player.PickUpItem(this, 1);
                ActorManager.Singleton.DestroyActor(this);
                Player.Inventory.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Debug.Log);
                return true;
            }
            else
            {
                Player.Inventory[this]++;
                return true;
            }

        }


    }
}
