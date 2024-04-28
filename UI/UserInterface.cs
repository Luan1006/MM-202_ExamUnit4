namespace Luan1006.MM202.ExamUnit4
{
    public class MainMenu
    {
        private enum MenuItems
        {
            LogTodaysWeather,
            Report,
            Exit
        }

        private int selectedMenuItem = 0;
        private string[] menuItems = ["Log today's weather", "Report", "Exit"];

        public void DisplayBanner()
        {
            string banner = "Weather logger";
            Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (banner.Length / 2)) + "}", banner));
            Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + ("---------------".Length / 2)) + "}", "---------------"));
        }

        public void DisplayMenu()
        {
            for (int index = 0; index < menuItems.Length; index++)
            {
                if (index == selectedMenuItem)
                {
                    Console.Write("\u001b[1m"); // ANSI escape code for bold text
                }

                Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (menuItems[index].Length / 2)) + "}", menuItems[index]));

                if (index == selectedMenuItem)
                {
                    Console.Write("\u001b[0m"); // ANSI escape code to reset text formatting
                }
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
                    Environment.Exit(0);
                    break;
            }
        }
    }
}