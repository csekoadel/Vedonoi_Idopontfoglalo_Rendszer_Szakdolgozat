# Védőnői időpontfoglaló rendszer

A frontend a `ClientApp/src` mappában található (Angular). A backend a `Context`, `Controllers`, `Migrations` és `Models` mappákban van (ASP.NET Core 8, Entity Framework Core).

Az adatbázis SQLite, így nincs szükség külön adatbázisszerverre. A migrációs fájlok a `Migrations` mappában vannak, az adatbázis létrehozása:

```bash
dotnet ef database update
```

Új migráció készítése:

```bash
dotnet ef migrations add <MigracioNeve>
```

Indítás:

```bash
dotnet run
```

Az adatbázis (`idopontfoglalo.db`) bármilyen SQLite-kezelővel megnyitható, például a DB Browser for SQLite programmal.