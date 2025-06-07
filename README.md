# 📱 App MAUI - Consumo de API y Verificación de Sensores

Aplicación móvil creada con .NET MAUI como parte de la materia **Programación de Dispositivos Móviles**.

## 🚀 Funcionalidades

- ✅ Consumo de API REST para obtener artículos en tiempo real.
- 🔍 Filtro dinámico por nombre o código de barra.
- 🌐 Verificación automática cada 5 segundos de:
  - Conexión a Internet
  - Estado del Wi-Fi
  - GPS activo o no
  - Bluetooth encendido o apagado
- 🔐 Solicitud de permisos dinámicos para ubicación y Bluetooth.
- 🕒 Visualización de la última hora de verificación.

## 🧪 Tecnologías y Paquetes NuGet usados

- [.NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/)
- `Plugin.BLE` – Verificación de Bluetooth
- `Microsoft.Maui.Essentials` – Para geolocalización, red y sensores
- `Microsoft.Maui.Permissions` – Para manejo de permisos en tiempo de ejecución

## 👩‍💻 Autor

**Nathaly Michel Berroa Fermín**  
Proyecto académico - UTESA
