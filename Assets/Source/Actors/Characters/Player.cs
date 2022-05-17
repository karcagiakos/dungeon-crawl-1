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
                PickUpItem(ActorManager.Singleton.GetActorAt<YellowKey>(currentPosition));
                Debug.Log(currentPosition);
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

        public static void PickUpItem(Item item)
        {
            bool isInInventory = Inventory.ContainsKey(item);
            if (!isInInventory)
            {
                var pickedItem = item.Clone();
                Debug.Log("ifág");
                Inventory[pickedItem] = 1;
                ActorManager.Singleton.DestroyActor(item);
                UserInterface.Singleton.SetText(String.Empty, UserInterface.TextPosition.BottomRight);
                Inventory.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Debug.Log);
                Debug.Log(Inventory[pickedItem]);
            }
            else
            {
                var pickedItem = item.Clone();
                Debug.Log("elszág");
                Inventory[pickedItem]++;
                ActorManager.Singleton.DestroyActor(item);
                UserInterface.Singleton.SetText(String.Empty, UserInterface.TextPosition.BottomRight);
                Inventory.Select(i => $"{i.Key}: {i.Value}").ToList().ForEach(Debug.Log);
                Debug.Log(Inventory[pickedItem]);
            }
        }



        /// <summary>
        /// Ennek listának kellene lennie
        /// </summary>
        public static Dictionary<object, int> Inventory { get; set; } = new Dictionary<object, int>();
        public override int DefaultSpriteId => 24;
        public override string DefaultName => "Player";
    }
}
