namespace examSubtitles
{
    class Program
    {
        static void Main()
        {
            Subtitles subtitles = new Subtitles();

            //вместо работы с файлом и прочее:
            subtitles.Start.Minutes = int.Parse("02:45".Split(':')[0]);
            subtitles.Start.Seconds = int.Parse("02:45".Split(':')[1]);

            subtitles.End.Minutes = int.Parse("13:09".Split(':')[0]);
            subtitles.End.Seconds = int.Parse("13:09".Split(':')[1]);

            subtitles.Location = IsLocation("Top") ? Location.Top : Location.Bottom;
            subtitles.Color = IsColor("Red") ? Color.Red : Color.White;

            subtitles.Title = "*some input*";

            DisplayText(subtitles);
        }
        static void DisplayText(Subtitles subs)
        {
            Console.Clear();
            DrawScreenFrame();

            // Расчет координат для размещения текста в зависимости от указанного местоположения
            int x, y;
            Console.WindowWidth = 100;
            Console.WindowHeight = 30;

            if (subs.Location == Location.Top)
            {
                x = Console.WindowWidth / 2 - subs.Title.Length / 2;
                y = 2;
            }
            else if (subs.Location == Location.Bottom)
            {
                x = Console.WindowWidth / 2 - subs.Title.Length / 2;
                y = Console.WindowHeight - 2;
            }
            else if (subs.Location == Location.Right)
            {
                x = Console.WindowWidth - subs.Title.Length - 2;
                y = Console.WindowHeight / 2;
            }
            else if (subs.Location == Location.Left)
            {
                x = 2;
                y = Console.WindowHeight / 2;
            }
            else
            {
                x = Console.WindowWidth / 2 - subs.Title.Length / 2;
                y = Console.WindowHeight / 2;
            }

            // Установка цвета текста
            ConsoleColor consoleColor;
            if (subs.Color == Color.Red)
            {
                consoleColor = ConsoleColor.Red;
            }
            else if (subs.Color == Color.Green)
            {
                consoleColor = ConsoleColor.Green;
            }
            else if (subs.Color == Color.Blue)
            {
                consoleColor = ConsoleColor.Blue;
            }
            else
            {
                consoleColor = ConsoleColor.White;
            }
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(subs.Title);

            // Задержка перед очисткой экрана
            //int duration = (int.Parse(endTime.Split(':')[1]) - int.Parse(startTime.Split(':')[1])) * 1000;
            int duration = (subs.Start.Seconds - subs.End.Seconds) * 1000;
            Thread.Sleep(duration);

            // Очистка экрана
            Console.Clear();
            DrawScreenFrame();
        }
        static void DrawScreenFrame()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("**************************************************");
            for (int i = 1; i < Console.WindowHeight - 2; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine("*                                                *");
            }
            Console.SetCursorPosition(0, Console.WindowHeight - 2);
            Console.WriteLine("**************************************************");
        }

        static bool IsColor(string input)
        {
            if (input is Color)
            {
                return true;
            }
            return false;
        }
        static bool IsLocation(string input)
        {
            if (input is Location)
            {
                return true;
            }
            return false;
        }
    }
}
