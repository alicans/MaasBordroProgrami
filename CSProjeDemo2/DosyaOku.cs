using System.Text.Json;

namespace CSProjeDemo2
{
    public class DosyaOku
    {
        // Personel listesi
        private static List<Personel> personelListesi = new List<Personel>();

        public DosyaOku()
        {
            // Personel listesini oluştur
            personelListesi = new List<Personel>();
        }

        /// <summary>
        /// Personel listesini json dosyasından okur ve getMaasBilgileri fonksiyonunu kullanarak maaş bilgilerini arayüzden alır.
        /// </summary>
        /// <param name="jsonDosyaYolu">Personel listesi json dosyasının yolu </param>
        /// <param name="getMaasBilgileri">Maaş bilgilerini arayüzden alacak fonksiyon </param>
        /// <returns>Personel listesi </returns>
        public static List<Personel> PersonelListesiniYukle(string jsonDosyaYolu, Func<string, string, (decimal hourlyRate, int workingHours, decimal bonus, int derece)> getMaasBilgileri)
        {
            // hata denetimi
            if (!File.Exists(jsonDosyaYolu))
            {
                throw new FileNotFoundException($"Personel listesi dosyası bulunamadı: {jsonDosyaYolu}");
            }

            try
            {
                // json dosyasını oku
                string jsonString = File.ReadAllText(jsonDosyaYolu);
                var personelData = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(jsonString);

                // eğer personel verisi varsa
                if (personelData != null)
                {
                    foreach (var personel in personelData)
                    {
                        // eğer personel yönetici ise maaş bilgilerini al
                        if (personel["title"] == "Yonetici")
                        {
                            // maaş bilgilerini program.cs'den işleyerek getir
                            var maasBilgileri = getMaasBilgileri(personel["name"], personel["title"]);

                            // yöneticiyi listeye ekle
                            personelListesi.Add(
                                new Yonetici(personel["name"])
                                {
                                    HourlyRate = maasBilgileri.hourlyRate,
                                    WorkingHours = maasBilgileri.workingHours,
                                    Bonus = maasBilgileri.bonus
                                }
                            );
                        }
                        else if (personel["title"] == "Memur")
                        {
                            // maaş bilgilerini program.cs'den işleyerek getir
                            var maasBilgileri = getMaasBilgileri(personel["name"], personel["title"]);

                            // memuru listeye ekle
                            personelListesi.Add(
                                new Memur(personel["name"])
                                {
                                    HourlyRate = maasBilgileri.hourlyRate,
                                    WorkingHours = maasBilgileri.workingHours,
                                    Bonus = maasBilgileri.bonus,
                                    Derece = maasBilgileri.derece
                                }
                            );
                        }
                    }
                }
                // personel listesini geri döndür
                return personelListesi;
            }
            catch (Exception)
            {
                throw new Exception("Personel listesi dosyası okunurken bir hata oluştu.");
            }


        }
    }
}
