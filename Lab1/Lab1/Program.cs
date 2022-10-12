namespace Lab1;

class Program
{
    public static void Main(string[] args)
    {
        Random random = new Random();//створюємо рандом
        GameAccount firstPlayer = new GameAccount("Liza");//ств першого гравця
        GameAccount secondPlayer = new GameAccount("Anna");//ств другого гравця
        Game game = new Game("Volleyball", firstPlayer, secondPlayer);//ств ігру

        for (int i = 0; i < 20; i++)
        {
            game.RandomGame(random.Next(2,8));
        }

        Console.WriteLine("");
        firstPlayer.GetInfo();
        Console.WriteLine("");
        firstPlayer.GetStats();
        Console.WriteLine("\n");
        secondPlayer.GetInfo();
        Console.WriteLine("");
        secondPlayer.GetStats();
        Console.WriteLine("\n");
        game.GetHistoty();
    }
}