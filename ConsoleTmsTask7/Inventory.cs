namespace ConsoleTmsTask7
{
    internal class Inventory
    {
        private List<Product> _products = new List<Product>();

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void RemoveProduct(int productId)
        {
            _products.RemoveAll(p => p.Id == productId);
        }

        public decimal CalculateInventoryValue()
        {
            decimal totalValue = 0;
            foreach (var product in _products)
            {
                totalValue += product.TotalValue();
            }
            return totalValue;
        }

        public void DisplayInventory()
        {
            foreach (var product in _products)
            {
                Console.WriteLine($"Номер: {product.Id}, Название: {product.Name}, Цена: {product.Price} BYN, Количество: {product.Quantity}");
            }
        }

        public void SaveInventory(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var product in _products)
                {
                    writer.WriteLine($"{product.Id},{product.Name},{product.Price},{product.Quantity}");
                }
            }
        }
    }
}
