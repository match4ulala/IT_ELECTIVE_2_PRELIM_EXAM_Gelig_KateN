using System.Net;
using System.Text;
using System.Text.Json;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class CreateReview
{
    public static async Task Run(HttpClient client)
    {
        string url = "https://jsonplaceholder.typicode.com/posts";
        string json = """
        {
            "title": "Great Pasta!",
            "body": "Loved this recipe",
            "userId": 1
        }
        """;

        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await client.PostAsync(url, content);

        if (response.StatusCode != HttpStatusCode.Created)
            throw new Exception("Expected status code 201 Created.");

        string body = await response.Content.ReadAsStringAsync();
        using JsonDocument doc = JsonDocument.Parse(body);

        if (!doc.RootElement.TryGetProperty("id", out JsonElement id))
            throw new Exception("Response does not contain an id field.");

        if (id.ValueKind == JsonValueKind.Null)
            throw new Exception("id field is null.");
    }
}