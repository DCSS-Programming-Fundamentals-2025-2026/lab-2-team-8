using Lab1.Domain.Core;
using Lab1.Domain.Storage;
namespace Lab1.Tests;

public class TestableUserRepository : UserRepository
{
    public int ExposedCount => _count;
    public User[] ExposedUsers => users;
}

public class TestableWalletRepository : WalletRepository
{
    public int ExposedCount => _count;
    public Wallet[] ExposedWallets => wallets;
}

public class TestableEventRepository : EventRepository
{
    public int ExposedCount => _count;
    public Event[] ExposedEvents => events;
}

public class TestableSaleRepository : SaleRepository
{
    public int ExposedCountT => _countT;
    public int ExposedCountC => _countC;
    public decimal ExposedRevenue => revenue;
    public int ExposedSold => sold;
    public int ExposedReturned => returned;
    public Ticket[] ExposedTickets => tickets;
}

public class Lab1Tests
{
    [Test]
    public void UserRepositoryAddTest()
    {
        var repo = new TestableUserRepository();
        var user = new User("u1", "Max");

        bool result = repo.AddUser(user);

        Assert.IsTrue(result);
        Assert.AreEqual(1, repo.ExposedCount);
        Assert.AreEqual("Max", repo.ExposedUsers[0].Name);
    }

    [Test]
    public void UserRepositoryAddDuplicateTest()
    {
        var repo = new TestableUserRepository();
        var user = new User("u1", "Max");
        repo.AddUser(user);

        bool result = repo.AddUser(user);

        Assert.IsFalse(result);
        Assert.AreEqual(1, repo.ExposedCount);
    }

    [Test]
    public void WalletRepositoryTest()
    {
        var repo = new TestableWalletRepository();
        var user = new User("u1", "Max");
        var wallet = new Wallet("w1", user, 100);

        bool resultError = repo.IncreaseBalance(wallet, -50);

        Assert.IsFalse(resultError);
        Assert.AreEqual(100, wallet.Balance);

        bool resultSuccess = repo.IncreaseBalance(wallet, 50);

        Assert.IsTrue(resultSuccess);
        Assert.AreEqual(150, wallet.Balance);
    }

    [Test]
    public void EventRepositoryTest()
    {
        var repo = new TestableEventRepository();

        var pastEvent = new Event("e1", "Past Concert", DateTime.Now.AddDays(-1));
        var futureEvent = new Event("e2", "Future Concert", DateTime.Now.AddDays(5));

        repo.AddEvent(pastEvent);
        repo.AddEvent(futureEvent);

        repo.ChangeStatus();

        Assert.AreEqual("Finished", repo.ExposedEvents[0].Status);
        Assert.AreEqual("Planned", repo.ExposedEvents[1].Status);
    }

    [Test]
    public void SaleRepositoryTest()
    {
        var saleRepo = new TestableSaleRepository();
        var user = new User("u1", "Buyer");
        var wallet = new Wallet("w1", user, 1000);
        user.Wallet = wallet;

        var evt = new Event("e1", "Concert", DateTime.Now.AddDays(5));
        var ticket = new Ticket("t1", evt, user, "VIP Ticket", 200);

        bool result = saleRepo.AddTicket(ticket, wallet);

        Assert.IsTrue(result);
        Assert.AreEqual(800, wallet.Balance);
        Assert.AreEqual(200, saleRepo.ExposedRevenue);
        Assert.AreEqual(1, saleRepo.ExposedSold);
        Assert.AreEqual(1, saleRepo.ExposedCountC);
    }

    [Test]
    public void SaleRepositoryTest2()
    {
        var saleRepo = new TestableSaleRepository();
        var user = new User("u1", "PoorGuy");
        var wallet = new Wallet("w1", user, 50);
        user.Wallet = wallet;

        var evt = new Event("e1", "Concert", DateTime.Now.AddDays(5));
        var ticket = new Ticket("t1", evt, user, "VIP Ticket", 200);

        bool result = saleRepo.AddTicket(ticket, wallet);

        Assert.IsFalse(result);
        Assert.AreEqual(50, wallet.Balance);
        Assert.AreEqual(0, saleRepo.ExposedCountT);
    }

    [Test]
    public void IntegrationFullPurchaseCycle()
    {
        var userRepo = new TestableUserRepository();
        var walletRepo = new TestableWalletRepository();
        var saleRepo = new TestableSaleRepository();

        var user = new User("u1", "IntegrationUser");
        userRepo.AddUser(user);

        var wallet = new Wallet("w1", user, 500);
        walletRepo.AddWallet(wallet, user);

        var evt = new Event("e1", "BigShow", DateTime.Now.AddDays(10));
        var ticket = new Ticket("t1", evt, user, "Seat 1", 300);

        bool buyResult = saleRepo.AddTicket(ticket, wallet);

        Assert.IsTrue(buyResult);
        Assert.AreEqual(200, wallet.Balance);
        Assert.AreEqual(user, ticket.Owner);
        Assert.AreEqual(1, saleRepo.ExposedSold);
    }

    [Test]
    public void IntegrationBuyAndReturnTicket()
    {
        var saleRepo = new TestableSaleRepository();
        var user = new User("u1", "Returner");
        var wallet = new Wallet("w1", user, 1000);
        var evt = new Event("e1", "Show", DateTime.Now.AddDays(2));

        decimal ticketPrice = 400;
        var ticket = new Ticket("t1", evt, user, "Seat A", ticketPrice);

        saleRepo.AddTicket(ticket, wallet);

        bool returnResult = saleRepo.SellTicket(ticket, wallet);

        Assert.IsTrue(returnResult);
        Assert.AreEqual(920, wallet.Balance);

        Assert.IsNull(ticket.Owner);
        Assert.AreEqual(1, saleRepo.ExposedReturned);
    }
}