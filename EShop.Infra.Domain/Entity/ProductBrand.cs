namespace EShop.Infra.Domain.Entity;


public class ProductBrand
{
    public int Id { get; private set; }

    public string Name { get; private set; }


    public ProductBrand(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public ProductBrand(string name)
    {
        Name = name;
    }
}
