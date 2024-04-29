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

        public void DisplayBanner()
        {
            Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (Constants.banner.Length / 2)) + "}", Constants.banner));
            Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (Constants.bannerLine.Length / 2)) + "}", Constants.bannerLine));
        }


        public void DisplayMenu()
        {
            for (int index = 0; index < Constants.mainMenuOptionDescriptions.Length; index++)
            {
                if (index == currentMenuOptionIndex)
                {
                    Console.Write("\u001b[1m"); // ANSI escape code for bold text
                }

                Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (Constants.mainMenuOptionDescriptions[index].Length / 2)) + "}", Constants.mainMenuOptionDescriptions[index]));

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
                    currentMenuOptionIndex = (currentMenuOptionIndex - 1 + Constants.mainMenuOptionDescriptions.Length) % Constants.mainMenuOptionDescriptions.Length;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    currentMenuOptionIndex = (currentMenuOptionIndex + 1) % Constants.mainMenuOptionDescriptions.Length;
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
                    LogTodaysWeather.Run();
                    break;
                case (int)MenuOptions.Report:
                    Report report = new Report();
                    report.NavigateMenu();
                    break;
                case (int)MenuOptions.Exit:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}