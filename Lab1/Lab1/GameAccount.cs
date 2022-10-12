using System.Text;

namespace Lab1;

public class GameAccount
{
    public string UserName { get; }//ім'я гравця
    public int CurrentRating { get; private set; } = 1;//рейтинг користувача
    public int GameCount { get; private set; } //кількість зіграних ігор
    private StringBuilder history;//історія ігор

    public GameAccount(string userName)
    {
        UserName = userName;
        history = new StringBuilder();
        history.Append($"  ID         Result       Rating         Oponent      {UserName} rating   \n");
    }

    public void GetInfo() //функція, що виводить інформацію про гравця
    { 
        Console.WriteLine("Information about player ");
        Console.WriteLine("Name: " + UserName);
        Console.WriteLine("Rating: " + CurrentRating);
        Console.WriteLine("GаmeCount: " + GameCount);
    }

    //функція, що виводить історію ігор гравця
    public void GetStats()
    {
        Console.WriteLine("History account " + UserName);
        Console.WriteLine(history);
    }
    //функція, що викликається  у випадку перемоги
    public void WinGame(GameAccount opponent, int rating, int id)
    {
        if (rating < 0)
        {
            throw new Exception(" Рейтинг від`ємний");
        }

        CurrentRating += rating;
        GameCount++;
        history.Append(
            $"{id,-6}        {Result.Win,-6}        {rating,-6}        {opponent.UserName,-7}        {$"{CurrentRating} (+{rating})",-11}\n"); //добавляю у хісторі результат
    }

    //функція, що викликається  у випадку програшу
    public void LoseGame(GameAccount opponent, int rating, int id)
    {
        if (rating < 0)
        {
            throw new Exception(" Pейтинг від`ємний");
        }

        if (CurrentRating - rating < 1)
        {
            CurrentRating = 1;
        }
        else
        {
            CurrentRating -= rating;
        }
    
        GameCount++;
        history.Append(
            $"{id,-6}        {Result.Lose,-6}        {rating,-6}        {opponent.UserName,-7}        {$"{CurrentRating} (-{rating})",-11}\n");

       
    }
}