namespace CSProjeDemo2
{
    public class Yonetici : Personel
    {
        // Yonetici'nin saatlik ucreti 500 den kucuk olamaz
        private const decimal MIN_HOURLY_RATE = 500m;

        public Yonetici(string name)
        {
            Name = name;
            Title = "Yonetici";
        }

        // Maaş hesaplama işlemi
        public override decimal MaasHesapla(decimal hourlyRate, int workingHours, decimal Bonus)
        {
            // Saatlik ücret kontrolü
            if (hourlyRate < MIN_HOURLY_RATE)
                throw new ArgumentException($"Yöneticinin saatlik ücreti {MIN_HOURLY_RATE} TL'den küçük olamaz.");

            // Ana maaş hesaplama
            decimal Salary = hourlyRate * workingHours;

            // Bonus eklenerek toplam ödeme hesaplanır
            return Salary + Bonus;
        }
    }
}
