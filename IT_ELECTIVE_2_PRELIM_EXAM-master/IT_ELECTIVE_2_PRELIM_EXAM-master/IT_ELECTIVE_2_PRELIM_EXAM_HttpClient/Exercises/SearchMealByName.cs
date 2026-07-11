using System.Net;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class SearchMealByName
{
    public static async Task Run(HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/search.php?s=Arrabiata";
        var response = await client.GetAsync(url);

        if (response.StatusCode != HttpStatusCode.OK)
            throw new Exception("Expected status code 200 OK.");

        string body = await response.Content.ReadAsStringAsync();
        using JsonDocument doc = JsonDocument.Parse(body);

        JsonElement meals = doc.RootElement.GetProperty("meals");

        if (meals.ValueKind == JsonValueKind.Null)
            throw new Exception("Meals array is null.");

        if (meals.GetArrayLength() < 1)
            throw new Exception("No meals found.");
    }
}