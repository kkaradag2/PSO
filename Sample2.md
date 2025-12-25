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

$`


