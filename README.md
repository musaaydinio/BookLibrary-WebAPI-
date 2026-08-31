# 📚 Library Management System Web API (N-Tier Architecture)

## 🎯 About The Project
This project is a fundamental building block in the backend development journey. This API was built by actively following the **BTK Akademi** training course, while simultaneously integrating custom features, extensions, and architectural improvements to push the project far beyond a standard tutorial output. 

Industry-standard mechanisms for API security, performance, and scalability were successfully integrated. This repository served as the architectural blueprint and discipline that was subsequently used to build the completely independent, self-developed 
**[E-Commerce Web API Project](https://github.com/musaaydinio/PC-Components-AP)**.

## 🏗️ Architectural Layers
To maximize maintainability and ensure loose coupling, the project is strictly separated into four distinct layers:
*   **Entities:** Domain models, Data Transfer Objects (DTOs), custom Exceptions, and Link models.
*   **Repository:** The Data Access layer utilizing Entity Framework Core and implementing the Repository Pattern.
*   **Services:** The Business Logic layer handling data manipulation, mapping, and validation.
*   **Presentation:** The API entry point containing Controllers and routing logic.

## 🚀 Advanced Features & Mechanisms
The **Service Extensions Pattern** (`ServiceExtensions.cs`) is utilized to keep the `Program.cs` file exceptionally clean while applying the following complex configurations:

*   **Repository & Service Manager (Facade Pattern):** Centralized Dependency Injection management for seamless cross-layer communication.
*   **HATEOAS & Custom Media Types:** Output formatters are configured to support custom media types like `application/vnd.NiMu.hateoas+json` for dynamic hypermedia navigation.
*   **Data Shaping:** Client applications are empowered to request only specific object properties, reducing payload size.
*   **Rate Limiting & Response Caching:** `AspNetCoreRateLimit` is integrated to protect endpoints from abuse, and `Marvin.Cache.Headers` is used to enforce HTTP-level caching policies.
*   **API Versioning:** Header-based API versioning (`api-version`) is configured to support V1 and V2 controllers while maintaining backward compatibility.
*   **Custom Action Filters:** Validation, Logging, and Media Type validations are handled at the filter level (AOP approach) to keep Controllers clean.
*   **Identity & JWT Authentication:** ASP.NET Core Identity is configured with strict password policies alongside a secure JWT Bearer authentication flow with custom challenge responses.
*   **Advanced Swagger UI Integration:** Swagger is configured to support multiple API versions and JWT Bearer authorization directly from the UI.
*   **Health Checks:** SQL Server liveness probes are configured to monitor system stability.

## 🎥 Postman API Demonstration
A detailed demonstration showing how the endpoints communicate, how Rate Limiting protects the API, and how HATEOAS generates links has been recorded.

👉 **[Watch the Postman API Demonstration Video Here](https://lnkd.in/p/dck2NgkQ)**

## 🛠️ Tech Stack
*   **Framework:** .NET Core (C#)
*   **Architecture:** N-Tier (Entities, Repository, Services, Presentation)
*   **Database:** SQL Server & Entity Framework Core
*   **Security:** JWT Bearer & ASP.NET Core Identity
*   **Libraries:** AspNetCoreRateLimit, Marvin.Cache.Headers, AutoMapper, NLog
