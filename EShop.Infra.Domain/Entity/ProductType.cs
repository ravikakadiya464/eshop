namespace EShop.Infra.Domain.Entity;


public class ProductType
{
    public int Id { get; private set; }

    public string Name { get; private set; }


    public ProductType(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public ProductType(string name)
    {
        Name = name;
    }
}