//Tic Tac Toe game - for now only checks if the game is won 
public class TicTacToe
{
    private readonly char[,] _board = new char[3,3];

    public TicTacToe(char[,] board)
    {
        _board = board;
    }

    public bool IsWonBy(char playerSymbol)
    {
        return 
            IsAnyRowFilledWith(playerSymbol) ||
            IsAnyColumnFilledWith(playerSymbol) ||
            IsAnyDiagonalFilledWith(playerSymbol);
    }

    private bool IsAnyRowFilledWith(char playerSymbol)
    {
        for (int rowIndex = 0; rowIndex < 3; rowIndex++)
        {
            if (_board[rowIndex, 0] == playerSymbol &&
                _board[rowIndex, 1] == playerSymbol &&
                _board[rowIndex, 2] == playerSymbol)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsAnyColumnFilledWith(char playerSymbol)
    {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++)
        {
            if (_board[0, columnIndex] == playerSymbol &&
                _board[1, columnIndex] == playerSymbol &&
                _board[2, columnIndex] == playerSymbol)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsAnyDiagonalFilledWith(char playerSymbol)
    {
        if ((_board[0, 0] == playerSymbol &&
            _board[1, 1] == playerSymbol &&
            _board[2, 2] == playerSymbol) ||
            (_board[0, 2] == playerSymbol &&
            _board[1, 1] == playerSymbol &&
            _board[2, 0] == playerSymbol))
        {
            return true;
        }
        return false;
    }
}
