# Taller de Patrones de Diseño - Aplicativo de Automóviles

## Descripción del Proyecto

Este proyecto implementa un sistema de gestión de vehículos utilizando patrones de diseño para resolver los requerimientos funcionales de la empresa Codificando Con Patrones Cía. Ltda. El aplicativo permite gestionar diferentes modelos de automóviles Ford con funcionalidades como agregar vehículos, controlar el motor y gestionar combustible.

## Identificación del Problema

### Problemas Encontrados en el Escenario

1. **Funcionalidad de Agregar Vehículos No Operativa**: Los métodos `addMustang` y `addExplorer` en el Home Page no funcionan correctamente según reportes del equipo de QA.

2. **Dependencia de Base de Datos**: El esquema de base de datos no está listo, requiriendo una solución temporal para probar funcionalidad sin persistencia de datos.

3. **Escalabilidad de Propiedades**: El equipo de negocio requiere agregar el año actual y 20 propiedades adicionales por defecto que afectarán a los vehículos en el siguiente sprint.

4. **Expansión de Modelos**: Se planea agregar nuevos modelos de vehículos (Escape, Mustang, Explorer) y se prevé la introducción de más modelos en el futuro.

### Limitaciones y Restricciones Técnicas

- **Base de Datos No Disponible**: No se puede implementar persistencia real de datos
- **Compatibilidad Futura**: La solución debe permitir fácil migración a base de datos cuando esté disponible
- **Escalabilidad**: El sistema debe soportar nuevos modelos y propiedades sin cambios masivos
- **Mantenibilidad**: El código debe seguir principios SOLID y ser fácil de mantener

## Metodologías Integrales Implementadas

### Patrones de Diseño Seleccionados

#### 1. Patrón Repository
**Propósito**: Abstraer la lógica de acceso a datos y permitir cambiar entre diferentes fuentes de datos sin afectar la lógica de negocio.

**Implementación**:
- `IVehicleRepository`: Interfaz que define las operaciones CRUD
- `MyVehiclesRepository`: Implementación en memoria para pruebas
- `DBVehicleRepository`: Implementación preparada para base de datos

**Ventajas**:
- Desacopla la lógica de negocio del acceso a datos
- Permite cambiar entre memoria y base de datos fácilmente
- Facilita las pruebas unitarias

#### 2. Patrón Factory Method
**Propósito**: Crear objetos sin especificar sus clases exactas, permitiendo la extensión para nuevos tipos de vehículos.

**Implementación**:
- `CarFactory`: Clase abstracta base
- `FordMustangFactory`, `FordEscapeFactory`, `FordExplorerFactory`: Implementaciones específicas

**Ventajas**:
- Encapsula la lógica de creación de objetos
- Permite agregar nuevos modelos sin modificar código existente
- Mantiene la consistencia en la creación de objetos

#### 3. Patrón Builder
**Propósito**: Construir objetos complejos paso a paso, especialmente útil para objetos con muchas propiedades opcionales.

**Implementación**:
- `CarModelBuilder`: Permite construir vehículos con propiedades por defecto
- Método fluido (fluent interface) para configuración

**Ventajas**:
- Facilita la creación de objetos con muchas propiedades
- Proporciona valores por defecto
- Permite configuración flexible

#### 4. Patrón Singleton
**Propósito**: Garantizar que una clase tenga una sola instancia y proporcionar un punto de acceso global a ella.

**Implementación**:
- `MemoryCollection`: Almacenamiento en memoria único para la aplicación

**Ventajas**:
- Garantiza consistencia de datos en memoria
- Evita múltiples instancias innecesarias
- Simplifica el acceso a datos compartidos

#### 5. Patrón Dependency Injection
**Propósito**: Invertir el control de dependencias, permitiendo mayor flexibilidad y testabilidad.

**Implementación**:
- `ServicesConfiguration`: Configuración centralizada de servicios
- Inyección de `IVehicleRepository` en el controlador

**Ventajas**:
- Reduce el acoplamiento entre componentes
- Facilita las pruebas unitarias
- Permite cambiar implementaciones fácilmente

## Diagramas UML

### Diagrama de Clases Principal

```
┌─────────────────┐    ┌──────────────────┐    ┌─────────────────┐
│   HomeController│    │ IVehicleRepository│    │   Vehicle       │
├─────────────────┤    ├──────────────────┤    ├─────────────────┤
│ -logger         │    │ +GetVehicles()   │    │ #ID: Guid       │
│ -repository     │    │ +AddVehicle()    │    │ #Color: string  │
├─────────────────┤    │ +Find()          │    │ #Brand: string  │
│ +Index()        │    └──────────────────┘    │ #Model: string  │
│ +AddMustang()   │             ▲              │ #Gas: double    │
│ +AddExplorer()  │             │              │ #Year: int      │
│ +StartEngine()  │    ┌──────────────────┐    ├─────────────────┤
│ +StopEngine()   │    │MyVehiclesRepository│  │ +StartEngine()  │
│ +AddGas()       │    ├──────────────────┤    │ +StopEngine()   │
└─────────────────┘    │ -memoryCollection│    │ +AddGas()       │
                       │ +AddVehicle()    │    │ +NeedsGas()     │
                       │ +Find()          │    │ +IsEngineOn()   │
                       │ +GetVehicles()   │    └─────────────────┘
                       └──────────────────┘             ▲
                                                        │
                                               ┌─────────────────┐
                                               │      Car        │
                                               ├─────────────────┤
                                               │ +Tires: int     │
                                               └─────────────────┘
```

### Diagrama de Patrón Factory Method

```
┌─────────────────┐
│   CarFactory    │
├─────────────────┤
│ +Created(): Vehicle │
└─────────────────┘
         ▲
         │
    ┌────┴────┐
    │         │
┌─────────┐ ┌─────────┐
│FordMustang│ │FordEscape│
│Factory   │ │Factory   │
├─────────┤ ├─────────┤
│+Created()│ │+Created()│
└─────────┘ └─────────┘
```

### Diagrama de Patrón Builder

```
┌─────────────────┐
│ CarModelBuilder │
├─────────────────┤
│ -color: string  │
│ -brand: string  │
│ -model: string  │
│ -year: int      │
├─────────────────┤
│ +setColor()     │
│ +setBrand()     │
│ +setModel()     │
│ +setYear()      │
│ +Build(): Vehicle│
└─────────────────┘
```

## Propuesta Técnica

### Arquitectura de la Solución

La solución implementa una arquitectura en capas con los siguientes componentes:

1. **Capa de Presentación**: Controllers y Views de ASP.NET Core
2. **Capa de Lógica de Negocio**: Modelos y Factories
3. **Capa de Acceso a Datos**: Repositories y MemoryCollection
4. **Capa de Infraestructura**: Dependency Injection y configuración

### Ventajas de la Implementación

1. **Flexibilidad**: Los patrones implementados permiten cambios futuros sin afectar el código existente
2. **Testabilidad**: La inyección de dependencias facilita las pruebas unitarias
3. **Escalabilidad**: El patrón Factory permite agregar nuevos modelos fácilmente
4. **Mantenibilidad**: El código sigue principios SOLID y es fácil de entender

### Preparación para el Siguiente Sprint

La implementación actual está preparada para el siguiente sprint de la siguiente manera:

1. **Propiedades Adicionales**: El patrón Builder puede extenderse fácilmente para incluir las 20 propiedades adicionales
2. **Nuevos Modelos**: El patrón Factory Method permite agregar nuevos modelos sin modificar código existente
3. **Base de Datos**: El patrón Repository permite cambiar de memoria a base de datos simplemente modificando la configuración de DI

## Instrucciones de Ejecución

### Prerrequisitos
- .NET 6.0 o superior
- Visual Studio 2022 o Visual Studio Code

### Pasos para Ejecutar

1. Clonar el repositorio:
```bash
git clone https://github.com/xavierrivan/Mejores-Pr-cticas.git
```

2. Navegar al directorio del proyecto:
```bash
cd DesignPatterns
```

3. Restaurar dependencias:
```bash
dotnet restore
```

4. Ejecutar la aplicación:
```bash
dotnet run
```

5. Abrir el navegador en: `https://localhost:5001`

### Funcionalidades Disponibles

- **Agregar Mustang**: Crea un Ford Mustang con propiedades por defecto
- **Agregar Explorer**: Crea un Ford Explorer usando el patrón Factory
- **Control de Motor**: Iniciar y detener el motor de los vehículos
- **Gestión de Combustible**: Agregar gasolina a los vehículos

## Estructura del Proyecto

```
DesignPatterns/
├── Controllers/
│   └── HomeController.cs          # Controlador principal
├── Factories/
│   ├── CarFactory.cs              # Factory abstracto
│   ├── FordMustangFactory.cs      # Factory para Mustang
│   ├── FordEscapeFactory.cs       # Factory para Escape
│   └── FordExplorerFactory.cs     # Factory para Explorer
├── Models/
│   ├── IVehicle.cs                # Interfaz del vehículo
│   ├── Vehicle.cs                 # Clase base abstracta
│   └── Car.cs                     # Implementación de Car
├── ModelBuilders/
│   └── CarModelBuilder.cs         # Builder para construcción de vehículos
├── Repositories/
│   ├── IVehicleRepository.cs      # Interfaz del repositorio
│   ├── MyVehiclesRepository.cs    # Implementación en memoria
│   └── DBVehicleRepository.cs     # Implementación para BD (preparado)
├── Infraestructure/
│   └── DependencyInjection/
│       └── ServicesConfiguration.cs # Configuración de DI
├── Views/
│   └── Home/
│       └── Index.cshtml           # Vista principal
└── MemoryCollection.cs            # Singleton para almacenamiento
```

## Conclusión

La implementación de estos patrones de diseño resuelve todos los problemas identificados en el escenario:

1. **Funcionalidad de Agregar Vehículos**: Implementada correctamente con Factory Method y Builder
2. **Independencia de Base de Datos**: Resuelta con Repository Pattern y almacenamiento en memoria
3. **Escalabilidad de Propiedades**: Preparada con Builder Pattern
4. **Expansión de Modelos**: Facilitada con Factory Method Pattern

La solución es robusta, mantenible y preparada para futuras expansiones, cumpliendo con los principios SOLID y las mejores prácticas de desarrollo de software.

## Autor

Xavier Ivan Gordillo Boya

## Fecha de Entrega

Enero 2025