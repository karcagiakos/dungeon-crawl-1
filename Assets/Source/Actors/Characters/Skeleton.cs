using System;
using Assets.Source.Actors.Static.Items;
using Assets.Source.Core;
using DungeonCrawl.Core;
using UnityEngine;
using System.Threading.Tasks;
using Random = UnityEngine.Random;

namespace DungeonCrawl.Actors.Characters
{
    public class Skeleton : Character
    {
        public override int DefaultSpriteId => 316;
        public override string DefaultName => "Skeleton";

        public Skeleton()
        {
            SetHp(20);
            //SetDamage(2);
        }


        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Player)
            {
                ApplyDamage(Player.WeaponDamage);
                UserInterface.Singleton.SetText($"Enemy's health: {Health}", UserInterface.TextPosition.BottomRight);
                if (Health <= 0)
                {
                    UserInterface.Singleton.SetText("Enemy is dead", UserInterface.TextPosition.BottomRight);
                }

            }

            return false;
        }

        //public void AttackPlayer(Direction direction)
        //{
        //    var vector = direction.ToVector();
        //    (int x, int y) targetPosition = (Position.x + vector.x, Position.y + vector.y);

        //    var actorAtTargetPosition = ActorManager.Singleton.GetActorAt(targetPosition);

        //    if (actorAtTargetPosition is Skeleton)
        //    {
        //        ApplyDamage(2);
        //    }
        //}


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
