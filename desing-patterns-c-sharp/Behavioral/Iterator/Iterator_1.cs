using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desing_patterns_c_sharp.Behavioral.Iterator
{
    public class Pokemon
    {
        public string Name { get; }
        public string Type { get; }

        public Pokemon(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public override string ToString()
        {
            return $"Pokemon(name='{Name}', type='{Type}')";
        }
    }

    public interface IIterator<T>
    {
        T? Next();
        bool HasNext();
        T? Current();
    }

    public class PokemonCollection
    {
        private List<Pokemon> pokemons = new List<Pokemon>();

        public void Add(Pokemon pokemon)
        {
            pokemons.Add(pokemon);
        }

        public Pokemon? GetPokemon(int index)
        {
            if (index >= 0 && index < pokemons.Count)
                return pokemons[index];
            return null;
        }

        public int GetLength()
        {
            return pokemons.Count;
        }

        public PokemonIterator CreateIterator()
        {
            return new PokemonIterator(this);
        }
    }

    public class PokemonIterator : IIterator<Pokemon>
    {
        private int index = 0;
        private PokemonCollection collection;

        public PokemonIterator(PokemonCollection collection)
        {
            this.collection = collection;
        }

        public Pokemon? Next()
        {
            if (HasNext())
            {
                return collection.GetPokemon(index++);
            }
            return null;
        }

        public bool HasNext()
        {
            return index < collection.GetLength();
        }

        public Pokemon? Current()
        {
            return collection.GetPokemon(index);
        }
    }

    public static class Iterator_1
    {
        public static void Main()
        {
            var pokedex = new PokemonCollection();
            pokedex.Add(new Pokemon("Pikachu", "Electric"));
            pokedex.Add(new Pokemon("Charmander", "Fire"));
            pokedex.Add(new Pokemon("Squirtle", "Water"));

            var iterator = pokedex.CreateIterator();

            while (iterator.HasNext())
            {
                var pokemon = iterator.Next();
                if (pokemon != null)
                    Console.WriteLine(pokemon);
            }
        }
    }

}
