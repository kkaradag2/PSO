## Örnek-I
3 parçacıktan oluşan bir sürüde, $`f(x) = x^2 `$ amaç fonksyonu minimize edecek sonuca ulaşmak istiyoruz. Bu amaçla algoritmanın $`w=0.5`$, $`c_1=1`$ , $`c_2=1`$  ve $`r1=r2=1`$  değerleri ile iki iterasyon ilerletelim.

## Çözüm

### Başlangıç ($`t = 0`$)

$`t = 0`$ anında parçacıkların konumları rastgele belirlenir. Yani arazi üzerine rastgele dağıtılırlar. Parçaçıkların $`t = 0`$ anındaki hızlarıda 0' dır. Böylece;

- Parçacıkların başlangıç konumları: $`x_1^0 = 4, x_2^0 = -2`$ ve $`x_3^0 = 1`$ olarak rastgele atanır.
- Başlangıç anında parçaçıkların aynı ve $`v_1^0 =v_2^0 =v_3^0 = 0`$ dır.

Parçaların $`t = 0`$ anındaki konumları $`f(x)=x^2`$ amaç foksiyonuna x değeri olarak konularak sürünün en iyi konumu belirlenmeye çalışılır.

- $`x_1= 4`$ => $`f(x)=x^2`$ 'den $`f(4)=(4)^2 = 14`$
- $`x_2=-2`$ => $`f(x)=x^2`$ 'den $`f(-2)=(-2)^2 = 4`$
- $`x_1= 4`$ => $`f(x)=x^2`$ 'den $`f(1)=(1)^2 = 1`$

Bu sonuçlara göre en düşük değer $`f(1)= 1`$ değeridir. Bu değeri algoritmanın $`gBest`$ değerine yani sürünün en iyi konum değerine  $`gBest=1`$ olarak atıyoruz. Artık hiz formulümüzü kullanarak parçacıkların bir sonraki an için hızlarını ve konumlarını belirleyebiliriz. Çünkü $`\vec{v}_i^{(t+1)} = w\,\vec{v}_i^t + c_1 r_1\big(\vec{pBest}_i^t - \vec{x}_i^t\big) + c_2 r_2\big(\vec{gBest}^t - \vec{x}_i^t\big)`$ formülde kullanılmak üzere $`\vec{gBest}`$, ve $`\vec{pBest}`$ değerleri elimizde artık mevcut. Buradan;
&nbsp;
&nbsp;
&nbsp;
- $`t=0`$ için $`\vec{v}_i^{(t+1)}`$ değeri $`\vec{v}_i^{(0+1)}`$ dan $`\vec{v}_i^1`$ olacaktır.
- Böylece parçaçığın $`t=1`$ değeri için hızını, hız değişim formülünden hesaplayabiliriz.
- Aynı şekilde parçaçığın $`t=1`$ anın için konumu $`x_i^{t+1} = x_i^t + \vec{v}_i^{t+1}`$ formülünden hesaplayabiliriz.
- $`w=0.5`$, $`c_1=1`$ , $`c_2=1`$  ve $`r1=r2=1`$ olarak soruda verilmişti.
- Artık elimizde $`\vec{gBest}`$, ve $`\vec{pBest}`$ değerleri de mevcut. 
&nbsp;
&nbsp;

**Parçacık-1**

- $`t=1`$ anı için hız, $`\vec{v}_1^{(1)} = (0.5).(0) +(1).(1).(4-4) + (1).(1).(1-4) = -3`$ 
- $`t=1`$ anı için konum, $`x_1^{1} =4 + (-3) = 1`$  olarak hesaplanır.

**Parçacık 2**

- $`t=1`$ anı için hız, $`\vec{v}_2^{(1)} = (0.5).(0) +(1).(1).(-2-(-2)) + (1).(1).(1-(-2)) = 3`$ 
- $`t=1`$ anı için konum, $`x_2^{1} = -2 + 3= 1`$  olarak hesaplanır.

**Parçacık 3**

- $`t=1`$ anı için hız, $`\vec{v}_3^{(1)} = (0.5).(0) +(1).(1).(1-1) + (1).(1).(1-1) = 0`$ 
- $`t=1`$ anı için konum, $`x_3^{1} = 1-1= 0`$  olarak hesaplanır.

Buradan;

$`t=1`$  anı için yeni bulunan $`x`$ değerleri $`f(x)=x^2`$ amaç fonyonuna konularak sürünün yeni $`gBest`$  değeri hesaplanır:

- $`x_1^1 = 1`$ için  $`f(x)=x^2`$ ise $`f(1)=1^2= 1`$
- $`x_2^1 = 1`$ için  $`f(x)=x^2`$ ise $`f(1)=1^2= 1`$
- $`x_3^1 = 1`$ için  $`f(x)=x^2`$ ise $`f(1)=1^2 =1`$ 

Bu hesaplama sonucunda tüm parçacıklar aynı noktada olduğundan birinin en iyi değerini $`gBest = 1`$ olarak atıyoruz.

**Iterasyon 1 ($`t=2`$)**

 Halen parçacıklar aynı konumda yanı 1 konumundalar ama artık hepsinin farklı bir hızı var. Bu nedenle $`t=2`$ hesaplamalarında farklı $`x`$ değerleri görmeye başlayacağız.

**Parçacık-1**

- $`t=1`$ anı için hız, $`\vec{v}_1^{(2)} = (0.5).(-3) +(1).(1).(1-1) + (1).(1).(1-1) = -1.5`$ 
- $`t=1`$ anı için konum, $`x_1^{2} = 1 + (-1.5) = 0.5`$  olarak hesaplanır.

**Parçacık 2**

- $`t=1`$ anı için hız, $`\vec{v}_2^{(2)} = (0.5).(3) +(1).(1).(1-1) + (1).(1).(1-1) = 1.5`$ 
- $`t=1`$ anı için konum, $`x_2^{2} = 1 + 1.5 = 2.5`$  olarak hesaplanır.

**Parçacık 3**

- $`t=1`$ anı için hız, $`\vec{v}_3^{(2)} = (0.5).(0) +(1).(1).(1-1) + (1).(1).(1-1) = 0`$ 
- $`t=1`$ anı için konum, $`x_3^{2} = 1 +0 = 1`$  olarak hesaplanır.

&nbsp;
Buradan;
&nbsp;
$`t=2`$  anı için yeni bulunan $`x`$ değerleri $`f(x)=x^2`$ amaç fonyonuna konularak sürünün yeni $`gBest`$  değeri hesaplanır:

- $`x_1^2 = 0.5`$ için  $`f(x)=x^2`$ ise $`f(0.5)=(0.5)^2= 0.25`$
- $`x_2^2 = 2.5`$ için  $`f(x)=x^2`$ ise $`f(2.5)=(2.5)^2= 6.25`$
- $`x_3^2 = 1`$ için  $`f(x)=x^2`$ ise $`f(1)=1^2 =1`$ 

&nbsp;
bu durumda $`gBest= 0.25`$ olur. Sonuç olarak $`t=0$` anından $`t=2$ anına kadar olan değişim aşağıdaki tablodaki gibi özetlenebilir

| Zaman (t) | Parçacık | Konum $`(x_i^t)`$ | Hız $`x_i^t`$ |  $`f(x_i^t)`$ | pBest_i | gBest |
|-----------|----------|---------------|-------------|----------|---------|-------|
| 0 | 1 | 4    | 0    | 16   | 4   | 1 |
| 0 | 2 | -2   | 0    | 4    | -2  | 1 |
| 0 | 3 | 1    | 0    | 1    | 1   | 1 |
| 1 | 1 | 1    | -3   | 1    | 4   | 1 |
| 1 | 2 | 1    | 3    | 1    | -2  | 1 |
| 1 | 3 | 1    | 0    | 1    | 1   | 1 |
| 2 | 1 | 2.5  | 1.5  | 6.25 | 4   | 0.25 |
| 2 | 2 | -0.5 | -1.5 | 0.25 | -2  | 0.25 |
| 2 | 3 | 1    | 0    | 1    | 1   | 0.25 |

<img width="557" height="412" alt="PSO_Soru_1" src="https://github.com/user-attachments/assets/83766dff-b30d-45be-ac1b-1f4326022471" />

[Geri Dön](README.md)

