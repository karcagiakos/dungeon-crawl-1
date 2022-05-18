using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Source.Core;
using DungeonCrawl.Actors;

namespace Assets.Source.Actors.Static.Items
{
    public abstract class Item : Actor
    {
        public int Damage { get; set; }
        public abstract int Owned { get; set; }
        public override int DefaultSpriteId { get; }
        public override string DefaultName { get; }

        public override bool OnCollision(Actor anotherActor)
        {
            UserInterface.Singleton.SetText("Press E to pick up", UserInterface.TextPosition.BottomRight);
            return true;
        }


        //public object Clone()
        //{
        //    return this.MemberwiseClone();
        //}



    }
}
