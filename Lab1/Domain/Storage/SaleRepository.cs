using Lab1.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Domain.Storage
{
    class SaleRepository
    {
        Ticket[] tickets = new Ticket[500];
        private int _count = 0;

        public bool AddSale(Ticket ticket)
        {
            if (tickets.Contains(ticket) || _count == 0)
            {
                return false;
            }
            tickets[_count] = ticket;
            _count++;
            return true;
        }
        public void CountAll()
        {

        }
    }
}
