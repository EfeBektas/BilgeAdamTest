BilgeAdamTest – Test Otomasyon Projesi

Bu proje, BilgeAdam Teknoloji teknik değerlendirme çalışması kapsamında hazırlanmıştır.
Test otomasyon çalışmaları https://www.saucedemo.com/ üzerinde yürütülmüştür.

Kullanılan Teknolojiler

.NET 8
C#
Selenium WebDriver
NUnit
GitHub Actions (CI)
JSON Configuration
Page Object Model (POM)

Proje Yapısı
BilgeAdamTest/
Config/                  
Drivers/                 
Pages/                  
Tests/                    
Utilities/                
TestData/                  
.github/workflows/         

Kurulum
git clone https://github.com/EfeBektas/BilgeAdamTest.git
cd BilgeAdamTest
dotnet restore

Konfigürasyon

Config/configTxt.json:
{
  "baseUrl": "https://www.saucedemo.com/",
  "username": "standard_user",
  "password": "secret_sauce",
  "browser": "chrome"
}

Testleri Çalıştırma

Standart çalıştırma:
dotnet test

Paralel Test Çalıştırma
Proje, paralel test yürütmeyi destekleyecek şekilde yapılandırılmıştır.
4 iş parçacığında paralel çalıştırmak için:
dotnet test -- NUnit.NumberOfTestWorkers=4

GitHub Actions Pipeline
.github/workflows/ci.yml dosyasında bulunan pipeline:
.NET 8 kurar
Bağımlılıkları yükler
Testleri çalıştırır
Push ve Pull Request işlemlerinde otomatik tetiklenir

Senaryo Özeti
1. Giriş / Oturum Güvenliği
Geçerli bilgilerle başarılı giriş
Hatalı giriş doğrulamaları
Yetkisiz sayfa erişim kontrolü

2. Veri Güdümlü Test (DDT)
Ürünlerin JSON'dan okunması
Üç ürünün sepete eklenmesi
Sepet doğrulamaları

3. Uçtan Uca Sipariş Akışı
Checkout adımları
Vergi (Tax) ve Total hesaplama kontrolü
Sipariş tamamlama doğrulaması
Sipariş sonrası tekrar ürün ekleme senaryosu

Özel Bekleme Mekanizması
Proje, standart WebDriver beklemeleri dışında özel bir bekleme sınıfı içerir:
CustomWait.WaitForUrlToBe(driver, "inventory.html");
Zaman aşımında özel bir istisna üretilir:
WaitTimeoutException
