using Core;

namespace Infra
{
    public sealed class Cache
    {
        private static readonly Lazy<Cache> _instance = new(() => new Cache());

        private readonly List<Character> _characters = [];
        private readonly Dictionary<string, Character> _charactersByName = [];

        private readonly List<Quote> _quotes = [];

        private Cache()
        {
            var requests = new APIRequests();

            var characters = requests.GetCharactersAsync().Result;
            foreach (var character in characters)
            {
                _characters.Add(character);
                _charactersByName[character.Name.Trim().ToLower()] = character;
            }

            var quotes = requests.GetQuotesAsync().Result;
            foreach (var quote in quotes)
            {
                _quotes.Add(quote);
            }
        }

        private static Cache Instance => _instance.Value;

        public static IReadOnlyList<Character> Characters => Instance._characters;
        public static Character? CharacterByName(string name) => Instance._charactersByName.GetValueOrDefault(name);
        public static IReadOnlyList<Quote> Quotes => Instance._quotes;
    }
}
