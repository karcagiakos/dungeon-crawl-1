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
        public static int WeaponDamage { get; set; } = 0;

        public Player()
        {
            SetHp(100);
            SetDamage(WeaponDamage);
        }





        protected override void OnUpdate(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                // Move up
                TryMove(Direction.Up);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                // Move down
                TryMove(Direction.Down);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                // Move left
                TryMove(Direction.Left);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
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
                //var pickedItem = item.Clone();
                Debug.Log("ifág");
                Inventory.Add(item.DefaultName, item.Owned);
                ActorManager.Singleton.DestroyActor(item);
                UserInterface.Singleton.SetText(String.Empty, UserInterface.TextPosition.BottomRight);
                //Inventory.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Debug.Log);
                Debug.Log(item.Owned);
            }
            else if (Inventory.ContainsKey(item.DefaultName))
            {
                //var pickedItem = item.Clone();
                Debug.Log("elszág");
                Inventory[item.DefaultName]++;
                item.Owned++;
                ActorManager.Singleton.DestroyActor(item);
                UserInterface.Singleton.SetText(String.Empty, UserInterface.TextPosition.BottomRight);
                //Inventory.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Debug.Log);
                Debug.Log(item.Owned);
            }
        }



    }
}
