using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4_muhasebe
{
    class Person
    {
        private string _tcKimlik;
        public string IsimSoyisim { get; set; }
        int tcOn = 0, tcOnbir = 0, tctek = 0, tccift = 0;
        public string TcKimlikNo
        {
            get { return _tcKimlik; }
            set
            {
                if (value.Length != 11)
                {
                    foreach (char deger in value)
                    {
                        if (!char.IsDigit(deger))
                            throw new ArgumentOutOfRangeException("11 Haneli ve sayısal değerlerden oluşan bir TC Kimlik numarası giriniz.");
                        for (int i = 0; i < value.Length - 2; i += 2)
                        {
                            tctek += value[i];
                        }
                        for (int i = 0; i < value.Length - 3; i++)
                        {
                            tccift += value[i];
                        }
                        tcOn = ((tctek * 7) - tccift) % 10;
                        if (tcOn == value[9])
                        {
                            tcOnbir = (tcOn + tctek + tccift) % 10;
                            if (tcOnbir == value[10])
                            {
                                Console.WriteLine("Başarılı Tc Kimlik No girişi. ");
                            }
                        }
                        else
                            throw new Exception("Hata Tc Kimlik No girişi yaptınız. ");
                        _tcKimlik = value;
                    }

                }
            }
        }
    }
}
