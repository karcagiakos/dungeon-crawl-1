using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Skeleton : Character
    {
        public override int DefaultSpriteId => 316;
        public override string DefaultName => "Skeleton";

        public Skeleton()
        {
            SetHp(20);
            SetDamage(5);
        }


        public override bool OnCollision(Actor anotherActor)
        {
            ApplyDamage(Player.WeaponDamage);
            Debug.Log(Health);
            return false;
        }


        protected override void OnDeath()
        {
            Debug.Log("Well, I was already dead anyway...");
        }

    }
}
