using Lab1.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Domain.Core
{
    class Check: IIdenifiable
    {
        public string Id { get; }
        public DateTime PaymentTime { get; } = DateTime.Now;
        public Ticket Ticket { get; }
        public string Status { get; }
        public Wallet Wallet { get; }
        public Check(string id, Ticket ticket, string status)
        {
            Id = id;
            Ticket = ticket;
            Status = status;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Operation time: {PaymentTime}, Status: {Status}";
        }
    }
}
