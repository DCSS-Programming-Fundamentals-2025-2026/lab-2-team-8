using Lab1.Domain.Core;

namespace Lab1.Domain.Storage;

public class TecketRepository
{
    private Ticket[] tickets = new Ticket[500];
    private int _count = 0;
    
    public int GetCount()
    {
        return _count;
    }
    
    public bool AddTicket(Ticket ticket, Wallet wallet)
    {
        if (tickets.Contains(ticket) || _countT == 500 || wallet.Balance < ticket.BasePrice || ticket.eVent.DT < DateTime.Now)
        {
            return false;
        }
        if (ticket.eVent.Status == "Ongoing")
        {
            ticket.Price *= (decimal)0.8;
        }
        ticket.Owner = wallet.User;
        tickets[_count] = ticket;
        wallet.Balance -= ticket.Price;
        checks[_countC] = new Check("check" + _countC, ticket, "Purchasing");

        _countC++;
        _countT++;
        sold++;
        revenue += ticket.Price;

        return true;
    }
}