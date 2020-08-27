using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class SVendingMachine
    {
        private double UangDeposite = 0;
        private double _nominal = 0;
        private double _harga = 0;
        private int _stock = 0;

        public void ListMakanan()
        {
            foreach (var i in GetListMakanan.OrderBy(a => a.No))
            {
                Console.WriteLine("{0}) {1} \t: {2}", i.No, i.JenisMakanan, i.Harga);
            }
        }
        public void ListUang()
        {
            foreach (var i in GetListUang.OrderBy(a => a.No))
            {
                Console.WriteLine("{0}) {1}", i.No, i.Nominal);
            }
        }
        public void HitungDepoite(int No)
        {
            int vNoU;
            string NoU;
            _nominal = GetListUang.Single(a => a.No.Equals(No)).Nominal;
            UangDeposite += _nominal;
            if (_stock > 0)
            {
                Console.WriteLine("Deposite Anda : {0} dari harga : {1}", UangDeposite, _harga);
                if (UangDeposite < _harga)
                {
                    while (UangDeposite < _harga)
                    {
                        ListUang();
                        Console.Write("Silahkan Tambah Deposite Anda : ");
                        NoU = Console.ReadLine();

                        if (!Int32.TryParse(NoU, out vNoU) || GetListUang.Count() < vNoU)
                        {
                            Console.WriteLine("Uang tidak Valid");
                        }
                        else
                        {
                            HitungDepoite(vNoU);
                        }
                    }
                }
            }
        }
        public void GetMakanan(int No)
        {
            var Makanan = GetListMakanan.Single(a => a.No.Equals(No));
            _harga = Makanan.Harga;
            _stock = Makanan.Stock;
            Console.WriteLine("\n\nMakanan {0} harga {1}", Makanan.JenisMakanan, Makanan.Harga);
        }
        public void GetRefund()
        {
            if (_stock > 0)
                Console.WriteLine("Kembalian uang anda {0}", UangDeposite - _harga);
            else
                Console.WriteLine("Maaf Stok Habis !! \nKembalian uang anda {0}", UangDeposite);
            UangDeposite = 0;
        }

        public class Makanan
        {
            public int No { get; set; }
            public string JenisMakanan { get; set; }
            public double Harga { get; set; }
            public int Stock { get; set; }
        }

        public class Uang
        {
            public int No { get; set; }
            public double Nominal { get; set; }
        }

        public readonly IEnumerable<Makanan> GetListMakanan = new[]
        {
            new Makanan{
                No=1,
                JenisMakanan="Biskuit",
                Harga = 6000,
                Stock = 2
            },
            new Makanan{
                No=2,
                JenisMakanan="Chips",
                Harga = 8000,
                Stock = 0
            },
            new Makanan{
                No=3,
                JenisMakanan="Oreo",
                Harga = 10000,
                Stock = 1
            },
            new Makanan{
                No=4,
                JenisMakanan="Tango",
                Harga = 12000,
                Stock = 1
            },
            new Makanan{
                No=5,
                JenisMakanan="Cokelat",
                Harga = 15000,
                Stock = 1
            }
        };

        public readonly IEnumerable<Uang> GetListUang = new[]
        {
            new Uang{
                No=1,
                Nominal = 2000
            },
            new Uang{
                No=2,
                Nominal = 5000
            },
            new Uang{
                No=3,
                Nominal = 10000
            },
            new Uang{
                No=4,
                Nominal = 20000
            },
            new Uang{
                No=5,
                Nominal = 50000
            }
        };
    }
}
