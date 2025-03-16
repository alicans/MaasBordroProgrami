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

# Memur Dereceleri

Bu dosya, `Memur` sınıfının derecelerini ve her derecenin saatlik ücretini açıklamaktadır.

## Dereceler ve Saatlik Ücretler

`Memur` sınıfında, memurların derecelerine göre saatlik ücretleri değişmektedir. Aşağıda her derece için saatlik ücretler belirtilmiştir:

- **1. Derece**: Saatlik ücret 750 TL
- **2. Derece**: Saatlik ücret 700 TL
- **3. Derece**: Saatlik ücret 650 TL
- **4. Derece**: Saatlik ücret 600 TL
- **5. Derece**: Saatlik ücret 550 TL
- **Varsayılan Derece**: Saatlik ücret 500 TL (Derece belirtilmemişse veya tanımsızsa)

## Maaş Hesaplama

Memurların maaşı, çalışma saatlerine ve derecelerine göre hesaplanır. Hesaplama şu şekilde yapılır:

- **Normal Çalışma Saatleri**: Memurların maaşı maksimum 180 saat üzerinden hesaplanır.
- **Fazla Mesai**: 180 saati geçen her çalışma süresi, normal saatlik ücretin 1.5 katı bedelle belirlenerek ek mesai ücreti olarak ana maaşa eklenir.

### Örnek Hesaplama

- **1. Derece Memur**:
  - Saatlik Ücret: 750 TL
  - Çalışma Saati: 200 saat
  - Normal Maaş: 180 saat * 750 TL = 135,000 TL
  - Fazla Mesai: 20 saat * 750 TL * 1.5 = 22,500 TL
  - Toplam Maaş: 135,000 TL + 22,500 TL = 157,500 TL

- **Varsayılan Derece Memur**:
  - Saatlik Ücret: 500 TL
  - Çalışma Saati: 160 saat
  - Normal Maaş: 160 saat * 500 TL = 80,000 TL
  - Fazla Mesai: Yok
  - Toplam Maaş: 80,000 TL

## Notlar

- Memurun derecesi belirtilmemişse veya tanımsızsa, varsayılan saatlik ücret 500 TL olarak alınır.
- Memurların maaş hesaplamasında bonus ek ödemeler de dikkate alınır.

Bu bilgiler, `Memur` sınıfının maaş hesaplama mantığını ve derecelerine göre saatlik ücretlerini açıklamaktadır.

## Katkıda Bulunma

Katkıda bulunmak isterseniz, lütfen bir pull request gönderin. Her türlü katkı ve geri bildirim memnuniyetle karşılanır.

## Lisans

Bu proje MIT Lisansı ile lisanslanmıştır. Daha fazla bilgi için `LICENSE` dosyasına bakın.
