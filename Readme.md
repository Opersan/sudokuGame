# Yazılım Mühendisliğinde Güncel Konular Vize Projesi
## Projeye Genel Bakış
Yazılım Mühendisliğinde Güncel konular dersinin vize projesinde sudoku oyununu mobil platform üzerinde geliştirmeyi amaçladım. Yoklama sırasında 50.sıradayım ve 50.kart görseli aşağıda eklidir.
Bahsi geçen mobil uygulama için geliştirme ortamını Unity ve C# olarak belirledim. Uygulama 9x9 boyutunda tablolardan oluşan bir bulmaca oyunu ve depremzede çocuklar için
eğlenceli bir oyun olmayı amaçlıyor. Uygulamanın ipucu, geri alma, duraklatılabilme, bir sayaç, ana menüye dönebilme, zorlukların seçilebilmesi, not alabilme gibi özellikleri barındırmasını amaçlıyorum.


![](19.png) <br>

## Sudoku Tanıtımı
Sudoku, rakamlardan oluşan bir mantık bulmaca oyunudur. Bunu çözmek için konsantre olmanız ve aynı zamanda mantıksal düşünmeyi kullanmalısınız. Sudoku'nun zorluğu, başlangıçta doldurulmuş olan hücrelerin sayısına ve bunu çözmek için kullanılması gereken yöntemlere bağlıdır. Düzenli Sudoku oynamak hafızayı, mental netliği geliştirir ve beyin hücrelerinin yaşlanmasını azaltır.
## Oyunun Kuralları
Oynama alanı, kenarda 3 hücre ile küçük karelere bölünmüş 9x9 karedir. Oyunun amacı, her bir sırada, her bir sütunda ve her bir küçük 3 × 3 karede her numara sadece bir kez yer alacak şekilde boş hücreleri 1'den 9'a kadar rakamlarla doldurmaktır.

Oyunun başında hücrelerin bazıları zaten doludur.<br>

![](1.png) <br>

Bir hücreye rakam eklemeden önce hücreyi aşağıdaki kurallara göre inceleyin:

1. Rakam her bir satırda sadece bir kez yer alabilir.

![](2.png) <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Yanlış

![](3.png) <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Doğru

2. Rakam her bir sütunda sadece bir kez yer alabilir. <br>
![](4.png) &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
![](5.png)  <br>
   &nbsp;&nbsp;&nbsp;&nbsp;Yanlış&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Doğru <br>

3. Rakam her bir küçük 3×3 karede sadece bir kez bulunabilir. <br>
![](6.png) &nbsp;&nbsp;&nbsp;
![](7.png) <br>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Yanlış&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Doğru

# Çözüm Yöntemi

İlk olarak mümkün olduğunca çok sayıda rakamın açık olduğu küçük bir kare seçin. Not modunu kullamamrak her bir boş hücreye rakam adaylarını girip yukarıda açıkladığımız kuralları hesaba katarak hangi rakamların orada olabileceğini veya olamayacağını analiz edin. Sonuç olarak bu seçeneği elde etmelisiniz:
<br>

![](8.png) <br>

Burada bir hücrede tek bir rakam adayı olduğunu görüyoruz. Çözüm olarak girilebilir:
<br>![](9.png)

6 girdikten sonra diğer hücrelerden kaldırılır ve böylece sadece bir rakam adayı olduğunda yeni seçenekler açılabilir. Bu durumda, 4 rakamını gireriz:
Yine tek bir rakam adayımız var: 1 ve 3 giriyoruz: <br>

![](10.png)

Ve küçük karenin tamamı doldurulmuş oldu. <br>

![](11.png) <br>

Yukarıda, her bir seferinde tek bir rakam adayımız olan ideal bir durumu göz önünde bulundurduk ancak daha karmaşık düzenlerde hiçbir hücrede tek bir rakam adayı olmayan durumlar olabilir. Böyle bir durumda, diğer küçük karelere giderek her birine tüm rakam adaylarını gir. Ve daha sonra bitişik küçük karelerde rakam adaylarının nasıl durduğuna dikkat ederek eleme yöntemiyle ilerleyin.

![](12.png) <br>

Tüm hücreleri rakam adaylarıyla dolduruyoruz. Daha sonra, tek bir adayı olan her bir hücre için rakamları girin.

![](13.png) <br> 

Tebrikler, Sudoku'yu çözdünüz! Şimdi zihninizi eğitmeyi deneyin ve not modunu kullanmayın, tüm rakam adaylarını akılda tutun, hafızanızı ve mantığınızı kullanın!

## Bazı Belirsiz Butonların Açıklaması ve Sınırlamaların Tanıtımı
Oyun başına tam olarak **3 adet** yanlış yapma hakkınız vardır. Bu haklar dolduğunda oyun biter ve süreniz görüntülenir.

![](14.png) &nbsp;&nbsp;&nbsp; ![](15.png)

Aşağıdaki görseli bulunan buton size **3 adet** ipucu hakkı sunar. Haklarınız dolduğunda soluk ve tıklanamaz bir butona
dönüşücektir.

![](16.png)

Alt taraftaki butonların işlevi sırasıyla; Anamenü, Sil, Not Ekle ve Duraklat.
![](17.png)

Ek olarak not almak istediğiniz buton aktif olduğunda maviye dönüşmektedir.

![](18.png)

# Proje İle İlgili Belge ve Çizelgeler
## Zaman Çizelgesi Belgesi

![](20.png)

## Programcı Kılavuzu Dökümanı ve Diyagramlar

Aşağıda sırasıyla UML sınıf diyagramlarının ekran görüntülerini paylaşıyorum. İlk ekran görüntüsünde tüm sistemin
birbiriyle olan ilişkileri belirtilirken, 2. fotoğraf ana sistem olan sudokunun ana mantığıyla ilgili iken, 3.fotoğraf
menü butonları ve 4.fotoğraf ise oyun olayları hakkındaki ilişkileri belirtmektedir.

![](24.png)

![](21.png)

![](22.png)

![](23.png)




