# Sistema de Registro de Dinosaurios 

## Contexto

En la isla científica **NeoGenesis Park**, un grupo de investigadores ha logrado recrear dinosaurios mediante ingeniería genética.

Para garantizar el control, monitoreo y estudio de cada especie, se requiere un sistema de gestión que registre información básica de cada dinosaurio dentro del parque.

Cada dinosaurio debe tener una identidad única dentro del sistema para poder ser rastreado, estudiado y controlado.

---

## Registro de Dinosaurio

Para registrar un dinosaurio en el sistema, se requieren obligatoriamente los siguientes datos mínimos:

- First Name (nombre asignado)
- Last Name (clasificación científica o especie)
- Username (identificador único del espécimen)
- Email (código de registro único del laboratorio)

Los demás datos son opcionales y pueden completarse más adelante.

El nombre asignado a cada dato (First Name, Last Name, etc.) es opcional, puede variar dependiendo de que tanto se quiera ambientar el sistema.

---

## Módulos del Sistema

### Consultas Funcionales del Módulo de Dinosaurios

El sistema debe permitir:

- Listar todos los dinosaurios registrados (reporte general).
- Ver el detalle de un dinosaurio por su Id (consulta individual).
- Ver el detalle de un dinosaurio por su código de registro (email).
- Listar todos los dinosaurios de una zona específica del parque (equivalente a ciudad).
- Listar todos los dinosaurios de un sector del parque (equivalente a país).
- Listar todos los dinosaurios mayores de una edad específica.
- Listar todos los dinosaurios de un tipo específico (carnívoro/herbívoro).
- Mostrar un listado con nombres completos y códigos de registro (para reportes científicos).
- Contar el total de dinosaurios registrados en el sistema.
- Contar cuántos dinosaurios hay en cada zona.
- Contar cuántos dinosaurios hay en cada sector.
- Ver cuáles dinosaurios no tienen dispositivo de rastreo (teléfono).
- Ver cuáles dinosaurios no tienen ubicación registrada (dirección).
- Listar los últimos dinosaurios registrados (ordenados por fecha de creación).
- Listar los dinosaurios ordenados alfabéticamente por especie.

---

### Módulo de Eliminación

El sistema debe permitir:

- Eliminar un dinosaurio por su Id.
- Eliminar un dinosaurio por su código de registro.

Antes de eliminar, el sistema debe mostrar un mensaje de confirmación:

"¿Está seguro de eliminar este dinosaurio? (S/N)"

El sistema debe mostrar un mensaje confirmando que el dinosaurio fue eliminado correctamente.

---

### Módulo de Actualización

El sistema debe permitir:

- Actualizar cada uno de los datos del dinosaurio.
- Actualizar el código de seguridad (contraseña) del dinosaurio, solicitando confirmación.

El sistema debe mostrar un mensaje de confirmación cuando los datos sean actualizados.

---

### Módulo de Inserción

El sistema debe permitir:

- Registrar un nuevo dinosaurio.

El sistema debe solicitar y guardar los siguientes datos:

- Nombre
- Especie
- Identificador único (username)
- Código de registro (email)

El sistema debe:

- Rechazar registros si el código de registro ya existe.
- Rechazar registros si el identificador ya existe.
- Mostrar un mensaje confirmando que el dinosaurio fue creado correctamente.

---

## Reglas del Sistema

- Username debe ser único.
- Email debe ser único.
- Los campos obligatorios no pueden estar vacíos.
- Validar formato del código de registro.
- Edad debe ser mayor o igual a 0.

---

## Uso Obligatorio de LINQ

El sistema debe implementar consultas usando LINQ para:

### Consultas básicas
- Listar todos los dinosaurios.
- Filtrar por zona o sector.
- Filtrar por edad o tipo.

### Proyecciones
- Mostrar nombre completo + código de registro.

### Ordenamientos
- Ordenar por fecha de registro.
- Ordenar alfabéticamente.

### Agrupaciones
- Contar dinosaurios por sector.
- Contar dinosaurios por zona.

### Filtros avanzados
- Dinosaurios sin dispositivo de rastreo.
- Dinosaurios sin ubicación registrada.
- Dinosaurios recientemente registrados.

---

## Requisitos de Implementación (EF Core)

El sistema debe incluir:

- DbContext
- DbSet para Dinosaurios
- Configuración de entidades
- Validaciones de unicidad
- Migraciones:
  - Add-Migration InitialCreate
  - Update-Database

---

Buenas prácticas:

- Código limpio
- Nombres consistentes
- Separación de responsabilidades

---

## Entregables

El estudiante debe entregar:

- Diagrama de Flujo
- Diagrama de Casos de Uso
- Diagrama de Clases
- Código fuente funcional organizado
- Evidencia de actividades en Azure DevOps o Jira
- Repositorio en GitHub con Conventional Commits
- Documentación en Docusaurus 🦖

---

