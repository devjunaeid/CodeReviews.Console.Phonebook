using Controllers;

public class Program{
  public static async Task Main(string[] args){
    MenuController _menu = new MenuController();
    await _menu.MainMenu();
  }
}
