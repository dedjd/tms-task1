var wikiUrl = "https://ru.wikipedia.org/wiki/.";

var nonExistentPagesFile = "non_existent_pages.txt";

var client = new HttpClient();

for (char letter1 = 'a'; letter1 <= 'z'; letter1++)
{
    for (char letter2 = 'a'; letter2 <= 'z'; letter2++)
    {
        var pageUrl = wikiUrl + letter1 + letter2;

        try
        {
            HttpResponseMessage response = await client.GetAsync(pageUrl);

            if (response.IsSuccessStatusCode)
            {
                var html = await response.Content.ReadAsStringAsync();
                var fileName = $".{letter1}{letter2}.html";
                File.WriteAllText(fileName, html);
                Console.WriteLine($"HTML-код страницы {pageUrl} сохранен в файл {fileName}");
            }
            else
            {
                Console.WriteLine($"Страница {pageUrl} не существует.");
                File.AppendAllText(nonExistentPagesFile, pageUrl + Environment.NewLine);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка при обработке страницы {pageUrl}: {ex.Message}");
        }
    }
}    