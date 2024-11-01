## TheCoderPage

TheCoderPage, yazılım geliştiricilerin karşılaştıkları sorunları paylaşarak çözüm bulmalarına olanak tanıyan etkileşimli bir platformdur. Kullanıcılar, problemlerini paylaşabilir, diğer geliştiricilerle etkileşimde bulunarak çözüm arayışına girebilir ve kişisel profilleri üzerinden etkinliklerini yönetebilirler. Platform, kullanıcıların paylaşımlarını kategoriler halinde yapmasına, diğer kullanıcılarla fikir alışverişinde bulunmasına ve katkı sağlamasına olanak tanır.

- **Amaç**: TheCoderPage, yazılım geliştiricilerin karşılaştıkları sorunları ve çözümlerini paylaşabileceği bir ortam sunmayı amaçlar.
- **Hedef Kitle**: Sorunlarına çözüm arayan yazılım geliştiriciler.

### 1. Gereksinimler

#### 1.1 Teknik Gereksinimler:
- .NET MVC Core
- Entity Framework Core (veritabanı etkileşimleri için)
- SQL Server
- UI için Bootstrap gibi ön yüz çerçeveleri

#### 1.2 Kullanıcı Gereksinimleri:
- Kullanıcı kaydı ve kimlik doğrulama
- Sorun paylaşma ve yorum yapma

### 2. Kullanıcı Rolleri

#### 2.1 Normal Kullanıcılar:
- Kendi sorunlarını oluşturma, görüntüleme ve yönetme
- Diğer kullanıcıların sorunlarına yorum yapma ve beğenme

#### 2.2 Admin Kullanıcılar:
- Kullanıcıları, problemleri, yorumları, şikayetleri ve kategorileri yönetme

### 3. Özellikler

#### 3.1 Kullanıcı Sayfası:
- **Anasayfa**: Sorunların listelendiği başlangıç sayfası
- **Problem Detay Sayfası**: Sorunun açıklaması, çözümler ve yorumları içerir
- **Problem Oluşturma Formu**: Yeni sorun paylaşmak için bir form
- **Profil Yönetimi**: Kişisel bilgileri güncelleme ve gönderilen sorunları takip etme

#### 3.2 Admin Sayfası:
- **Kontrol Paneli**: İstatistiklerin yer aldığı bir panel
- **Yönetim**: Problemleri, yorumları, kullanıcıları, kategorileri ve şikayetleri yönetme

### 4. Kullanıcı Özellikleri

- **Kayıt ve Profil Yönetimi**: Kullanıcılar, kaydolduktan sonra profil oluşturabilir, profil resmi ekleyebilir ve bilgilerini düzenleyebilirler.
- **Problem Paylaşımı ve Etkileşim**: Kendi problemlerini kategori seçerek paylaşabilir, beğenebilir, yorum yapabilir ve şikayet edebilirler.
- **Problem Listesi**: Kullanıcılar, platformdaki problemleri listeleyebilir ve ilgi alanlarına göre arama yapabilir.
- **Problem Detayı**: Detay sayfasında açıklamalar, çözümler ve kullanıcı yorumları yer alır. Burada beğeni, yorum ve rapor seçenekleri sunulur.
- **Kendi Problemlerini Yönetme**: Kullanıcılar, paylaştıkları problemleri görebilir, “Çözümlendi” olarak işaretleyebilir veya silebilirler.

### 5. Admin Paneli Özellikleri

Admin paneli, admin rolüne sahip kullanıcılara platformun yönetim işlevlerini yerine getirme yetkisi verir:
- **İstatistik ve Kontrol Paneli**: Platformun genel durumu ve analizleri grafik ve istatistikler ile görüntülenebilir.
- **Kullanıcı ve İçerik Yönetimi**: Kullanıcılar, problemler, yorumlar ve kategoriler üzerinde oluşturma, okuma, güncelleme ve silme işlemleri yapılabilir.
- **Şikayet Yönetimi**: Problemler için yapılan şikayetleri inceleme ve gerekli işlemleri gerçekleştirme.

--- 

Bu açıklama, TheCoderPage platformunu tanıtmak ve genel işlevlerini özetlemek amacıyla hazırlanmıştır.
