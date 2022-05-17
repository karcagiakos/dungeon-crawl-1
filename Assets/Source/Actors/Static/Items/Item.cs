using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static.Items
{
    public class Item : Actor
    {
        public override int DefaultSpriteId { get; }
        public override string DefaultName { get; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
