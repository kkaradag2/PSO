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

##Örnek-I
3 parçacıktan oluşan bir sürüde, aşağıda verilen amaç fonksyonun minimize edilmesi isteniyor.
```math
f(x) = x^2 
```
w=0.5, c1=1, c2=1 ve r1=r2=1 olmak üzere başlangıç anında parçacıklar sırayla 4, -2 ve 1 konumundalar. Bu verilenlerle PSO algoritmasını iki iterasyon ilerletelim.

## Çözüm

### Başlangıç (t = 0)

- Parçacıkların başlangıç (t = 0) anındaki konumları. Genellikle rastgele verilir.

```math
\begin{aligned}
x_1^0 &= 4 \\
x_2^0 &= -2 \\
x_3^0 &= 1
\end{aligned}
```

- Parçacıkların başlangıç (t = 0) anındaki hızları. Başlangıç anında tüm parçacıkların hızı 0’dır.

```math
\begin{aligned}
v_1^0 &= 0 \\
v_2^0 &= 0 \\
v_3^0 &= 0
\end{aligned}
```

Bu değerleri amaç fonksiyonu

```math
f(x) = x^2
```

içinde yerine koyduğumuzda:

```math
x_1 = 4 \Rightarrow f(4) = 4^2 = 16
```

```math
x_2 = -2 \Rightarrow f(-2) = (-2)^2 = 4
```

```math
x_3 = 1 \Rightarrow f(1) = 1^2 = 1
```

değerleri elde edilir. Bu değerler arasında en küçük değer **1** olduğu için, sürünün en iyi konumu gBest = 1 olarak belirlenir.
Tüm parçaların bir sonraki hareket için posiyon ve hızlarını hesaplayabilemek için elimizde artık GBest değeri var.

```math
\vec{v}_i^{(t+1)} = w\,\vec{v}_i^t
+ c_1 r_1\big(\vec{pBest}_i^t - \vec{x}_i^t\big)
+ c_2 r_2\big(\vec{gBest}^t - \vec{x}_i^t\big)
```

formulunu kullanarak tüm parçaıklar için hız ve pozisyonaları hesaplayacağız;

**Parçacık 1**

```math
\vec{v}_1^{(0+1)} = \vec{v}_1^{(1)} 
```
ile 1 parçacığın t=1 anındaki hızını hesaplalım

```math
\vec{v}_1^{(1)} = (0.5).(0) +(1).(1).(4-4) + (1).(1).(1-4) = -3
```

bu hıza bağlı olarak t=1 anında parçacığın yeni konumu 

```math
x_i^{t+1} = x_i^t + \vec{v}_i^{t+1}
```
forlumü kullanılarak hesaplanabililir.
```math
x_1^{1} =4 + (-3) = 1
```
**Parçacık 2**

```math
\vec{v}_2^{(1)} = (0.5).(0) +(1).(1).(-2-(-2)) + (1).(1).(1-(-2)) = 3
```
ve konumu;
```math
x_2^{1} = -2 + 3= 1
```

**Parçacık 3**

```math
\vec{v}_2^{(1)} = (0.5).(0) +(1).(1).(1-1)) + (1).(1).(1-1) = 0
```
ve konumu;
```math
x_2^{1} = 1 -0 = 1
```

t=1 anı için hesaplamalar sonucunda parçacıkların durumları amaç fonsyonda yerien konularak yeni gBest noktası bulunur.

```math
\begin{aligned}
x_1^1 = 1 , x_2^1 = 1 , x_3^1 = 1
\end{aligned}
```
```math
x_1^1 = 1 \Rightarrow f(1) = 1^2 = 1
```

```math
x_2^1 = 1 \Rightarrow f(1) = 1^2 = 1
```

```math
x_3^1 = 1 \Rightarrow f(1) = 1^2 = 1
```

Bu hesaplama sonucunda gBest = 1 olur.

**Iterasyon 1 (t=2)**
 Halen parçacıklar aynı konumda yanı 1 konumundalar ama artık hepsinin farklı bir hızı olduğıu için t=2 anı için farklı noktalara gitmeye başlayacaklar.

 **Parçacık 1**

```math
\vec{v}_1^{(2)} = (0.5).(-3) +(1).(1).(1-1) + (1).(1).(1-1) = -1.5
```

bu hıza bağlı olarak t=2 anında parçacığın yeni konumu 

```math
x_i^{t+1} = x_i^t + \vec{v}_i^{t+1}
```
forlumü kullanılarak hesaplanabililir.
```math
x_1^{2} = 1 + (-1.5) = 0.5
```
