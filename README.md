# Sistema de Gestión de Metas Personales
## Segundo Examen Parcial – Programación III
## Universidad Americana – Ing. Andrey Padías C.

---

### Integrantes
-  Delroy Campbell Thomas
-  Rolando Madrigal Rojas
-  Daniela Mora Ramirez


---

### Descripción del Proyecto

Este proyecto implementa un Sistema de Gestión de Metas Personales desarrollado con ASP.NET Core MVC, Entity Framework Core y SQL Server.  
El sistema permite al usuario organizar metas personales, crear tareas, asignar prioridades y controlar su progreso.

---

### Objetivo del Sistema

El usuario utiliza notas dispersas y recordatorios básicos que dificultan priorizar tareas, hacer seguimiento y visualizar avances.  
Este sistema centraliza toda la información, permitiendo una gestión clara y organizada.

---

## Funcionalidades

### Gestión de Metas  
Incluye atributos como:  
- ID  
- Título  
- Descripción  
- Categoría  
- Fecha de creación  
- Fecha límite  
- Prioridad  
- Estado  

Permite:  
- Crear metas  
- Editarlas  
- Cambiar su estado  
- Eliminar metas completadas

---

### Gestión de Tareas  
Atributos:  
- ID  
- Descripción  
- Fecha de creación  
- Fecha límite  
- Estado  
- Dificultad  
- Tiempo estimado  
- Meta asociada  

Permite:  
- Crear tareas dentro de una meta  
- Editarlas  
- Actualizar estado  
- Marcar como completadas  
- Eliminar tareas

---

## Relación entre Entidades  
- Una Meta puede tener múltiples tareas  
- Una Tarea pertenece a una única Meta

---

# Tecnologías Utilizadas

- C#  
- ASP.NET Core MVC  
- Entity Framework Core (Code First)  
- SQL Server  
- Bootstrap 5  
- LINQ  

---

# Estructura Completa del Proyecto
```
ExamenParcial2_Progra3/
│
├── Controllers/
│ ├── MetasController.cs
│ └── TareasController.cs
│
├── Data/
│ └── AppDbContext.cs
│ 
├── Diagramas/
│ └── DiagramaEntidades.png
│
├── Models/
│ ├── CategoriaMeta.cs
│ ├── Dificultad.cs
│ ├── EstadoMeta.cs
│ ├── EstadoTarea.cs
│ ├── Meta.cs
│ ├── PrioridadMeta.cs
│ └── Tarea.cs
│
├── Views/
│ ├── Metas/
│ │ ├── Index.cshtml
│ │ ├── Create.cshtml
│ │ ├── Edit.cshtml
│ │ ├── Details.cshtml
│ │ └── Delete.cshtml
│
│ └── Tareas/
│ ├── Index.cshtml
│ ├── Create.cshtml
│ ├── Edit.cshtml
│ ├── Details.cshtml
│ └── Delete.cshtml
│
├── wwwroot/
│ ├── css/
│ ├── js/
│ └── lib/
│
├── appsettings.json
├── Program.cs
├── ExamenParcial2_Progra3.csproj
└── README.md
```

---

# Entrega del Examen

El proyecto puede entregarse en:  
- Archivo ZIP  
- Repositorio GitHub  
- OneDrive institucional  

---
# Créditos
Proyecto desarrollado para el Segundo Examen Parcial de Programación III (Universidad Americana).  
Profesor: Ing. Andrey Padías C.
---
# Licencia
Este proyecto está bajo la licencia MIT.
Puedes usarlo, modificarlo y distribuirlo libremente, siempre que se incluya la notificación de copyright y la licencia correspondiente.



