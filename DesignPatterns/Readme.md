## Yaratýcý Tasarým Desenleri
### Abstract Factory
- Soyut Fabrika tasarým deseni, somut sýnýflarýný belirtmeden ilgili veya baðýmlý nesnelerin ailelerini oluþturmak için bir arayüz saðlar.
### Builder
- Oluþturucu tasarým deseni, ayný yapým sürecinin farklý temsiller oluþturabilmesi için karmaþýk bir nesnenin yapýmýný temsilinden ayýrýr.
### Factory Method
- Fabrika Yöntemi tasarým deseni, bir nesne oluþturmak için bir arabirim tanýmlar, ancak alt sýnýflarýn hangi sýnýfýn baþlatýlacaðýna karar vermesine izin verir. Bu model, bir sýnýfýn somutlaþtýrmayý alt sýnýflara ertelemesine izin verir.
### Prototype
- Prototip tasarým deseni, prototipik bir örnek kullanarak oluþturulacak nesne türlerini ve bu prototipi kopyalayarak yeni nesneler oluþturmayý belirtir.
### Singleton
- Singleton tasarým deseni, bir sýnýfýn yalnýzca bir örneðe sahip olmasýný saðlar ve buna global bir eriþim noktasý saðlar.
#### Abstract Factory vs Builder
- Builder þablonu karmaþýk bir nesneyi adým adým oluþturmaya odaklanýr. Abstract Factory þablonu ise benzer ürün ailelerini karmaþýk veya basit farketmeksizin oluþturmak için kullanýlýr
- Builder þablonu ürünü son adýmda kullanýcýya teslim ederken Abstract Factory þablonu anýnda ürünü verir.
#### Abstract Factory vs Factory Method
- Fabrika olarak düþünürsek, Factory DP sadece tek bir ürünün üretildiði fabrika, Abstract Factory DP ise farklý farklý ürünlerin üretildiði fabrika olarak düþünebiliriz.