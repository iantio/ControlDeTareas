--DROP---------------------------------------------------------
DROP TABLE FLUJO;
DROP TABLE DETALLE_TAREA;
DROP TABLE EMPLEADO;
DROP TABLE ROL;
DROP TABLE PROCESO;
DROP TABLE UNIDAD;
DROP TABLE TAREA;
DROP TABLE ESTADO;
DROP TABLE EMPRESA;

--CREATE TABLES------------------------------------------------
create table EMPRESA(
id_empresa number(10) not null primary key,
nombre_empresa varchar2(100)
);

create table ROL(
id_rol number(10) not null primary key,
id_empresa_rol number(10),
nombre_rol varchar2(50)
);

create table EMPLEADO(
id_rut number(10) not null primary key,
id_empresa_emp number(10),
id_rol_emp number(10),
fecha_ingreso date,
nombre_emp varchar2(50),
usuario varchar2(50),
clave varchar2(50)
);

create table ESTADO(
id_estado number(2) not null primary key,
nombre_estado varchar2(25)
);

create table PROCESO(
id_proceso number(10) not null primary key,
id_estado_pro number(2),
id_empresa_pro number(10),
nombre_proceso varchar2(50),
fecha_inicio date,
fecha_termino date
);

create table UNIDAD(
id_unidad number(10) not null primary key,
id_proceso_uni number(10),
id_estado_uni number(2),
id_empresa_uni number(10),
nombre_unidad varchar2(50),
fecha_inicio date,
fecha_termino date
);
create table TAREA(
id_tarea number(10) not null primary key,
id_unidad_tarea number(10),
id_estado_tarea number(2),
id_empresa_tarea number(10),
nombre_tarea varchar2(50),
fecha_inicio date,
fecha_termino date
);

create table DETALLE_TAREA(
id_detalle number(10) not null primary key,
id_rut_detalle number(10),
id_tarea_detalle number(10));

create table FLUJO(
id_flujo number(10)not null primary key,
id_unidad_flujo number(10),
id_tarea_flujo number(10));

--FOREING KEY--------------------------------------------------
alter table ROL
    add foreign key (id_empresa_rol) references EMPRESA (id_empresa);

alter table EMPLEADO
    add foreign key (id_empresa_emp) references EMPRESA (id_empresa);
alter table EMPLEADO
    add foreign key (id_rol_emp) references ROL (id_rol);
    
alter table PROCESO
    add foreign key (id_estado_pro) references ESTADO (id_estado);
alter table PROCESO
    add foreign key (id_empresa_pro) references EMPRESA (id_empresa);

alter table UNIDAD
    add foreign key (id_proceso_uni) references PROCESO (id_proceso);
alter table UNIDAD
    add foreign key (id_estado_uni) references ESTADO (id_estado);
alter table UNIDAD
    add foreign key (id_empresa_uni) references EMPRESA (id_empresa);
    
alter table TAREA
    add foreign key (id_unidad_tarea) references UNIDAD (id_unidad);
alter table TAREA
    add foreign key (id_empresa_tarea) references EMPRESA (id_empresa);
alter table TAREA
    add foreign key (id_estado_tarea) references ESTADO (id_estado);

alter table DETALLE_TAREA
    add foreign key (id_rut_detalle) references EMPLEADO (id_rut);
alter table DETALLE_TAREA
    add foreign key (id_tarea_detalle) references TAREA (id_tarea);

alter table FLUJO
    add foreign key (id_unidad_flujo) references UNIDAD (id_unidad);
alter table FLUJO
    add foreign key (id_tarea_flujo) references TAREA (id_tarea);

--INSERT-------------------------------------------------------
insert into EMPRESA VALUES(1,'duoc uc');
insert into EMPRESA VALUES(2,'inacap');

insert into ROL VALUES(1,1,'ADMINISTRADOR');
insert into ROL VALUES(2,1,'FUNCIONARIO');
insert into ROL VALUES(3,2,'ADMINISTRADOR');

insert into EMPLEADO VALUES(205533990,1,1,SYSDATE,'ISAIAS ANTIO','is.antio','1234');
insert into EMPLEADO VALUES(205533991,1,2,SYSDATE,'DIEGO FLORES','die.flores','1234');
insert into EMPLEADO VALUES(205533992,2,3,SYSDATE,'SEBASTIAN SANDOVAL','se.sandoval','1234');

insert into ESTADO VALUES(1,'FINALIZADO');
insert into ESTADO VALUES(2,'EN ESPERA');
insert into ESTADO VALUES(3,'POSTERGADO');
insert into ESTADO VALUES(4,'EN PROCESO');
insert into ESTADO VALUES(5,'DECLINADO');

INSERT INTO PROCESO VALUES(1,4,1,'VENTA DUOC',SYSDATE,'20/12/2022');
INSERT INTO PROCESO VALUES(2,4,2,'VENTA INACAP',SYSDATE,'20/12/2022');

INSERT INTO UNIDAD VALUES(1,1,2,1,'UNIDAD 1 DUOC',SYSDATE,'15/12/2022');
INSERT INTO UNIDAD VALUES(2,2,2,2,'UNIDAD 1 INACAP',SYSDATE,'15/12/2022');

INSERT INTO TAREA VALUES(1,1,5,1,'TAREA 1 DUOC',SYSDATE,'15/12/2022');
INSERT INTO TAREA VALUES(2,2,4,2,'TAREA 1 INACAP',SYSDATE,'15/12/2022');

INSERT INTO DETALLE_TAREA VALUES(1,205533990,1);
INSERT INTO DETALLE_TAREA VALUES(2,205533991,1);
INSERT INTO DETALLE_TAREA VALUES(3,205533992,2);

commit;

--SELECT-------------------------------------------------------

SELECT substr(to_char(id_rut,'99G999G9999'),1,11) ||'-'||substr(id_rut,-1) as rut ,nombre_emp,nombre_empresa,nombre_rol
from empleado
join empresa
on empresa.id_empresa = empleado.id_empresa_emp
join rol
on rol.id_rol = empleado.id_rol_emp
where empresa.id_empresa = 1;

select nombre_rol,nombre_empresa
from rol
join empresa
on empresa.id_empresa = rol.id_empresa_rol
where empresa.id_empresa = 2;

select nombre_empresa,nombre_proceso,nombre_unidad,nombre_tarea
from proceso
join unidad
on unidad.id_proceso_uni = proceso.id_proceso
join tarea
on tarea.id_unidad_tarea = unidad.id_unidad
join empresa
on empresa.id_empresa = tarea.id_empresa_tarea
where empresa.id_empresa = 1;

select nombre_emp,nombre_rol, nombre_tarea, nombre_unidad,nombre_proceso
from detalle_tarea
join empleado
on empleado.id_rut = detalle_tarea.id_rut_detalle
join rol
on rol.id_rol = empleado.id_rol_emp
join tarea
on tarea.id_tarea = detalle_tarea.id_tarea_detalle
join unidad
on unidad.id_unidad = tarea.id_unidad_tarea
join proceso
on proceso.id_proceso = unidad.id_proceso_uni;