using Assets.Source.Actors.Static.Items;
using Assets.Source.Core;
using DungeonCrawl.Core;
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
            SetDamage(2);
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


        private float frame = 0.2f;

        protected override void OnUpdate(float deltaTime)
        {
            if (frame > 1)
            {
                int randomDirection = Random.Range(0, 4);
                Direction direction = (Direction)randomDirection;

                TryMove(direction);
                frame = 0.2f;
            }
            else
            {
                frame += deltaTime;
            }


        }
    }
}
