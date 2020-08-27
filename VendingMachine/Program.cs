using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            SVendingMachine vm = new SVendingMachine();
            int vNoM,vNoU;
            string NoM,NoU;

            while (true)
            {
                vm.ListMakanan();
                Console.Write("Silahkan Pilih No Jenis Makanan : ");
                NoM = Console.ReadLine();

                vm.ListUang();
                Console.Write("Pilih No Deposite Uang : ");
                NoU = Console.ReadLine();
                int a = vm.GetListMakanan.Count();
                if (!Int32.TryParse(NoM, out vNoM) || vm.GetListMakanan.Count() < vNoM)
                {
                    Console.WriteLine("Jenis Makanan Tidak Tersedia");
                }
                else
                {
                    if (!Int32.TryParse(NoU, out vNoU) || vm.GetListUang.Count() < vNoU)
                    {
                        Console.WriteLine("Uang tidak Valid");
                    }
                    else
                    {
                        vm.GetMakanan(vNoM);
                        vm.HitungDepoite(vNoU);
                        vm.GetRefund();
                    }
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
