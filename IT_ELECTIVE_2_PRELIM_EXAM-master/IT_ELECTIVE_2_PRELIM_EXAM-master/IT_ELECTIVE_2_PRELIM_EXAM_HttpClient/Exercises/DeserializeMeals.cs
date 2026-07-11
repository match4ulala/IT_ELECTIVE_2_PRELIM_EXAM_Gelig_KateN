using System.Net;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class DeserializeMeals
{
    public static async Task Run(HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/search.php?f=a";
        var response = await client.GetAsync(url);

        if (response.StatusCode != HttpStatusCode.OK)
            throw new Exception("Expected status code 200 OK.");

        string body = await response.Content.ReadAsStringAsync();
        using JsonDocument doc = JsonDocument.Parse(body);

        JsonElement meals = doc.RootElement.GetProperty("meals");

        if (meals.ValueKind == JsonValueKind.Null)
            throw new Exception("Meals array is null.");

        if (meals.GetArrayLength() == 0)
            throw new Exception("No meals found.");

        // Collect the names first
        List<string> mealNames = new();
        Console.WriteLine();

        foreach (JsonElement meal in meals.EnumerateArray())
        {
            Console.WriteLine(meal.GetProperty("strMeal").GetString());
        }
        Console.WriteLine("Finished Exercise 10");
    }
}