using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static.Items
{
    public class YellowKey : Actor
    {
        public override int DefaultSpriteId => 559;
        public override string DefaultName => "YellowKey";
        public override int Z => -1;

        public override bool OnCollision(Actor anotherActor)
        {
            return true;
        }

    }
}
