# 2. Hangman
### Required Features:
* The player has 10 guesses to complete the word before losing the game. 
* The player can make two type of guesses:
#### 1. Guess for a specific letter. If player guess a letter that occurs in the word, the program should update by inserting the letter in the correct position(s).

#### 2. Guess for the whole word. The player type in a word he/she thinks is the word. If the guess is correct player wins the game and the whole word is revealed. If the word is incorrect nothing should get revealed. 

#### 3. If the player guesses the same letter twice, the program will not consume a guess. 

### Code Requirements:
* The secret word should be randomly chosen from an array of Strings
* The incorrect letters the player has guessed, should be put inside a StringBuilder and presented to the player after each guess. 
* The correct letters should be put inside a char array. Unrevealed letters need to be represented by a lower dash ( _ ).

### Optional:
* You unit tests need to have at least 50% coverage. 
* Read in the words from a text file with Comma-separated values and then store them in an array or list of Strings.