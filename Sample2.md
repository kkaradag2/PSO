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
c) Parçacık $`P_2`$ için sigmoid bit güncellemelerini yaparak $`X_2^1`$ possiyonlarını bulun.
d)  $`X^(1)_2`$ için  $`W(X), Val(X), f(X), pBest`$ ve $`gBest`$ değerlerini tekrar hesaplayın.

