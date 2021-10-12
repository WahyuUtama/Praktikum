using System;

namespace ConsoleApp2
{
    class Program
    {
        public class BonusPendapatan
        {
            public string NamaDepan { get; }
            public string NamaBelakang { get; }
            public string NomorIdentitas { get; }
            private decimal hasilPenjualan; 
            private decimal hasilKeuntungan;
            private decimal pendapatanDasar;

            public BonusPendapatan(string namaDepan, string namaBelakang, string nomorIdentitas, decimal hasilPenjualan, decimal hasilKeuntungan, decimal pendapatanDasar)
            {
                NamaDepan = namaDepan;
                NamaBelakang = namaBelakang;
                NomorIdentitas = nomorIdentitas;
                HasilPenjualan = hasilPenjualan;
                HasilKeuntungan = hasilKeuntungan;
                PendapatanDasar = pendapatanDasar;
            }
            public decimal HasilPenjualan
            {
                get
                {
                    return hasilPenjualan;
                }
                set
                {
                    if (value < 0) // validation
                     {
                     throw new ArgumentOutOfRangeException(nameof(value),
                     value, $"{nameof(HasilPenjualan)} must be >= 0");
                     }
                hasilPenjualan = value;
                }
            }
            public decimal HasilKeuntungan
            {
                get
                {
                    return hasilKeuntungan;
                }
                set
                {
                    if (value <= 0 || value >= 1) // validation
                    {
                        throw new ArgumentOutOfRangeException(nameof(value),
                        value, $"{nameof(HasilKeuntungan)} must be > 0 and < 1");
                    }
                hasilKeuntungan = value;
                }
            }
            public decimal PendapatanDasar
            {
                get
                {
                    return pendapatanDasar;
                }
                set
                {
                    if (value < 0) // validation
                    {
                        throw new ArgumentOutOfRangeException(nameof(value),
                        value, $"{nameof(PendapatanDasar)} must be >= 0");
                    }
                pendapatanDasar = value;
                }
            }
            public decimal Pendapatan() => pendapatanDasar + (hasilKeuntungan * hasilPenjualan);

            public override string ToString() => $"Bonus Dari: {NamaDepan} {NamaBelakang}\n" + $"Nomor Identitas: {NomorIdentitas}\n" + $"Penjualan: {HasilPenjualan:C}\n" + $"Keuntungan: {hasilKeuntungan:F2}\n" + $"Pendapatan Dasar: {pendapatanDasar:C}";
        }
        static void Main(string[] args)
        {
            var pegaway = new BonusPendapatan("Bob", "Lewis","333-33-3333", 5000.00M, .04M, 300.00M);

            Console.WriteLine("Informasi karyawan yang diperoleh dengan properti dan metode: ");
            Console.WriteLine();
            Console.WriteLine($"Nama Depan : " + pegaway.NamaDepan);
            Console.WriteLine($"Nama Belakang : " + pegaway.NamaBelakang);
            Console.WriteLine($"Nomer Keamanan : " + pegaway.NomorIdentitas);
            Console.WriteLine($"Berhasil menjual Gross : {pegaway.HasilPenjualan:C}");
            Console.WriteLine($"Persentasi Bonus : " + pegaway.HasilKeuntungan);
            Console.WriteLine($"Pendapatan : {pegaway.Pendapatan():C}");
            Console.WriteLine($"Penghasilan Dasar : {pegaway.PendapatanDasar}");
            Console.WriteLine();

            pegaway.PendapatanDasar = 1000.00M;


            Console.WriteLine("Update Informasi");
            Console.WriteLine();
            Console.WriteLine(pegaway.ToString());
            Console.WriteLine($"Pendapatan : { pegaway.Pendapatan():C}");

            Console.ReadLine();
        }
    }
}
