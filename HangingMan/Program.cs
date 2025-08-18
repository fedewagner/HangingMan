namespace HangingMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
        
        /*
         * Hangman is a game where a word is secretly chosen and the player guesses letters to fill in the word.
           Each correct guess fills in that letter in the word.  Guess too many wrong letters and the player loses.
           Tips: It is all a matter of taking the letter the player guesses and looping through the word comparing it to each letter in the word character by character. If the letters match, you show that letter to the player. If you reach the end of the word and no letters have been matched, it is a wrong guess.
           Remember that strings are often treated as an array of characters. Most languages have a function to fetch a single letter from a string.
           Keep track of how many wrong guesses the player has done and use this number to determine if the game has been won or lost.
           Added Difficulty: Increase the length of the words and choose more complex unknown words to have the player guess.
         */    
            
        //Define a List or Dictionary with words
        //Select randomly one of those
        //Print the screen telling the user to guess one character
        //check if the character was already given?
        //For each character in the word, check if that character equals with the one give by the user
        //if the character equals, then add this to a list with the positive found characters
        //if the character doesn't equal, then add a counter of tries ++1
        //then check the word and compare with the all the elements from the positive list and in case, a character is found, then add that character to a variable
        // if that character is not in the list, then add "_"
        //Print the variable
        //ask the user to enter a new character

        //Define a List or Dictionary with words
        List<string> listOfWords = new List<string>() {"Hello", "Dog", "House", "Car" };
        
        //Select randomly one of those
        Random random = new Random();
        const int MIN_FOR_RANDOM_FUNCTION = 0;
        int listLength = listOfWords.Count;
        int indexWordToGuess = random.Next(MIN_FOR_RANDOM_FUNCTION, listLength);
        string wordToGuess = listOfWords[indexWordToGuess];
        Console.WriteLine(wordToGuess);
        
        //Print the screen telling the user to guess one character
        Console.WriteLine("Hi there! You need to pick a character to figure out which word has been picked!");
        Console.WriteLine("What Character should we check?");
        
        //store user's character
        string userCharacterGuess;
        userCharacterGuess = Console.ReadLine();
        
        //ADITONAL: make sure only one character is entered
        //check if the character was already given?
        List<char> guessedCharacter = new List<char>();
        if (userCharacterGuess != null)
        {
            if (guessedCharacter.Contains(userCharacterGuess))
                {
                Console.WriteLine("That word is already picked!");
                }
            else
            {
                guessedCharacter.Add(userCharacterGuess);
            }
            
        }




        }
    }
}