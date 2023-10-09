Start();

static void Start()
{
    while (true)
    {   
        var result = Operations();
        if (!result)
            break;
    }
}

static bool Operations()
{
    Console.WriteLine("Выберите операцию: " +
    "\n1. Сложение '+' " +
    "\n2. Вычитание '-' " +
    "\n3. Деление '/' " +
    "\n4. Умножение '*' " +
    "\n5. Процент от числа '%' " +
    "\n6. Квадратный корень числа '√'");
    var operation = Console.ReadLine();
    switch (operation)
    {
        case "1":
            {
                Console.WriteLine("Ввведите первое число:");
                var number1 = CheckInput();
                Console.WriteLine("Введите второе число:");
                var number2 = CheckInput();
                var result = number1 + number2;
                Console.WriteLine("Результат:\n" + $"{number1} + {number2} = {result}");
                break;
            }
        case "2":
            {
                Console.WriteLine("Ввведите первое число:");
                var number1 = CheckInput();
                Console.WriteLine("Введите второе число:");
                var number2 = CheckInput();
                var result = number1 - number2;
                Console.WriteLine("Результат:\n" + $"{number1} - {number2} = {result}");
                break;
            }
        case "3":
            {
                Console.WriteLine("Ввведите первое число:");
                var number1 = CheckInput();
                Console.WriteLine("Введите второе число:");
                var number2 = CheckInput();
                var result = number1 / number2;
                Console.WriteLine("Результат:\n" + $"{number1}  /  {number2} = {result}");
                break;
            }
        case "4":
            {
                Console.WriteLine("Ввведите первое число:");
                var number1 = CheckInput();
                Console.WriteLine("Введите второе число:");
                var number2 = CheckInput();
                var result = number1 * number2;
                Console.WriteLine("Результат:\n" + $"{number1}  *  {number2} = {result}");
                break;
            }
        case "5":
            {
                Console.WriteLine("Ввведите число:");
                var number1 = CheckInput();
                Console.WriteLine("Введите процент, который вы хотите вычислить:");
                var number2 = CheckInput();
                var result = (number2 / 100) * number1;
                Console.WriteLine("Результат:\n" + $"{number2}% от числа {number1} = " + result);
                break;
            }
        case "6":
            {
                Console.WriteLine("Ввведите число:");
                var number1 = CheckInput();
                var result = Math.Sqrt(number1);
                Console.WriteLine("Результат:\n" + $"√{number1} = " + result);
                break;
            }
        default:
            {
                Console.WriteLine("Вы ввели некорректные данные! Введите номер необходимой операции из списка!");
                break;
            }
    }
    Console.WriteLine("Для продолжения работы нажмите клавишу Enter." +
        "\nДля завершения работы нажмите любую другую клавишу.");
    if (Console.ReadKey(true).Key != ConsoleKey.Enter)
    {
        return false;
    }
    else
    {
        return true;
    }
}

static double CheckInput()
{
    while (true)
    {
        var input = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(input))
        {
            if (double.TryParse(input, out double number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Вы ввели не число!");
            }
        }
        else
        {
            Console.WriteLine("Вы ввели пустую строку!");
        }
    }
}