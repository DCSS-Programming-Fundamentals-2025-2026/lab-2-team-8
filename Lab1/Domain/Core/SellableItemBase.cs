namespace Lab1.Domain.Core;

public abstract class SellableItemBase
{
<<<<<<< HEAD
    public string Name { get; }
    public decimal BasePrice { get; set; }
    public SellableItemBase(string name, decimal basePrice)
=======
    public abstract class SellableItemBase 
>>>>>>> 5642b93c31b07d2060d14ef13f0800239f03ad7f
    {
        Name = name;
        BasePrice = basePrice;
    }
    public SellableItemBase(string name)
    {
        Name = name;
    }

}