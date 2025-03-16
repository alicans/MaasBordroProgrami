namespace CSProjeDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            // personel listesini initialize et
            List<Personel> personeller = new List<Personel>();
            // personel listesini json dosyasından oku ve maaş bilgilerini al
            personeller = DosyaOku.PersonelListesiniYukle("personel.json", GetMaasBilgileri);

            // her personel için maaş bordrosu oluştur
            foreach (var personel in personeller)
            {
                MaasBordro.BordroKaydet(personel, "Subat 2020");
            }

            // bordro raporunu göster
            MaasBordro.BordroRaporuGoster(personeller, "Subat 2020");



        }

        /// <summary>
        /// Maaş bilgilerini arayüzden alır.
        /// </summary>
        /// <param name="name">Personel adı </param>
        /// <param name="title">Personel ünvanı </param>
        /// <returns>saatlik ücret, çalışma saati, bonus ek ödeme, derece</returns>
        static (decimal hourlyRate, int workingHours, decimal bonus, int derece) GetMaasBilgileri(string name, string title)
        {
            Console.WriteLine(name + " için maaş bilgilerini giriniz:");

            // saatlik ücret bilgisini al
            decimal hourlyRate;
            while (true)
            {
                Console.Write("Saatlik ücret: ");
                string input = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Boş değer girilemez. Lütfen bir sayı giriniz.");
                    continue;
                }

                if (!decimal.TryParse(input, out hourlyRate))
                {
                    Console.WriteLine("Geçersiz değer. Lütfen sayısal bir değer giriniz.");
                    continue;
                }

                if (hourlyRate < 500)
                {
                    Console.WriteLine("Saatlik ücret 500'den küçük olamaz. Tekrar deneyin.");
                    continue;
                }
                break;
            }

            // çalışma saati bilgisini al
            int workingHours;
            while (true)
            {
                Console.Write("Çalışma saati: ");
                string input = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Boş değer girilemez. Lütfen bir sayı giriniz.");
                    continue;
                }

                if (!int.TryParse(input, out workingHours) || workingHours < 0)
                {
                    Console.WriteLine("Geçersiz değer. Lütfen pozitif bir tam sayı giriniz.");
                    continue;
                }
                break;
            }

            // bonus bilgisini al
            decimal bonus;
            while (true)
            {
                Console.Write("Bonus: ");
                string input = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Boş değer girilemez. Lütfen bir sayı giriniz.");
                    continue;
                }

                if (!decimal.TryParse(input, out bonus) || bonus < 0)
                {
                    Console.WriteLine("Geçersiz değer. Lütfen pozitif bir sayı giriniz.");
                    continue;
                }
                break;
            }

            int derece = 0;
            if (title == "Memur")
            {
                // derece bilgisini al

                while (true)
                {
                    Console.Write("Derece: ");
                    string input = Console.ReadLine() ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Boş değer girilemez. Lütfen bir sayı giriniz.");
                        continue;
                    }

                    if (!int.TryParse(input, out derece))
                    {
                        Console.WriteLine("Geçersiz değer. Lütfen sayısal bir değer giriniz.");
                        continue;
                    }

                    break;
                }
            }

            return (hourlyRate, workingHours, bonus, derece);
        }
    }
}
