using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;

namespace Assets.Source.Actors.Static.Items
{
    public class YellowKey : Actor
    {
        public override int DefaultSpriteId => 559;
        public override string DefaultName => "YellowKey";
        public override int Z => -1;

        //public static void PickUpItem()


        public override bool OnCollision(Actor anotherActor)
        {
            //if (anotherActor is Player)
            //{
            //    if (!Player.Inventory.ContainsKey(this))
            //    {
            //        Player.Inventory.Add(this, 1);
            //        return true;
            //    }
            //    else
            //    {
            //        Player.Inventory[this]++;
            //        return true;
            //    }

            //}
            return true;
        }


    }
}
