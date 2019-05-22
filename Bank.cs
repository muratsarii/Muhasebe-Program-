using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4_muhasebe
{
    class Bank
    {
        public Account[] accounts = new Account[0];
        public void AddNewAccount(Account account)
        {
            Array.Resize(ref accounts, accounts.Length + 1); //  tek boyutlu yeniden boyutlandırılabilinir dizi.
            for (int i = 0; i < accounts.Length; i++)
            {
                if (i == (accounts.Length - 1))
                    accounts[i] = account;
            }
        }
    }
}
