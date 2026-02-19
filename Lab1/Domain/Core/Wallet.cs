<<<<<<< HEAD
﻿using Lab1.Domain.Core.Interfaces;
<<<<<<< HEAD
=======
namespace Lab1.Domain.Core;
>>>>>>> d61e295 (Tests.)
=======
﻿using System.Runtime.CompilerServices;
using Lab1.Domain.Core.Interfaces;
>>>>>>> 5642b93c31b07d2060d14ef13f0800239f03ad7f

public class Wallet : IIdenifiable
{
<<<<<<< HEAD
    public string Id { get; }
    public User uSer { get; }
    public decimal Balance { get; set; }
    public Wallet(string id, User user, decimal balance)
=======
    public class Wallet : IIdenifiable, IComparable
>>>>>>> 5642b93c31b07d2060d14ef13f0800239f03ad7f
    {
<<<<<<< HEAD
        public string Id { get; }
        public User User { get; }
        public decimal Balance { get; set; }
        public Wallet (string id, User user, decimal balance)
        {
            Id = id;
            User = user;
            Balance = balance;
        }
=======
        Id = id;
        uSer = user;
        Balance = balance;
    }
>>>>>>> d61e295 (Tests.)

    public override string ToString()
    {
        return $"Wallet Id: {Id}, balance: {Balance}";
    }
    public override bool Equals(object? obj)
    {
        if (obj is not Wallet || obj == null)
        {
<<<<<<< HEAD
            return $"Wallet Id: {Id}, balance: {Balance}";
        }
<<<<<<< HEAD
=======
            return false;
        }
        return Id.Equals(((Wallet)obj).Id);
>>>>>>> d61e295 (Tests.)
=======
        
        public int CompareTo(object? obj)
        {
            if (obj is not Wallet other)
            {
                throw new ArgumentException("Object must be type of Wallet");
            }
            
            return this.Balance.CompareTo(other.Balance);
        }
>>>>>>> 5642b93c31b07d2060d14ef13f0800239f03ad7f
    }
}
