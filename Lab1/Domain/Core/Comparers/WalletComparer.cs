using System.Collections;

namespace Lab1.Domain.Core.Comparers;

public class WalletComparer : IComparer
{
    public int Compare(object x, object y)
    {
        Wallet c1 = x as Wallet;
        Wallet c2 = y as Wallet;

        return c1.Balance.CompareTo(c2.Balance);
    }
}