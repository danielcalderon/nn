USE [GD1C2015]
GO
/****** Object:  Schema [NN]    Script Date: 06/27/2015 18:31:53 ******/
CREATE SCHEMA [NN] AUTHORIZATION [gd]
GO
/****** Object:  Table [NN].[Rol]    Script Date: 06/27/2015 18:31:53 ******/
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
/****** Object:  Table [NN].[Tipo_de_Cuentas]    Script Date: 06/27/2015 18:31:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NN].[Tipo_de_Cuentas](
	[tipo_de_cuenta_cod] [decimal](18, 0) IDENTITY(1,1) NOT NULL,
	[tipo_de_cuenta_desc] [varchar](50) NOT NULL,
	[tipo_de_cuenta_dias] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Tipo_de_Cuentas] PRIMARY KEY CLUSTERED 
(
	[tipo_de_cuenta_cod] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [NN].[Usuario]    Script Date: 06/27/2015 18:31:53 ******/
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
/****** Object:  Table [NN].[Bancos]    Script Date: 06/27/2015 18:31:53 ******/
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
/****** Object:  Table [NN].[Funcionalidad]    Script Date: 06/27/2015 18:31:53 ******/
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
/****** Object:  Table [NN].[Emisores]    Script Date: 06/27/2015 18:31:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NN].[Emisores](
	[Emisor_Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Emisor_Desc] [varchar](255) NULL,
 CONSTRAINT [PK_Emisores] PRIMARY KEY CLUSTERED 
(
	[Emisor_Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [NN].[Documentos]    Script Date: 06/27/2015 18:31:53 ******/
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
/****** Object:  Table [NN].[Paises]    Script Date: 06/27/2015 18:31:53 ******/
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
/****** Object:  Table [NN].[Monedas]    Script Date: 06/27/2015 18:31:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [NN].[Monedas](
	[Monedas_Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Monedas_Desc] [nvarchar](50) NULL,
 CONSTRAINT [PK_Monedas] PRIMARY KEY CLUSTERED 
(
	[Monedas_Codigo] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [NN].[Login]    Script Date: 06/27/2015 18:31:53 ******/
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
/****** Object:  Table [NN].[FuncionalidadXRol]    Script Date: 06/27/2015 18:31:53 ******/
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
/****** Object:  Table [NN].[Clientes]    Script Date: 06/27/2015 18:31:53 ******/
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
	[Cli_Activo] [bit] NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Cli_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [NN].[RolXUsuario]    Script Date: 06/27/2015 18:31:53 ******/
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
/****** Object:  Table [NN].[Tarjetas]    Script Date: 06/27/2015 18:31:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NN].[Tarjetas](
	[Tarjeta_Id] [int] IDENTITY(1,1) NOT NULL,
	[Cli_Id] [int] NULL,
	[Tarjeta_Numero] [varchar](16) NULL,
	[Tarjeta_Codigo_Seg] [varchar](3) NULL,
	[Tarjeta_Emisor_Codigo] [int] NULL,
	[Tarjeta_Fecha_Emision] [datetime] NULL,
	[Tarjeta_Fecha_Vencimiento] [datetime] NULL,
	[Tarjeta_Activo] [bit] NULL,
 CONSTRAINT [PK_Tarjetas] PRIMARY KEY CLUSTERED 
(
	[Tarjeta_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [NN].[Cuentas]    Script Date: 06/27/2015 18:31:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [NN].[Cuentas](
	[Cuenta_Id] [int] IDENTITY(1,1) NOT NULL,
	[Cli_Id] [int] NULL,
	[Cuenta_Numero] [numeric](18, 0) NULL,
	[Cuenta_Fecha_Creacion] [datetime] NULL,
	[Cuenta_Pais_Codigo] [numeric](18, 0) NULL,
	[Cuenta_Estado] [varchar](255) NULL,
	[Cuenta_Fecha_Cierre] [datetime] NULL,
	[tipo_de_cuenta_cod] [decimal](18, 0) NULL,
	[tipo_moneda_cod] [decimal](18, 0) NULL,
	[Cuenta_Saldo] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Cuentas] PRIMARY KEY CLUSTERED 
(
	[Cuenta_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [NN].[Depositos]    Script Date: 06/27/2015 18:31:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [NN].[Depositos](
	[Deposito_Id] [int] IDENTITY(1,1) NOT NULL,
	[Deposito_Codigo] [numeric](18, 0) NULL,
	[Cli_Id] [int] NULL,
	[Cuenta_Id] [int] NULL,
	[Deposito_Fecha] [datetime] NULL,
	[Deposito_Importe] [numeric](18, 2) NULL,
	[Tarjeta_Id] [int] NULL,
	[Moneda_Codigo] [int] NULL,
 CONSTRAINT [PK_Depositos] PRIMARY KEY CLUSTERED 
(
	[Deposito_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [NN].[Cheques]    Script Date: 06/27/2015 18:31:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [NN].[Cheques](
	[Cheque_Id] [int] IDENTITY(1,1) NOT NULL,
	[Cheque_Numero] [numeric](18, 0) NULL,
	[Cheque_Fecha] [datetime] NULL,
	[Cheque_Importe] [numeric](18, 2) NULL,
	[Cuenta_Id] [int] NULL,
	[Cheque_Cobrado] [bit] NULL,
 CONSTRAINT [PK_Cheques] PRIMARY KEY CLUSTERED 
(
	[Cheque_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [NN].[Transferencias]    Script Date: 06/27/2015 18:31:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [NN].[Transferencias](
	[Trans_Id] [int] IDENTITY(1,1) NOT NULL,
	[Cuenta_Origen] [int] NULL,
	[Cuenta_Destino] [int] NULL,
	[Transf_Fecha] [datetime] NULL,
	[Trans_Importe] [numeric](18, 2) NULL,
	[Trans_Costo_Trans] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Transferencias] PRIMARY KEY CLUSTERED 
(
	[Trans_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [NN].[Retiros]    Script Date: 06/27/2015 18:31:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [NN].[Retiros](
	[Retiro_Id] [int] IDENTITY(1,1) NOT NULL,
	[Cuenta_Id] [int] NULL,
	[Cheque_Id] [int] NULL,
	[Retiro_Fecha] [datetime] NULL,
	[Retiro_Codigo] [numeric](18, 0) NULL,
	[Retiro_Importe] [numeric](18, 2) NULL,
	[Banco_Codigo] [numeric](18, 0) NULL,
 CONSTRAINT [PK_Retiros] PRIMARY KEY CLUSTERED 
(
	[Retiro_Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF_Clientes_Cli_Activo]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[Clientes] ADD  CONSTRAINT [DF_Clientes_Cli_Activo]  DEFAULT ((1)) FOR [Cli_Activo]
GO
/****** Object:  ForeignKey [FK_Cheques_Cuentas]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[Cheques]  WITH CHECK ADD  CONSTRAINT [FK_Cheques_Cuentas] FOREIGN KEY([Cuenta_Id])
REFERENCES [NN].[Cuentas] ([Cuenta_Id])
GO
ALTER TABLE [NN].[Cheques] CHECK CONSTRAINT [FK_Cheques_Cuentas]
GO
/****** Object:  ForeignKey [FK_Clientes_Documentos]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Documentos] FOREIGN KEY([Cli_Tipo_Doc_Cod])
REFERENCES [NN].[Documentos] ([Tipo_Doc_Cod])
GO
ALTER TABLE [NN].[Clientes] CHECK CONSTRAINT [FK_Clientes_Documentos]
GO
/****** Object:  ForeignKey [FK_Clientes_Paises]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Paises] FOREIGN KEY([Cli_Pais_Codigo])
REFERENCES [NN].[Paises] ([Pais_codigo])
GO
ALTER TABLE [NN].[Clientes] CHECK CONSTRAINT [FK_Clientes_Paises]
GO
/****** Object:  ForeignKey [FK_Clientes_Usuario]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[Clientes]  WITH CHECK ADD  CONSTRAINT [FK_Clientes_Usuario] FOREIGN KEY([Cli_Usuario])
REFERENCES [NN].[Usuario] ([Usu_Id])
GO
ALTER TABLE [NN].[Clientes] CHECK CONSTRAINT [FK_Clientes_Usuario]
GO
/****** Object:  ForeignKey [FK_Cuentas_Clientes]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[Cuentas]  WITH CHECK ADD  CONSTRAINT [FK_Cuentas_Clientes] FOREIGN KEY([Cli_Id])
REFERENCES [NN].[Clientes] ([Cli_Id])
GO
ALTER TABLE [NN].[Cuentas] CHECK CONSTRAINT [FK_Cuentas_Clientes]
GO
/****** Object:  ForeignKey [FK_Cuentas_Paises]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[Cuentas]  WITH CHECK ADD  CONSTRAINT [FK_Cuentas_Paises] FOREIGN KEY([Cuenta_Pais_Codigo])
REFERENCES [NN].[Paises] ([Pais_codigo])
GO
ALTER TABLE [NN].[Cuentas] CHECK CONSTRAINT [FK_Cuentas_Paises]
GO
/****** Object:  ForeignKey [FK_Cuentas_Tipo_de_Cuentas]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[Cuentas]  WITH CHECK ADD  CONSTRAINT [FK_Cuentas_Tipo_de_Cuentas] FOREIGN KEY([tipo_de_cuenta_cod])
REFERENCES [NN].[Tipo_de_Cuentas] ([tipo_de_cuenta_cod])
GO
ALTER TABLE [NN].[Cuentas] CHECK CONSTRAINT [FK_Cuentas_Tipo_de_Cuentas]
GO
/****** Object:  ForeignKey [FK_Depositos_Clientes]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[Depositos]  WITH CHECK ADD  CONSTRAINT [FK_Depositos_Clientes] FOREIGN KEY([Cli_Id])
REFERENCES [NN].[Clientes] ([Cli_Id])
GO
ALTER TABLE [NN].[Depositos] CHECK CONSTRAINT [FK_Depositos_Clientes]
GO
/****** Object:  ForeignKey [FK_Depositos_Cuentas]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[Depositos]  WITH CHECK ADD  CONSTRAINT [FK_Depositos_Cuentas] FOREIGN KEY([Cuenta_Id])
REFERENCES [NN].[Cuentas] ([Cuenta_Id])
GO
ALTER TABLE [NN].[Depositos] CHECK CONSTRAINT [FK_Depositos_Cuentas]
GO
/****** Object:  ForeignKey [FK_Depositos_Monedas]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[Depositos]  WITH CHECK ADD  CONSTRAINT [FK_Depositos_Monedas] FOREIGN KEY([Moneda_Codigo])
REFERENCES [NN].[Monedas] ([Monedas_Codigo])
GO
ALTER TABLE [NN].[Depositos] CHECK CONSTRAINT [FK_Depositos_Monedas]
GO
/****** Object:  ForeignKey [FK_Depositos_Tarjetas]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[Depositos]  WITH CHECK ADD  CONSTRAINT [FK_Depositos_Tarjetas] FOREIGN KEY([Tarjeta_Id])
REFERENCES [NN].[Tarjetas] ([Tarjeta_Id])
GO
ALTER TABLE [NN].[Depositos] CHECK CONSTRAINT [FK_Depositos_Tarjetas]
GO
/****** Object:  ForeignKey [FK_FuncionalidadXRol_Funcionalidad]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[FuncionalidadXRol]  WITH CHECK ADD  CONSTRAINT [FK_FuncionalidadXRol_Funcionalidad] FOREIGN KEY([Func_Id])
REFERENCES [NN].[Funcionalidad] ([Func_Id])
GO
ALTER TABLE [NN].[FuncionalidadXRol] CHECK CONSTRAINT [FK_FuncionalidadXRol_Funcionalidad]
GO
/****** Object:  ForeignKey [FK_FuncionalidadXRol_Rol]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[FuncionalidadXRol]  WITH CHECK ADD  CONSTRAINT [FK_FuncionalidadXRol_Rol] FOREIGN KEY([Rol_Id])
REFERENCES [NN].[Rol] ([Rol_Id])
GO
ALTER TABLE [NN].[FuncionalidadXRol] CHECK CONSTRAINT [FK_FuncionalidadXRol_Rol]
GO
/****** Object:  ForeignKey [FK_Login_Usuario1]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[Login]  WITH CHECK ADD  CONSTRAINT [FK_Login_Usuario1] FOREIGN KEY([Login_UsuarioId])
REFERENCES [NN].[Usuario] ([Usu_Id])
GO
ALTER TABLE [NN].[Login] CHECK CONSTRAINT [FK_Login_Usuario1]
GO
/****** Object:  ForeignKey [FK_Retiros_Bancos]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[Retiros]  WITH CHECK ADD  CONSTRAINT [FK_Retiros_Bancos] FOREIGN KEY([Banco_Codigo])
REFERENCES [NN].[Bancos] ([Banco_Codigo])
GO
ALTER TABLE [NN].[Retiros] CHECK CONSTRAINT [FK_Retiros_Bancos]
GO
/****** Object:  ForeignKey [FK_Retiros_Cheques]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[Retiros]  WITH CHECK ADD  CONSTRAINT [FK_Retiros_Cheques] FOREIGN KEY([Cheque_Id])
REFERENCES [NN].[Cheques] ([Cheque_Id])
GO
ALTER TABLE [NN].[Retiros] CHECK CONSTRAINT [FK_Retiros_Cheques]
GO
/****** Object:  ForeignKey [FK_Retiros_Cuentas]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[Retiros]  WITH CHECK ADD  CONSTRAINT [FK_Retiros_Cuentas] FOREIGN KEY([Cuenta_Id])
REFERENCES [NN].[Cuentas] ([Cuenta_Id])
GO
ALTER TABLE [NN].[Retiros] CHECK CONSTRAINT [FK_Retiros_Cuentas]
GO
/****** Object:  ForeignKey [FK_RolXUsuario_Rol]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[RolXUsuario]  WITH CHECK ADD  CONSTRAINT [FK_RolXUsuario_Rol] FOREIGN KEY([Rol_Id])
REFERENCES [NN].[Rol] ([Rol_Id])
GO
ALTER TABLE [NN].[RolXUsuario] CHECK CONSTRAINT [FK_RolXUsuario_Rol]
GO
/****** Object:  ForeignKey [FK_RolXUsuario_Usuario]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[RolXUsuario]  WITH CHECK ADD  CONSTRAINT [FK_RolXUsuario_Usuario] FOREIGN KEY([Usu_Id])
REFERENCES [NN].[Usuario] ([Usu_Id])
GO
ALTER TABLE [NN].[RolXUsuario] CHECK CONSTRAINT [FK_RolXUsuario_Usuario]
GO
/****** Object:  ForeignKey [FK_Tarjetas_Clientes]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[Tarjetas]  WITH CHECK ADD  CONSTRAINT [FK_Tarjetas_Clientes] FOREIGN KEY([Cli_Id])
REFERENCES [NN].[Clientes] ([Cli_Id])
GO
ALTER TABLE [NN].[Tarjetas] CHECK CONSTRAINT [FK_Tarjetas_Clientes]
GO
/****** Object:  ForeignKey [FK_Tarjetas_Emisores]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[Tarjetas]  WITH CHECK ADD  CONSTRAINT [FK_Tarjetas_Emisores] FOREIGN KEY([Tarjeta_Emisor_Codigo])
REFERENCES [NN].[Emisores] ([Emisor_Codigo])
GO
ALTER TABLE [NN].[Tarjetas] CHECK CONSTRAINT [FK_Tarjetas_Emisores]
GO
/****** Object:  ForeignKey [FK_Transferencias_Cuentas_Destino]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[Transferencias]  WITH CHECK ADD  CONSTRAINT [FK_Transferencias_Cuentas_Destino] FOREIGN KEY([Cuenta_Destino])
REFERENCES [NN].[Cuentas] ([Cuenta_Id])
GO
ALTER TABLE [NN].[Transferencias] CHECK CONSTRAINT [FK_Transferencias_Cuentas_Destino]
GO
/****** Object:  ForeignKey [FK_Transferencias_Cuentas_Origen]    Script Date: 06/27/2015 18:31:53 ******/
ALTER TABLE [NN].[Transferencias]  WITH CHECK ADD  CONSTRAINT [FK_Transferencias_Cuentas_Origen] FOREIGN KEY([Cuenta_Origen])
REFERENCES [NN].[Cuentas] ([Cuenta_Id])
GO
ALTER TABLE [NN].[Transferencias] CHECK CONSTRAINT [FK_Transferencias_Cuentas_Origen]
GO

-- CREO TABLA MONEDAS

insert into nn.monedas values ('Dolar')

-- CREAR TABLA DE PAISES

insert into NN.Paises
select distinct pais_desc from
(select distinct cli_pais_desc pais_desc
from gd_esquema.Maestra
union
select distinct cuenta_pais_desc pais_desc
from gd_esquema.Maestra
union
select distinct cuenta_dest_pais_desc pais_desc
from gd_esquema.Maestra) p
where pais_desc is not null

-- CREA LA TABLA EMISORES

insert into nn.Emisores
select distinct Tarjeta_Emisor_Descripcion 
from gd_esquema.Maestra
where Tarjeta_Emisor_Descripcion is not null

-- CREA TABLA DE DOCUMENTOS

INSERT INTO nn.Documentos VALUES ('DNI')
INSERT INTO nn.Documentos VALUES ('LE')
INSERT INTO nn.Documentos VALUES ('LC')
insert into nn.Documentos
select distinct Cli_Tipo_Doc_Desc 
from gd_esquema.Maestra

-- CREA TABLA DE CLIENTES

insert into nn.Clientes
select distinct (select Pais_codigo from nn.Paises where Pais_Desc = Cli_Pais_Desc), Cli_Nombre, Cli_Apellido, (select Tipo_Doc_Cod from nn.Documentos where Tipo_Doc_Desc = Cli_Tipo_Doc_Desc), Cli_Nro_Doc, Cli_Dom_Calle, Cli_Dom_Nro, Cli_Dom_Piso, Cli_Dom_Depto, Cli_Fecha_Nac, Cli_Mail, null, null, null, 1
from gd_esquema.Maestra

-- CREA TABLA DE TIPO DE CUENTAS

insert into nn.Tipo_de_Cuentas values ('Oro', 50)
insert into nn.Tipo_de_Cuentas values ('Plata', 40)
insert into nn.Tipo_de_Cuentas values ('Bronce', 30)
insert into nn.Tipo_de_Cuentas values ('Gratuita', 10)

-- CREA TABLA DE CUENTAS

insert into nn.Cuentas
select distinct (select nn.Clientes.Cli_Id from nn.Clientes where nn.Clientes.Cli_Nro_Doc = gd_esquema.Maestra.Cli_Nro_Doc), Cuenta_Numero, Cuenta_Fecha_Creacion, (select Pais_codigo from nn.Paises where Pais_Desc = Cuenta_Pais_Desc), 'H', Cuenta_Fecha_Cierre, (select tipo_de_cuenta_cod from nn.Tipo_de_Cuentas where tipo_de_cuenta_desc = 'Gratuita'), (select monedas_codigo from nn.Monedas where Monedas_desc = 'Dolar'), 0
from gd_esquema.Maestra

-- CREA TARJETAS

insert into nn.Tarjetas
select distinct (select nn.Clientes.Cli_Id from nn.Clientes where nn.Clientes.Cli_Nro_Doc = gd_esquema.Maestra.Cli_Nro_Doc), Tarjeta_Numero, Tarjeta_Codigo_Seg, (select emisor_codigo from nn.Emisores where emisor_desc = Tarjeta_Emisor_Descripcion), Tarjeta_Fecha_Emision, Tarjeta_Fecha_Vencimiento, 1
from gd_esquema.Maestra
where Tarjeta_Numero is not null and Tarjeta_Codigo_Seg is not null and Tarjeta_Emisor_Descripcion is not null and Tarjeta_Fecha_Emision is not null and Tarjeta_Fecha_Vencimiento is not  null

-- CREA TABLA DEPOSITOS

insert into nn.Depositos
select distinct Deposito_Codigo, (select nn.Clientes.Cli_Id from nn.Clientes where nn.Clientes.Cli_Nro_Doc = gd_esquema.Maestra.Cli_Nro_Doc), (select nn.Cuentas.Cuenta_Id from nn.Cuentas where nn.Cuentas.Cuenta_Numero = gd_esquema.Maestra.Cuenta_Numero), Deposito_Fecha, Deposito_Importe, (select nn.Tarjetas.Tarjeta_Id from nn.Tarjetas where nn.Tarjetas.Tarjeta_Numero = gd_esquema.Maestra.Tarjeta_Numero), (select monedas_codigo from nn.Monedas where Monedas_desc = 'Dolar')
from gd_esquema.Maestra
where Cli_Nro_Doc is not null and Deposito_Codigo is not null and Deposito_Fecha is not null and Deposito_Importe is not null and Tarjeta_Numero is not  null

-- CREA TABLA DE Transferencias

insert into nn.Transferencias
select distinct (select nn.Cuentas.Cuenta_Id from nn.Cuentas where nn.Cuentas.Cuenta_Numero = gd_esquema.Maestra.Cuenta_Numero), (select nn.Cuentas.Cuenta_Id from nn.Cuentas where nn.Cuentas.Cuenta_Numero = gd_esquema.Maestra.Cuenta_Dest_Numero), Transf_Fecha, Trans_Importe, Trans_Costo_Trans
from gd_esquema.Maestra

-- CREA TABLA DE BANCOS

insert into nn.Bancos
select distinct Banco_Nombre, Banco_Direccion 
from gd_esquema.Maestra
where Banco_Cogido is not null and Banco_Nombre is not null and Banco_Direccion is not null
 
-- CREA TABLA RETIROS

insert into nn.Retiros
select distinct (select nn.Cuentas.cuenta_id from nn.Cuentas where nn.Cuentas.Cuenta_Numero = gd_esquema.Maestra.Cuenta_Numero), (select nn.Cheques.Cheque_Id from nn.Cheques where nn.Cheques.Cheque_Numero = gd_esquema.Maestra.Cheque_Numero), Retiro_Fecha, Retiro_Codigo, Retiro_Importe, (select nn.Bancos.Banco_Codigo from nn.Bancos where nn.Bancos.Banco_Nombre = gd_esquema.Maestra.Banco_Nombre)
from gd_esquema.Maestra
where Cuenta_Numero is not null and Retiro_Codigo is not null
 
-- CREA TABLA CHEQUES

insert into nn.Cheques
select distinct Cheque_Numero, Cheque_Fecha, Cheque_Importe, (select nn.Cuentas.Cuenta_Id from nn.Cuentas where nn.Cuentas.Cuenta_Numero = gd_esquema.Maestra.Cuenta_Numero), 1
from gd_esquema.Maestra

-- CREA TABLA ROL

insert into nn.rol (Rol_Nombre, Rol_Activo) values ('Administrador', 1)
insert into nn.rol (Rol_Nombre, Rol_Activo) values ('Cliente', 1)

-- CREA TABLA FUNCIONALIDAD

insert into nn.Funcionalidad values ('ABM Roles')
insert into nn.Funcionalidad values ('ABM Clientes')
insert into nn.Funcionalidad values ('ABM Cuentas')
insert into nn.Funcionalidad values ('ABM Usuarios')

-- CREA TABLA FuncionalidadXRol

INSERT INTO nn.FuncionalidadXRol (Func_Id, Rol_Id) VALUES ((select Func_Id from nn.Funcionalidad where Func_Nombre = 'ABM Roles'), (select Rol_Id from nn.Rol where Rol_Nombre = 'Administrador'))
INSERT INTO nn.FuncionalidadXRol (Func_Id, Rol_Id) VALUES ((select Func_Id from nn.Funcionalidad where Func_Nombre = 'ABM Clientes'), (select Rol_Id from nn.Rol where Rol_Nombre = 'Administrador'))
INSERT INTO nn.FuncionalidadXRol (Func_Id, Rol_Id) VALUES ((select Func_Id from nn.Funcionalidad where Func_Nombre = 'ABM Cuentas'), (select Rol_Id from nn.Rol where Rol_Nombre = 'Administrador'))
INSERT INTO nn.FuncionalidadXRol (Func_Id, Rol_Id) VALUES ((select Func_Id from nn.Funcionalidad where Func_Nombre = 'ABM Usuarios'), (select Rol_Id from nn.Rol where Rol_Nombre = 'Administrador'))

-- CREA TABLA USUARIO

INSERT INTO nn.Usuario (Usu_Nombre, Usu_Password, Usu_Activo) VALUES ('admin', '5rhwUL/LgUP8uNsBcKTcntANkE3dPipK0bHo3A/cm+c=', 1)

insert into nn.Usuario (Usu_Nombre, Usu_Password, Usu_Activo)
select distinct Substring(Cli_Mail, 1, Charindex('@', Cli_Mail) - 1), 'jZae727K08KaOmKSgOaGzww/XVqGr/PKEgIMkjrcbJI=', 1
from nn.Clientes

update nn.Usuario set usu_intentos = 0

-- ACTUALIZO TABLA CLIENTES

update nn.Clientes set Cli_Usuario = (select Usu_Id from nn.Usuario where Usu_Nombre = Substring(Cli_Mail, 1, Charindex('@', Cli_Mail) - 1)) where Cli_Usuario is null


-- CREA TABLA RolXUsuario

INSERT INTO nn.RolXUsuario (Usu_Id, Rol_Id) VALUES ((select Usu_Id from nn.Usuario where Usu_Nombre = 'admin'), (select Rol_Id from nn.Rol where Rol_Nombre = 'Administrador'))

INSERT INTO nn.RolXUsuario (Usu_Id, Rol_Id)
select Cli_Usuario, (select Rol_Id from nn.Rol where Rol_Nombre = 'Cliente')
from nn.Clientes

-- ACTUALIZO TABLA Paises

update nn.Paises set pais_desc = REPLACE(pais_desc, CHAR(160), '')
