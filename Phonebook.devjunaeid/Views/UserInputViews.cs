
using Spectre.Console;
using Enums;
using Models;
using Utils;

namespace Views
{
    public class UserInputViews
    {
        private CustomValidator _validator = new CustomValidator();
        public MainUi GetUiSelection()
        {
            MainUi choice = AnsiConsole.Prompt(new SelectionPrompt<MainUi>()
                .Title("Select [green]options from the menu.[/]?").AddChoices(new List<MainUi>((MainUi[])Enum.GetValues(typeof(MainUi)))));
            return choice;
        }

        public Phonebook GetPhoneBookInput()
        {
            var userInput = new Phonebook();

            userInput.Name = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter [green]Name[/]:")
                    .Validate(name =>
                        !string.IsNullOrWhiteSpace(name)
                            ? ValidationResult.Success()
                            : ValidationResult.Error("[red]Name cannot be empty[/]")));

            userInput.Email = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter [green]Email[/]:")
                    .Validate(email =>
                        _validator.IsValidEmail(email)
                            ? ValidationResult.Success()
                            : ValidationResult.Error("[red]Invalid email format[/]")));

            userInput.Address = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter [green]Address[/]:")
                    .Validate(address =>
                        !string.IsNullOrWhiteSpace(address)
                            ? ValidationResult.Success()
                            : ValidationResult.Error("[red]Address cannot be empty[/]")));

            userInput.PhoneNumber = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter [green]Phone Number[/]:")
                    .Validate(phone =>
                        _validator.IsValidPhoneNumber(phone)
                            ? ValidationResult.Success()
                            : ValidationResult.Error("[red]Invalid phone number format(only +, -, numbers and < 15 char long)[/]")));

            return userInput;
        }

        public Phonebook GetSingleContact(List<Phonebook> allContacts)
        {
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
