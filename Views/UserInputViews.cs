
using Spectre.Console;
using Enums;
using Models;

namespace Views
{
  public class UserInputViews
  {
    public MainUi GetUiSelection()
    {
        MainUi choice = AnsiConsole.Prompt(new SelectionPrompt<MainUi>()
            .Title("Select [green]options from the menu.[/]?").AddChoices(new List<MainUi>((MainUi[])Enum.GetValues(typeof(MainUi)))));
        return choice;
    }

    public Phonebook GetPhoneBookInput(){
        var userInput = new Phonebook();
        userInput.Name = AnsiConsole.Ask<string>("Enter [green]Name[/]:");
        userInput.Email = AnsiConsole.Ask<string>("Enter [green]Email[/]:");
        userInput.Address = AnsiConsole.Ask<string>("Enter [green]Address[/]:");
        userInput.PhoneNumber = AnsiConsole.Ask<string>("Enter [green]Phone Number[/]:");

        return userInput;
    }

    public Phonebook GetSingleContact(List<Phonebook> allContacts){
      Phonebook choice = AnsiConsole.Prompt(new SelectionPrompt<Phonebook>().Title("Select a contact to modify/delete...").AddChoices(allContacts));
      return choice;
    }

  
    public ConsoleKeyInfo? ModifyOptionPrompt()
    {
        AnsiConsole.MarkupLine("[green]> Press ESC to return to main menu\n> Press E to edit\n> Press D to delete...[/]");
        while (true)
        {
            var keyPressed = AnsiConsole.Console.Input.ReadKey(true);
            if (keyPressed is { Key: ConsoleKey.Escape } || keyPressed is { Key: ConsoleKey.D } || keyPressed is { Key: ConsoleKey.E })
            {
                return keyPressed;
            }
        }
    }

    public bool ContinueInput(string? extraMessage = null)
    {
        if (extraMessage != null)
        {
            AnsiConsole.MarkupLineInterpolated($"\n[blue]{extraMessage}[/]");
        }

        AnsiConsole.MarkupLine("[green]Press ESC to continue...[/]");

        while (true)
        {
            var keyPressed = AnsiConsole.Console.Input.ReadKey(true);
            if (keyPressed is { Key: ConsoleKey.Escape })
            {
                return true;
            }
        }
    }
  }
}
