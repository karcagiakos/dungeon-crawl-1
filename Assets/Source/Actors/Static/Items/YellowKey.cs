using Assets.Source.Core;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using System;
using System.Linq;
using UnityEngine;

namespace Assets.Source.Actors.Static.Items
{
    public class YellowKey : Item
    {
        public override int DefaultSpriteId => 559;
        public override string DefaultName => "YellowKey";
        public override int Owned { get; set; } = 1;
        public override int Z => -1;


    }
}
