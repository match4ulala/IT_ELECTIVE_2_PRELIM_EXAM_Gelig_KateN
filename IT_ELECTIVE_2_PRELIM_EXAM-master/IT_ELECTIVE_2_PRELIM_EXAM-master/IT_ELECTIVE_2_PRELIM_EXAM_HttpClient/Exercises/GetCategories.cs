using System.Net;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class GetCategories
{
    public static async Task Run(HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/categories.php";
        var response = await client.GetAsync(url);

        if (response.StatusCode != HttpStatusCode.OK)
            throw new Exception("Expected status code 200 OK.");

        string body = await response.Content.ReadAsStringAsync();
        using JsonDocument doc = JsonDocument.Parse(body);

        JsonElement categories = doc.RootElement.GetProperty("categories");

        if (categories.ValueKind == JsonValueKind.Null)
            throw new Exception("Categories array is null.");

        if (categories.GetArrayLength() == 0)
            throw new Exception("No categories found.");
    }
}