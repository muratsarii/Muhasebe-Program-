using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4_muhasebe
{
    class Account
    {
        private string _accountNumber;
        public int _balance = 0;
        public decimal _bakiye = 0;
        public Person kisi;
        public Account personAccount;
        public Bank personBank = new Bank();

        public string AccountNo
        {
            get { return _accountNumber; }
            set
            {
                string num = value;
                bool deger = int.TryParse(num, out int input);
                char[] charArr = value.ToCharArray();
                if (charArr.Length != 6)
                {
                    Console.WriteLine("Girdiğiniz hesap numarası 6 haneli olmalıdır!\nTekrar deneyiniz: ");
                    AccountNo = Console.ReadLine();
                }
                else if (!deger)
                {
                    Console.WriteLine("Girdiğiniz değer yalnızca rakamlardan oluşmalıdır!\nTekrar deneyiniz: ");
                    AccountNo = Console.ReadLine();
                }
                else
                    _accountNumber = value;
            }
        }
        public decimal Bakiye
        {
            get
            {
                return _bakiye;
            }
            set
            {
                if (value < 0)
                    throw new Exception("Bakiye sıfırdan küçük olamaz.");
                value = _bakiye;
            }
        }
            

    }
}
