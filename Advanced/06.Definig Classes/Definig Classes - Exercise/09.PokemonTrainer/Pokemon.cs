namespace DefiningClasses
{
    public class Pokemon
    {
        public Pokemon(string pokemonName, string pokemonElement, int pokemonHealth)
        {
            Name = pokemonName;
            Element = pokemonElement;
            Health = pokemonHealth;
        }

        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }

    }
}
