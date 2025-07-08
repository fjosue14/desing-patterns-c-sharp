using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desing_patterns_c_sharp.Behavioral.Iterator
{
   
    public class Pkm
    {
        public string Name { get; }
        public string Type { get; }

        public Pkm(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public override string ToString()
        {
            return $"Pokemon: {Name}, Type: {Type}";
        }
    }

    public class PkmCollection : IEnumerable<Pkm>
    { 
        private List<Pkm> pokemons = new List<Pkm>();

        public void AddPokemon(Pkm pokemon)
        {
            pokemons.Add(pokemon);
        }

        public IEnumerator<Pkm> GetEnumerator()
        {
            foreach (var pokemon in pokemons)
            {
                yield return pokemon;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

    public static class Iterator_2
    {
        public static void Main()
        {
            var pokedex = new PkmCollection();
            pokedex.AddPokemon(new Pkm("Pikachu", "Electric"));
            pokedex.AddPokemon(new Pkm("Charmander", "Fire"));
            pokedex.AddPokemon(new Pkm("Squirtle", "Water"));
            pokedex.AddPokemon(new Pkm("Bulbasaur", "Plant"));

            Console.WriteLine("Touring the Pokemon collection:");
            foreach (var pokemon in pokedex)
            {
                Console.WriteLine(pokemon);
            }
        }
    }

}
