# PSO Knapsack (0–1) — Binary Particle Swarm Optimization

Kısa açıklama
- Bu proje, 0–1 Knapsack problemini Binary Particle Swarm Optimization (PSO) ile çözen basit, deneysel bir C# uygulamasıdır.
- Hedef: .NET 9, Visual Studio 2022 uyumlu.

Gereksinimler
- .NET 9 SDK
- Visual Studio 2022 veya `dotnet` komut satırı

Hızlı başlatma
- Visual Studio'da çözümü açın ve __Debug > Start Debugging__ veya __Ctrl+F5__ ile çalıştırın.
- CLI: proje klasöründe çalıştırın:
  - `dotnet run` (proje dizinindeyken)

Ana dosyalar
- `Program.cs` — Öğe seti, kapasite ve PSO yapılandırmasını barındırır; uygulama buradan başlar.
- `Models\BinaryPSO.cs` — PSO algoritmasının tamamı (pozisyon/hız güncelleme, repair, logging, early-stop).
- `Models\Particle.cs` — Particle veri yapısı (`Position`, `Velocity`, `BestPosition`, `BestFitness`).
- `Models\Item.cs` — Öğe model (`Weight`, `Value`).

Kullanım / Parametreler
- `BinaryPSO` yapıcısı (özet):
  - `List<Item> items, int capacity`
  - `int swarmSize` — parçacık sayısı (ör. 50–200).
  - `int maxIter` — maksimum iterasyon.
  - `double inertia (w), double cognitive (c1), double social (c2)` — PSO parametreleri.
  - `bool enableLogging` — loglamayı aktif eder.
  - `int[] debugParticles` — detaylı loglanacak particle indeksleri (0-tabanlı). Boş dizi ile sadece özet loglayın.
  - `int maxLoggedIterations` — kaç iterasyonu loglamak istersiniz.
  - `int earlyStopPatience` — gBest son iyileşmeden sonra kaç iterasyon beklenir (early-stop).

Logging hakkında
- `enableLogging: true` ile konsolda detaylı bilgi alınır:
  - Seçilen partiküllerin başlangıç pozisyonu/hızı, güncellenen hız/pozisyon, repair sonucu, weight ve fitness.
  - İterasyon özeti olarak `gBestFitness`, `gBestWeight` ve `gBestPosition`.
- Tüm partikülleri değil, sadece `debugParticles` içindekileri loglayın; çok fazla çıktı performansı düşürür.
- Özet log için `debugParticles = new int[0]` ve `maxLoggedIterations = N` kullanabilirsiniz.

Early stop (erken durma)
- `earlyStopPatience` parametresi eklendi.
- Eğer ardışık `earlyStopPatience` iterasyonda `gBest` iyileşmezse döngü kırılır.
- Kullanışlı örnek: `earlyStopPatience: 10` → son 10 iterasyonda gelişme yoksa dur.

Çıktı / Sonucun alınması
- En iyi çözüm `GetBestSolution()` ile alınır: `(int[] Position, int TotalValue, int TotalWeight)`.
- Ek bilgiler: `BinaryPSO.BestFoundAtIteration` ve `BinaryPSO.IterationsRun` — hangi iterasyonda en iyi bulunduğu ve kaç iterasyon çalıştırıldığı.

Kod yapısı (kısa)
- `InitializeSwarm()` — rastgele başlangıç, repair, kişisel/global best hesaplama.
- `Run()` — iterasyon döngüsü; velocity/position güncelleme, repair, evaluate, personal/global best güncelleme, logging, early-stop.
- `Repair(int[] position)` — kapasiteyi aşan çözümleri düzeltiyor (value/weight oranına göre çıkarma).
- `Sigmoid(double x)` — binary PSO pozisyon güncellemesi için kullanılıyor.

İpuçları / tuning
- Daha güvenilir sonuç: `swarmSize` artırın ama performans düşer.
- `w` (inertia) yüksekse arama daha geniş, düşükse yerel arama hakim olur. Genelde 0.6–0.9 arası deneyin.
- `c1` ve `c2` eşit veya benzer değerde tutulabilir (örn. 1.4–1.6).
- `earlyStopPatience` ile gereksiz uzun çalıştırmaları engelleyebilirsiniz.

Örnek: Program ayarı (özet)
- `Program.cs` içinde `BinaryPSO` oluşturma örneği:
  - `enableLogging: true, debugParticles: new int[] {0,1}, maxLoggedIterations: 1, earlyStopPatience: 10`


<img width="557" height="412" alt="PSO_Soru_1" src="https://github.com/user-attachments/assets/83766dff-b30d-45be-ac1b-1f4326022471" />
