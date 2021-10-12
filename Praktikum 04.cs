using System;

namespace ConsoleApp4
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
                        {
                            throw new ArgumentOutOfRangeException(nameof(value),
                            value, $"{nameof(HasilKeuntungan)} must be > 0 and < 1");
                        }
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
            var GajiPegawai = new GajiPegawai("Andi", "Adinata", "222-22-2222", 10000000.00M, .06M);

            var bonusPendapatan = new BonusPendapatan("Luwumi", "Celestial", "333-33-3333", 5000000.00M, .04M, 300000.00M);

            Console.WriteLine(GajiPegawai.ToString());
            Console.WriteLine($"Pendapatan: {GajiPegawai.pendapatan:C}\n");

            Console.WriteLine(bonusPendapatan.ToString());
            Console.WriteLine($"Pendapatan: {bonusPendapatan.Pendapatan():C}\n");

            BonusPendapatan GajiPegawai2 = bonusPendapatan;

            Console.WriteLine(GajiPegawai2);
            Console.WriteLine($"Pendapatan: {bonusPendapatan.Pendapatan():C}\n");

            Console.ReadLine();
        }
    }
}
