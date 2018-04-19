/*
Plantilla de script posterior a la implementación							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se anexarán al script de compilación.		
 Use la sintaxis de SQLCMD para incluir un archivo en el script posterior a la implementación.			
 Ejemplo:      :r .\miArchivo.sql								
 Use la sintaxis de SQLCMD para hacer referencia a una variable en el script posterior a la implementación.		
 Ejemplo:      :setvar TableName miTabla							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

/* cargar las tablas con los datos basicos para su funcionalidad y pruebas */
INSERT INTO AreaTerapeutica (Descripcion, Visible) VALUES ('CAR',1);
INSERT INTO AreaTerapeutica (Descripcion, Visible) VALUES ('CNC',1);
INSERT INTO AreaTerapeutica (Descripcion, Visible) VALUES ('COX2',1);

INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Algólogos',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Anestesiólogos',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Cardiologos',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Cirujanos',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Endocrinologos',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Farmaceuticos',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Ginecologos',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Hematologos',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Infectologos',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Intensivistas',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Generales',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Internistas',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Nefrologos',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Neumologos',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Oftalmologos',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Oncologos',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Ortopedistas',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Otorrinolaringologos',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Pediatras',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Psiquiatras',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Reumatologos',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Traumatologos',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Urologos',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Fuerza de Ventas',1);
INSERT INTO Audiencia (Descripcion, Visible) VALUES ('Reformadores',1);

