# Maaş Bordro Uygulaması

Bu proje, küçük bir şirketin maaş bordrolarını oluşturan bir uygulamadır. Şirketin en az iki tipte (Yönetici ve Memur) personeline maaşlarını hesaplamak, kayıt altına almak ve raporlama işlemlerini gerçekleştirmek için tasarlanmıştır. Ayrıca, projeye daha sonradan oluşabilecek yeni personel kadroları dahilinde genişletilebilir.

## Özellikler

- Her personelin maaşı saatlik ücret * çalışma saati bilgileri doğrultusunda hesaplanır.
- Yöneticinin saatlik ücreti 500 TL'den küçük olamaz ve her yöneticiye maaş dışında bonus adlı ek bir ödeme yapılır.
- Memurların maaşı maksimum 180 saat üzerinden hesaplanır. 180 saati geçen her çalışma süresi normal saatlik ücretin 1.5 katı bedelle belirlenerek ek mesai ücreti olarak ana maaşa eklenir.
- Memurun saatlik ücreti varsayılan olarak 500 TL'dir. Fakat memurun derecesine göre değişebilir.
- Memur ve Yönetici listesi bir JSON dosyası olarak verilecektir. Program maaş hesaplamaya JSON dosyasından okuma yaparak sırasıyla personelin maaş bilgilerinin girişi yapılmasını isteyecektir.
- Hesaplanan maaş bilgileri her personelin adına açılan klasörün içerisine maaş tarih bilgisiyle birlikte JSON formatında kayıt edilecektir.
- Program sonunda maaş hesabı yapılan tüm personelin rapor görüntüsünün ekrana yazdırılması ve ayrıca 150 saatten az çalışan personellerin bilgilerinin belirtilmesi gerekmektedir.

## Katkıda Bulunma

Katkıda bulunmak isterseniz, lütfen bir pull request gönderin. Her türlü katkı ve geri bildirim memnuniyetle karşılanır.

## Lisans

Bu proje MIT Lisansı ile lisanslanmıştır. Daha fazla bilgi için `LICENSE` dosyasına bakın.
