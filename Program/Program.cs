/*
 Küçük bir şirketin maaş bordrolarını oluşturan bir uygulama oluşturalım. Şirketimize yazılacak olan maaş bordro program en az iki tipte (Yonetici ve Memur) personeline maaşlarını hesaplamak, kayıt altına almak ve raporlama işlemlerine sahip olmalıdır. Ayrıca projemize daha sonradan oluşabilecek yeni personel kadroları dahilinde genişletilebilir olmalıdır.


Beklenen İşlevler:
• Her personelin maaş hesabı saatlik ücret * çalışma saati bilgileri doğrultusunda hesaplanır.
• Yoneticinin saatlik ucreti 500 den kucuk olamaz ve her her yoneticiye maaş dışında bonus adlı ek bir ödeme alır.
• Memurların maaşı maksimum 180 saat den hesaplanır. 180 saati geçen her çalışma süresi normal saatlik ücretin 1.5 katı bedelle belirlenerek ek mesai ücreti olarak ana maaşa eklenir.
• Memurun saatlik ücreti varsayılan olarak 500 TL dir. Fakat memurun derecesine göre değişebilir olmalıdır.
• Memur ve Yonetici listesi bir json dosyası olarak verilecektir. Program maaş hesaplamaya .json dosyasından okuma yaparak sırasıyla personelin maaş bilgilerinin girişi yapılmasını isteyecektir.

Örnek Json Dosyası:

{
"name": "fatih alkan"
"title": Yonetici},
{
"name": "mehmet arslan"
"title": "Memur",
},


Hesaplanan maaş bilgileri her personelin adına açılan klasörün içersine maaş tarih bilgisiyle birlikte .json formatında kayıt edilecektir.

Örnek Json Dosyası:
Maas Bordro, SUBAT 2020
{
"Personel Ismi": "Beyazıt",
"Calisma Saati": 200,
"Ana Odeme": "₺9.000,00",
"Mesai": "₺1.000,00"
"Toplam Odeme": "₺10.000,00"
}

• Program sonunda maaş hesabı yapılan tüm personelin rapor görüntüsünün ekrana yazdırılmasını ve ayrıca 150 saat az çalışan personellerin bilgilerinin belirtilmesi gerekmektedir.
 

 */

namespace CSProjeDemo2
{
    class Program
    {
        static void Main(string[] args)
        {
            Yonetici Ali = new Yonetici("Ali");
            Yonetici Veli = new Yonetici("Veli");

            Memur Ahmet = new Memur("Ahmet"); // 1. derece memur
            Memur Mehmet = new Memur("Mehmet", 2); // 2. derece memur

            Console.WriteLine(Ali);


        }
    }
}
