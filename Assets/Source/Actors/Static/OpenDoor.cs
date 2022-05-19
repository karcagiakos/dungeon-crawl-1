using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using JetBrains.Annotations;

namespace Assets.Source.Actors.Static
{
    public class OpenDoor : ClosedDoor
    {
        public override int DefaultSpriteId => 147;
        public override string DefaultName => "OpenDoor";

        public bool isOpen;

        public override bool OnCollision(Actor anotherActor)
        {
            isOpen = true;
            EnterNextMap();
            return true;
        }

        public override void EnterNextMap()
        {
            if (isOpen)
            {
                ActorManager.Singleton.DestroyAllActors();
                MapLoader.LoadMap(2);
            }

        }
    }
}