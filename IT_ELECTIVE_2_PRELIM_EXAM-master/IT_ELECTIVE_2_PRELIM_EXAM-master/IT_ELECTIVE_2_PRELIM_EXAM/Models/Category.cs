namespace IT_ELECTIVE_2_PRELIM_EXAM.Models;

// EXERCISE 3 & 4: Constructors - Default and Parameterized
public class Category
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Category()
    {
        Name = "";
        Description = "";
    }
    public Category(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public override string ToString()
    {
        return $"Category: {Name} - {Description}";
    }
}