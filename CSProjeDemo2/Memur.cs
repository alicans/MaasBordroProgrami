namespace CSProjeDemo2
{
    public class Memur : Personel
    {
        // Memurun saatlik ücreti varsayılan olarak 500 TL'dir. Fakat memurun derecesine göre değişebilir olmalıdır.
        private const int DEFAULT_HOURLY_RATE = 500;
        // Memurların maaşı maksimum 180 saatten hesaplanır.
        private const int REGULAR_HOURS_LIMIT = 180;
        // 180 saati geçen her çalışma süresi normal saatlik ücretin 1.5 katı bedelle belirlenerek ek mesai ücreti olarak ana maaşa eklenir.
        private const decimal OVERTIME_RATE_MULTIPLIER = 1.5m;

        public int Derece { get; set; } = 1;

        public Memur(string name, int derece = 0)
        {
            Name = name;
            Title = "Memur";
            Derece = derece;
        }

        /// <summary>
        /// Memur maaşını hesaplayan metot.
        /// </summary>
        /// <param name="hourlyRate">Saatlik ücret </param>
        /// <param name="workingHours">Çalışma saati </param>
        /// <param name="Bonus">Bonus Ek Ödeme</param>
        /// <returns>Toplam maaş</returns>
        public override decimal MaasHesapla(decimal hourlyRate, int workingHours, decimal Bonus)
        {
            int SaatlikUcret = DEFAULT_HOURLY_RATE;

            // eğer derece 0'dan büyükse saatlik ücreti güncelle
            if (Derece > 0)
            {
                // Her derece için saatlik ücret tanımlaması
                SaatlikUcret = Derece switch
                {
                    5 => 550, // 5. derece memur için saatlik ücret 550 TL
                    4 => 600, // 4. derece memur için saatlik ücret 600 TL
                    3 => 650, // 3. derece memur için saatlik ücret 650 TL
                    2 => 700, // 2. derece memur için saatlik ücret 700 TL
                    1 => 750, // 1. derece memur için saatlik ücret 750 TL
                    _ => DEFAULT_HOURLY_RATE // Tanımsız derece için varsayılan ücret
                };
            }

            // Eğer parametre olarak gelen hourlyRate 0'dan büyükse onu kullan,
            // değilse sınıfın kendi DEFAULT_HOURLY_RATE değerini kullan
            decimal actualHourlyRate = hourlyRate > 0 ? SaatlikUcret : DEFAULT_HOURLY_RATE;

            decimal actualSalary;
            decimal mesaiUcreti = 0;

            // eğer çalışma saati 180 saatten az ise normal saatlik ücret üzerinden maaş hesapla
            if (workingHours <= REGULAR_HOURS_LIMIT)
            {
                actualSalary = workingHours * actualHourlyRate;
            }
            // eğer çalışma saati 180 saatten fazla ise 180 saate kadar olan kısmı normal saatlik ücret üzerinden,
            // 180 saatten fazla olan kısmı ise normal saatlik ücretin 1.5 katı üzerinden maaş hesapla
            else
            {
                actualSalary = REGULAR_HOURS_LIMIT * actualHourlyRate; // 180 saate kadar olan kısım
                int fazlaMesaiSaati = workingHours - REGULAR_HOURS_LIMIT; // 180 saatten fazla olan kısmı bul
                mesaiUcreti = fazlaMesaiSaati * actualHourlyRate * OVERTIME_RATE_MULTIPLIER; // 180'den fazla olan kısmı 1.5 katı ile çarp
            }

            return actualSalary + mesaiUcreti + Bonus;
        }

        public override string ToString()
        {
            return $"Personel Adı: {Name}, Ünvanı: {Title}, Derecesi: {Derece}";
        }
    }
}
