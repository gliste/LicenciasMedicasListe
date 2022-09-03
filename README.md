# LicenciasMedicasListe

## Objetivos 📋

Desarrollar un sistema de de Licencias Médicas para una empresa Pyme, que permita la administración y uso de ella. 
De cara a los empleados de RRHH: Empleados, Medicos, Licencias, Visita, etc. 
De cara a los empleados: solo visualizar sus licencias. 
Utilizar Visual Studio 2019 preferentemente y crear una aplicación utilizando ASP.NET MVC Core (versión a definir por el docente 3.1 o 6.0).

<hr />

## Enunciado 📢
La idea principal de este trabajo práctico, es que Uds. se comporten como un equipo de desarrollo.
Este documento, les acerca, un equivalente al resultado de una primera entrevista entre el paciente y alguien del equipo, el cual relevó e identificó la información aquí contenida. 
A partir de este momento, deberán comprender lo que se está requiriendo y construir dicha aplicación, 

Deben recopilar todas las dudas que tengan y evacuarlas con su nexo (el docente) de cara al paciente. De esta manera, él nos ayudará a conseguir la información ya un poco más procesada. 
Es importante destacar, que este proceso, no debe esperar a ser en clase; es importante, que junten algunas consultas, sea de índole funcional o técnicas, en lugar de cada consulta enviarla de forma independiente.

Las consultas que sean realizadas por correo deben seguir el siguiente formato:

Subject: [CURSO-<X> GRUPO-<XX>] <Proyecto XXX>

Body: 

1.<xxxxxxxx>

2.< xxxxxxxx>


# Ejemplo
**Subject:** [CURSO-A GRUPO-05] LicenciasMedicas

**Body:**

1.La relación del Empleado con Licnecia es 1:1 o 1:N?

2.Está bien que encaremos la validación de LicenciaActiva para los empleados, como con una propiedad booleana?

### Proceso de ejecución en alto nivel
 - Crear un nuevo proyecto en [visual studio](https://visualstudio.microsoft.com/en/vs/).
 - Adicionar todos los modelos dentro de la carpeta Models cada uno en un archivo separado.
 - Especificar todas las restricciones y validaciones solicitadas a cada una de las entidades. [DataAnnotations](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=netcore-3.1).
 - Crear las relaciones entre las entidades
 - Crear una carpeta Data que dentro tendrá al menos la clase que representará el contexto de la base de datos DbContext. 
 - Crear el DbContext utilizando base de datos en memoria (con fines de testing inicial). [DbContext](https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext?view=efcore-3.1), [Database In-Memory](https://docs.microsoft.com/en-us/ef/core/providers/in-memory/?tabs=vs).
 - Agregar los DbSet para cada una de las entidades en el DbContext.
 - Crear el Scaffolding para permitir los CRUD de las entidades al menos solicitadas en el enunciado.
 - Aplicar las adecuaciones y validaciones necesarias en los controladores.  
 - Realizar un sistema de login con al menos los roles equivalentes a <Usuario Cliente> y <Usuario Administrador> (o con permisos elevados).
 - Si el proyecto lo requiere, generar el proceso de registración. 
 - Un administrador podrá realizar todas tareas que impliquen interacción del lado del negocio (ABM "Alta-Baja-Modificación" de las entidades del sistema y configuraciones en caso de ser necesarias).
 - El <Usuario Cliente> sólo podrá tomar acción en el sistema, en base al rol que tiene.
 - Realizar todos los ajustes necesarios en los modelos y/o funcionalidades.
 - Realizar los ajustes requeridos del lado de los permisos.
 - Todo lo referido a la presentación de la aplicaión (cuestiones visuales).
 
<hr />

## Entidades 📄

- Persona 🟢
- Empleado
- Medico 
- Licencia
- Visita
- Prestadora

`Importante: Todas las entidades deben tener su identificador unico. Id o <ClassNameId>`

`
Las propiedades descriptas a continuación, son las minimas que deben tener las entidades. Uds. pueden agregar las que consideren necesarias.
De la misma manera Uds. deben definir los tipos de datos asociados a cada una de ellas, como así también las restricciones.
`

**Persona**🟢
```
- Nombre
- Email
- FechaAlta
- Password
```

**Empleado**
```
- Nombre
- Apellido
- DNI
- Telefono
- Direccion
- FechaAlta
- Email 
- ObraSocial
- Legajo
- EmpleadoActivo
- Licencias
```

**Medico**
```
- Nombre
- Apellido
- DNI
- Matricula
- Telefono
- FechaAlta
- Email 
- Prestadora
- Licencias
```

**Telefono**
```
- Numero
- TipoTelefono
```

**TipoTelefono**
```
- Nombre
```

**Licencia**
```
- FechaSolicitud
- Descipcion
- Empleado
- Visitas
- FechaInicioSolicitada
- FechaFinSolicitada
- FechaInicio
- FechaFin
- Activa
```

**Visita**
```
- Licencia
- Medico
- FechayHoraVisita
- FechaInicio
- FechaFin
- Descripcion (Ej. Lumbalgia)
- Justificada
- CantidadDias
- Nota
- Cargada
```

**Prestadora**
```
- Nombre- 
- Direccion
- TelefonoContacto
- EmailContacto
- Medicos
```

**NOTA:** aquí un link para refrescar el uso de los [Data annotations](https://www.c-sharpcorner.com/UploadFile/af66b7/data-annotations-for-mvc/).

<hr />

## Caracteristicas y Funcionalidades ⌨️
`Todas las entidades, deben tener implementado su correspondiente ABM, a menos que sea implicito el no tener que soportar alguna de estas acciones.`


**Usuario**
- Los Empleados no pueden auto registrarse.

**Empleado**
- Los empleados, deben ser agregados por otro Empleado.
	- Al momento, del alta del empleado, se le definirá un username y password debe ser asignada por el sistema.
    - También se le asignará a estas cuentas el rol de empleado y adicionalmente el de RRHH si corresponde.
    - Un empleado, solo puede actualizar sus telefonos y foto, pero puede ver todos sus datos.
    - Lo mismo ocurrirá para dar de alta medicos, solo los empleados con el Rol de RRHH, pueden realizar esta tarea.
- Un empleado puede consultar todas sus licencias medicas y estado de las mismas.
- Un empleado puede solicitar una licencia medica por telefono y/o por la web.
- Solo puede tener una licencia medica activa. 

**Empleado RRHH**
- Se distingue solo por un rol, que le da los permisos para gestioar toda la información del sistema, con la excepción de que no puede modificar ni eliminar ningúna Visita. 
- Al momento de recibir una llamada telefonica, solicitandoles una licencia médica, el empleado de RRHH podrá crear una Licencia (si no hay otra activa), para un determinado empleado. 
- Al crearse esta, la misma, deberá ser completada con los datos de minima (Fecha de inicio solicitada por el empleado, opcional de fin, una descripción de que le ocurre). Esto creará una Visita de forma automática, con una fecha de visita al día siguiente de la carga y un medico que podrá elegir aleatoriamente el empleado de RRHH del listado de medicos en el sistema.
- Podrá listar a todos los empleados.
    - Al acceder al empleado, vera el detalle de sus datos y todas las licencias medicas solicitadas, en orden descendente por Fecha.
        - También, podrá ver el detalle de cada licencia, viendo todos las visitas de forma descendente.
- Podrá Modificar el Medico asignado a una Visita, siempre y cuando, la visita no esté en estado completada.


**Medico**
- Un medico, solo puede ver las visitas asignadas a él. En el detalle, verá no solo la información a cargar de la misma, sino también, los datos del Empleado para ir a su domicilio y datos de contacto.
- Puede cargar las visitas que tiene asignadas, pero una vez que fué completada, no puede modificarlas.
- Nunca puede eliminar las visitas.

**Visita**
- Cuando un medico carga los datos de una visita, al enviarla, se podrá en estado cargada.
    - Si el medico indica que la licencia(Visita), está justificada entonces la licencia estará activa.
    - El medicó ingresará la Fecha de Inicio de la licencia (según la visita por defecto), pero puede modificar por una fecha posterior (Ej. Por operación programada) y cantidad de dias justificados.
    - Si no se justifica, los días, no serán tenidos en cuenta.
    - Cargará un Diagnostico, por ejemplo: Lumbalgia, Gripe, etc.
    - Cargará notas 
- Si la Visita fué justificada y es la primera, se cargará la fecha de Inicio y Fin en base a la cantidad de dias justificados.
    - Si no es la primera visita, entonces, solo ajustará la fecha de fin según lo que de como resultante en base a los días justificados.
    - El caso de dia de alta, será en base al concepto, Justificada y cantidad de dias 0, por lo cual, dará la fecha de la vista como resultante.
- Si no está Justificada, la licencia pasará a estar Inactiva y no cargará y/o modificará las fechas de la licencia.

**Aplicación General**
- Información institucional, en base a la información de la Empresa, con su respectiva imagen (Logo)
- Nadie, puede eliminar las visitas, ni licencias medicas. 
- Los accesos a las funcionalidades y/o capacidades, debe estar basada en los roles que tenga cada individuo o tipo.


