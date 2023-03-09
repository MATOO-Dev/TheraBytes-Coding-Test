//Let‘s Code: Reversi
//Background: About the game Reversi
//Reversi (a.k.a Othello) is a game for two players on a square tiled board.
//Each player puts a disc on an empty tile in every of his / her turns.The disc is red on one side and
//black on the other.The players always turn their respective color facing up when placing a disc.
//If a player puts a disc next to a series of opponent discs and on the other side of that series is again a
//disc of the active player, the enclosed tokens are turned around and taken over.
//Any direction for overtaking is valid, including diagonals.
//    It is also possible to take over more than one series of discs with one placed disc.
//This is all you have to know about Reversi for this exercise.
//Exercise Description
//Your solution will receive a state of a Reversi game in form of a string.You are the active player.You
//have to find the tile where the greatest amount of discs can be taken over, if the next disc would be
//placed at that tile.
//Return the position of that tile.
//If there is more than one position with the same amount of discs to take over, return any one of
//them.
//The string you will receive contains the game board.
//The first line of the string contains the width followed by the height of the board. These values are
//separated by a space character.
//Each further line of the string corresponds to a line of the board.
//Every second character in a line represents one tile and its content:
//• An empty tile is represented by a dot: '.'
//• A disc owned by the opponent is represented by an 'O'
//• A disc owned by the active player (you) is represented by an 'X'
//• There is a space ' ' behind every tile-character which can be ignored
//Unlike in the original game, the dimension of the game board can differ:
//• 3 < width <= 26
//• 0 < height <= 26
//The colums of the board are counted with ongoing uppercase Letters (A, B, C, ...).
//The rows of the board are counted with numbers starting with 1 (1, 2, 3, ...).
//For the output value you have to use this counting, specifying the column first with the letter
//followed by the row with a number.
//Examples:
//• For the tile at the very top left, pass "A1"
//• For the tile third from the left, second from the top, pass "C2"
//Project Setup
//If you choose to use C# as programming language, add the following code to your project as entry
//point for your solution (if you use a different language, make it similar to that code):
//public class Solution
//{
//    public static string PlaceToken(string board)
//    {
//    }
//}
//To test your solution call „Solution.PlaceToken()“ from the Main method of your program and pass a
//string representing the board you want to test.
//You can copy the following code to your main function (C#) to test your program:
//public static void Main(String[] args)
//{
//    // 1. Correct Answer: "E1"
//    string board1 = @"5 1
//X O O O . ";
//    string result1 = Solution.PlaceToken(board1);
//    Console.WriteLine("board 1: " + result1);
//    // 2. Correct Answer: "B2"
//    string board2 = @"8 7
//. . . . . . . .
//. . . . . . . .
//. . O . . . . .
//. . . O X . . .
//. . . X O O . .
//. . . . . X . .
//. . . . . . X . ";
//    string result2 = Solution.PlaceToken(board2);
//    Console.WriteLine("board 2: " + result2);
//    // 3. Correct Answer: "D3", "C4", "F5", "E6"
//    string board3 = @"8 8
//. . . . . . . .
//. . . . . . . .
//. . . . . . . .
//. . . O X . . .
//. . . X O . . .
//. . . . . . . .
//. . . . . . . .
//. . . . . . . . ";
//    string result3 = Solution.PlaceToken(board3);
//    Console.WriteLine("board 3: " + result3);
//    // 4. Correct Answer: "D6
//    string board4 = @"7 6
//. . . . . . .
//. . . O . O .
//X O O X O X X
//. O X X X O X
//. X O O O . X
//. . . . . . . ";
//    string result4 = Solution.PlaceToken(board4);
//    Console.WriteLine("board 4: " + result4);
//}
//Please do not change the input string(board1, ..., board4).There are new line characters added after
//each line because of the @-sign in front of the string