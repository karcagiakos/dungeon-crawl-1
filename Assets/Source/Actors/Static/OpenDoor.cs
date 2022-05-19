using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;

namespace Assets.Source.Actors.Static
{
    public class OpenDoor : ClosedDoor
    {
        public override int DefaultSpriteId => 147;
        public override string DefaultName => "OpenDoor";

        public override bool OnCollision(Actor anotherActor)
        {

            //System.Threading.Thread.Sleep(3000);
            return true;
        }


    }
}