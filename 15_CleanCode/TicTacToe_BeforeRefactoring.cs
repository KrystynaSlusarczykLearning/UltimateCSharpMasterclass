//Tic Tac Toe game - for now only checks if the game is won 
public class Game
{
    private readonly char[,] gameArray = new char[3, 3];

    public Game(char[,] gameArray)
    {
        this.gameArray = gameArray;
    }

    public bool Win(char c)
    {
        // Check rows
        for (int i = 0; i < 3; i++)
        {
            if (gameArray[i, 0] == c && gameArray[i, 1] == c && gameArray[i, 2] == c)
            {
                return true;
            }
        }

        // Check columns
        for (int i = 0; i < 3; i++)
        {
            if (gameArray[0, i] == c && gameArray[1, i] == c && gameArray[2, i] == c)
            {
                return true;
            }
        }

        // Check diagonals
        if ((gameArray[0, 0] == c && gameArray[1, 1] == c && gameArray[2, 2] == c) ||
            (gameArray[0, 2] == c && gameArray[1, 1] == c && gameArray[2, 0] == c))
        {
            return true;
        }

        return false;
    }
}
