# Club Naval

## Descripción General
El sistema **Club Naval** es una aplicación de escritorio desarrollada en C# (Windows Forms) bajo una arquitectura estricta de tres capas (Presentación, Lógica de Negocio y Acceso a Datos). Su propósito principal es gestionar las operaciones operativas y administrativas de un club náutico. El sistema controla el registro de personas (socios, dueños, capitanes), administra la flota de barcos, y maneja de manera segura la bitácora de salidas al mar.

Una de sus características principales es el control automatizado de disponibilidad: el sistema asegura de forma transaccional que un barco o un capitán en altamar no puedan ser asignados a otra salida de forma simultánea. Además, cuenta con un módulo inicializador que genera automáticamente las tablas y procedimientos almacenados en SQL Server, facilitando enormemente su instalación y despliegue en nuevos entornos.

---

## 1. Definición y Análisis de Requerimientos del Sistema

Tras un análisis exhaustivo de la base de código (Interfaces, Lógica de Negocio y Acceso a Datos), no fue necesario el uso de múltiples agentes, ya que se logró mapear el 100% de las funcionalidades implementadas en una sola pasada iterativa. A continuación se detallan los requerimientos:

### Requerimientos Funcionales (RF)

**Módulo de Gestión de Personas**
* **RF01:** El sistema debe permitir registrar nuevas personas capturando: Nombre, Teléfono, Dirección, Correo, Cargo y Fotografía (URL o ruta).
* **RF02:** El sistema debe permitir actualizar los datos y la fotografía de una persona ya existente.
* **RF03:** El sistema debe permitir la eliminación lógica de una persona (marcándola como "no disponible") para mantener la integridad del historial de salidas.
* **RF04:** El sistema debe permitir consultar un listado general de todas las personas registradas.
* **RF05:** El sistema debe clasificar a las personas mediante un catálogo o identificador de cargos (ej. 1 = Capitán, 2 = Tripulante).

**Módulo de Gestión de Barcos**
* **RF06:** El sistema debe permitir registrar nuevos barcos capturando: Matrícula, Número de Amarre, Nombre, Cuota de mantenimiento, Persona Dueña y Fotografía.
* **RF07:** El sistema debe permitir actualizar la información y la fotografía de un barco existente.
* **RF08:** El sistema debe permitir la eliminación lógica de un barco registrado.
* **RF09:** El sistema debe permitir consultar un listado general de barcos activos.
* **RF10:** Al registrar o editar un barco, el sistema debe permitir seleccionar como "Dueño" a cualquier persona previamente registrada en el catálogo de personas (incluso aquellas que estén temporalmente "No disponibles" por encontrarse en altamar).

**Módulo de Gestión de Salidas (Bitácora)**
* **RF11:** El sistema debe permitir registrar una nueva salida al mar especificando: Fecha y Hora de salida, Destino, Barco seleccionado y Capitán a cargo. El sistema asignará automáticamente el estado inicial de la salida como "En Viaje".
* **RF12:** Al registrar una salida, la interfaz debe filtrar y permitir seleccionar **únicamente barcos que se encuentren "Disponibles"** en ese momento.
* **RF13:** Al registrar una salida, la interfaz debe filtrar y permitir seleccionar **únicamente personas con cargo de "Capitán" que se encuentren "Disponibles"**.
* **RF14:** Al concretar el registro de una salida, el sistema debe procesar una transacción que cambie automáticamente el estado de disponibilidad del Barco y del Capitán seleccionados a "No disponibles".
* **RF15:** El sistema debe permitir consultar el historial de salidas registradas, incluyendo datos relacionales extendidos (nombres y fotos del barco y del capitán).
* **RF16:** El sistema debe permitir "Finalizar" una salida en curso, actualizando su estado interno a "Terminada".
* **RF17:** Al finalizar una salida, el sistema debe ejecutar una transacción que libere automáticamente al Barco y al Capitán, restaurando su estado a "Disponibles".
* **RF18:** El sistema debe permitir la eliminación lógica de una salida (cambiando su estado a "ELIMINADA") en caso de error de captura, sin alterar la disponibilidad actual del barco y el capitán.

**Automatización y Despliegue**
* **RF19:** Al iniciar la aplicación, el sistema debe analizar la base de datos SQL Server configurada y crear automáticamente todas las tablas relacionales (`Personas`, `Barcos`, `Salidas`) en caso de no existir.
* **RF20:** De igual forma, el sistema debe verificar y crear automáticamente todos los procedimientos almacenados (Stored Procedures) necesarios para realizar el CRUD de las entidades.

### Requerimientos No Funcionales (RNF)

* **RNF01 (Arquitectura):** El sistema debe estar estructurado obligatoriamente en 3 capas de software: Presentación (`CNaval`), Lógica de Negocio (`BussinesLogic`) y Acceso a Datos (`DataAccess`).
* **RNF02 (Tecnología UI):** La interfaz gráfica debe estar desarrollada mediante Windows Forms (.NET Framework / C#).
* **RNF03 (Base de Datos):** El motor de base de datos utilizado debe ser SQL Server.
* **RNF04 (Persistencia):** Todas las operaciones de interacción con la base de datos deben realizarse obligatoriamente a través de Procedimientos Almacenados, evitando consultas directas (quemadas) en la capa de datos.
* **RNF05 (Mapeo O/R):** Se debe utilizar la librería `Dapper` para el mapeo ágil de los registros devueltos por SQL Server a objetos (POCOs) de C#.
* **RNF06 (Asincronismo):** El 100% de las operaciones de lectura/escritura hacia la base de datos deben ser asíncronas (`async/await` y métodos `...Async()`) para asegurar que la interfaz de usuario nunca se congele.
* **RNF07 (Configuración):** La cadena de conexión a la base de datos (ConnectionString) debe leerse dinámicamente desde un archivo `appsettings.json` ubicado en la raíz del ejecutable.
