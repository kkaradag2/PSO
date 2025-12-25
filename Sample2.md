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
- $`W(x) = 




**Amaç:** Kapasiteyi aşmadan toplam değeri en üst düzeye çıkaracak ürünleri seçmek.
