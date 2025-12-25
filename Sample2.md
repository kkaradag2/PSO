# Örnek Soru 2
## 0–1 Knapsack Problemine PSO Yaklaşımları

Kapasite $`W=7`$ olan bir 0-1 Knapsac problemi için malzemeleirn ağırlıkları ve değerleri aşağıdaki gibidir.

| Malzeme | $`W_i`$ | $`V_i`$ |
|---------|---------|--------|
| 1 | 2 | 6 |  
| 2 | 3 | 9 |  
| 3 | 4 | 12|
| 4 | 1 | 4 |  

- Fitness Fonksyonu :  $`f(x)=Val(x)- λ.max(0, W(x)- W)`$ olarak verilmiş ve λ=5 dir.
- Paremetreler      :  $`w=0.5`$ ,  $`c1=2`$,  $`c2=2`$,  $`r1=0.4`$,  $`r2=0.7`$
- Particle (solution) representation : $`X =(x1,x2,x3,x4), xi ∈ {0,1}`$
- $`W(x) = \sum_{i=1}^4 w_i x_i`$
- $`Val(x) = \sum_{i=1}^4 w_i V_i`$
- Amaç: Kapasiteyi aşmadan toplam değeri en üst düzeye çıkaracak ürünleri seçmek.

  **Başlangıç Değerleri:**
- $`P_1:  X_1 = (1, 0, 1, 1)`$
- $`P_2:  X_2 = (0, 1, 1, 0)`$
- $`P_3:  X_3 = (1, 1, 0, 0)`$

a) Başlangıç posisyonları için $`W(X), Val(X), f(X), pBest`$ ve $`gBest`$ değerlerini hesapla.
b) Parçacık $`P_2`$ için velocity $`V_2`$ değerlerini iterasyon-1 de hesaplayın.
c) Parçacık $`P_2`$ için sigmoid bit güncellemelerini yaparak $`x_2^1$  posisyonlarını hesaplayın.
d) $`x_2^1$  için  $`W(X), Val(X), f(X), pBest`$ ve $`gBest`$ değerlerini tekrar hesaplayın.

## Cevaplar

a) Başlangıç değerleri için 

| Parçacık | $`X_i`$      | $`W(x)`$    | $`Val(x)`$  | $`f(x)`$       | $`pBest`$       |
|----------|--------------|-------------|-------------|----------------|-----------------------|
| $`P_1`$  | $`X_1`$=(1, 0, 1, 1) | 2+0+4+1 = 7 | 6+0+12+4=22 | $`22-5.max(0,(7-7)) = 22-0=22`$|(1, 0, 1, 1)|
| $`P_2`$  | $`X_2`$=(0, 1, 1, 0) | 0+3+4+0 = 7 | 0+9+12+0=21 | $`21-5.max(0,(7-7)) = 21-0=21`$|(0, 1, 1, 0) |
| $`P_3`$  | $`X_3`$=(1, 1, 0, 0) | 0+3+4+0 = 5 | 2+2+0+0=15 | $`15-5.max(0,(5-7)) = 15-0=15`$|(1, 1, 0, 0)|

en iyi değer  $`P_1`$ için $`f(x_1)`$ = 22 olduğundan  $`gBest=22`$  

b) $`P_2`$ parçaığının başlangıç anında hızı 0 dır. Bunun için $`V_2^0=(0,0,0,0)`$ olarak gösterilir. $`P_2`$ parçaçığının tüm bitlerine sigmoit-bir uygulayarak t=1 anı için hızlarını ve buradan yeni possiyonlarını bulabiliriz.

 $`\vec{v}_{ij}^{(t+1)} = w\,\vec{v}_i^t + c_1 r_1\big(\vec{pBest}_{ij}^t - \vec{x}_{ij}^t\big) + c_2 r_2\big(\vec{gBest}^t - \vec{x}_{ij}^t\big)`$ formulunde her bir bit için yanı  $`X_2`$=(0, 1, 1, 0) 'nin tüm elemanlarını j indeksindeki değerini alıp fonsyonda yerien koyacağız.

 - j=1 => $`\vec{v}_{21}^{(1)} = w\,\vec{v}_2^0 + c_1 r_1\big(\vec{pBest}_{21}^0 - \vec{x}_{21}^0\big) + c_2 r_2\big(\vec{gBest}^0 - \vec{x}_{21}^t\big)`$= $`0.5.0+2.0.4(0-0)+2.0.7(1-0) = 0+0+1.4 = 1.4`$

$`S(v_{21}^{(1)})=\frac{1}{1+e^{-1.4}} = 0.80`$  ise $`u_1=0.3 < 0.80 => x_{21}^1=1`$

 - j=2 => $`\vec{v}_{22}^{(1)} = w\,\vec{v}_2^0 + c_1 r_1\big(\vec{pBest}_{22}^0 - \vec{x}_{22}^0\big) + c_2 r_2\big(\vec{gBest}^0 - \vec{x}_{22}^t\big)`$= $`0.5.0+2.0.4(1-1)+2.0.7(0-1) = 0+0-1.4 = -1.4`$

$`S(v_{22}^{(1)})=\frac{1}{1+e^{1.4}} = 0.19`$  ise $`u_2=0.8 > 0.19 => x_{22}^1=0`$

 - j=3 => $`\vec{v}_{23}^{(1)} = w\,\vec{v}_2^0 + c_1 r_1\big(\vec{pBest}_{23}^0 - \vec{x}_{23}^0\big) + c_2 r_2\big(\vec{gBest}^0 - \vec{x}_{23}^t\big)`$= $`0.5.0+2.0.4(0)+2.0.7(1-1) = 0`$

$`S(v_{23}^{(1)})=\frac{1}{1+e^{0}} = 0.5`$  ise $`u_3=0.4 < 0.5 => x_{23}^1=1`$


 - j=4 => $`\vec{v}_{24}^{(1)} = w\,\vec{v}_2^0 + c_1 r_1\big(\vec{pBest}_{24}^0 - \vec{x}_{24}^0\big) + c_2 r_2\big(\vec{gBest}^0 - \vec{x}_{24}^t\big)`$= $`0.5.0+2.0.4(0)+2.0.7(1-0) = 1.4`$

$`S(v_{23}^{(1)})=\frac{1}{1+e^{-1.4}} = 0.80`$  ise $`u_4=0.6 < 0.8 => x_{24}^1=1`$

Bu durumda $`X_2^{(1)}`$=(1, 0, 1, 1) olarak hesaplanır.



