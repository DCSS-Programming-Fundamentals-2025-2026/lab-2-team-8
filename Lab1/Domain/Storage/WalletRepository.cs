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

public class WalletRepository
{
<<<<<<< HEAD
    protected Wallet[] wallets = new Wallet[50];
    protected int _count = 0;

    public int GetCount()
    {
        return _count;
=======
    class WalletRepository : IEnumerable
    {
        Wallet[] wallets = new Wallet[50];
        private int _count = 0;

        public int GetCount()
        {
            return _count;
        }

        public bool AddWallet(Wallet wallet, User user)
        {
            if (_count == 50 || wallets.Contains(wallet))
            {
                return false;
            }
            user.Wallet = wallet;
            wallets[_count] = wallet;

            _count++;
            return true;
        }
        public bool IncreaseBalance(Wallet wallet, decimal balance)
        {
            if (balance <= 0)
            {
                return false;
            }
            wallet.Balance += balance;
            return true;
        }

        public IEnumerator GetEnumerator()
        {
            return new WalletEnumerator(wallets);
        }
        
        public void NatSort()
        {
            Array.Sort(wallets, 0, _count);
        }
        
        public void AltSort()
        {
            Array.Sort(wallets, 0, _count, new WalletComparer());
        }
>>>>>>> 5642b93c31b07d2060d14ef13f0800239f03ad7f
    }

    public bool AddWallet(Wallet wallet, User user)
    {
        if (_count == 50 || wallets.Contains(wallet))
        {
            return false;
        }
        user.Wallet = wallet;
        wallets[_count] = wallet;

        _count++;
        return true;
    }
    public bool IncreaseBalance(Wallet wallet, decimal balance)
    {
        if (balance <= 0)
        {
            return false;
        }
        wallet.Balance += balance;
        return true;
    }
}