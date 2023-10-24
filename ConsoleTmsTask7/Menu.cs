using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTmsTask7
{
    internal class Menu
    {
        public static void Show()
        {
            Inventory inventory = new Inventory();
            var productId = 1;

            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Добавить новый продукт");
                Console.WriteLine("2. Удалить продукт");
                Console.WriteLine("3. Вывести инвентарь");
                Console.WriteLine("4. Подсчитать общую сумму инвентаря");
                Console.WriteLine("5. Сохранить инвентарь в файл");
                Console.WriteLine("6. Выход");
                Console.Write("Введите необходимый пункт: ");

                if (int.TryParse(Console.ReadLine(), out int point))
                {
                    switch (point)
                    {
                        case 1:
                            Console.Write("Введите название продукта: ");
                            string name = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(name))
                            {
                                Console.Write("Введите стоимость продукта: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal price))
                                {
                                    Console.Write("Введите количество продукта: ");
                                    if (int.TryParse(Console.ReadLine(), out int quantity))
                                    {
                                        Product newProduct = new Product(productId, name, price, quantity);
                                        inventory.AddProduct(newProduct);
                                        productId++;
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Вы ввели пустую строку!");
                            }
                            break;

                        case 2:
                            Console.Write("Введите номер продукта для удаления из инвентаря: ");
                            if (int.TryParse(Console.ReadLine(), out int productIdToRemove))
                            {
                                inventory.RemoveProduct(productIdToRemove);
                            }
                            break;

                        case 3:
                            inventory.DisplayInventory();
                            break;

                        case 4:
                            decimal inventoryValue = inventory.CalculateInventoryValue();
                            Console.WriteLine($"Общая стоимость инвентаря: {inventoryValue} BYN");
                            break;

                        case 5:
                            Console.Write("Введите путь: ");
                            string filePath = Console.ReadLine();
                            inventory.SaveInventory(filePath);
                            Console.WriteLine("Инвентарь сохранен.");
                            break;

                        case 6:
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Неверный выбор. Выберите номер от 1 до 6.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Введите номер.");
                }
            }
        }
    }
}
