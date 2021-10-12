using System;

namespace ConsoleApp3
{
    class Program
    {
        public class CommissionEmployee
        {
            public string namaDepan { get; }
            public string namaBelakang { get; }
            public string nomerKeamanan { get; }
            private decimal grossTerjual;
            private decimal persentaseKeuntungan;

            public GajiPegawai(string NamaDepan, string NamaBelakang, string NomerKeamanan, decimal grossTerjual, decimal PresentaseKeuntungan)
            {
                namaDepan = NamaDepan;
                namaBelakang = NamaBelakang;
                nomerKeamanan = NomerKeamanan;
                GrossTerjual = grossTerjual;
                PK = PresentaseKeuntungan;
                
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
            public decimal PK
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
                        value, $"{nameof(PK)} must be > 0 and < 1");
                    }
                    persentaseKeuntungan = value;
                }
            }
            public decimal pendapatan => persentaseKeuntungan * grossTerjual;

            public string ToString() => $"Bonus Pegawai: {namaDepan} {namaBelakang}\n" + $"Nomer Keamanan: {nomerKeamanan}\n" + $"Menjual Gross: { grossTerjual:C}\n" + $"Persentasi Keuntungan: { persentaseKeuntungan:F2}";
        }
        public class BasePlusCommissionEmployee : CommissionEmployee 
        {

            private decimal pendapatanDasar; // base salary per week
            public BasePlusCommissionEmployee(string NamaDepan, string NamaBelakang, string NomerKeamanan, decimal grossTerjual, decimal PresentaseKeuntungan, decimal pendapatanDasar) : base(NamaDepan, NamaBelakang, NomerKeamanan, grossTerjual, PresentaseKeuntungan)
            {
                PendapatanDasar = pendapatanDasar; // validates base salary
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
            public override decimal pendapatan() => pendapatanDasar + base.pendapatan();

            public override string ToString() => $"Pendapatan Dawsar{base.ToString}\nPendapatan Dasar : {PendapatanDasar:C}";
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
