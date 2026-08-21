using Core;
using Infra;

namespace App
{
    internal sealed class Data
    {
        public static IReadOnlyList<Character> GetCharacters => Cache.Characters;

        public static Character? GetCharacterByName(string name)
        {
            name = name.Trim().ToLower();
            if (name == string.Empty) return null;

            return Cache.CharacterByName(name);
        }

        public static IReadOnlyList<Quote> GetQuotes => Cache.Quotes;

        public static IReadOnlyList<Quote> GetQuotesByCharacterName(string characterName)
        {
            var character = GetCharacterByName(characterName);
            if (character is null) return [];

            return [.. Cache.Quotes.Where(q => q.CharacterId == character.Id)];
        }
    }
}
