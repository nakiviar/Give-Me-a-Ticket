use Negocios2018;


	-- Listar Clientes y Paises

	create procedure sp_clientes
	as
	select * from tb_clientes;
	go

	create procedure sp_paises
	as
	select * from tb_paises;
	go

	-- Agregar
	create procedure sp_agregar
	@id varchar(10),
	@nombre varchar(150),
	@dir varchar(150),
	@pais varchar(3),
	@fono varchar(50)
	as
	Insert tb_clientes Values(dbo.GenerarCodigo(),@nombre,@dir,@pais,@fono)
	go

	-- Actualizar
	create procedure sp_actualizar
	@id varchar(10),
	@nombre varchar(150),
	@dir varchar(150),
	@pais varchar(3),
	@fono varchar(50)
	as
	Update tb_clientes 
	Set nombrecia=@nombre,direccion=@dir,idpais=@pais,
	telefono=@fono 
	Where idcliente=@id
	go


	-- Funcion que genere un codigo autogenerado
	-- C9999
	drop function GenerarCodigo;

	CREATE FUNCTION GenerarCodigo()
	RETURNS VARCHAR(5)
	AS
		BEGIN 
			DECLARE @c INT
				select @c = count(*) from tb_clientes;
			if(@c > 0 AND @c < 10 )
			return Concat('C','000',@c);
			if(@c< 100 )
			return Concat('C','00',@c);
			if(@c < 1000 )
			return Concat('C','0',@c);
			if(@c < 10000 )
			return Concat('C',@c);		
			SET @c = @c +1;
			return 'xxxxx'
		END
	GO

	use Negocios2018;
	select dbo.GenerarCodigo() ;

