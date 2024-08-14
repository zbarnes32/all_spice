namespace all_spice.Models;

public class Recipe 
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime MyProperty { get; set; }
    public string Title { get; set; }
    public string Instructions { get; set; }
    public string Img { get; set; }
    public string Category { get; set; }
    public string CreatorId { get; set; }

}