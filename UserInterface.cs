public class UserInterface
{
    private enum MenuItems
    {
        LogTodaysWeather,
        Report,
        Exit
    }

    private int selectedMenuItem;
    private string[] menuItems;

    public UserInterface()
    {
        selectedMenuItem = 0;
        menuItems = ["Log today's weather", "Report", "Exit"];
    }

    public void DisplayBanner()
    {
        string banner = "Weather logger";
        Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (banner.Length / 2)) + "}", banner));
        Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + ("---------------".Length / 2)) + "}", "---------------"));
    }

    public void DisplayMenu()
    {
        for (int i = 0; i < menuItems.Length; i++)
        {
            if (i == selectedMenuItem)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (menuItems[i].Length / 2)) + "}", menuItems[i]));

            Console.ResetColor();
        }
    }

    public void NavigateMenu()
    {
        ConsoleKeyInfo keyInfo;

        do
        {
            Console.Clear();
            DisplayBanner();
            DisplayMenu();

            keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedMenuItem = (selectedMenuItem - 1 + menuItems.Length) % menuItems.Length;
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedMenuItem = (selectedMenuItem + 1) % menuItems.Length;
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                HandleMenuSelection();
            }
        }
        while (keyInfo.Key != ConsoleKey.Escape);
    }

    private void HandleMenuSelection()
    {
        switch (selectedMenuItem)
        {
            case (int)MenuItems.LogTodaysWeather:
                throw new NotImplementedException();
            case (int)MenuItems.Report:
                throw new NotImplementedException();
            case (int)MenuItems.Exit:
                throw new NotImplementedException();
        }
    }
}