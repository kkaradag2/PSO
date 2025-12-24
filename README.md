# Particle Swarm Optimization (PSO)
Particle Swarm Optimization (PSO), doğadaki kuş ve balık sürülerinin yiyecek aramak veya bir yerden başka bir yere göç etmek için uyguladıkları yöntemleri taklit ederek oluşturulmuş stokastik bir algotitmadır. 1990'ların başında James Kennedy (Sosyal pisikolog) ve Russell Eberhart(Elektirik Mühendisi) adlı iki bilim insanının kuş ve balık sürülerinin davranışlarını bir matematik modelel olarak ortaya koyma çlaışmalarına dayanır. Kennedy ve Eberhart , 1995 yılında bu davranış modelinin, sayısal problemlerde çözüm olarak kullanılabileceğini fark ederek yayınladıkları "Partical Swarm Optimization" - 1995, IEEE makelesiyle bilim dünyasına duyurulmuştur.

1998 - 2002 arasında modellerine, inertia weight (w), bireysel (c₁) ve sosyal (c₂) terimleri eklenerek yaklaşma davranışı kontrol altına alarak modeli daha da olgunlaştırmışlardır.

# Kullanım Alanları
Bir sayısal denklemin türevi alınarak bu denklemin eğitimi tespit edilebilir. Bu sayade verilecek paremetlerlerin büyüklükleri tespit edilerek yönün aşağı mı yukarımı çıkacağı bulunabilir. Bu yaklaşımı kullanan Gradient Descent, bir noktanın grafikteki eğimine bakarak aşağıya nasıl gidilebileceği bulabilir. Böylece o noktadan daha iyi bir noktaya (aşağıya) nasıl gidilebileceğini tespit edebilir. Bu yaklaşım, alan pürüzsüzse veya çok fazla girinti çıkıntı yoksa sistmei hızlıca sonuca ulaştırır. Ama yüzey çok bozuksa, dolayısyla çok fazla çukur ve çıkıntı varsa yanıltıcı sonuçlar üretebilir. Özetle Gradient Descent eğime güvenir.

PSO ise eğime güvenmez bunun yerine birden fazla noktaya aynı anda parçacıkları sayesinde gezer. Hangi parçacık iyi bir konum bulduysa diğerlerine haber vererek tüm sürünün yavaş yavaş o noktaya kaymasını sağlar. Bu yaklaşımı ile türevi alınamayan veya alınsa bile çok karmaşık yüzeylerin yada çok paremetreli sistmelerin çözümünde etkili bir çözüm sunar.

## Dron Örneği
Bir arama kurtarma bölgesi düşünün. Bu alan çok büyük, inişlerin çıkışların çok fazla , görüş mesafesinin yer yer farklı olan zor bir arazi. Böyle bir arazide tek bir dron ile arama yapan Gradient Descent algoritması şöyle davranır;
- Dron zemine bakar
- Eğimi hesaplar
- Aşağıya doğru giden bir yön bulur ve gider.

Bu durumda dron daha alçak bir noktaya ilerlemiş olsa bile bu yer arazideki en alçak yer olmayabilir. Dron ileride daha iyi bir konumun olduğunu bilemez.BU durumu aşmak için farklı uygulamalar, iyilaştirmeler vardır.

PSO algoritması ise bu arazide şöyel davranır. N tane dron aynı anda havalanır. Hepsi Farklı yerlere gider ve her bir dron şunu yapar;
- Bulunduğum yerde konum iyi mi ?
- Daha önce gittiğim yerler arasında en iyi hangisi?
- Diğer dronlardan biri benden daha iyi bir yerde mi ?

Bir dron herkezden daha iyi bir konum bulduğunda diğerleri o yöne doğru yavaş yavaş kaymaya başlar. Bu kayma yavaş yavaş olur ve tüm sürü birden bire aynı noktaya toplanmaz. Böylece, algortma keşif/sömürü dengesini kurmuş olur. Tüm sürü aynı anda en iyi olan noktaya gitmeyerek yol üzeirndeki olası daha iyi konumu sürüye bildirme şansını kaybetmezler ama yavaş yavaş aynı noktaya kayarak tüm parçacıkların en iyi yer egelmesini sağlarlar.

#Hız Denklemi
Dron sürüsü örneğinde, her dronun aynı and ahavandığını ve farklı yönlere gittiklerinden bahsettik. Peki dronlar farklı yönlere nasıl dağılırlar. İlk başlangıçtadronlar aynı anda havalandığı için hepsi aynı hızda yanı 0 olacaklardır. Hız denklemi parçacıkların mevcut konumlarına göre yeni hızlarını hesaplayıp dronların hızı değiştiğinde doğal olarak aralarındaki mesafe farklılaşacaktır.

PSO algoritmasında bir parcacığun bir sonraki adımda nereye gideceğini belirleyen hızdenklemi (velocity equation), üç temel bileşenden oluşur. Bu bileşenler, parçacığın hem kendi geçmişine hemde sürünün(sosyal) bilgisine daynarak hareket etmesini sağlar.


$$
v_i(t+1) = w\,v_i(t)
+ c_1 r_1 \big(pBest_i - x_i(t)\big)
+ c_2 r_2 \big(gBest - x_i(t)\big)
$$


**The Cauchy-Schwarz Inequality**

```math
\left( \sum_{k=1}^n a_k b_k \right)^2 \leq \left( \sum_{k=1}^n a_k^2 \right) \left( \sum_{k=1}^n b_k^2 \right)
```

 