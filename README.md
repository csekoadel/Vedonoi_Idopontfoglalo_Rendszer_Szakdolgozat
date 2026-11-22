# Védőnői időpontfoglaló rendszer

A frontend a `ClientApp/src` mappában található (Angular). A backend a `Context`, `Controllers`, `Migrations` és `Models` mappákban van (ASP.NET Core 8, Entity Framework Core).

Az adatbázis SQLite, így nincs szükség külön adatbázisszerverre.

## Indítás

**1. Adatbázis létrehozása** (első indítás előtt kötelező):

```bash
dotnet tool install --global dotnet-ef
dotnet ef database update
```

**2. Frontend csomagok telepítése:**

```bash
cd ClientApp
npm ci
cd ..
```

**3. Indítás:**

```bash
dotnet run
```

Ezután: http://localhost:5000 (az első indítás kb. 1 percig tart).

## Fejlesztés

Új migráció készítése:

```bash
dotnet ef migrations add <MigracioNeve>
```

Az adatbázis (`idopontfoglalo.db`) bármilyen SQLite-kezelővel megnyitható, például a DB Browser for SQLite programmal.