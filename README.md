# 🧱 BaseProject - Clean Architecture en .NET

Este proyecto sigue los principios de **Clean Architecture** para separar responsabilidades, facilitar el mantenimiento, pruebas unitarias y escalabilidad.

---

## 📁 Estructura de carpetas

```plaintext
📦 Solution "BaseProject"
├── Api                  → Capa de presentación (Web API)
│   ├── Controllers      → Endpoints HTTP (ej: ProductoController)
│   ├── Middlewares      → Middleware globales (manejo de errores, logging)
│   
│
├── Application          → Lógica de negocio y casos de uso
│   ├── Common           → Respuestas genéricas, clases utilitarias
│   ├── UseCases         → Comandos/Casos de uso agrupados por funcionalidad
│   │   └── ProductoCreate
│   │       ├── Handler, Request, Validator
│
├── Domain               → Modelo de dominio (núcleo de la aplicación)
│   ├── Entities         → Entidades puras (sin dependencias)
│   ├── Enums            → Enumeraciones del dominio
│   ├── Exceptions       → Errores de lógica de negocio
│   └── Interfaces       → Repositorios o servicios que implementa Infrastructure
│
├── Infrastructure       → Acceso a datos, servicios externos, configuración
│   ├── Configuration    → EF Core configurations (IEntityTypeConfiguration)
│   ├── Persistence      → Repositorios, DbContext
│   └── Services         → Servicios como Email, FileStorage, etc.
```

---

## 🔁 Flujo de una solicitud típica

1. **API** recibe el request en un controlador
2. Se envía un `Request` al **caso de uso** correspondiente
3. El handler en `Application` ejecuta la lógica
4. El handler llama a interfaces del dominio (como repositorios)
5. **Infrastructure** implementa los repositorios y ejecuta operaciones reales

---

## 📦 Tecnologías

- ASP.NET Core
- Entity Framework Core
- FluentValidation


---

## ✅ Buenas prácticas usadas

- Separación de capas (SRP - Principio de responsabilidad única)
- Inversión de dependencias mediante interfaces
- Validaciones desacopladas
- Arquitectura preparada para testing

---


## ✨ Contribuciones

Este proyecto puede servir como base para cualquier sistema orientado a dominios, DDD o arquitectura limpia.

---


