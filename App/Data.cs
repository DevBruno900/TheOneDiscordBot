using Core;
using Infra;

namespace App
{
    internal sealed class Data
    {
        public static IReadOnlyList<Character> GetCharacters => Cache.Characters;

        public static IReadOnlyList<Character> GetCharactersByName(string name)
        {
            name = name.Trim().ToLower();
            if (name == string.Empty) return [];

            return Cache.CharactersByName(name);
        }

        public static IReadOnlyList<Quote> GetQuotes => Cache.Quotes;

        public static IReadOnlyList<Quote> GetQuotesByCharacter(string characterName)
        {
            var characters = GetCharactersByName(characterName);
            if (characters.Count == 0) return [];

            var quotes = new List<Quote>();
            foreach (var character in characters)
            {
                quotes.AddRange([.. Cache.Quotes.Where(q => q.CharacterId == character!.Id)]);
            }

            return quotes;
        }
    }
}
