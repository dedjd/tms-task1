Console.WriteLine("Привет, как тебя зовут?");
var name = Console.ReadLine();

if (name == "Олег")
{
    Console.WriteLine("До свидания, Олег!");
}
else
{
    Console.WriteLine("Очень приятно, " + name + "!");
    Console.WriteLine("Наш список цен:");

    for (var i = 1; i <= 3; i++)
    {
        Console.WriteLine("Кружка " + i + "50мл. - " + int.Parse(i + "50") / 50 + " руб.");
    }

    Console.WriteLine("Сколько кружек лимонада ты хочешь?");
    var count = int.Parse(Console.ReadLine());
    Console.WriteLine("Какого объёма?");
    var volume = int.Parse(Console.ReadLine());

    if (volume == 150 || volume == 250 || volume == 350)
    {
        var price = volume / 50;
        var totalPrice = count * price;
        Console.WriteLine("С тебя " + totalPrice + " руб.");
    }
    else
    {
        Console.WriteLine("Кружки в " + volume + "мл. нет!");
    }
}

Console.ReadLine();