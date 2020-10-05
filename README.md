![.NET Core](https://github.com/GustinAG/trending-command-service/workflows/.NET%20Core/badge.svg)  ![Master docker-compose build](https://github.com/GustinAG/trending-command-service/workflows/Master%20docker-compose%20build/badge.svg)

# trending-command-service
Trending CQRS Sample - Command microservice

---
## Goal of This
Demontsrating these architecture paterns within working code in a very simplified way.
This might help better understand them.

On the other hand, with the help of this sample code, you will ***not*** see the complictions that come with a huge, complex project.

---
## What You Need for This
 + Visual Studio 2019 - *or higher* - incl.:
    + C# stuff
    + .NET Core 3.1
    + Markdown Editor
 + Docker Desktop with Linux containers
 + Also recommended:
    + ReSharper
    + TortoiseGit
    + Notepad++ including XML Tools

---
## How This Was Created
&rarr; [HowCreated.md](HowCreated.md)

## How To...
### Start & Stop MongoDB
```powershell
docker-compose -f .\docker-compose.dev.storage.yml up -d
docker ps
docker-compose -f .\docker-compose.dev.storage.yml down
```

### Run Unit & Integration Tests
1. Start MongoDB
2. Visual Studio &rarr; **`TrendingCommandService`** solution **&#9655; Run Unit Tests**

### Start
0. **docker-compose** &rarr; Set as Startup Project
1. Start MongoDB
1. `docker stop Trending.Command.Api` - azért, hogy ne akadjon össze vele
1. Visual Studio: **&#9655; Docker Compose**
 2. &rarr; http://localhost:32780 <br />
    &rarr; http://localhost:32780/swagger

### Look Around In MongoDB
```powershell
docker ps
docker exec -it trending-command-service_mongodb_1 bash
```
<center> &darr; </center>

```Bash
mongo
```

<center> &darr; </center>

```SQL
show dbs
use trendingevents
db.articleevents.find()
db.articleevents.find().sort({ $natural: 1 })
```

---
## Architecture Patterns <br /> <small> *covered in this sample* </small>
 + **C**ommand **Q**uery **R**esponsibility **S**egragation
 + **I**nversion **o**f **C**ontrol / **D**ependency **I**njection
 + Repository

### See Also
 + &rarr; [CQRS *(Fowler)*](https://martinfowler.com/bliki/CQRS.html)
 + &rarr; [Inversion of Control Containers and the Dependency Injection pattern *(Fowler)*](https://martinfowler.com/articles/injection.html)
