# Mikroservis .NET Projesi

Projenin geliştirilmesinde aşağıdaki teknolojiler ve mimari desenlere ağırlık verilmiştir:  

- Mikroservis Mimarisi  
- CQRS (Command Query Responsibility Segregation)  
- MediatR  
- Repository Design Pattern  
- Onion Architecture  
- Redis  
- Docker  
- Ocelot API Gateway  

---

## Kullanılan Teknolojiler ve Mimari Yaklaşımlar

### 🔹 Mikroservis Mimarisi
Mikroservis, uygulamayı küçük, bağımsız ve birbiriyle haberleşebilen servislerden oluşacak şekilde tasarlama yaklaşımıdır.  
- Servisler birbirinden bağımsız ölçeklenebilir.  
- Daha esnek ve bakımı kolay bir yapı sağlanır.  
- Farklı servisler farklı teknolojiler ile geliştirilebilir.  

---

### 🔹 CQRS (Command Query Responsibility Segregation)
CQRS, **okuma (Query)** ve **yazma (Command)** işlemlerini birbirinden ayıran bir mimari yaklaşımdır.  
- Komutlar (Command) sistemi değiştirmek için kullanılır.  
- Sorgular (Query) veriyi okumak için kullanılır.  
Bu ayrım performans, ölçeklenebilirlik ve sistemin daha anlaşılır olmasını sağlar.  

---

### 🔹 MediatR
MediatR, .NET projelerinde **Mediator Design Pattern** uygulamak için kullanılan bir kütüphanedir.  
- Katmanlar arasındaki bağımlılığı azaltır.  
- Command ve Query işlemleri tek bir merkezden yönetilir.  
- Kodun daha okunabilir ve sürdürülebilir olmasını sağlar.  

---

### 🔹 Repository Design Pattern
Repository, veri erişim katmanını soyutlamak için kullanılan bir tasarım desenidir.  
- Veritabanı erişim kodları tek bir noktada toplanır.  
- Kod tekrarını önler.  
- Daha kolay test edilebilir bir yapı sağlar.  

---

### 🔹 Onion Architecture
Onion Architecture, **bağımlılıkları merkeze yönlendiren** katmanlı bir mimaridir.  
- Merkezde domain (iş kuralları) bulunur.  
- Uygulama katmanları bu çekirdeğe bağımlıdır, ancak çekirdek dış katmanlara bağımlı değildir.  
- Bu sayede esneklik, test edilebilirlik ve sürdürülebilirlik artar.  

---

### 🔹 Redis
Redis, bellek tabanlı bir veri yapısı deposudur.  
- Cache (önbellekleme) amaçlı kullanılır.  
- Yüksek performans ve düşük gecikme süresi sağlar.  
- Dağıtık sistemlerde veri paylaşımı için idealdir.  

---

### 🔹 Docker
Docker, uygulamaları container teknolojisi ile izole bir ortamda çalıştırmayı sağlar.  
- Uygulamanın her ortamda aynı şekilde çalışmasını garanti eder.  
- Hızlı dağıtım ve ölçeklenebilirlik sunar.  
- Mikroservis yapıları için olmazsa olmaz bir teknolojidir.  

---

### 🔹 Ocelot API Gateway
Ocelot, mikroservisler için kullanılan bir **API Gateway** kütüphanesidir.  
- Dış dünyadan gelen istekleri ilgili mikroservise yönlendirir.  
- Routing, authentication, load balancing gibi işlevleri kolayca yönetir.  
- Mikroservislerin dışarıya tek bir kapıdan açılmasını sağlar.  

---
