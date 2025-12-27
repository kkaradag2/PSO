# Particle Swarm Optimization (PSO)

Particle Swarm Optimization (PSO), doğadaki kuş ve balık sürülerinin yiyecek arama ve yön bulma davranışlarından esinlenilerek geliştirilmiş, popülasyon tabanlı bir optimizasyon algoritmasıdır. Algoritma, 1995 yılında James Kennedy ve Russell Eberhart tarafından önerilmiştir.

PSO’nun temel fikri, çözüm uzayında hareket eden parçacıkların hem kendi deneyimlerinden (bireysel en iyi konum) hem de sürünün paylaşılan bilgisinden (global en iyi konum) faydalanarak daha iyi çözümlere yönelmesidir. Bu yaklaşım sayesinde algoritma, türev bilgisine ihtiyaç duymadan karmaşık ve doğrusal olmayan problemlerde etkili sonuçlar üretebilir.

İlerleyen yıllarda PSO modeli çeşitli geliştirmelerle zenginleştirilmiştir. Özellikle inertia weight (w), bireysel öğrenme katsayısı (c₁) ve sosyal öğrenme katsayısı (c₂) gibi parametreler tanımlanarak algoritmanın keşif (exploration) ve sömürü (exploitation) dengesi daha kontrollü hale getirilmiştir. Bu geliştirmeler, PSO’nun farklı problem türlerine uyarlanabilirliğini ve performansını artırmıştır. 

# Kullanım Alanları
Bir sayısal denklemin türevi alınarak bu denklemin eğitimi tespit edilebilir. Bu sayade verilecek parametrelerin büyüklükleri tespit edilerek yönün aşağı mı yukarımı çıkacağı bulunabilir. Bu yaklaşımı kullanan Gradient Descent, bir noktanın grafikteki eğimine bakarak aşağıya nasıl gidilebileceği bulabilir. Böylece o noktadan daha iyi bir noktaya (aşağıya) nasıl gidilebileceğini tespit edebilir. Bu yaklaşım, alan pürüzsüzse veya çok fazla girinti çıkıntı yoksa sistmei hızlıca sonuca ulaştırır. Ama yüzey çok bozuksa, dolayısyla çok fazla çukur ve çıkıntı varsa yanıltıcı sonuçlar üretebilir. Özetle Gradient Descent eğime güvenir.

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


**PSO Hız Güncelleme Formulü**

```math
\vec{v}_i^{(t+1)} = w\,\vec{v}_i^t
+ c_1 r_1\big(\vec{pBest}_i^t - \vec{x}_i^t\big)
+ c_2 r_2\big(\vec{gBest}^t - \vec{x}_i^t\big)
```


 **Intertia (Atalet)**
 Bu bileşen, parçacığın mevcut hareket yönünü ve hızını koruma eğilimidir. Altet ağırlığı adı verilen bu değişken ( w ) ile çarpılır. Bu bileşenin temel görevi, parçacığın aniden yön değiştirmesini engelleyerek arama uzayında daha genişalanaların taranmasını sağlamaktır. (Keşif/exploration)

 ```math
 w\,\vec{v}_i^t
 ```

 **Individual Component (Bireysel Bileşen)**
 Bu bileşen, parçacığın hendi geçmişinde ulaştığı en iyi konum (pBest) ile mevcut konumu arasındaki mesafeyi belirtir. Bu bileşen c1 katsayıs ile kontrol edilir.

 ```math
 c_1 r_1\big(\vec{pBest}_i^t - \vec{x}_i^t\big)

```
**Social Component (Sosyal Bileşen)** 
Bu bileşen, parçacığın mevcut konumu ile tüm sürünün şimdiye kadarki en iyi konumu {gBest} arasındaki mesafeyi hesaplar. Bu  da parçacıkların birbirleriyle iletişim kurması ve sürünün kollektif hareket etmesini sağlar Bu bileşen c2 katsayıs ile yönetilir.

```math
 c_2 r_2\big(\vec{gBest}^t - \vec{x}_i^t\big)
```

Bu formülle, parçacığın mevcut hızını kendi başarılarını ve arkadaşlarının başarısını bir araya getirerek bir vektör oluşturur.

## [Örnek Soru 1](Sample1.md)

## [Örnek Soru 2](Sample2.md)

## [Kod Dokümantasyonu](CodeDocumentation.md)

# Pseudo Code
```code
01. Initialize the Controlling Parameters(N, c1,c2, Wmin, Wmax, Vmax, MaxIter)
02. Initialize the population of N Particles
03. do
04.   for each Particles
05.       calculate the objective of the particle
06.       update pBEST if required
07.       update gBEST if required
08.   end for
09.   update the intertia weight
10.   for each Particles
11.       update the velocity(v)
12.       update the positiob(x)
13.   end for
14. while the end condition is not satisfied
15. return gBEST
```
