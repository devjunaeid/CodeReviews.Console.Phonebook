using Spectre.Console;
using Models;

namespace Views
{
  public class UserViews
  {
    public void ShowProjectInfo()
    {
      var appName = new FigletText("Contact Keeper")
              .Color(Color.Cyan1)
              .Centered();
          AnsiConsole.Write(appName);
          AnsiConsole.Write(new Align(new Markup("-[orange3 italic] Keep your contact organized...[/]"), HorizontalAlignment.Center, VerticalAlignment.Top));
    }

    public void ShowContacts(List<Phonebook> phonebooks)
    {
      var table = new Table();
      table.Border(TableBorder.Rounded);
      table.AddColumn("[yellow]Name[/]");
      table.AddColumn("[blue]Email[/]");
      table.AddColumn("[green]Phone[/]");
      table.AddColumn("[grey]Address[/]");
      table.AddColumn("[white]Created[/]");

      foreach (var entry in phonebooks)
      {
        table.AddRow(
          entry.Name,
          entry.Email ?? "-",
          entry.PhoneNumber,
          entry.Address ?? "-",
          entry.CreatedAt.ToString("yyyy-MM-dd HH:mm")
        );
      }
      AnsiConsole.Write(table);
    }
  }

  
}
