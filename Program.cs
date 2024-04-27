namespace Luan1006.MM202.ExamUnit4
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to the weatherlog!");
            Console.WriteLine("Please enter your location: ");
            string location = Console.ReadLine();
            Console.WriteLine("Please enter the temperature in celsius: ");
            double temperature = double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the date (yyyy-MM-dd) or : ");
            DateTime date = DateTime.Parse(Console.ReadLine());
        }
    }
}