using Lab1.Domain.Core.Interfaces;
using Lab1.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Domain.Core
{
    class Ticket : SellableItemBase, IIdenifiable, IReceiptLine
    {
        public string Id { get; }
        public string OwnerId {  get; }
        public Ticket (string id, string name, string ownerId, decimal basePrice) : base(name, basePrice)
        {
            Id = id;
            OwnerId = ownerId;
        }

    }
}
