namespace Luan1006.MM202.ExamUnit4
{
    public class MainMenu
    {
        private enum MenuOptions
        {
            LogTodaysWeather,
            Report,
            Exit
        }

        private int currentMenuOptionIndex = 0;
        private string[] menuOptionDescriptions = ["Log today's weather", "Report", "Exit"];

        public void DisplayBanner()
        {
            string banner = "Weather logger";
            Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (banner.Length / 2)) + "}", banner));
            Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + ("---------------".Length / 2)) + "}", "---------------"));
        }

        public void DisplayMenu()
        {
            for (int index = 0; index < menuOptionDescriptions.Length; index++)
            {
                if (index == currentMenuOptionIndex)
                {
                    Console.Write("\u001b[1m"); // ANSI escape code for bold text
                }

                Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (menuOptionDescriptions[index].Length / 2)) + "}", menuOptionDescriptions[index]));

                if (index == currentMenuOptionIndex)
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
                    currentMenuOptionIndex = (currentMenuOptionIndex - 1 + menuOptionDescriptions.Length) % menuOptionDescriptions.Length;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    currentMenuOptionIndex = (currentMenuOptionIndex + 1) % menuOptionDescriptions.Length;
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
            switch (currentMenuOptionIndex)
            {
                case (int)MenuOptions.LogTodaysWeather:
                    throw new NotImplementedException();
                case (int)MenuOptions.Report:
                    throw new NotImplementedException();
                case (int)MenuOptions.Exit:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}