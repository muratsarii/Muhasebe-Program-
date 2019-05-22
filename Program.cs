using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOP4_muhasebe
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank banka = new Bank();
            Person sahis = new Person();
            Account hesap = new Account();
            file.Read(banka);
            int secim = 0;
            do
            {
                Console.Clear();
                secim = MenuIslem(banka);
            } while (secim != 6);
            if (GetUserChoiseMain())
            {
                Console.Clear();
                Main(null);
            }
            file.Write(banka);
            Console.ReadKey();
        }
        static int MenuIslem(Bank islem)
        {
            DosyayaYazmaYadaOkuma file = new DosyayaYazmaYadaOkuma();
            bool secim = false;
            do
            {
                switch (GetUserChoiseMenu(out int deger))
                {
                    case 1: //Hesap Tanımla
                        CreateAnAccount(islem);
                        break;
                    case 2: //Hesapları Listele
                        GetAccounts(islem);
                        break;
                    case 3: //Para Yatır
                        EditBalance(islem);
                        break;
                    case 4: //Havale Yap
                        Havale(islem);
                        break;
                    case 5: //Hesap Detayları
                        int f = GetAccounts(islem);
                        file.HesapHareketleri(islem[f]);
                        break;
                    case 6: //Çıkış
                        secim = true;
                        break;
                    default:
                        HataMesaji("Lütfen menüdeki seçeneklerden birini seçiniz.");
                        break;
                }
            } while (secim=false);
            return deger;
        }
        static int GetUserChoiseMenu(out int secim)
        {
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("1- Hesap Tanımla");
            Console.WriteLine("2- Hesapları Listele");
            Console.WriteLine("3- Para Yatır");
            Console.WriteLine("4- Havale Yap");
            Console.WriteLine("5- Hesap Detayları");
            Console.WriteLine("6- Çıkış");
            Console.WriteLine("---------------------------------------");
            return secim = int.Parse(Console.ReadLine());
        }
        static void Havale(Bank gelendeger)
        {
            int sendHesapNo = GetAccountNoFromUser("Gönderen hesabın sıra no'sunu giriniz: ", gelendeger);
            int comHesapNo = GetAccountNoFromUser("Alıcı hesabın sıra no'sunu giriniz: ", gelendeger);
            int deger = GetIntegerFromUser("Hesaba yatırmak istediğiniz miktarı giriniz: ");
            gelendeger.accounts[sendHesapNo - 1]._balance -= deger;
            gelendeger.accounts[comHesapNo - 1]._balance += deger;
        }
        static void EditBalance(Bank gelenDeger)
        {
            int hesanpno = GetAccountNoFromUser("Değişiklik yapmak istediğiniz hesabın sıra No giriniz: ", gelenDeger);
            int deger = GetIntegerFromUser("Hesaba yatırmak istediğiniz miktarı giriniz: ");
            gelenDeger.accounts[hesanpno - 1]._balance += deger;
        }
        static void GetAccounts(Bank gelendeger)
        {
            for (int i = 0; i < gelendeger.accounts.Length; i++)
            {
                string formatlanmis = string.Format("Sıra No: {0}\nHesap Sahibinin Adı Soyadı: {1}\nTc Kimlik No: {2}\nHesap No: {3}\nBakiye: {4}\n", i + 1, gelendeger.accounts[i].kisi.IsimSoyisim, gelendeger.accounts[i].kisi.TcKimlikNo, gelendeger.accounts[i].AccountNo, gelendeger.accounts[i]._balance);
                Console.WriteLine(formatlanmis);
            }
        }
        static void CreateAnAccount(Bank gelendeger)
        {
            Account hesap = new Account();
            hesap.kisi = new Person();
            Console.Write("Lütfen Adınızı Soyadınızı Giriniz: ");
            hesap.kisi.IsimSoyisim = Console.ReadLine();
            Console.Write("Tc Kimlik No: ");
            hesap.kisi.TcKimlikNo = Console.ReadLine();
            Console.Write("Hesap No: ");
            hesap.AccountNo = Console.ReadLine();
            gelendeger.AddNewAccount(hesap);
        }
        static int GetAccountNoFromUser(string message, Bank gelen)
        {
            int input = 0;
            Console.WriteLine(message);
            if (!int.TryParse(Console.ReadLine(), out input))
            {
                if (input < gelen.accounts.Length && input > gelen.accounts.Length)
                {
                    Console.WriteLine("Lütfen seçeneklerden birinin sıra no'sunu giriniz!");
                    GetAccountNoFromUser(message, gelen);
                }
            }
            return input;
        }
        static string GetStringFromUser(string message)
        {
            string input;
            Console.Write(message);
            return input = Console.ReadLine();
        }
        static int GetIntegerFromUser(string message)
        {
            int input = 0;
            Console.WriteLine(message);
            if (!int.TryParse(Console.ReadLine(), out input))
            {
                GetIntegerFromUser(message);
            }
            return input;
        }
        static bool GetUserChoiseMain()
        {
            Console.Write("Do you want to replay ? (Y/N)");
            return Console.ReadKey().Key == ConsoleKey.Y;
        }
        static void HataMesaji(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hata: {0}",message);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }   
}
