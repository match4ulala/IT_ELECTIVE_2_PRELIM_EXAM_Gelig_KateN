namespace IT_ELECTIVE_2_PRELIM_EXAM.Models;

public class Meal
{
    private string name;
    private string category;
    private string area;
    private string instructions;
    private string thumbnail;
    private string tags;

    public string Name
    {
        get => name;
        set => name = value;
    }
    public string Category
    {
        get => category;
        set => category = value;
    }
    public string Area
    {
        get => area;
        set => area = value;
    }
    public Meal()
    {
        name = "";
        category = "";
        area = "";
        instructions = "";
        thumbnail = "";
        tags = "";
    }
    public Meal(string name, string category, string area)
    {
        this.name = name;
        this.category = category;
        this.area = area;
        this.instructions = "";
        this.thumbnail = "";
        this.tags = "";
    }
    public override string ToString()
    {
        return $"Meal: {Name} | Category: {Category} | Area: {Area}";
    }
}