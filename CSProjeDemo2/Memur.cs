namespace CSProjeDemo2
{
    public class Memur : Personel
    {
        // Memurun saatlik ücreti varsayılan olarak 500 TL'dir. Fakat memurun derecesine göre değişebilir olmalıdır.
        private const decimal DEFAULT_HOURLY_RATE = 500m;
        // Memurların maaşı maksimum 180 saatten hesaplanır.
        private const int REGULAR_HOURS_LIMIT = 180;
        // 180 saati geçen her çalışma süresi normal saatlik ücretin 1.5 katı bedelle belirlenerek ek mesai ücreti olarak ana maaşa eklenir.
        private const decimal OVERTIME_RATE_MULTIPLIER = 1.5m;

        public int Derece { get; set; } = 1;
        public decimal SaatlikUcret { get; private set; } = DEFAULT_HOURLY_RATE;

        public Memur(string name, int derece = 1)
        {
            Name = name;
            Title = "Memur";
            Derece = derece;
            UpdateHourlyRate();
        }

        // Derecesine göre saatlik ücreti günceller
        public void UpdateHourlyRate()
        {
            // Derece arttıkça saatlik ücret de artacak şekilde hesaplama
            SaatlikUcret = DEFAULT_HOURLY_RATE + ((Derece - 1) * 50m);
        }

        public override decimal MaasHesapla(decimal hourlyRate, int workingHours, decimal Bonus)
        {
            // Eğer parametre olarak gelen hourlyRate 0'dan büyükse onu kullan,
            // değilse sınıfın kendi SaatlikUcret değerini kullan
            decimal actualHourlyRate = hourlyRate > 0 ? hourlyRate : SaatlikUcret;

            decimal normalMaas;
            decimal mesaiUcreti = 0;

            if (workingHours <= REGULAR_HOURS_LIMIT)
            {
                normalMaas = workingHours * actualHourlyRate;
            }
            else
            {
                normalMaas = REGULAR_HOURS_LIMIT * actualHourlyRate;
                int mesaiSaati = workingHours - REGULAR_HOURS_LIMIT;
                mesaiUcreti = mesaiSaati * actualHourlyRate * OVERTIME_RATE_MULTIPLIER;
            }

            return normalMaas + mesaiUcreti;
        }
    }
}
