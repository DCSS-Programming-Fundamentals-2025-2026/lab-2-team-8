using System.Collections;

namespace Lab1.Domain.Core.Comparers;

public class UserComparer : IComparer
{
    public int Compare(object x, object y)
    {
        User c1 = x as User;
        User c2 = y as User;

        return string.Compare(c1.Name, c2.Name, StringComparison.OrdinalIgnoreCase);
    }
}