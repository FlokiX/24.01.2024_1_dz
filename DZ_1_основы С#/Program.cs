namespace DZ_1_основы_С_
{
    public enum Season
    {
        Winter,
        Spring,
        Summer,
        Fall,
        Unknown
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            multiplicityCheck();
            percentageCalculation();
            formingNumbersFromLetters();
            dateConversionText();
            TemperatureConverter();
            OutputEvenNumbersInRange();
        }


        static void OutputEvenNumbersInRange()
        {
            Console.WriteLine("Введите два числа (начало и конец диапазона):");

            if (int.TryParse(Console.ReadLine(), out int start) && int.TryParse(Console.ReadLine(), out int end))
            {
                NormalizeBounds(ref start, ref end);
                PrintEvenNumbersInRange(start, end);
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Введите два целых числа.");
            }
            Console.WriteLine("\n");
        }

        static void NormalizeBounds(ref int start, ref int end)
        {
            if (start > end)
            {
                (start, end) = (end, start);
            }
        }

        static void PrintEvenNumbersInRange(int start, int end)
        {
            Console.WriteLine($"Четные числа в диапазоне от {start} до {end}:");

            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }



        static void TemperatureConverter()
        {
            int temperature;
            char unit;

            Console.WriteLine("Введите показания температуры:");
            temperature = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите единицу измерения температуры (F или C):");
            unit = Console.ReadLine()[0];


            switch (unit)
            {
                case 'F':
                    temperature = (temperature - 32) * 5 / 9;
                    break;
                case 'C':

                    temperature = (temperature * 9 / 5) + 32;
                    break;
                default:
                    Console.WriteLine("Некорректная единица измерения температуры");
                    return;
            }
            Console.WriteLine("Температура в {0}: {1} градусов", unit, temperature);
            Console.WriteLine("\n");
        }
        static void dateConversionText()
        {
            Console.WriteLine("Введите дату в формате ДД.ММ.ГГГГ:");
            string date = Console.ReadLine();
            DateTime dt;
            if (!DateTime.TryParse(date, out dt))
            {
                Console.WriteLine("Неверный формат даты. Пожалуйста, введите дату в формате ДД.ММ.ГГГГ.");
                return;
            }
            Season season = GetSeason(dt.Month);
            Console.WriteLine($"{season} {dt.DayOfWeek.ToString()}");
            Console.WriteLine("\n");
        }
        static Season GetSeason(int month)
        {
            if (month == 12 || month == 1 || month == 2) return Season.Winter;
            else if (month >= 3 && month <= 5) return Season.Spring;
            else if (month >= 6 && month <= 8) return Season.Summer;
            else if (month >= 9 && month <= 11) return Season.Fall;
            else return Season.Unknown;
        }

        static void ReversingNumbers()
        {
            string number = Console.ReadLine();


            if (number.Length != 6)
            {
                Console.WriteLine("Введите шестизначное число");
                return;
            }


            int firstDigit = int.Parse(Console.ReadLine());
            int secondDigit = int.Parse(Console.ReadLine());


            char[] digits = number.ToCharArray();
            char temp = digits[firstDigit - 1];
            digits[firstDigit - 1] = digits[secondDigit - 1];
            digits[secondDigit - 1] = temp;


            Console.WriteLine($"Номер с переставленными цифрами: {new string(digits)}");
            Console.WriteLine("\n");
        }

        static void formingNumbersFromLetters()
        {
            Console.WriteLine("Введите четыре цифры:");

            string input = Console.ReadLine();

            if (input.Length == 4 && int.TryParse(input, out int number))
            {
                Console.WriteLine($"Сформированное число: {number}");
            }
            else
            {
                Console.WriteLine("Ошибка: Введите ровно четыре цифры.");
            }
            Console.WriteLine("\n");
        }

        static void multiplicityCheck()
        {
            Console.WriteLine("Введите число от 1 до 100:");

            if (int.TryParse(Console.ReadLine(), out int userInput) && userInput >= 1 && userInput <= 100)
            {
                string output = (userInput % 3 == 0 && userInput % 5 == 0) ? "Fizz Buzz" :
                                (userInput % 3 == 0) ? "Fizz" :
                                (userInput % 5 == 0) ? "Buzz" :
                                userInput.ToString();

                Console.WriteLine(output);
            }
            else
            {
                Console.WriteLine("Ошибка: Введите корректное число от 1 до 100");
            }
            Console.WriteLine("\n");
        }
        static void percentageCalculation()
        {
            Console.WriteLine("Введите два числа через пробел (значение и процент):");

            string userInput = Console.ReadLine();
            string[] inputParts = userInput.Split(' ');

            if (inputParts.Length == 2 && double.TryParse(inputParts[0], out double inputValue) && double.TryParse(inputParts[1], out double inputPercent))
            {
                double result = CalculatePercentage(inputValue, inputPercent);
                Console.WriteLine($"Результат: {result}");
            }
            else
            {
                Console.WriteLine("Ошибка: Введите корректные числа");
            }
            Console.WriteLine("\n");
        }
        static double CalculatePercentage(double value, double percent)
        {
            return (value * percent) / 100;
        }
    }
}
