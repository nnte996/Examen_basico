USE
BdiExamen
GO

CREATE table tblExamen (
idExamen int not null,
Nombre varchar(255),
Descripcion varchar(255)
primary key(idExamen)
)

INSERT INTO tblExamen VALUES (1, 'nico Torres','Ingeniero');  
GO
INSERT INTO tblExamen VALUES (2, 'Raul Iniguez' , 'Psicologo');  
GO  
INSERT INTO tblExamen VALUES (3, 'Lourdes', 'Contadora'); 
go  
INSERT INTO tblExamen VALUES (4, 'Luis', 'Programador');  
go  

select * from tblExamen

Create procedure crud
   (
   @idExamen INT,
   @Nombre VARCHAR(255) = NULL,  
   @Descripcion VARCHAR(255) = NULL,  
   @Statementtype nvarchar(200) = ''  
   )
   AS
   
   BEGIN  
	IF @Statementtype = 'spAgregar'
	BEGIN  
		Insert into tblExamen(idExamen, Nombre, Descripcion) values (@idExamen, @Nombre, @Descripcion)  
	END  
	IF @Statementtype = 'spConsultar'
	BEGIN  
		SELECT idExamen, Nombre, Descripcion FROM tblExamen WHERE (idExamen = @idExamen)
	END  
	IF @Statementtype = 'spActualizar'
	BEGIN
		UPDATE tblExamen SET
			Nombre = @Nombre, 
			Descripcion = @Descripcion		
		WHERE idExamen = @idExamen
	END  
	IF @Statementtype = 'spEliminar'  
	BEGIN  
		Delete from tblExamen Where idExamen = @idExamen
	END
END
---------------------------------------------------------
EXEC crud
	5, 'Noe Torres Escobar', 'Ingeniero Mecatronico', 'spAgregar'
	
EXEC crud
	1, 'Noe Nicolas Torres Escobar', 'Ingeniero Desarrollador de Software', 'spActualizar'
	
EXEC crud
	@idExamen = 5, @statementtype = 'spEliminar'
	
EXEC crud
    @idExamen = 1, @statementtype = 'spConsultar'