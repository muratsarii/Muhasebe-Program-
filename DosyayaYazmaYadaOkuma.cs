using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //<<<<<<<=========================<<<<<<<BU YAZILMASI GEREK<<<<<<<=========================<<<<<<<

namespace OOP4_muhasebe
{
    class DosyayaYazmaYadaOkuma
    {
        public string[] accounts = new string[1];
        public void Write(Account[] gelendeger)
        {
            for (int i = 0; i < gelendeger.Length; i++)
            {
                Array.Resize(ref accounts, accounts.Length + 1);
                Console.WriteLine("|Hesap Sahibinin Adı Soyadı: {0}\n|Tc Kimlik No: {1}\n|Hesap No: {2}\n|Bakiye: {3}\n", gelendeger[i].kisi.IsimSoyisim, gelendeger[i].kisi.TcKimlikNo, gelendeger[i].AccountNo, gelendeger[i]._balance);
                accounts[i] = Console.ReadLine();
            }
            File.WriteAllLines(@"F:\KursOrnekler\muhasebe.txt", accounts);
        }
        public void addLinetoTxt (Account hesap)
        {
            string hesapstring = string.Format("{0},{1},{2},{3}", hesap.kisi.IsimSoyisim, hesap.kisi.TcKimlikNo, hesap.AccountNo, hesap.Bakiye);
            File.AppendAllText(@"F:\KursOrnekler\muhasebe.txt", hesapstring + Environment.NewLine); //Bir dosya açar, belirtilen dizeyi dosyaya ekler ve ardından dosyayı kapatır. Dosya mevcut değilse bu yöntem bir dosya oluşturur, belirtilen dizeyi yazar ve ardından dosyayı kapatır.
        }
        public void AccountUpdate (Account[] hesaplar)
        {
            File.Delete(@"F:\KursOrnekler\muhasebe.txt");
            for (int i = 0; i < hesaplar.Length; i++)
            {
                Write(hesaplar);
                //addLinetoTxt(hesaplar[i]);
            }
        }
        public void HesapHareketleri(Account hesaplar)
        {
            string[] TumIslemler = File.ReadAllLines(@"F:\KursOrnekler\muhasebe.txt"); //Bir metin dosyasını açar, dosyanın tüm satırları okur ve ardından dosyayı kapatır.
            for (int i = 0; i < TumIslemler.Length; i++)
            {
                string[] bilgi = TumIslemler[i].Split(',');

                if (bilgi[0] == hesaplar.AccountNo)
                {
                    Console.WriteLine(bilgi[0] + " " + bilgi[1]);
                }
            }
        }
        /*public static int[] Read(Account gelendeger)
        {
            string[] readtext = File.ReadAllLines(@"F:\KursOrnekler\muhasebe.txt");
            for (int i = 0; i < readtext.Length; i++)
            {
                Account hesap = new Account();
                hesap.kisi = new Person();
                hesap.personBank = new Bank();
                string text = readtext[i];
                string[] members = text.Split('|');
                for (int j = 0; i < members.Length; j++)
                {
                    hesap.kisi.IsimSoyisim = members[0].Trim();
                    hesap.kisi.TcKimlikNo = members[1].Trim();
                    hesap.AccountNo = members[2].Trim();
                    hesap._balance = Convert.ToInt32(members[3].Trim());
                }
                gelendeger.personBank.AddNewAccount(hesap);
                gelendeger.kisi.IsimSoyisim = hesap.kisi.IsimSoyisim;
                gelendeger.kisi.TcKimlikNo = hesap.kisi.TcKimlikNo;
                gelendeger.AccountNo = hesap.AccountNo;
                gelendeger._balance = hesap._balance;
            }
            return gelendeger[];
        }*/
        public void Read(Bank gelendeger)
        {
            string[] readtext = File.ReadAllLines(@"F:\KursOrnekler\muhasebe.txt");
            for (int i = 0; i < readtext.Length; i++)
            {
                Account hesap = new Account();
                hesap.kisi = new Person();
                string text = readtext[i];
                string[] members = text.Split('|');
                for (int j = 0; i < members.Length; j++)
                {
                    hesap.kisi.IsimSoyisim = members[0].Trim();
                    hesap.kisi.TcKimlikNo = members[1].Trim();
                    hesap.AccountNo = members[2].Trim();
                    hesap._balance = Convert.ToInt32(members[3].Trim());
                }
                gelendeger.AddNewAccount(hesap);
                gelendeger.accounts[i].kisi.IsimSoyisim = hesap.kisi.IsimSoyisim;
                gelendeger.accounts[i].kisi.TcKimlikNo = hesap.kisi.TcKimlikNo;
                gelendeger.accounts[i].AccountNo = hesap.AccountNo;
                gelendeger.accounts[i]._balance = hesap._balance;
            }
        }
    }
}
