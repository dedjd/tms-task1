using ConsoleTmsTask6;

Phone[] phones = new Phone[]
{
    new(80257785666, "iPhone 8", 148.1),

    new(80294445511, "Samsung A50", 166.2),

    new(80339998877, "Google Pixel 4a", 162.3)
};

string[] names = { "Роман", "Федор", "Дмитрий" };
var name = 0;

foreach (Phone phone in phones)
{
    PrintPhone(phone);
    phone.ReceiveCall(names[name]);
    name++;
    phone.GetNumber();
}

phones[1].ReceiveCall("Anonymous", 80000000000);

phones[2].SenMessage(80295555555, 80337923757);

static void PrintPhone(Phone phone)
{
    Console.WriteLine($"Номер: {phone.Number}; Модель: {phone.Model}; Вес: {phone.Weight}");
}
