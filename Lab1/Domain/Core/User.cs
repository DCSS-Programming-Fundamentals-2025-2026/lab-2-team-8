using Lab1.Domain.Core.Interfaces;
<<<<<<< HEAD
=======
namespace Lab1.Domain.Core;
>>>>>>> d61e295 (Tests.)

public class User : IIdenifiable
{
<<<<<<< HEAD
    public string Id { get; }
    public string Name { get; }
    public Wallet Wallet { get; set; }
    public User(string id, string name)
=======
    public class User : IIdenifiable, IComparable
>>>>>>> 5642b93c31b07d2060d14ef13f0800239f03ad7f
    {
<<<<<<< HEAD
        public string Id { get; }
        public string Name { get; }
        public Wallet Wallet { get; set; }
        public User(string id, string name)
        {
            Id = id;
            Name = name;
        }
        public override string ToString()
        {
            if (Wallet == null)
            {
                return $"Id:{Id} Name: {Name} Wallet: None";
            }
            return $"Id:{Id} Name: {Name} Wallet: {Wallet.ToString()}";
        }
<<<<<<< HEAD
=======
        Id = id;
        Name = name;
>>>>>>> d61e295 (Tests.)
=======
        
        public int CompareTo(object obj)
        {
            if (obj is not User other)
            {
                throw new ArgumentException("Object must be type of User");
            }
            
            return this.Wallet.Balance.CompareTo(other.Wallet.Balance);
        }
>>>>>>> 5642b93c31b07d2060d14ef13f0800239f03ad7f
    }
    public override string ToString()
    {
        if (Wallet == null)
        {
            return $"Id:{Id} Name: {Name} Wallet: None";
        }
        return $"Id:{Id} Name: {Name} Wallet: {Wallet.ToString()}";
    }
    public override bool Equals(object? obj)
    {
        if (obj is not User || obj == null)
        {
            return false;
        }
        return Id.Equals(((User)obj).Id);
    }
}