using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Assets.Source.Actors.Static.Items;
using Assets.Source.Core;
using DungeonCrawl.Core;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;


namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {
        public static Dictionary<string, int> Inventory { get; set; } = new Dictionary<string, int>();
        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";
        public static int WeaponDamage { get; set; } = 5;

        public Player()
        {
            SetHp(20);
            SetDamage(WeaponDamage);
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Attack(Direction.Up);
                // Move up
                TryMove(Direction.Up);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Attack(Direction.Down);
                // Move down
                TryMove(Direction.Down);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                Attack(Direction.Left);
                // Move left
                TryMove(Direction.Left);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                Attack(Direction.Right);
                // Move right
                TryMove(Direction.Right);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                (int x, int y) currentPosition = (Position.x, Position.y);
                PickUpItem(ActorManager.Singleton.GetActorAt<Item>(currentPosition));
                Debug.Log(currentPosition);
            }

            if (deltaTime > 0)
            {

                UserInterface.Singleton.SetText("Health: " + Health, UserInterface.TextPosition.BottomLeft);

                if (Inventory is null)
                {
                    UserInterface.Singleton.SetText("Inventory:", UserInterface.TextPosition.TopLeft);
                }
                if (Inventory is not null)
                {
                    UserInterface.Singleton.DisplayInventory(Inventory);
                }
            }
        }

        public override bool OnCollision(Actor anotherActor)
        {
            if (anotherActor is Skeleton)
            {
                if (Health <= 0)
                {
                    UserInterface.Singleton.SetText("You are dead", UserInterface.TextPosition.BottomRight);
                }

            }
            return false;
        }


        protected override void OnDeath()
        {
            Debug.Log("Oh no, I'm dead!");
        }

        public void PickUpItem(Item item)
        {
            if (WeaponDamage == 0)
            {
                WeaponDamage = item.Damage;
            }
            else if (WeaponDamage < item.Damage)
            {
                WeaponDamage = item.Damage;
            }

            if (!Inventory.ContainsKey(item.DefaultName))
            {
                Debug.Log("ifág");
                Inventory.Add(item.DefaultName, item.Owned);
                ActorManager.Singleton.DestroyActor(item);
                UserInterface.Singleton.SetText(String.Empty, UserInterface.TextPosition.BottomRight);
            }
            else if (Inventory.ContainsKey(item.DefaultName))
            {
                Debug.Log("elszág");
                Inventory[item.DefaultName]++;
                item.Owned++;
                ActorManager.Singleton.DestroyActor(item);
                UserInterface.Singleton.SetText(String.Empty, UserInterface.TextPosition.BottomRight);
            }
        }

        public void Attack(Direction direction)
        {
            var vector = direction.ToVector();
            (int x, int y) targetPosition = (Position.x + vector.x, Position.y + vector.y);

            var actorAtTargetPosition = ActorManager.Singleton.GetActorAt(targetPosition);

            if (actorAtTargetPosition is Skeleton)
            {
                ApplyDamage(2);
            }
        }

    }
}
