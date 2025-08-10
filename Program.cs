using Controllers;

public class Program
{
    public static async Task Main(string[] args)
    {
        MenuController _menu = new MenuController();
        Console.Clear();
        await _menu.MainMenu();
    }
}
