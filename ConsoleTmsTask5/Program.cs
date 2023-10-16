using System.Text;

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
    Console.WriteLine("Доступные действия для работы со строкой:" +
        "\n1. Найти слова, содержащие максимальное количество цифр." +
        "\n2. Найти самое длинное слово и определить, сколько раз оно встретилось в тексте." +
        "\n3. Заменить цифры от 0 до 9 на слова «ноль», «один», ..., «девять»." +
        "\n4. Вывести на экран сначала вопросительные, а затем восклицательные предложения." +
        "\n5. Вывести на экран только предложения, не содержащие запятых." +
        "\n6. Найти слова, начинающиеся и заканчивающиеся на одну и ту же букву.");

    Console.WriteLine("Выберите действие:");
    var point = Console.ReadLine();

    switch (point)
    {
        case "1":
            {
                MaxCountNumbers();
            }
            break;
        case "2":
            {
                MaxLengthWord();
            }
            break;
        case "3":
            {
                ReplaceDigits();
            }
            break;
        case "4":
            {
                Sentences("4");
            }
            break;
        case "5":
            {
                Sentences("5");
            }
            break;
        case "6":
            {
                IdenticalLetters();
            }
            break;
        default:
            {
                Console.WriteLine("Вы ввели некорректные данные! Введите номер необходимого действия из списка!");
                break;
            }
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

//Решение 1-ой задачи
static void MaxCountNumbers()
{
    var str = CheckInput();
    var words = str.Split(' ');
    var maxCount = 0;
    var maxWords = new List<string>();
    for (int i = 0; i < words.Length; i++)
    {
        var word = words[i];
        var count = 0;
        foreach (var c in word)
        {
            if (char.IsDigit(c))
            {
                count++;
            }
        }
        if (count > maxCount)
        {
            maxCount = count;
            maxWords.Clear();
            maxWords.Add(word);
        }
        else if (count == maxCount)
        {
            maxWords.Add(word);
        }
    }

    Console.WriteLine($"Максимальное количество цифр ({maxCount}) содержат следующие слова:");

    foreach (var word in maxWords)
    {
        Console.Write(word + "; ");
    }
}

//Решение 2-ой задачи
static void MaxLengthWord()
{
    var str = CheckInput();
    var words = str.Split(' ');
    var maxLength = 0;
    var maxWords = new List<string>();
    var countWords = new List<int>();
    for (int i = 0; i < words.Length; i++)
    {
        var word = words[i];
        var length = 0;
        foreach (var c in word)
        {
            length++;
        }
        if (length > maxLength)
        {
            maxLength = length;
            maxWords.Clear();
            maxWords.Add(word);
            countWords.Clear();
            countWords.Add(1);
        }
        else if (length == maxLength)
        {
            int index = maxWords.IndexOf(word);
            if (index >= 0)
            {
                countWords[index]++;
            }
            else
            {
                maxWords.Add(word);
                countWords.Add(1);
            }
        }
    }

    Console.WriteLine($"Самые длинные слова (количество вхождений):");

    for (int i = 0; i < maxWords.Count; i++)
    {
        Console.Write(maxWords[i] + $" ({countWords[i]}); ");
    }
}

//Решение 3-ей задачи
static void ReplaceDigits()
{
    var str = CheckInput();
    var words = str.Split(' ');
    string[] numberWords = { "ноль", "один", "два", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять" };

    for (int i = 0; i < words.Length; i++)
    {
        string word = words[i];

        for (int j = 0; j < word.Length; j++)
        {
            if (char.IsDigit(word[j]))
            {
                int digit = (int)char.GetNumericValue(word[j]);
                word = word.Replace(word[j].ToString(), numberWords[digit]);
            }
        }

        words[i] = word;
    }

    string result = string.Join(" ", words);

    Console.WriteLine("Вывод строки после замены цифр на слова:\n" + result);
}

//Решения 4-ой и 5-ой задач
static void Sentences(string task)
{
    var str = CheckInput();
    var sentences = new List<string>();
    var currentSentence = new StringBuilder();

    foreach (char c in str)
    {
        currentSentence.Append(c);
        if (c == '.' || c == '!' || c == '?')
        {
            sentences.Add(currentSentence.ToString());
            currentSentence.Clear();
        }
    }

    switch (task)
    {
        //Решение 4-ой задачи
        case "4":
            {
                Console.WriteLine("Вопросительные предложения:");
                foreach (var sentence in sentences)
                {
                    if (sentence.EndsWith("?"))
                    {
                        Console.WriteLine(sentence.TrimStart());
                    }
                }

                Console.WriteLine("Восклицательные предложения:");
                foreach (var sentence in sentences)
                {
                    if (sentence.TrimStart().EndsWith("!"))
                    {
                        Console.WriteLine(sentence.TrimStart());
                    }
                }
            }
            break;
        //Решение 5-ой задачи
        case "5":
            {
                Console.WriteLine("Предложения не содержащие запятых:");
                foreach (var sentence in sentences)
                {
                    if (!sentence.Contains(","))
                    {
                        Console.WriteLine(sentence.TrimStart());
                    }
                }
            }
            break;
    }
}

//Решение 6-ой задачи
static void IdenticalLetters()
{
    var str = CheckInput();
    var words = str.Split(' ');

    Console.WriteLine("Слова, начинающиеся и заканчивающиеся на одну и ту же букву:");
    foreach (string word in words)
    {
        if (word.Length >= 2 && word[0] == word[word.Length - 1])
        {
            Console.Write(word + "; ");
        }
    }
}

static string CheckInput()
{
    while (true)
    {
        Console.WriteLine("Введите строку:");
        var str = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(str))
        {
            return str;
        }
        else
        {
            Console.WriteLine("Вы ввели пустую строку!");
        }
    }
}