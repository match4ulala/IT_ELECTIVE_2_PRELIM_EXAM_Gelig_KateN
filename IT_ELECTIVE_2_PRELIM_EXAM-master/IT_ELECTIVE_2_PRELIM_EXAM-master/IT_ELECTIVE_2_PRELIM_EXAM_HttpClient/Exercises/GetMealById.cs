using System.Net;

using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class GetMealById

{
    public static async Task Run(HttpClient client)

    {
        string url = "https://themealdb.com/api/json/v1/1/lookup.php?i=52772";
        HttpResponseMessage response = await client.GetAsync(url);

        if (response.StatusCode != HttpStatusCode.OK)
            throw new Exception("Expected status code 200 OK.");

        string body = await response.Content.ReadAsStringAsync(); 
        using JsonDocument doc = JsonDocument.Parse(body);

        JsonElement meals = doc.RootElement.GetProperty("meals");

        if (meals.ValueKind == JsonValueKind.Null || meals.GetArrayLength() == 0)
            throw new Exception("Meal not found.");

        string? mealName = meals[0].GetProperty("strMeal").GetString();

        if (mealName != "Teriyaki Chicken Casserole")
            throw new Exception($"Expected 'Teriyaki Chicken Casserole' but got '{mealName}'.");
    }
}
