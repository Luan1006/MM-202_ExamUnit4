namespace Luan1006.MM202.ExamUnit4
{
    public class Report
    {
        private enum MenuOptions
        {
            DailyReport,
            WeeklyReport,
            MonthlyReport,
            BackToMainMenu
        }

        private int currentMenuOptionIndex = 0;

        public void DisplayBanner()
        {
            Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (Constants.banner.Length / 2)) + "}", Constants.banner));
            Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (Constants.bannerLine.Length / 2)) + "}", Constants.bannerLine));
        }

        public void DisplayMenu()
        {
            for (int index = 0; index < Constants.reportMenuOptionDescriptions.Length; index++)
            {
                if (index == currentMenuOptionIndex)
                {
                    Console.Write("\u001b[1m"); // ANSI escape code for bold text
                }

                Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (Constants.reportMenuOptionDescriptions[index].Length / 2)) + "}", Constants.reportMenuOptionDescriptions[index]));

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
                    currentMenuOptionIndex = (currentMenuOptionIndex - 1 + Constants.reportMenuOptionDescriptions.Length) % Constants.reportMenuOptionDescriptions.Length;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    currentMenuOptionIndex = (currentMenuOptionIndex + 1) % Constants.reportMenuOptionDescriptions.Length;
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
            DateTime dailyDate;

            switch (currentMenuOptionIndex)
            {
                case (int)MenuOptions.DailyReport:
                    Console.WriteLine(Constants.enterDate);
                    if (DateTime.TryParse(Console.ReadLine(), out dailyDate))
                    {
                        WeatherReport.GenerateDailyReport(dailyDate);
                    }
                    else
                    {
                        Console.WriteLine(Constants.invalidDate);
                    }
                    break;

                case (int)MenuOptions.WeeklyReport:
                    WeatherReport.GenerateWeeklyReport();
                    break;

                case (int)MenuOptions.MonthlyReport:
                    WeatherReport.GenerateMonthlyReport();
                    break;

                case (int)MenuOptions.BackToMainMenu:
                    MainMenu userInterface = new MainMenu();
                    userInterface.NavigateMenu();
                    break;

            }
        }
    }
}