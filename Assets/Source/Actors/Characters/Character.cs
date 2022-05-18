using Assets.Source.Actors.Static.Items;
using DungeonCrawl.Core;

namespace DungeonCrawl.Actors.Characters
{
    public abstract class Character : Actor
    {
        public int Health { get; private set; }

        public int Damage { get; private set; }

        public void ApplyDamage(int damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                // Die
                OnDeath();

                ActorManager.Singleton.DestroyActor(this);
            }
        }

        public void SetHp(int health)
        {
            Health = health;
        }

        public void SetDamage(int damage)
        {
            Damage = damage;
        }

        public void SetDamage(Item item)
        {
            Damage = item.Damage;
        }

        protected abstract void OnDeath();

        /// <summary>
        ///     All characters are drawn "above" floor etc
        /// </summary>
        public override int Z => -1;
    }
}
