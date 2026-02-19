using Lab1.Domain.Core.Interfaces;
namespace Lab1.Domain.Core;

public class Ticket : SellableItemBase, IIdenifiable, IReceiptLine
{
<<<<<<< HEAD
    public string Id { get; }
    public Event eVent { get; }
    public User Owner { get; set; }
    public decimal Price { get; set; }
    public Ticket(string id, Event evEnt, User owner, string name, decimal basePrice) : base(name, basePrice)
=======
    public class Ticket : SellableItemBase, IIdenifiable, IReceiptLine, IComparable
>>>>>>> 5642b93c31b07d2060d14ef13f0800239f03ad7f
    {
<<<<<<< HEAD
        public string Id { get; }
        public Event eVent { get; }
        public User Owner { get; set; }
        public decimal Price { get; set; } 
        public Ticket (string id, Event evEnt, User owner, string name, decimal basePrice) : base(name, basePrice)
        {
            Id = id;
            Owner = owner;
            eVent = evEnt;
            Price = base.BasePrice;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Ticket || obj == null)
            {
                return false;
            }
            return Id.Equals(((Ticket)obj).Id);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Owner, Price);
        }

        public string PrintCheck()
        {
            return $"Id: {Id} Event: {eVent.Name} Price: {BasePrice} Buyer: {Owner.Name}";
        }
<<<<<<< HEAD
=======
        Id = id;
        Owner = owner;
        eVent = evEnt;
        Price = base.BasePrice;
>>>>>>> d61e295 (Tests.)
=======

        public override string ToString()
        {
            return $"Id: {Id} Event: {eVent.Name} Price: {BasePrice} Buyer: {Owner.Name}";
        }

        public int CompareTo(object? obj)
        {
            if (obj is not Ticket other)
            {
                throw new ArgumentException("Object must be type of Ticket");
            }
            
            return Price.CompareTo(other.Price);
        }
>>>>>>> 5642b93c31b07d2060d14ef13f0800239f03ad7f
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Ticket || obj == null)
        {
            return false;
        }
        return Id.Equals(((Ticket)obj).Id);
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Owner, Price);
    }
    public string PrintCheck()
    {
        return $"Id: {Id} Event: {eVent.Name} Price: {BasePrice} Buyer: {Owner.Name}";
    }
}