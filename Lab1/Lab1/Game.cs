using System.Text;

namespace Lab1;

public class Game
{
    public string GameName { get; }//ім'я гри 
    public int GameCount { get; private set; }//кількість зіграних ігор
    public GameAccount FirstPlayer { get; }//сторюємо першого гравця
    public GameAccount SecondPlayer { get; }//сторюємо другого гравця 
    private Random random;//строрюємо рандом
    private StringBuilder history;//історія ігор
    private static int id = 123450;//ідентифікатор ігор

    public Game(string gameName, GameAccount firstPlayer, GameAccount secondPlayer)
    {
        GameName = gameName;
        FirstPlayer = firstPlayer;
        SecondPlayer = secondPlayer;
        random = new Random();
        history = new StringBuilder();
        history.Append("  ID        OPONENT1        OPONENT2       RATING          WINNER\n");

    }
    //функція, що рамдомно  визначає переможця
    public void RandomGame(int rating)
    {
        int resultRandom = random.Next(1, 3);
        if (resultRandom == 1)
        {
            FirstPlayer.WinGame(SecondPlayer, rating, id);
            SecondPlayer.LoseGame(FirstPlayer, rating, id);
            history.Append(
                $"{id,-6}        {FirstPlayer.UserName,-8}        {SecondPlayer.UserName,-8}        {rating,-6}        {FirstPlayer.UserName,-6}   \n");
        }
        else
        {
            SecondPlayer.WinGame(FirstPlayer, rating, id);
            FirstPlayer.LoseGame(SecondPlayer, rating, id);
            history.Append(
                $"{id,6}        {FirstPlayer.UserName,-8}        {SecondPlayer.UserName,-8}        {rating,-6}        {SecondPlayer.UserName,-6}   \n");
        }

        GameCount++;
        id++;
    }

    //історію ігор стола
    public void GetHistoty()
    {
        Console.WriteLine("History game ");
        Console.WriteLine("Game name: " + GameName);
        Console.WriteLine("Count games: " + GameCount);
        Console.WriteLine(history);
    }
}