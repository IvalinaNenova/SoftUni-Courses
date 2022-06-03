using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Trainer
    {
        public string Name { get; set; }

        public int Badges
        {
            get => _badges;
            set => this._badges = 0;
        }

        public List<Pokemon> Pokemons = new List<Pokemon>();

        private int _badges;

        public Trainer(string trainerName)
        {
            Name = trainerName;
        }

        public void AddBadge()
        {
            _badges += 1;
        }

        public void ReduceHealth()
        {
            foreach (var pokemon in Pokemons)
            {
                pokemon.Health -= 10;
            }
        }

        public void ClearDeadPokemons()
        {
            Pokemons.RemoveAll(pokemons => pokemons.Health <= 0);
        }
    }
}
