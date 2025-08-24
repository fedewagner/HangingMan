namespace HangingMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //const always at the top
            const int MAX_TRIED_CHARACTERS = 5;
            const int MIN_FOR_RANDOM_FUNCTION = 0;

            //Putting some art
            var HANGMANPICS = new List<string>
            {
                @"
  +---+
  |   |
      |
      |
      |
      |
=========",
                @"
  +---+
  |   |
  O   |
      |
      |
      |
=========",
                @"
  +---+
  |   |
  O   |
 /|\  |
      |
      |
=========",
                @"
  +---+
  |   |
  O   |
 /|\  |
  |   |
      |
=========",
                @"
  +---+
  |   |
  O   |
 /|\  |
  |   |
 / \  |
========="
            };

            //Define a List or Dictionary with words
            List<string> listOfWords = new List<string>()
            {
                "abundance", "accomplish", "adventure", "affectionate", "amusement",
                "appearance", "appreciate", "astonishing", "atmosphere", "background",
                "benevolent", "biological", "bookkeeper", "brilliance", "calculation",
                "capability", "celebration", "characteristic", "civilization", "collaboration",
                "commitment", "communication", "competition", "complexity", "composition",
                "comprehensive", "consequence", "consideration", "construction", "contagious",
                "convenience", "cooperation", "courageous", "creativity", "curiosity",
                "dedication", "deliberate", "democratic", "description", "determination",
                "development", "discovery", "distinction", "electricity", "enthusiasm",
                "environment", "establishment", "evaluation", "experience", "explanation",
                "fascination", "friendship", "fundamental", "generation", "governments",
                "gratitude", "harmonious", "imagination", "importance", "improvement",
                "independent", "information", "innovation", "instrument", "intelligence",
                "interaction", "interesting", "intermediate", "investigate", "invitation",
                "knowledgeable", "leadership", "librarianship", "literature", "magnificent",
                "mathematical", "meaningful", "medication", "motivation", "multimedia",
                "navigation", "necessities", "negotiation", "observation", "opportunity",
                "organization", "partnership", "performance", "personality", "perspective",
                "philosopher", "photography", "population", "possibility", "preparation",
                "productivity", "professional", "psychology", "recognition", "relationship"
            };

            //allowed alphabet
            var alphabetLower = new List<char>
            {
                'a','b','c','d','e','f','g','h','i','j',
                'k','l','m','n','o','p','q','r','s','t',
                'u','v','w','x','y','z'
            };

            //Select randomly one of those words
            Random random = new Random();
            int listLength = listOfWords.Count;
            int indexWordToGuess = random.Next(MIN_FOR_RANDOM_FUNCTION, listLength);
            string wordToGuess = listOfWords[indexWordToGuess];

            //Welcome the user
            Console.WriteLine(
                "Hi there! You need to pick one character to figure out which word has been picked! (only one!)");

            //Variables and lists declaration

            List<char> charactersToGuessList = new List<char>(wordToGuess);
            List<char> triedCharacters = new List<char>();

            int wrongtriedCharactersCount = 0;
            int countOfCharactersToGuess = charactersToGuessList.Distinct().Count();
            int triesLeft = MAX_TRIED_CHARACTERS;


            //While Loop with triedCharactersCount for checking loosing and countOfCharactersToGuess for winning
            while (triesLeft > 0 &&
                   countOfCharactersToGuess > 0)
            {
                //Print the screen for the user and read key
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("What character should be checked?");
                Console.ForegroundColor = ConsoleColor.White;
                
                //check the introduced character is in the accepted dictionary
                var keyInfo = Console.ReadKey(true);
                char userCharacterGuess = char.ToLower(keyInfo.KeyChar);
                while (!alphabetLower.Contains(userCharacterGuess)){
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Please introduce a character from the english alphabet!");
                    Console.ForegroundColor = ConsoleColor.White;
                    keyInfo = Console.ReadKey(true);
                    userCharacterGuess = char.ToLower(keyInfo.KeyChar);
                }
                //check if the character was already given.
                if (triedCharacters.Contains(userCharacterGuess))
                {
                    //already used character => we don't do anything
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"You've already tried with '{userCharacterGuess}'!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    //the character is new, so we add it to the list of tried characters
                    Console.WriteLine($"'{userCharacterGuess}' just checked");
                    triedCharacters.Add(userCharacterGuess);

                    //check if the word contains the guessed character
                    if (wordToGuess.Contains(userCharacterGuess))
                    {
                        //in case it contains it ==> nicely done, we congratulate the user
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Well done! '{userCharacterGuess}' is in the word!");
                        Console.ForegroundColor = ConsoleColor.White;
                        
                        //remove the all those characters from the list to be guessed
                        charactersToGuessList.RemoveAll(c => c == userCharacterGuess);
                        
                        //count the characters that still need to be guessed
                        countOfCharactersToGuess = charactersToGuessList.Distinct().Count();
                    }
                    else
                    {
                        //in case it's not in the word => removes a "life"
                        triesLeft--;
                        //increase the counter for the art list
                        wrongtriedCharactersCount++;
                        
                        //in case we still have some lifes available => print extra text and amount of lifes available
                        if (triesLeft > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(
                                $"The character is not in the word! Try again, you have still {triesLeft}.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(HANGMANPICS[wrongtriedCharactersCount - 1]);
                        }
                    }
                }
                
                // in case we still have some character to guess
                if (countOfCharactersToGuess > 0 && triesLeft > 0)
                {
                    //Print the word with guessed characters
                    Console.Write("The word with your guesses looks like this: ");

                    //For each character in the word, check if that character equals with the one give by the user
                    foreach (char character in wordToGuess)
                    {
                        if (triedCharacters.Contains(character))
                        {
                            Console.Write(string.Concat(character, ' '));
                        }
                        else
                        {
                            Console.Write(string.Concat('_', ' '));
                        }
                    }

                    //Print empty line
                    Console.WriteLine();
                }
            }

            //final check if user won or not
            if (countOfCharactersToGuess == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You won 100$ guessing the word '{wordToGuess}'!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("I'm afraid you haven't guessed the word! and you have no try left!");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"The word to guess was: {wordToGuess}");
            }
        }
    }
}