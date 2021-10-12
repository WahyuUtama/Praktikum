using System;

namespace ConsoleApp5
{
    class Program
    {
        public abstract class Pegawai
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
        }

        public class GajiPegawai : Pegawai
        {
            private decimal gajiMingguan;

            public GajiPegawai(string namaDepan, string namaBelakang, string nomorIdentitas, decimal gajiMingguan) : base (namaDepan, namaBelakang, nomorIdentitas)
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

        public class JamKerjaPegawai : Pegawai
        {
            private decimal upah;
            private decimal jam;

            public JamKerjaPegawai(string namaDepan, string namaBelakang, string nomorIdentitas, decimal jamKerja, decimal upahPerJam) :base (namaDepan, namaBelakang, nomorIdentitas)
            {
                Upah = upahPerJam;
                Jam = jamKerja;
            }

            public decimal Upah
            {
                get
                {
                    return upah;
                }
                set
                {
                    if (value < 0) // validation
                    {
                        throw new ArgumentOutOfRangeException(nameof(value),
                        value, $"{nameof(Upah)} must be >= 0");
                    }
                upah = value;
                }
            }

            public decimal Jam
            {
                get
                {
                    return jam;
                }
                set
                {
                    if (value < 0 || value > 168) // validation
                    {
                        throw new ArgumentOutOfRangeException(nameof(value),
                        value, $"{nameof(Jam)} must be >= 0 and <= 168");
                    }
                    jam = value;
                }
            }
            public override decimal Pendapatan()
            {
                if (Jam < 40)
                {
                    return Upah * Jam;                
                }
                else
                {
                    return (Upah * 40) + ((Jam - 40) * Upah * 1.5M);
                }
            }
            public override string ToString() => $"Pekerja: {base.ToString()}\n" + $"Upah PerJam: {Upah:C}\nJam Bekerja: {Jam:F2}";
        }

        public class BonusPekerja : Pegawai
        {
            private decimal hasilPenjualan;
            private decimal persentaseBonus;

            public BonusPekerja(string namaDepan, string namaBelakang, string nomorIdentitas, decimal hasilPenjualan, decimal persentaseBonus) :base(namaDepan, namaBelakang, nomorIdentitas)
            {
                HasilPenjualan = hasilPenjualan;
                PersentaseBonus = persentaseBonus;
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

            public decimal PersentaseBonus
            {
                get
                {
                    return persentaseBonus;
                }
                set
                {
                    if (value <= 0 || value >= 1) // validation
                    {
                        throw new ArgumentOutOfRangeException(nameof(value),
                        value, $"{nameof(PersentaseBonus)} must be > 0 and < 1");
                    }
                    
                    persentaseBonus = value;
                }
            }

            public override decimal Pendapatan() => hasilPenjualan * persentaseBonus;

            public override string ToString() => $"Bonus Pegawai: {base.ToString()}\n" + $"Hasil Penjualan: {HasilPenjualan:C}\n" + $"Persentase Bonus: {PersentaseBonus:F2}";
        }

        public class GajiPokokPegawai : BonusPekerja
        {
            private decimal gajiPokok;

            public GajiPokokPegawai(string namaDepan, string namaBelakang, string nomorIdentitas, decimal hasilPenjualan, decimal persentaseBonus, decimal gajiPokok) : base(namaDepan, namaBelakang, nomorIdentitas, hasilPenjualan, persentaseBonus)
            {
                GajiPokok = gajiPokok;
            }

            public decimal GajiPokok
            {
                get
                {
                    return gajiPokok;
                }
                set
                {
                    if (value < 0) // validation
                    {
                        throw new ArgumentOutOfRangeException(nameof(value),
                        value, $"{nameof(GajiPokok)} must be >= 0");
                    }
                    
                gajiPokok = value;
                }
            }

            public override decimal Pendapatan() => GajiPokok + base.Pendapatan();

            public override string ToString() => $"Gaji Pokok Dari {base.ToString()}\nGaji Pokok: {GajiPokok:C}";
        }


        static void Main(string[] args)
        {
            var gajiPegawai = new GajiPegawai("Andi", "Adinata","111-11-1111", 8000000.00M);
            var jamKerjaPegawai = new JamKerjaPegawai("Limi", "Celestia","222-22-2222", 16.75M, 40000.0M);
            var bonusPekerja = new BonusPekerja("Ariani", "Iofifteen","333-33-3333", 10000000.00M, .06M);
            var gajiPokokPegawai = new GajiPokokPegawai("Chlowe", "Pawapuwa","444-44-4444", 5000000.00M, .04M, 300000.00M);

            Console.WriteLine("Pendapatan Individu Pegawai:\n");
            
            Console.WriteLine($"{gajiPegawai}\nearned: " + $"{gajiPegawai.Pendapatan():C}\n");
            Console.WriteLine($"{jamKerjaPegawai}\nearned: {jamKerjaPegawai.Pendapatan():C}\n");
            Console.WriteLine($"{bonusPekerja}\nearned: " + $"{bonusPekerja.Pendapatan():C}\n");
            Console.WriteLine($"{gajiPokokPegawai}\nearned: " + $"{gajiPokokPegawai.Pendapatan():C}\n");

            var pegawai = new List<Pegawai>() {gajiPegawai, jamKerjaPegawai, bonusPekerja, gajiPokokPegawai};

            Console.WriteLine("progres Pegawai:\n");

            foreach (var pegawaiSekarang in pegawai)
            {
                Console.WriteLine(pegawaiSekarang);

                if (pegawaiSekarang is GajiPokokPegawai)
                {
                    var pegawai = (GajiPokokPegawai)pegawaiSekarang;

                    pegawai.GajiPokok *= 10;
                    Console.WriteLine("Gaji baru yang telah bernilai 10%: " + $"{pegawai.GajiPokok:C}");
                }
                Console.WriteLine($"Pendapatan: {pegawaiSekarang.pendapatan :C}\n");
            }
            for (int j = 0; j < pegawai.Count; j++)
            {
                Console.WriteLine($"Pegawai {j} is a {pegawai[j].GetTupe() }");
            }
        }
    }
}
