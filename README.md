# ControlDeTareas
Aplicacion de portafolio de titulo

#Base de datos

--DROPS-------------------------------------------------------------------------
DROP TABLE EMPRESA;
DROP TABLE ROL;
DROP TABLE EMPLEADO;

--TABLAS------------------------------------------------------------------------
CREATE TABLE EMPRESA(
id_empresa NUMBER(10) NOT NULL PRIMARY KEY,
nombre_empresa varchar2(100)
);
    
CREATE TABLE ROL(
id_rol number(10) not null primary key,
nombre_rol varchar2(50)
);

CREATE TABLE EMPLEADO(
id_rut NUMBER(10) NOT NULL PRIMARY KEY,
id_empresa_emp NUMBER(10),
id_rol_emp NUMBER(10),
fecha_ingreso DATE,
nombre_emp VARCHAR2(100),
usuario varchar2(100),
clave varchar2(100)
);
alter table EMPLEADO
    add foreign key (id_empresa_emp) references EMPRESA (id_empresa);
alter table EMPLEADO
    add foreign key (id_rol_emp) references ROL (id_rol);
--INSERT------------------------------------------------------------------------
insert into empresa values (1,'process sa');
insert into rol values(1,'administrador');
insert into rol values(2,'diseñador de procesos');
insert into rol values(3,'funcionario');
insert into empleado values (205533990,1,1,'19/09/22','isaias antio','is.antio','1234');
insert into empleado values (123456789,1,2,'20/09/22','diego flores','die.flores','1234');
insert into empleado values (987654321,1,2,'21/09/22','sebastian sandoval','se.sandoval','1234');
