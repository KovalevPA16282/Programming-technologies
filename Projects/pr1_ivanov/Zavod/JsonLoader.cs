using System.Text.Json;

namespace Zavod
{
    internal static class JsonLoader
    {
        public static T[] LoadFromJson<T>(string fileName)
        {
            try
            {
                string json = File.ReadAllText(fileName);
                return JsonSerializer.Deserialize<T[]>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                }) ?? Array.Empty<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка загрузки {fileName}: {ex.Message}");
                return Array.Empty<T>();
            }
        }

        public static void SaveToJson<T>(string fileName, T[] data)
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(data, options);
                File.WriteAllText(fileName, json);
                Console.WriteLine($"Файл сохранён: {Path.GetFullPath(fileName)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка сохранения {fileName}: {ex.Message}");
            }
        }
    }
}
