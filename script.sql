USE [GD1C2015]
GO
/****** Object:  Schema [NN]    Script Date: 06/15/2015 15:25:45 ******/
CREATE SCHEMA [NN] AUTHORIZATION [gd]
GO
/****** Object:  Table [NN].[Usuario]    Script Date: 06/15/2015 15:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NN].[Usuario](
	[Usu_Id] [int] IDENTITY(1,1) NOT NULL,
	[Usu_Nombre] [varchar](50) NULL,
	[Usu_Password] [varchar](50) NULL,
	[Usu_Pregunta] [varchar](50) NULL,
	[Usu_Respuesta] [varchar](50) NULL,
	[Usu_Activo] [bit] NULL,
	[Usu_Intentos] [int] NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Usu_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_Nombre] UNIQUE NONCLUSTERED 
(
	[Usu_Nombre] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [NN].[Transferencias]    Script Date: 06/15/2015 15:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [NN].[Transferencias](
	[Trans_Id] [int] IDENTITY(1,1) NOT NULL,
	[Cuenta_Origen] [numeric](18, 0) NULL,
	[Cuenta_Dest_Numero] [numeric](18, 0) NULL,
	[Transf_Fecha] [datetime] NULL,
	[Trans_Importe] [numeric](18, 2) NULL,
	[Trans_Costo_Trans] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Transferencias] PRIMARY KEY CLUSTERED 
(
	[Trans_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [NN].[Tipo_de_Cuentas]    Script Date: 06/15/2015 15:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NN].[Tipo_de_Cuentas](
	[tipo_de_cuenta_cod] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[tipo_de_cuenta_desc] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Tipo_de_Cuentas] PRIMARY KEY CLUSTERED 
(
	[tipo_de_cuenta_cod] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [NN].[Cheques]    Script Date: 06/15/2015 15:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [NN].[Cheques](
	[Cheque_Id] [int] IDENTITY(1,1) NOT NULL,
	[Cheque_Numero] [numeric](18, 0) NULL,
	[Cheque_Fecha] [datetime] NULL,
	[Cheque_Importe] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Cheques] PRIMARY KEY CLUSTERED 
(
	[Cheque_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [NN].[Bancos]    Script Date: 06/15/2015 15:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NN].[Bancos](
	[Banco_Codigo] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Banco_Nombre] [varchar](255) NULL,
	[Banco_Direccion] [varchar](255) NULL,
 CONSTRAINT [PK_Bancos] PRIMARY KEY CLUSTERED 
(
	[Banco_Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [NN].[Funcionalidad]    Script Date: 06/15/2015 15:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NN].[Funcionalidad](
	[Func_Id] [int] IDENTITY(1,1) NOT NULL,
	[Func_Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Funcionalidad] PRIMARY KEY CLUSTERED 
(
	[Func_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [NN].[Documentos]    Script Date: 06/15/2015 15:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NN].[Documentos](
	[Tipo_Doc_Cod] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Tipo_Doc_Desc] [varchar](255) NULL,
 CONSTRAINT [PK_Documentos] PRIMARY KEY CLUSTERED 
(
	[Tipo_Doc_Cod] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [NN].[Rol]    Script Date: 06/15/2015 15:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NN].[Rol](
	[Rol_Id] [int] IDENTITY(1,1) NOT NULL,
	[Rol_Nombre] [varchar](50) NULL,
	[Rol_Activo] [bit] NULL,
 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED 
(
	[Rol_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [NN].[Retiros]    Script Date: 06/15/2015 15:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [NN].[Retiros](
	[Retiro_Id] [int] IDENTITY(1,1) NOT NULL,
	[Cuenta_Numero] [numeric](18, 0) NULL,
	[Retiro_Fecha] [datetime] NULL,
	[Retiro_Codigo] [numeric](18, 0) NULL,
	[Retiro_Importe] [numeric](18, 2) NULL,
	[Cheque_Numero] [numeric](18, 0) NULL,
	[Banco_Codigo] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Retiros] PRIMARY KEY CLUSTERED 
(
	[Retiro_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [NN].[Paises]    Script Date: 06/15/2015 15:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NN].[Paises](
	[Pais_codigo] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Pais_desc] [varchar](250) NULL,
 CONSTRAINT [PK_Paises] PRIMARY KEY CLUSTERED 
(
	[Pais_codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [NN].[Login]    Script Date: 06/15/2015 15:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NN].[Login](
	[Login_Id] [int] IDENTITY(1,1) NOT NULL,
	[Login_UsuarioId] [int] NULL,
	[Login_Usuario] [varchar](50) NULL,
	[Login_Fecha] [datetime] NULL,
	[Login_Exitoso] [bit] NULL,
	[Login_UsuarioActivo] [bit] NULL,
	[Login_Intentos] [int] NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[Login_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [NN].[FuncionalidadXRol]    Script Date: 06/15/2015 15:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [NN].[FuncionalidadXRol](
	[Func_Id] [int] NOT NULL,
	[Rol_Id] [int] NOT NULL,
 CONSTRAINT [PK_FuncionalidadXRol] PRIMARY KEY CLUSTERED 
(
	[Func_Id] ASC,
	[Rol_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [NN].[Clientes]    Script Date: 06/15/2015 15:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NN].[Clientes](
	[Cli_Id] [int] IDENTITY(1,1) NOT NULL,
	[Cli_Pais_Codigo] [numeric](18, 0) NULL,
	[Cli_Nombre] [varchar](255) NULL,
	[Cli_Apellido] [varchar](255) NULL,
	[Cli_Tipo_Doc_Cod] [numeric](18, 0) NULL,
	[Cli_Nro_Doc] [numeric](18, 0) NULL,
	[Cli_Dom_Calle] [varchar](255) NULL,
	[Cli_Dom_Nro] [numeric](18, 0) NULL,
	[Cli_Dom_Piso] [numeric](18, 0) NULL,
	[Cli_Dom_Depto] [varchar](10) NULL,
	[Cli_Fecha_Nac] [datetime] NULL,
	[Cli_Mail] [varchar](255) NULL,
	[Cli_Usuario] [int] NULL,
	[Cli_Localidad] [varchar](50) NULL,
	[Cli_Nacionalidad] [varchar](50) NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Cli_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [NN].[RolXUsuario]    Script Date: 06/15/2015 15:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [NN].[RolXUsuario](
	[Usu_Id] [int] NOT NULL,
	[Rol_Id] [int] NOT NULL,
 CONSTRAINT [PK_RolXUsuario] PRIMARY KEY CLUSTERED 
(
	[Usu_Id] ASC,
	[Rol_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [NN].[Tarjetas]    Script Date: 06/15/2015 15:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NN].[Tarjetas](
	[Tarjeta_Id] [int] IDENTITY(1,1) NOT NULL,
	[Cli_Id] [int] NULL,
	[Cli_Nro_Doc] [numeric](18, 0) NULL,
	[Tarjeta_Numero] [varchar](16) NULL,
	[Tarjeta_Codigo_Seg] [varchar](3) NULL,
	[Tarjeta_Emisor_Descripcion] [varchar](255) NULL,
	[Tarjeta_Fecha_Emision] [datetime] NULL,
	[Tarjeta_Fecha_Vencimiento] [datetime] NULL,
 CONSTRAINT [PK_Tarjetas] PRIMARY KEY CLUSTERED 
(
	[Tarjeta_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [NN].[Cuentas]    Script Date: 06/15/2015 15:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NN].[Cuentas](
	[Cuenta_Id] [int] IDENTITY(1,1) NOT NULL,
	[Cli_Id] [int] NULL,
	[Cli_Nro_Doc] [numeric](18, 0) NULL,
	[Cuenta_Numero] [numeric](18, 0) NULL,
	[Cuenta_Fecha_Creacion] [datetime] NULL,
	[Cuenta_Pais_Codigo] [numeric](18, 0) NULL,
	[Cuenta_Estado] [varchar](255) NULL,
	[Cuenta_Fecha_Cierre] [datetime] NULL,
	[tipo_de_cuenta_cod] [decimal](18, 0) NULL,
	[tipo_moneda_cod] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Cuentas] PRIMARY KEY CLUSTERED 
(
	[Cuenta_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [NN].[Depositos]    Script Date: 06/15/2015 15:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NN].[Depositos](
	[Deposito_Id] [int] IDENTITY(1,1) NOT NULL,
	[Deposito_Codigo] [numeric](18, 0) NULL,
	[Cli_Id] [int] NULL,
	[Cli_Nro_Doc] [numeric](18, 0) NULL,
	[Deposito_Fecha] [datetime] NULL,
	[Deposito_Importe] [numeric](18, 2) NULL,
	[Tarjeta_Id] [int] NULL,
	[Tarjeta_Numero] [varchar](16) NULL,
 CONSTRAINT [PK_Depositos] PRIMARY KEY CLUSTERED 
(
	[Deposito_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_Clientes_Documentos]    Script Date: 06/15/2015 15:25:46 ******/
ALTER TABLE [NN].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Documentos] FOREIGN KEY([Cli_Tipo_Doc_Cod])
REFERENCES [NN].[Documentos] ([Tipo_Doc_Cod])
GO
ALTER TABLE [NN].[Clientes] CHECK CONSTRAINT [FK_Clientes_Documentos]
GO
/****** Object:  ForeignKey [FK_Clientes_Usuario]    Script Date: 06/15/2015 15:25:46 ******/
ALTER TABLE [NN].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Usuario] FOREIGN KEY([Cli_Pais_Codigo])
REFERENCES [NN].[Paises] ([Pais_codigo])
GO
ALTER TABLE [NN].[Clientes] CHECK CONSTRAINT [FK_Clientes_Usuario]
GO
/****** Object:  ForeignKey [FK_Cuentas_Clientes]    Script Date: 06/15/2015 15:25:46 ******/
ALTER TABLE [NN].[Cuentas]  WITH CHECK ADD  CONSTRAINT [FK_Cuentas_Clientes] FOREIGN KEY([Cli_Id])
REFERENCES [NN].[Clientes] ([Cli_Id])
GO
ALTER TABLE [NN].[Cuentas] CHECK CONSTRAINT [FK_Cuentas_Clientes]
GO
/****** Object:  ForeignKey [FK_Depositos_Clientes]    Script Date: 06/15/2015 15:25:46 ******/
ALTER TABLE [NN].[Depositos]  WITH CHECK ADD  CONSTRAINT [FK_Depositos_Clientes] FOREIGN KEY([Cli_Id])
REFERENCES [NN].[Clientes] ([Cli_Id])
GO
ALTER TABLE [NN].[Depositos] CHECK CONSTRAINT [FK_Depositos_Clientes]
GO
/****** Object:  ForeignKey [FK_Depositos_Tarjetas]    Script Date: 06/15/2015 15:25:46 ******/
ALTER TABLE [NN].[Depositos]  WITH CHECK ADD  CONSTRAINT [FK_Depositos_Tarjetas] FOREIGN KEY([Tarjeta_Id])
REFERENCES [NN].[Tarjetas] ([Tarjeta_Id])
GO
ALTER TABLE [NN].[Depositos] CHECK CONSTRAINT [FK_Depositos_Tarjetas]
GO
/****** Object:  ForeignKey [FK_FuncionalidadXRol_Funcionalidad]    Script Date: 06/15/2015 15:25:46 ******/
ALTER TABLE [NN].[FuncionalidadXRol]  WITH CHECK ADD  CONSTRAINT [FK_FuncionalidadXRol_Funcionalidad] FOREIGN KEY([Func_Id])
REFERENCES [NN].[Funcionalidad] ([Func_Id])
GO
ALTER TABLE [NN].[FuncionalidadXRol] CHECK CONSTRAINT [FK_FuncionalidadXRol_Funcionalidad]
GO
/****** Object:  ForeignKey [FK_FuncionalidadXRol_Rol]    Script Date: 06/15/2015 15:25:46 ******/
ALTER TABLE [NN].[FuncionalidadXRol]  WITH CHECK ADD  CONSTRAINT [FK_FuncionalidadXRol_Rol] FOREIGN KEY([Rol_Id])
REFERENCES [NN].[Rol] ([Rol_Id])
GO
ALTER TABLE [NN].[FuncionalidadXRol] CHECK CONSTRAINT [FK_FuncionalidadXRol_Rol]
GO
/****** Object:  ForeignKey [FK_Login_Usuario1]    Script Date: 06/15/2015 15:25:46 ******/
ALTER TABLE [NN].[Login]  WITH CHECK ADD  CONSTRAINT [FK_Login_Usuario1] FOREIGN KEY([Login_UsuarioId])
REFERENCES [NN].[Usuario] ([Usu_Id])
GO
ALTER TABLE [NN].[Login] CHECK CONSTRAINT [FK_Login_Usuario1]
GO
/****** Object:  ForeignKey [FK_RolXUsuario_Rol]    Script Date: 06/15/2015 15:25:46 ******/
ALTER TABLE [NN].[RolXUsuario]  WITH CHECK ADD  CONSTRAINT [FK_RolXUsuario_Rol] FOREIGN KEY([Rol_Id])
REFERENCES [NN].[Rol] ([Rol_Id])
GO
ALTER TABLE [NN].[RolXUsuario] CHECK CONSTRAINT [FK_RolXUsuario_Rol]
GO
/****** Object:  ForeignKey [FK_RolXUsuario_Usuario]    Script Date: 06/15/2015 15:25:46 ******/
ALTER TABLE [NN].[RolXUsuario]  WITH CHECK ADD  CONSTRAINT [FK_RolXUsuario_Usuario] FOREIGN KEY([Usu_Id])
REFERENCES [NN].[Usuario] ([Usu_Id])
GO
ALTER TABLE [NN].[RolXUsuario] CHECK CONSTRAINT [FK_RolXUsuario_Usuario]
GO
/****** Object:  ForeignKey [FK_Tarjetas_Clientes]    Script Date: 06/15/2015 15:25:46 ******/
ALTER TABLE [NN].[Tarjetas]  WITH CHECK ADD  CONSTRAINT [FK_Tarjetas_Clientes] FOREIGN KEY([Cli_Id])
REFERENCES [NN].[Clientes] ([Cli_Id])
GO
ALTER TABLE [NN].[Tarjetas] CHECK CONSTRAINT [FK_Tarjetas_Clientes]
GO


-- CREAR TABLA DE PAISES

insert into NN.Paises
select distinct cli_pais_desc Pais_desc 
from gd_esquema.Maestra

-- CREA TABLA DE DOCUMENTOS

INSERT INTO nn.Documentos VALUES ('DNI')
INSERT INTO nn.Documentos VALUES ('LE')
INSERT INTO nn.Documentos VALUES ('LC')
insert into nn.Documentos
select distinct Cli_Tipo_Doc_Desc 
from gd_esquema.Maestra

-- CREA TABLA DE CLIENTES

insert into nn.Clientes
select distinct (select Pais_codigo from nn.Paises where Pais_Desc = Cli_Pais_Desc), Cli_Nombre, Cli_Apellido, (select Tipo_Doc_Cod from nn.Documentos where Tipo_Doc_Desc = Cli_Tipo_Doc_Desc), Cli_Nro_Doc, Cli_Dom_Calle, Cli_Dom_Nro, Cli_Dom_Piso, Cli_Dom_Depto, Cli_Fecha_Nac, Cli_Mail, null, null, null
from gd_esquema.Maestra

-- CREA TABLA DE TIPO DE CUENTAS

insert into nn.Tipo_de_Cuentas values ('Oro')
insert into nn.Tipo_de_Cuentas values ('Plata')
insert into nn.Tipo_de_Cuentas values ('Bronce')
insert into nn.Tipo_de_Cuentas values ('Gratuita')

-- CREA TABLA DE CUENTAS

insert into nn.Cuentas
select distinct null, Cli_Nro_Doc, Cuenta_Numero, Cuenta_Fecha_Creacion, Cuenta_Pais_Codigo, Cuenta_Estado, Cuenta_Fecha_Cierre, null, null
from gd_esquema.Maestra

-- CREA TABLA DEPOSITOS

insert into nn.Depositos
select distinct Deposito_Codigo, null, Cli_Nro_Doc, Deposito_Fecha, Deposito_Importe, null, Tarjeta_Numero
from gd_esquema.Maestra
where Cli_Nro_Doc is not null and Deposito_Codigo is not null and Deposito_Fecha is not null and Deposito_Importe is not null and Tarjeta_Numero is not  null

-- CREA TARJETAS

insert into nn.Tarjetas
select distinct null, Cli_Nro_Doc, Tarjeta_Numero, Tarjeta_Codigo_Seg, Tarjeta_Emisor_Descripcion, Tarjeta_Fecha_Emision, Tarjeta_Fecha_Vencimiento
from gd_esquema.Maestra

-- CREA TABLA DE Transferencias

insert into nn.Transferencias
select distinct Cuenta_Numero Cuenta_Origen, Cuenta_Dest_Numero, Transf_Fecha, Trans_Importe, Trans_Costo_Trans
from gd_esquema.Maestra

-- CREA TABLA DE BANCOS

insert into nn.Bancos
select distinct Banco_Nombre, Banco_Direccion 
from gd_esquema.Maestra
where Banco_Cogido is not null and Banco_Nombre is not null and Banco_Direccion is not null
 
-- CREA TABLA RETIROS

insert into nn.Retiros
select distinct Cuenta_Numero, Retiro_Fecha, Retiro_Codigo, Retiro_Importe, Cheque_Numero, Banco_Cogido Banco_Codigo
from gd_esquema.Maestra
where Cuenta_Numero is not null and Retiro_Codigo is not null
 
-- CREA TABLA CHEQUES

insert into nn.Cheques
select distinct Cheque_Numero, Cheque_Fecha, Cheque_Importe
from gd_esquema.Maestra

-- CREA TABLA ROL

insert into nn.rol (Rol_Nombre, Rol_Activo) values ('Administrador', 1)
insert into nn.rol (Rol_Nombre, Rol_Activo) values ('Cliente', 1)

-- CREA TABLA FUNCIONALIDAD

insert into nn.Funcionalidad values ('ABM Roles')
insert into nn.Funcionalidad values ('ABM Clientes')
insert into nn.Funcionalidad values ('ABM Cuentas')
insert into nn.Funcionalidad values ('ABM Usuarios')

-- CREA TABLA USUARIO

INSERT INTO nn.Usuario (Usu_Nombre, Usu_Password, Usu_Activo) VALUES ('admin', '5rhwUL/LgUP8uNsBcKTcntANkE3dPipK0bHo3A/cm+c=', 1)
update nn.Usuario set usu_intentos = 0

-- CREA TABLA RolXUsuario

INSERT INTO nn.RolXUsuario (Usu_Id, Rol_Id) VALUES ((select Usu_Id from nn.Usuario where Usu_Nombre = 'admin'), (select Rol_Id from nn.Rol where Rol_Nombre = 'Administrador'))
