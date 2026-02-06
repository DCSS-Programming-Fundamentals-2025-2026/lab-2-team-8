using Lab1.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Domain.Core
{
    class Wallet : IIdenifiable
    {
        public string Id { get; }
        public User uSer { get; }
        public decimal Balance { get; set; }
        public Wallet (string id, User user, decimal balance)
        {
            Id = id;
            uSer = user;
            Balance = balance;
        }
    }
}
