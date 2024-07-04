namespace OOP.Task4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Player playerKostya = new("Kostya");
            Player playerPasha = new("Pasha");

            Deck deck = new Deck();

            Dealer dealer = new(deck, handOutCardsCount: 6);
            dealer.AddPlayerToGame(playerKostya);
            dealer.AddPlayerToGame(playerPasha);

            dealer.HandOutCards();

            dealer.ShowPlayersCards();
            dealer.ShowDeck();
        }
    }

    internal enum CardType
    {
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Joker,
    }

    internal enum CardColor
    {
        Red,
        Black
    }

    internal enum CardSuitType
    {
        None,
        Booby,
        Spades,
        Clubs,
        Hearts,
    }

    internal struct Card
    {
        public Card(CardColor color, CardSuitType suit, CardType type)
        {
            Color = color;
            Suit = suit;
            Type = type;
        }

        public CardColor Color { get; private set; }

        public CardSuitType Suit { get; private set; }

        public CardType Type { get; private set; }

        public override string ToString()
        {
            return $"{Color} {Suit} {Type}";
        }
    }

    internal class Deck
    {
        private List<Card> _cards;

        public Deck()
        {
            _cards = new List<Card>();

            Dictionary<CardSuitType, CardColor> cardsSuitColors = new()
                {
                    { CardSuitType.Booby, CardColor.Red },
                    { CardSuitType.Hearts, CardColor.Red },
                    { CardSuitType.Clubs, CardColor.Black },
                    { CardSuitType.Spades, CardColor.Black },
                };

            List<CardSuitType> excludedNoneSuits = Enum
                .GetValues<CardSuitType>()
                .Where(suit => suit != CardSuitType.None)
                .ToList();

            List<CardType> excludedJockerTypes = Enum
                .GetValues<CardType>()
                .Where(card => card != CardType.Joker)
                .ToList();

            foreach (CardSuitType suit in excludedNoneSuits)
            {
                foreach (CardType cardType in excludedJockerTypes)
                {
                    Card newCard = new(cardsSuitColors[suit], suit, cardType);

                    _cards.Add(newCard);
                }
            }

            Card blackJoker = new(CardColor.Black, CardSuitType.None, CardType.Joker);
            Card redJoker = new(CardColor.Red, CardSuitType.None, CardType.Joker);

            _cards.Add(blackJoker);
            _cards.Add(redJoker);
        }

        public Deck(List<Card> cards)
        {
            _cards = cards;
        }

        public bool IsDeckEmpty => _cards.Count == 0;

        public List<Card> ProvideCards(int count)
        {
            List<Card> outCards = new List<Card>();

            for (int i = 0; i < count; ++i)
            {
                if (IsDeckEmpty == false)
                {
                    outCards.Add(_cards.First());

                    _cards.Remove(_cards.First());
                }
            }

            return outCards;
        }

        public void ShowCards()
        {
            Console.WriteLine("Deck:");

            foreach (Card card in _cards)
            {
                Console.WriteLine(card);
            }
        }
    }

    internal class Player
    {
        private List<Card> _cards;

        public Player(string name)
        {
            _cards = new List<Card>();

            Name = name;
        }

        public string Name { get; private set; }

        public void TakeCards(List<Card> cards)
        {
            _cards.AddRange(cards);
        }

        public void ShowCards()
        {
            Console.WriteLine($"Cards:");

            foreach (Card card in _cards)
            {
                Console.WriteLine(card);
            }
        }
    }

    internal class Dealer
    {
        private List<Player> _players;

        private Deck _deck;

        private int _handOutCardsCount;

        public Dealer(Deck newGameDeck, int handOutCardsCount)
        {
            _deck = newGameDeck;
            _handOutCardsCount = handOutCardsCount;
            _players = new List<Player>();
        }

        public void AddPlayerToGame(Player player)
        {
            _players.Add(player);
        }

        public void HandOutCards()
        {
            foreach (Player player in _players)
            {
                List<Card> cards = _deck.ProvideCards(_handOutCardsCount);

                player.TakeCards(cards);
            }
        }

        public void ShowPlayersCards()
        {
            foreach (Player player in _players)
            {
                Console.WriteLine($"Player: {player.Name}");

                player.ShowCards();
            }
        }

        public void ShowDeck()
        {
            _deck.ShowCards();
        }
    }
}
