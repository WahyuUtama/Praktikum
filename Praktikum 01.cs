using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public class GajiPegawai : object
        {
            public string NamaDepan { get; }
            public string NamaBelakang { get; }
            public string NomerKeamanan { get; }
            private decimal grossTerjual;
            private decimal persentaseKeuntungan;
            public GajiPegawai(string namaDepan, string namaBelakang, string nomerKeamanan, decimal grossTerjual, decimal PresentaseKeuntungan)
            {
                NamaDepan = namaDepan;
                NamaBelakang = namaBelakang;
                NomerKeamanan = nomerKeamanan;
                GrossTerjual = grossTerjual;
                PresentasiKeuntungan = PresentaseKeuntungan;
            }
            public decimal GrossTerjual
            {
                get
                {
                    return grossTerjual;
                }
                set
                {
                    if (value < 0) // validation
                    {
                        throw new ArgumentOutOfRangeException(nameof(value),
                        value, $"{nameof(GrossTerjual)} must be >= 0");
                    }
                    grossTerjual = value;
                }
            }
            public decimal PresentasiKeuntungan
            {
                get
                {
                    return persentaseKeuntungan;
                }
                set
                {
                    if (value <= 0 || value >= 1) // validation
                    {
                        throw new ArgumentOutOfRangeException(nameof(value),
                        value, $"{nameof(PresentasiKeuntungan)} must be > 0 and < 1");
                    }
                    persentaseKeuntungan = value;
                }
            }
            public decimal pendapatan => persentaseKeuntungan * grossTerjual;

            public string ToString() => $"Bonus Pegawai: {NamaDepan} {NamaBelakang}\n" + $"Nomer Keamanan: {NomerKeamanan}\n" + $"Menjual Gross: { grossTerjual:C}\n" + $"Persentasi Keuntungan: { persentaseKeuntungan:F2}";
        }
        static void Main(string[] args)
        {
            var pegaway = new GajiPegawai("Andi", "Adinata", "081-339", 10000.00M, .06M);

            Console.WriteLine("Informasi karyawan yang diperoleh dengan properti dan metode: ");
            Console.WriteLine();
            Console.WriteLine($"Nama Depan : " + pegaway.NamaDepan);
            Console.WriteLine($"Nama Belakang : " + pegaway.NamaBelakang);
            Console.WriteLine($"Nomer Keamanan : " + pegaway.NomerKeamanan);
            Console.WriteLine($"Berhasil menjual Gross : {pegaway.GrossTerjual:C}");
            Console.WriteLine($"Persentasi Bonus : " + pegaway.PresentasiKeuntungan);
            Console.WriteLine($"Pendapatan : {pegaway.pendapatan:C}\n");
            Console.WriteLine();

            pegaway.GrossTerjual = 50000000.00M;
            pegaway.PresentasiKeuntungan = .05M;
            

            Console.WriteLine("Update Informasi");
            Console.WriteLine();
            Console.WriteLine(pegaway.ToString());
            Console.WriteLine("Pendapatan : " + pegaway.pendapatan);

            Console.ReadLine();
        }
    }
}
