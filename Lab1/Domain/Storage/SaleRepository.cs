using Lab1.Domain.Core;
using Lab1.Domain.Storage;
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
        Check[] checks = new Check[1000];

        private int _countT = 0;
        private int _countC = 0;

        private int sold = 0;
        private int returned = 0;
        private decimal revenue = 0;

        public bool AddTicket(Ticket ticket, Wallet wallet)
        {
            if (tickets.Contains(ticket) || _countT == 500 || wallet.Balance < ticket.BasePrice || ticket.eVent.DT < DateTime.Now)
            {
                return false;
            }
            if (ticket.eVent.Status == "Ongoing")
            {
                ticket.Price *= (decimal)1.5;
            }
            tickets[_countT] = ticket;
            wallet.Balance -= ticket.Price;
            checks[_countC] = new Check("check" + _countC, ticket, "Purchasing");

            _countC++;
            _countT++;
            sold++;
            revenue++;

            return true;
        }
        public int GetTicketIndexById(string id)
        {
            for (int i = 0; i < _countT; i++)
            {
                if (id == tickets[i].Id)
                {
                    return i;
                }
            }
            return -1;
        }
        public Ticket GetTicketByID(string id)
        {
            for (int i = 0; i < _countT; i++)
            {
                if (id == tickets[i].Id)
                {
                    return tickets[i];
                }
            }
            return null;
        }
        public Check GetCheckByTicket(Ticket ticket)
        {
            for (int i = 0; i < _countC; i++)
            {
                if (checks[i].Ticket.Equals(ticket))
                {
                    return checks[i];
                }
            }
            return null;
        }
        public Check GetCheckById(string id)
        {
            for (int i = 0; i < _countC; i++)
            {
                if (checks[i].Id.Equals(id))
                {
                    return checks[i];
                }
            }
            return null;
        }

        public bool SellTicket(Ticket ticket, Wallet wallet)
        {
            Check check = GetCheckByTicket(ticket);
            if (!(tickets.Contains(ticket)) || _countT == 0 || check == null)
            {
                return false;
            }
            int indexToDelete = GetTicketIndexById(ticket.Id);
            tickets[indexToDelete] = tickets[_countT - 1]; 
            wallet.Balance += ticket.Price / (decimal)1.75;
            revenue -= ticket.Price / (decimal)1.75;
            checks[_countC] = new Check("check" + _countC, ticket, "Returning");

            _countC++;
            _countT--;
            returned++;
            return true;
        }
        public void EventSummary(Event @event)
        {
            decimal revenue = 0;
            for (int i = 0; i < _countT; i++)
            {
                if (tickets[i].eVent == @event)
                {
                    revenue += tickets[i].BasePrice;
                }
            }
            Console.WriteLine(@event.ToString() + $"Revenue: {revenue}");
        }
        public void SaleSummary()
        {
            Console.WriteLine($"Sold: {sold}, Returned: {returned}, Total Revenue: {revenue}");
        }
        public void PrintCheck(string id)
        {
            Check check = GetCheckById(id);
            if ( check != null )
            {
                Console.WriteLine(check.ToString());
            }
            else
            {
                Console.WriteLine("No checks with such id.");
            }
        }
        public void PrintCheck(Ticket ticket)
        {
            Check check = GetCheckByTicket(ticket);
            if (check != null)
            {
                Console.WriteLine(check.ToString());
            }
            else
            {
                Console.WriteLine("No checks with such ticket.");
            }
        }
    }
}
