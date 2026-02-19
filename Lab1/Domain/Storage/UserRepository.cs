<<<<<<< HEAD
﻿using Lab1.Domain.Core;
<<<<<<< HEAD
=======
namespace Lab1.Domain.Storage;
>>>>>>> d61e295 (Tests.)
=======
﻿using System.Collections;
using Lab1.Domain.Core;
using Lab1.Domain.Core.Comparers;
using Lab1.Domain.Core.Enumerators;
>>>>>>> 5642b93c31b07d2060d14ef13f0800239f03ad7f

public class UserRepository
{
<<<<<<< HEAD
    protected User[] users = new User[50];

    protected int _count = 0;

    public int GetCount()
    {
        return _count;
    }

=======
    class UserRepository : IEnumerable

    {
    User[] users = new User[50];
    private int _count = 0;

    public int GetCount()
    {
        return _count;
    }

>>>>>>> 5642b93c31b07d2060d14ef13f0800239f03ad7f
    public bool AddUser(User user)
    {
        if (users.Contains(user) || _count == 50)
        {
            return false;
        }
        users[_count] = user;
        _count++;
        return true;
    }

<<<<<<< HEAD
=======
        users[_count] = user;
        _count++;
        return true;
    }

>>>>>>> 5642b93c31b07d2060d14ef13f0800239f03ad7f
    public User GetUserById(string id)
    {
        for (int i = 0; i < _count; i++)
        {
            if (id.Equals(users[i].Id))
            {
                return users[i];
            }
        }
        return null;
    }

<<<<<<< HEAD
=======
        return null;
    }

>>>>>>> 5642b93c31b07d2060d14ef13f0800239f03ad7f
    public void PrintAll()
    {
        if (_count == 0)
        {
            Console.WriteLine("Create some first.");
        }
        else
        {
            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine(users[i].ToString());
            }
        }
    }

    public IEnumerator GetEnumerator()
    {
        return new UserEnumerator(users);
    }
    
    public void NatSort()
    {
        Array.Sort(users, 0, _count);
    }
    
    public void AltSort()
    {
        Array.Sort(users, 0, _count, new UserComparer());
    }
    }
}
