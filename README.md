# Particle Swarm Optimization (PSO)
Particle Swarm Optimization (PSO), doğadaki kuş ve balık sürülerinin yiyecek aramak veya bir yerden başka bir yere göç etmek için uyguladıkları yöntemleri taklit ederek oluşturulmuş stokastik bir algotitmadır. 1990'ların başında James Kennedy (Sosyal pisikolog) ve Russell Eberhart(Elektirik Mühendisi) adlı iki bilim insanının kuş ve balık sürülerinin davranışlarını bir matematik modelel olarak ortaya koyma çlaışmalarına dayanır. Kennedy ve Eberhart , 1995 yılında bu davranış modelinin, sayısal problemlerde çözüm olarak kullanılabileceğini fark ederek yayınladıkları "Partical Swarm Optimization" - 1995, IEEE makelesiyle bilim dünyasına duyurulmuştur.

1998 - 2002 arasında modellerine, inertia weight (w), bireysel (c₁) ve sosyal (c₂) terimleri eklenerek yaklaşma davranışı kontrol altına alarak modeli daha da olgunlaştırmışlardır.

# Kullanım Alanları
Bir sayısal denklemin türevi alınarak bu denklemin eğitimi tespit edilebilir. Bu sayade verilecek paremetlerlerin büyüklükleri tespit edilerek yönün aşağı mı yukarımı çıkacağı bulunabilir. Bu yaklaşımı kullanan Gradient Descent, bir noktanın grafikteki eğimine bakarak aşağıya nasıl gidilebileceği bulabilir. Böylece o noktadan daha iyi bir noktaya (aşağıya) nasıl gidilebileceğini tespit edebilir. Bu yaklaşım, alan pürüzsüzse veya çok fazla girinti çıkıntı yoksa sistmei hızlıca sonuca ulaştırır. Ama yüzey çok bozuksa, dolayısyla çok fazla çukur ve çıkıntı varsa yanıltıcı sonuçlar üretebilir. Özetle Gradient Descent eğime güvenir.

PSO ise eğime güvenmez bunun yerine birden fazla noktaya aynı anda parçacıkları sayesinde gezer. Hangi parçacık iyi bir konum bulduysa diğerlerine haber vererek tüm sürünün yavaş yavaş o noktaya kaymasını sağlar. Bu yaklaşımı ile türevi alınamayan veya alınsa bile çok karmaşık yüzeylerin yada çok paremetreli sistmelerin çözümünde etkili bir çözüm sunar.

## Dron Örneği
Bir arama kurtarma bölgesi düşünün. Bu alan çok büyük, inişlerin çıkışların çok fazla olduğu , görüş mesafesinin yer yer farklılaştığı zor bir arazi olsun. Böyle bir arazide tek bir dron ile arama yapan Gradient Descent algoritması şöyle davranır;
- Dron zemine bakar
- Eğimi hesaplar
- Aşağıya doğru giden bir yön bulur ve gider.

Bu durumda dron daha alçak bir noktaya ilerlemiş olsa bile bu yer arazideki en alçak yer olmayabilir. Bu probleme local optima sorun da denilir.




 