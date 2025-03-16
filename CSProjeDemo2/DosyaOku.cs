using System.Text.Json;

namespace CSProjeDemo2
{
    class DosyaOku
    {
        // Personel listesi
        private List<Personel> personelListesi;

        public DosyaOku()
        {
            personelListesi = new List<Personel>();
        }

        // Json dosyasından personel listesini yükle
        public void PersonelListesiniYukle(string jsonDosyaYolu)
        {
            string jsonString = File.ReadAllText(jsonDosyaYolu);
            var personelData = JsonSerializer.Deserialize<List<Dictionary<string, string>>>(jsonString);

            if (personelData != null)
            {
                foreach (var personel in personelData)
                {
                    if (personel["title"] == "Yonetici")
                        personelListesi.Add(new Yonetici(personel["name"]));
                    else if (personel["title"] == "Memur")
                        personelListesi.Add(new Memur(personel["name"]));
                }
            }
        }
    }
}
