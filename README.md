# GLogic Catálogo UI

Cliente web del catálogo de ropa, desarrollado con ASP.NET Core sobre .NET 8. Este proyecto complementa la API disponible en `GLogic-CatalogoAPI`.

## Tecnologías

- .NET 8 y ASP.NET Core
- C#
- Razor Pages y servicios de aplicación

## Estructura

```text
CatalogoRopaUI/
├── Interfaces/   # Contratos del cliente
├── Models/       # Modelos de presentación
├── Pages/        # Vistas y páginas de la aplicación
├── Services/     # Integración y lógica de cliente
├── Program.cs    # Configuración del host
└── appsettings.json
```

## Requisitos

- .NET SDK 8
- La API del catálogo disponible para las operaciones que consuman datos remotos.

## Ejecutar localmente

```bash
dotnet restore
dotnet run --project CatalogoRopaUI/CatalogoRopaUI.csproj
```

Abre la URL local mostrada por la consola al iniciar la aplicación.

## Configuración

Revisa `CatalogoRopaUI/appsettings.json` antes de ejecutar el proyecto y define allí —o mediante variables de entorno— las URLs y valores específicos de tu entorno. No publiques secretos ni credenciales.

## Relación con la API

Este repositorio contiene la interfaz del catálogo. Para el backend y la documentación de los endpoints, consulta [GLogic-CatalogoAPI](https://github.com/JonnathanMR/GLogic-CatalogoAPI).
