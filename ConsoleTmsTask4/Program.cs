Start();
static void Start()
{
    while (true)
    {
        var result = Menu();
        if (!result)
        {
            break;
        }
    }
}

static bool Menu()
{
    Console.Clear();
    Console.WriteLine("-Главное меню-" +
    "\nОсновное задание:\n1. Циклы:\n1.1\n1.2\n1.3\n1.4\n1.5\n1.6" +
    "\n2. Массивы:\n2.1\n2.2\n2.3\n2.4" +
    "\nДополнительное задание:\n3. Из методички:\n3.1\n3.2\n3.3\n3.4\n3.5\n3.6\n3.7" +
    "\n4. Из презентации:\n4.1");

    Console.Write("Выберите домашнее задание: ");
    var point = Console.ReadLine();

    switch (point)
    {
        case "1.1":
            {
                //Решение 1 задачи
                Console.WriteLine("Задача 1.1.\nПри помощи цикла for вывести на экран нечетные числа от 1 до 99." +
                    " При решении используйте операцию инкремента (++).");
                for (int i = 1; i <= 99; i++)
                {
                    Console.Write(i++ + " ");
                }
            }
            break;
        case "1.2":
            {
                //Решение 2 задачи
                Console.WriteLine("Задача 1.2.\nНеобходимо вывести на экран числа от 5 до 1." +
                    " При решении используйте операцию декремента (--).");
                for (int i = 5; i > 0; i--)
                {
                    Console.Write(i + " ");
                }
            }
            break;
        case "1.3":
            {
                //Решение 3 задачи
                Console.WriteLine("Задача 1.3.\nНапишите программу, где пользователь вводит любое целое положительное число. " +
                    "А программа суммирует все числа от 1 до введенного пользователем числа. " +
                    "Для ввода числа воспользуйтесь Console.ReadLine.");
                Console.Write("Введите любое целое положительное число: ");
                var sum = 0;
                if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
                {
                    for (int i = 1; i <= number; i++)
                    {
                        sum += i;
                    }
                    Console.WriteLine(sum);
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод!");
                }
            }
            break;
        case "1.4":
            {
                //Решение 4 задачи
                Console.WriteLine("Задача 1.4.\nНеобходимо, чтобы программа выводила на экран вот такую последовательность: " +
                    "7 14 21 28 35 42 49 56 63 70 77 84 91 98.");
                var task4 = 1;
                while (task4 <= 14)
                {
                    Console.Write(task4 * 7 + " ");
                    task4++;
                }
            }
            break;
        case "1.5":
            {
                //Решение 5 задачи
                Console.WriteLine("Задача 1.5.\nВывести 10 первых чисел последовательности 0, -5,-10,-15..");
                var task5 = 0;
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(task5 + " ");
                    task5 -= 5;
                }
            }
            break;
        case "1.6":
            {
                //Решение 6 задачи
                Console.WriteLine("Задача 1.6.\nСоставьте программу, выводящую на экран квадраты чисел от 10 до 20 включительно.");
                for (int i = 10; i <= 20; i++)
                {
                    Console.Write(Math.Pow(i, 2) + " ");
                }
            }
            break;
        case "2.1":
            {
                //Решение 0 задачи
                Console.WriteLine("Задача 2.1.\nСоздайте массив целых чисел. Напишете программу, которая выводит сообщение о том, " +
                    "входит ли заданное число в массив или нет. Пусть число для поиска задается с консоли.");
                int[] arrayTask1 = { -5, -3, -2, -1, 2, 3, 4, 5 };
                var status = false;

                Console.Write("Массив: ");
                foreach (int number in arrayTask1)
                {
                    Console.Write(number + " ");
                }

                Console.WriteLine("\nВведите целое число для поиска: ");
                if (int.TryParse(Console.ReadLine(), out int searchNumber))
                {
                    foreach (int number in arrayTask1)
                    {
                        if (number == searchNumber)
                        {
                            status = true;
                            break;
                        }
                    }
                    if (status)
                    {
                        Console.WriteLine($"Число {searchNumber} есть в массиве!");
                    }
                    else
                    {
                        Console.WriteLine("Такого числа нет!");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод!");
                }
            }
            break;
        case "2.2":
            {
                Console.WriteLine("Задача 2.2.\nСоздайте массив целых чисел. Удалите все вхождения заданного числа из массива. " +
        "Пусть число задается с консоли. Если такого числа нет - выведите сообщения об этом.");
                int[] arrayTask2 = { 1, 7, 2, 5, 7, 3, 2, 1, 1, 1, 9, 10 };
                var count = 0;

                Console.Write("Массив: ");
                foreach (int number in arrayTask2)
                {
                    Console.Write(number + " ");
                }

                Console.Write("\nВведите число, которое необходимо удалить: ");
                if (int.TryParse(Console.ReadLine(), out int deleteNumber))
                {
                    foreach (int number in arrayTask2)
                    {
                        var index = Array.IndexOf(arrayTask2, deleteNumber);
                        if (index >= 0)
                        {
                            arrayTask2 = Delete(arrayTask2, index);
                            count++;
                        }
                    }
                    if (count > 0)
                    {
                        Console.WriteLine("Обновленный массив:");
                        foreach (int number in arrayTask2)
                        {
                            Console.Write(number + " ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Такого числа нет!");
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод!");
                }

                static int[] Delete(int[] arrayTask2, int index)
                {
                    int[] result = new int[arrayTask2.Length - 1];
                    Array.Copy(arrayTask2, 0, result, 0, index);
                    Array.Copy(arrayTask2, index + 1, result, index, arrayTask2.Length - index - 1);
                    return result;
                }
            }
            break;
        case "2.3":
            {
                Console.WriteLine("Задача 2.3.\nСоздайте и заполните массив случайным числами и выведете максимальное, минимальное и " +
        "среднее значение. Пусть будет возможность создавать массив произвольного размера. Пусть размер массива вводится с консоли.");
                Console.Write("Введите размер массива: ");
                if (int.TryParse(Console.ReadLine(), out int size) && size > 0)
                {
                    int[] arrayTask3 = new int[size];
                    Random random = new Random();

                    for (int i = 0; i < arrayTask3.Length; i++)
                    {
                        arrayTask3[i] = random.Next(-1000, 1000);
                        Console.Write(arrayTask3[i] + " ");
                    }
                    Console.WriteLine("\nМаксимальное значение:" + arrayTask3.Max(x => x) + ";\nМинимальное значение:"
                        + arrayTask3.Min(x => x) + ";\nСреднее значение: " + arrayTask3.Average());
                }
                else
                {
                    Console.WriteLine("Некорректный ввод!");
                }
            }
            break;
        case "2.4":
            {
                Console.WriteLine("Задача 2.4.\nСоздайте 2 массива из 5 чисел. Выведите массивы на консоль в двух отдельных строках. " +
        "Посчитайте среднее арифметическое элементов каждого массива и сообщите, для какого из массивов это значение оказалось" +
        " больше (либо сообщите, что их средние арифметические равны).");
                int[] arrayTask41 = new int[5];
                int[] arrayTask42 = new int[5];
                Random random = new Random();
                Console.WriteLine("Массив 1: ");
                for (int i = 0; i < 5; i++)
                {
                    arrayTask41[i] = random.Next(-1000, 1000);
                    Console.Write(arrayTask41[i] + " ");
                }

                Console.WriteLine("\nМассив 2: ");
                for (int i = 0; i < 5; i++)
                {
                    arrayTask42[i] = random.Next(-1000, 1000);
                    Console.Write(arrayTask42[i] + " ");
                }

                Console.WriteLine();
                if (arrayTask41.Average() > arrayTask42.Average())
                {
                    Console.WriteLine("Среднее арифметическое первого массива " + arrayTask41.Average() + " > среднего арифметического второго массива " + arrayTask42.Average());
                }
                if (arrayTask42.Average() > arrayTask41.Average())
                {
                    Console.WriteLine("Среднее арифметическое второго массива " + arrayTask42.Average() + " > среднего арифметического первого массива " + arrayTask41.Average());
                }
                if (arrayTask42.Average() == arrayTask41.Average())
                {
                    Console.WriteLine("Среднее арифметическое первого массива " + arrayTask41.Average() + " = среднему арифметическому второго массива " + arrayTask42.Average());
                }
            }
            break;
        case "3.1":
            {
                Console.WriteLine("Задача 3.1.\nВыведите на экран первые 11 членов последовательности Фибоначчи.");
                var n1 = 0;
                var n2 = 1;
                for (int i = 0; i < 11; i++)
                {
                    if (i <= 1)
                    {
                        Console.Write(i + " ");
                    }
                    else
                    {
                        var fib = n1 + n2;
                        n1 = n2;
                        n2 = fib;
                        Console.Write(fib + " ");
                    }
                }
            }
            break;
        case "3.2":
            {
                Console.WriteLine("Задача 3.2.\nЗа каждый месяц банк начисляет к сумме вклада 7% от суммы. " +
        "Напишите программу, в которую пользователь вводит сумму вклада и количество месяцев. " +
        "А банк вычисляет конечную сумму вклада с учетом начисления процентов за каждый месяц. " +
        "Для вычисления суммы с учетом процентов используйте цикл for. Пусть сумма вклада будет представлять тип float.");
                while (true)
                {
                    Console.WriteLine("Введите сумму вклада: ");
                    if (!float.TryParse(Console.ReadLine(), out var sum))
                    {
                        Console.WriteLine("Некорректные данные!");
                    }
                    else
                    {
                        while (true)
                        {
                            Console.WriteLine("Введите количество месяцев: ");
                            if (!int.TryParse(Console.ReadLine(), out var months))
                            {
                                Console.WriteLine("Некорректные данные!");
                            }
                            else
                            {
                                for (int i = 0; i < months; i++)
                                {
                                    sum += sum * 7 / 100;
                                }
                                break;
                            }
                        }
                        Console.WriteLine(sum);
                        break;
                    }
                }
            }
            break;
        case "3.3":
            {
                //Решение 3 задачи
                Console.WriteLine("Задача 3.3.\nНапишите программу, выполняющую основные арифметические операции(калькулятор)");
                Console.WriteLine("Выполнено в домашнем задании #3");
            }
            break;
        case "3.4":
            {
                //Решение 4 задачи
                Console.WriteLine("Задача 3.4.\nСоздайте массив из n случайных целых чисел и выведите его на экран." +
                    "Размер массива пусть задается с консоли и размер массива может быть больше 5 и меньше или равно 10. " +
                    "Если n не удовлетворяет условию - выведите сообщение об этом. Если пользователь ввёл не подходящее число, " +
                    "то программа должна просить пользователя повторить ввод. Создайте второй массив только из чётных элементов " +
                    "первого массива, если они там есть, и вывести его на экран.");
                Console.WriteLine("Введите размер массива:");
                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out var size) || size <= 5 || size > 10)
                    {
                        Console.WriteLine("Некорректные данные!");
                    }
                    else
                    {
                        int[] arrayTask41 = new int[size];
                        var count = 0;
                        Random random = new Random();
                        for (int i = 0; i < size; i++)
                        {
                            arrayTask41[i] = random.Next(1, 50);
                            Console.Write(arrayTask41[i] + " ");
                            if (arrayTask41[i] % 2 == 0)
                            {
                                count++;
                            }
                        }

                        int[] arrayTask42 = new int[count];
                        var index = 0;
                        Console.WriteLine("\nВторой массив (чётные элементы первого массива): ");
                        foreach (int num in arrayTask41)
                        {
                            if (num % 2 == 0)
                            {
                                arrayTask42[index] = num;
                                Console.Write(arrayTask42[index] + " ");
                                index++;
                            }
                        }
                        break;
                    }
                }
            }
            break;
        case "3.5":
            {
                //Решение 5 задачи
                Console.WriteLine("Задача 3.5.\nСоздайте массив и заполните массив. Выведите массив на экран в строку. " +
                    "Замените каждый элемент с нечётным индексом на ноль. Снова выведете массив на экран на отдельной строке.");
                Console.WriteLine("Введите размер массива:");
                while (true)
                {
                    if (!int.TryParse(Console.ReadLine(), out var size))
                    {
                        Console.WriteLine("Некорректные данные!");
                    }
                    else
                    {
                        int[] arrayTask5 = new int[size];
                        var count = 0;
                        Random random = new Random();
                        for (int i = 0; i < size; i++)
                        {
                            arrayTask5[i] = random.Next(1, 50);
                            Console.Write(arrayTask5[i] + " ");
                        }
                        Console.WriteLine("\nЗамена нечётных элементов на 0: ");
                        for (int i = 0; i < size; i++)
                        {
                            if (arrayTask5[i] % 2 != 0)
                            {
                                arrayTask5[i] = 0;
                            }
                            Console.Write(arrayTask5[i] + " ");
                        }
                        break;
                    }
                }
            }
            break;
        case "3.6":
            {
                //Решение 6 задачи
                Console.WriteLine("Задача 3.6.\nСоздайте массив строк. Заполните его произвольными именами людей. " +
                    "Отсортируйте массив. Результат выведите на консоль.");
                string[] names = { "Роман", "Егор", "Алексей", "Геннадий", "Борис", "Владислав" };

                Console.WriteLine("Исходный массив:");
                foreach (string name in names)
                {
                    Console.Write(name + " ");
                }

                Array.Sort(names);

                Console.WriteLine("\nОтсортированный массив:");
                foreach (string name in names)
                {
                    Console.Write(name + " ");
                }
            }
            break;
        case "3.7":
            {
                //Решение 7 задачи
                Console.WriteLine("Задача 3.7.\nРеализуйте алгоритм сортировки пузырьком.");
                List<int> arrayTask7 = new List<int>();
                Console.WriteLine("Введите числа для записи в массив (для завершения введите exit):");
                while (true)
                {
                    string input = Console.ReadLine();

                    if (input.ToLower() == "exit")
                        break;
                    if (int.TryParse(input, out int number))
                    {
                        arrayTask7.Add(number);
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод числа. Повторите ввод.");
                    }
                }

                var n = arrayTask7.Count;

                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (arrayTask7[j] > arrayTask7[j + 1])
                        {
                            var copy = arrayTask7[j];
                            arrayTask7[j] = arrayTask7[j + 1];
                            arrayTask7[j + 1] = copy;
                        }
                    }
                }

                Console.WriteLine("Отсортированные числа:");
                foreach (int number in arrayTask7)
                {
                    Console.Write(number + " ");
                }
            }
            break;
        case "4.1":
            {
                //Матрица
                Console.WriteLine("Задача 4.1.\nСоздать программу работы с матрицами (двухмерными массивами) c возможностью выбора размера матрицы." +
                    "Элементы вводятся вручную. Вывести матрицу на консоль (добавить оформление, чтобы выглядело как матрица). " +
                    "Реализовать меню выбора действий:\n- Найти количество положительных/отрицательных чисел в матрице" +
                    "\n- Сортировка элементов матрицы построчно (в двух направлениях)" +
                    "\n- Инверсия элементов матрицы построчно" +
                    "\n- Все математические операции реализовать вручную, без использования статических методов класса Array");
                Console.Write("Введите количество строк матрицы: ");
                var rows = int.Parse(Console.ReadLine());

                Console.Write("Введите количество столбцов матрицы: ");
                var cols = int.Parse(Console.ReadLine());

                int[,] matrix = new int[rows, cols];

                Console.WriteLine("Введите элементы матрицы:");

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write($"Элемент [{i},{j}]: ");
                        matrix[i, j] = int.Parse(Console.ReadLine());
                    }
                }

                //Вывод матрицы
                OutputMatrix(matrix);

                //Положительные и отрицательные элементы
                var countPos = 0;
                var countNeg = 0;
                foreach (int number in matrix)
                {
                    if (number > 0)
                    {
                        countPos++;
                    }
                    if (number < 0)
                    {
                        countNeg++;
                    }
                }
                Console.WriteLine($"Количество положительных элементов - {countPos}.\nКоличество отрицательных элементов - {countNeg}");

                //Сортировка матрицы пузырьком
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                    {
                        for (int k = 0; k < matrix.GetLength(1) - j - 1; k++)
                        {
                            if (matrix[i, k] > matrix[i, k + 1])
                            {
                                var copy = matrix[i, k];
                                matrix[i, k] = matrix[i, k + 1];
                                matrix[i, k + 1] = copy;
                            }
                        }
                    }
                }

                //Вывод матрицы после сортировки
                OutputMatrix(matrix);

                static void OutputMatrix(int[,] matrix)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            Console.Write(matrix[i, j] + "\t");
                        }
                        Console.WriteLine();
                    }
                }
            }
            break;
    }

    Console.WriteLine("\nДля продолжения работы нажмите клавишу Enter." +
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