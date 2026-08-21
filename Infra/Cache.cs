using Core;

namespace Infra
{
    public sealed class Cache
    {
        private static readonly Lazy<Cache> _instance = new(() => new Cache());

        private readonly List<Character> _characters = [];
        private readonly Dictionary<string, Character> _charactersById = [];

        private readonly List<Quote> _quotes = [];

        private Cache()
        {
            var requests = new APIRequests();

            var characters = requests.GetCharactersAsync().Result;
            foreach (var character in characters)
            {
                _characters.Add(character);
                _charactersById[character.Id] = character;
            }
            _characters.Sort((c1, c2) => string.Compare(c1.Name, c2.Name, StringComparison.Ordinal));

            var quotes = requests.GetQuotesAsync().Result;
            foreach (var quote in quotes)
            {
                var character = _charactersById.GetValueOrDefault(quote.CharacterId);
                if (character is null) continue;

                quote.CharacterName = character.Name;
                _quotes.Add(quote);
            }
        }

        private static Cache Instance => _instance.Value;

        public static IReadOnlyList<Character> Characters => Instance._characters;
        public static IReadOnlyList<Character> CharactersByName(string name) =>
            [.. Instance._characters.Where(c => c.Name.Trim().ToLower().Contains(name))];

        public static IReadOnlyList<Quote> Quotes => Instance._quotes;
    }
}
