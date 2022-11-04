/* SCRIPT CON DATOS PARA LA BASE DE DATOS ACADEMIA */

use academia;

delete from alumnos_inscripciones;
delete from modulos_usuarios;
delete from modulos;
delete from usuarios;
delete from personas;
delete from cursos;
delete from materias;
delete from comisiones;
delete from planes;
delete from especialidades;

-- data especialidades
DBCC CHECKIDENT ('ESPECIALIDADES', RESEED, 0);

insert into especialidades(desc_especialidad)
values('Ingenieria Civil');
insert into especialidades(desc_especialidad)
values('Ingenieria Mecanica');
insert into especialidades(desc_especialidad)
values('Ingenieria Electrica');
insert into especialidades(desc_especialidad)
values('Ingenieria en Sistemas');
insert into especialidades(desc_especialidad)
values('Ingenieria Industrial');

-- data planes
DBCC CHECKIDENT ('PLANES', RESEED, 0);

insert into planes(desc_plan, id_especialidad)
values('1995', 1);
insert into planes(desc_plan, id_especialidad)
values('2008', 1);

insert into planes(desc_plan, id_especialidad)
values('1995', 2);
insert into planes(desc_plan, id_especialidad)
values('2008',2);

insert into planes(desc_plan, id_especialidad)
values('1995', 3);
insert into planes(desc_plan, id_especialidad)
values('2008', 3);

insert into planes(desc_plan, id_especialidad)
values('1995', 4);
insert into planes(desc_plan, id_especialidad)
values('2008', 4);
insert into planes(desc_plan, id_especialidad)
values('2023', 4);

insert into planes(desc_plan, id_especialidad)
values('1995', 5);
insert into planes(desc_plan, id_especialidad)
values('2008', 5);

-- data comisiones
DBCC CHECKIDENT ('COMISIONES', RESEED, 0);

insert into comisiones(desc_comision, anio_especialidad, id_plan)
values('301', 2022, 2);
insert into comisiones(desc_comision, anio_especialidad, id_plan)
values('302', 2022, 2);
insert into comisiones(desc_comision, anio_especialidad, id_plan)
values('301', 2022, 4);
insert into comisiones(desc_comision, anio_especialidad, id_plan)
values('302', 2022, 4);
insert into comisiones(desc_comision, anio_especialidad, id_plan)
values('301', 2022, 6);
insert into comisiones(desc_comision, anio_especialidad, id_plan)
values('302', 2022, 6);
insert into comisiones(desc_comision, anio_especialidad, id_plan)
values('301', 2022, 8);
insert into comisiones(desc_comision, anio_especialidad, id_plan)
values('302', 2022, 8);
insert into comisiones(desc_comision, anio_especialidad, id_plan)
values('303', 2022, 8);
insert into comisiones(desc_comision, anio_especialidad, id_plan)
values('301', 2022, 11);
insert into comisiones(desc_comision, anio_especialidad, id_plan)
values('302', 2022, 11);

-- data materias
DBCC CHECKIDENT ('MATERIAS', RESEED, 0);

insert into materias(desc_materia, hs_semanales, hs_totales, id_plan)
values('Net', 4, 60, 8);
insert into materias(desc_materia, hs_semanales, hs_totales, id_plan)
values('Diseño de sistemas', 6, 72, 8);
insert into materias(desc_materia, hs_semanales, hs_totales, id_plan)
values('Matematica Superior', 4, 60, 8);
insert into materias(desc_materia, hs_semanales, hs_totales, id_plan)
values('Comunicaciones', 3, 40, 8);

-- data cursos
DBCC CHECKIDENT ('CURSOS', RESEED, 0);

insert into cursos(id_materia, id_comision, anio_calendario, cupo)
values(1, 7, 2022, 50);
insert into cursos(id_materia, id_comision, anio_calendario, cupo)
values(1, 8, 2022, 40);
insert into cursos(id_materia, id_comision, anio_calendario, cupo)
values(1, 9, 2022, 25);
insert into cursos(id_materia, id_comision, anio_calendario, cupo)
values(2, 7, 2022, 60);
insert into cursos(id_materia, id_comision, anio_calendario, cupo)
values(2, 8, 2022, 50);
insert into cursos(id_materia, id_comision, anio_calendario, cupo)
values(2, 9, 2022, 45);

-- data personas
DBCC CHECKIDENT ('PERSONAS', RESEED, 0);

insert into personas(nombre, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona, id_plan)
values('Bautista','Guerra', 'Santiago 2000', 'bauguerra@gmail.com', '341111789', '20010101', 10900, 1, 8);
insert into personas(nombre, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona, id_plan)
values('Alessandro','Paolini', 'Paraguay 2000', 'alepaolini@gmail.com', '360900123', '20000101', 10800, 2, 8);
insert into personas(nombre, apellido, direccion, email, telefono, fecha_nac, legajo, tipo_persona, id_plan)
values('Ezequiel','Porta', 'Oroño 2000', 'ezeporta@gmail.com', '320600123', '20000101', 20000, 0, 8);

-- data usuarios 
DBCC CHECKIDENT ('USUARIOS', RESEED, 0);

insert into usuarios(nombre_usuario, nombre, apellido, email, clave, habilitado, id_persona)
values('bauguerra', 'Bautista', 'Guerra', 'bauguerra@gmail.com', 'bauguerra', 1, 1);
insert into usuarios(nombre_usuario, nombre, apellido, email, clave, habilitado, id_persona)
values('alepaolini', 'Alessandro', 'Paolini', 'alepaolini@gmail.com', 'alepaolini', 1, 2);
insert into usuarios(nombre_usuario, nombre, apellido, email, clave, habilitado, id_persona)
values('ezeporta', 'Ezequiel', 'Porta', 'ezeporta@gmail.com', 'ezeporta', 1, 3);

-- data modulos
DBCC CHECKIDENT ('MODULOS', RESEED, 0);

insert into modulos(desc_modulo)
values('DOCENTE');
insert into modulos(desc_modulo)
values('ALUMNO');
insert into modulos(desc_modulo)
values('ADMINISTRADOR');

-- data modulos usuarios
DBCC CHECKIDENT ('MODULOS_USUARIOS', RESEED, 0);

insert into modulos_usuarios(id_modulo, id_usuario, alta, baja, modificacion, consulta)
values(1, 3, 1,1,1,1);
insert into modulos_usuarios(id_modulo, id_usuario, alta, baja, modificacion, consulta)
values(2, 1, 0,0,0,1);
insert into modulos_usuarios(id_modulo, id_usuario, alta, baja, modificacion, consulta)
values(3, 2, 1,1,1,1);

-- data inscripciones
DBCC CHECKIDENT ('alumnos_inscripciones', RESEED, 0);

insert into alumnos_inscripciones(id_alumno, id_curso, condicion, nota)
values(1,1,'Aprobado', 6);
insert into alumnos_inscripciones(id_alumno, id_curso, condicion, nota)
values(4,1,'Aprobado', 7);
insert into alumnos_inscripciones(id_alumno, id_curso, condicion, nota)
values(4,4,'Aprobado', 9);
insert into alumnos_inscripciones(id_alumno, id_curso, condicion, nota)
values(1,2,'Aprobado', 6);
insert into alumnos_inscripciones(id_alumno, id_curso, condicion, nota)
values(4,5,'Aprobado', 6);


