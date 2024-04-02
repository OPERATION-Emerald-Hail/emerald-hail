namespace Emerald.Hail.Domain.Catalog;

public class Item 
{
    public int Id {get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Brand { get; set; }
    public decimal Price { get; set; }
    public List<Rating> Ratings { get; set; } = new List<Rating>();

    public Item(string name, string description, string brand, decimal price)
    {
        if(string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("A name is required!");
        }

        if(string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException("A description is required!");
        }

        if(string.IsNullOrWhiteSpace(brand))
        {
            throw new ArgumentException("A brand is required!");
        }

        if(price < 0 || price == 0)
        {
            throw new ArgumentException("Price cannot be negative or 0!");
        }

        Name = name;
        Description = description;
        Brand = brand;
        Price = price;
    }

    public void AddRating(Rating rating)
    {
        Ratings.Add(rating);
    }
}