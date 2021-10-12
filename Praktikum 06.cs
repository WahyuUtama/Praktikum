using System;

namespace ConsoleApp6
{
    class Program
    {
        public interface IPayable
        {
            decimal DapatkanNominalPembayaran();
        }

        public class Tagihan : IPayable
        {
            public string Nomer { get; }
            public string Deskripsi { get; }
            private int jumlah;
            private decimal hargaPerBarang;

            public Tagihan(string nomor, string deskripsi, int kualitas, decimal hargaPerBarang)
            {
                Nomer = nomor;
                Deskripsi = deskripsi;
                Jumlah = kualitas;
                HargaPerBarang = hargaPerBarang;
            }

            public int Jumlah
            {
                get
                {
                    return jumlah;
                }
                set
                {
                    if (value < 0) // validation
                    {
                        throw new ArgumentOutOfRangeException(nameof(value),
                        value, $"{nameof(Jumlah)} must be >= 0");
                    }
                    jumlah = value;
                }
            }
            public decimal HargaPerBarang
            {
                get
                {
                    return hargaPerBarang;
                }
                set
                {
                    if (value < 0) // validation
                    {
                        throw new ArgumentOutOfRangeException(nameof(value),
                        value, $"{nameof(HargaPerBarang)} must be >= 0");
                    }
                    hargaPerBarang = value;
                }
            }
            public override string ToString() => $"TAGIHAN:\nNomor Tagihan: {Nomer} ({Deskripsi})\n" + $"Jumlah Barang: {Jumlah}\nprice per item: {HargaPerBarang:C}";

            public decimal DapatkanNominalPembayaran() => Jumlah * HargaPerBarang;
        }
        public abstract class Pegawai : IPayable
        {
            public string NamaDepan { get; }
            public string NamaBelakang { get; }
            public string NomorIdentitas { get; }

            public Pegawai(string namaDepan, string namaBelakang, string nomorIdentitas)
            {
                NamaBelakang = namaBelakang;
                NamaDepan = namaDepan;
                NomorIdentitas = nomorIdentitas;
            }

            public override string ToString() => $"{NamaDepan} {NamaBelakang}\n" + $"Nomor Identitas: {NomorIdentitas}";

            public abstract decimal Pendapatan();

            public decimal DapatkanNominalPembayaran() => Pendapatan();
        }
        public class GajiPegawai : Pegawai
        {
            private decimal gajiMingguan;

            public GajiPegawai(string namaDepan, string namaBelakang, string nomorIdentitas) : base(namaDepan, namaBelakang, nomorIdentitas)
            {
            }

            public GajiPegawai(string namaDepan, string namaBelakang, string nomorIdentitas, decimal gajiMingguan) : base(namaDepan, namaBelakang, nomorIdentitas)
            {
                GajiMingguan = gajiMingguan;
            }

            public decimal GajiMingguan
            {
                get
                {
                    return gajiMingguan;
                }
                set
                {
                    if (value < 0) // validation
                    {
                        throw new ArgumentOutOfRangeException(nameof(value),
                        value, $"{nameof(GajiMingguan)} must be >= 0");
                    }
                    gajiMingguan = value;
                }
            }
            public override decimal Pendapatan() => GajiMingguan;

            public override string ToString() => $"Gaji yang dibayar: {base.ToString()}\n" + $"Gaji mingguan: {GajiMingguan}";
        }

        static void Main(string[] args)
        {
            var payableObjects = new List<IPayable>() 
            {
                new Tagihan("01234", "seat", 2, 375.00M),
                new Tagihan("56789", "tire", 4, 79.95M),
                new GajiPegawai("John", "Smith", "111-11-1111, 100000.ooM"),
                new GajiPegawai("Lisa", "Barnes", "888-88-8888, 2200000.00M")
            };
            Console.WriteLine("Daftar Tagihan dan Pegawaai\n");

            foreach (var pembayaran in payableObjects)
            {
                Console.WriteLine($"{pembayaran }");
                Console.WriteLine(
                $"payment due: {pembayaran.DapatkanNominalPembayaran():C}\n");
            }
        }
    }
}
