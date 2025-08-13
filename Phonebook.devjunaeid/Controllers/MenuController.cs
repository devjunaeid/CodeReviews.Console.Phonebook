using Enums;
using Views;
using Models;
using Spectre.Console;

namespace Controllers
{
    public class MenuController
    {
        private static bool IsRunning { get; set; }
        private UserInputViews _userInput = new UserInputViews();
        private UserViews _userViews = new UserViews();
        private PhonebookController _phonebookController = new PhonebookController();

        public MenuController()
        {
            IsRunning = true;
        }

        public async Task MainMenu()
        {
            while (IsRunning)
            {
                _userViews.ShowProjectInfo();
                var choice = _userInput.GetUiSelection();
                switch (choice)
                {
                    case MainUi.NewContact:
                        Phonebook newContact = _userInput.GetPhoneBookInput();
                        await _phonebookController.AddNewContact(newContact);
                        _userInput.ContinueInput();
                        Console.Clear();
                        break;
                    case MainUi.ViewContacts:
                        List<Phonebook> phonebooks = await _phonebookController.GetAllContacts();
                        if (phonebooks.Count <= 0)
                        {
                            Console.WriteLine("No Contact Found!");
                        }
                        else
                        {
                            _userViews.ShowContacts(phonebooks);
                        }
                        _userInput.ContinueInput();
                        Console.Clear();
                        break;
                    case MainUi.ModifyContact:
                        List<Phonebook> phonebookList = await _phonebookController.GetAllContacts();
                        if (phonebookList.Count <= 0)
                        {
                            Console.WriteLine("No Contact Found!");
                        }
                        else
                        {
                            Phonebook selectedContact = _userInput.GetSingleContact(phonebookList);
                            var userAction = _userInput.ModifyOptionPrompt();
                            switch (userAction?.Key)
                            {
                                case ConsoleKey.Escape:
                                    break;
                                case ConsoleKey.D:
                                    await _phonebookController.DeleteContact(selectedContact.Id);
                                    break;
                                case ConsoleKey.E:
                                    AnsiConsole.MarkupLine($"Editing: {selectedContact.Name} - {selectedContact.PhoneNumber}\n\n");
                                    Phonebook modifiedContact = _userInput.GetPhoneBookInput();
                                    await _phonebookController.ModifyContact(modifiedContact, selectedContact.Id);
                                    break;
                            }
                        }
                        _userInput.ContinueInput();
                        Console.Clear();
                        break;
                    case MainUi.Exit:
                        IsRunning = false;
                        Console.Clear();
                        break;
                }
            }
        }

    }
}
