using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static.Items
{
    public class Sword : Item
    {

        public override int DefaultSpriteId => 417;
        public override string DefaultName => "Sword";
        public override int Z => -1;
        public override int Owned { get; set; } = 1;


        public Sword()
        {
            Damage = 10;
        }

    }

}

