using System.Net;

namespace IT_ELECTIVE_2_PRELIM_EXAM_HttpClient.Exercises;

public static class GetRandomMeal
{
    public static async Task Run(HttpClient client)
    {
        string url = "https://themealdb.com/api/json/v1/1/random.php";

        var response = await client.GetAsync(url);
        var body = await response.Content.ReadAsStringAsync();

        if (response.StatusCode != HttpStatusCode.OK)
            throw new Exception("Expected status code 200 OK.");

        if (string.IsNullOrWhiteSpace(body))
            throw new Exception("Response body is empty.");
    }
}