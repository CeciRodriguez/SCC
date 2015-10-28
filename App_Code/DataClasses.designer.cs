﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.34209
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="scc")]
public partial class DataClassesDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Definiciones de métodos de extensibilidad
  partial void OnCreated();
  partial void InsertCliente(Cliente instance);
  partial void UpdateCliente(Cliente instance);
  partial void DeleteCliente(Cliente instance);
  partial void Insertmodalidad(modalidad instance);
  partial void Updatemodalidad(modalidad instance);
  partial void Deletemodalidad(modalidad instance);
  partial void Insertsesion(sesion instance);
  partial void Updatesesion(sesion instance);
  partial void Deletesesion(sesion instance);
  partial void Insertsexo(sexo instance);
  partial void Updatesexo(sexo instance);
  partial void Deletesexo(sexo instance);
  partial void Insertsolicitud(solicitud instance);
  partial void Updatesolicitud(solicitud instance);
  partial void Deletesolicitud(solicitud instance);
  #endregion
	
	public DataClassesDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["sccConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<Cliente> Cliente
	{
		get
		{
			return this.GetTable<Cliente>();
		}
	}
	
	public System.Data.Linq.Table<modalidad> modalidad
	{
		get
		{
			return this.GetTable<modalidad>();
		}
	}
	
	public System.Data.Linq.Table<sesion> sesion
	{
		get
		{
			return this.GetTable<sesion>();
		}
	}
	
	public System.Data.Linq.Table<sexo> sexo
	{
		get
		{
			return this.GetTable<sexo>();
		}
	}
	
	public System.Data.Linq.Table<solicitud> solicitud
	{
		get
		{
			return this.GetTable<solicitud>();
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Cliente")]
public partial class Cliente : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _idCliente;
	
	private string _nomCliente;
	
	private string _apCliente;
	
	private string _amCliente;
	
	private System.Nullable<int> _idSexo;
	
	private string _fechaNac;
	
	private string _numIFE;
	
	private string _domicilio;
	
	private string _num;
	
	private string _descripCasa;
	
	private string _telefono;
	
	private string _telefonoAlt;
	
	private EntitySet<solicitud> _solicitud;
	
	private EntityRef<sexo> _sexo;
	
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidClienteChanging(int value);
    partial void OnidClienteChanged();
    partial void OnnomClienteChanging(string value);
    partial void OnnomClienteChanged();
    partial void OnapClienteChanging(string value);
    partial void OnapClienteChanged();
    partial void OnamClienteChanging(string value);
    partial void OnamClienteChanged();
    partial void OnidSexoChanging(System.Nullable<int> value);
    partial void OnidSexoChanged();
    partial void OnfechaNacChanging(string value);
    partial void OnfechaNacChanged();
    partial void OnnumIFEChanging(string value);
    partial void OnnumIFEChanged();
    partial void OndomicilioChanging(string value);
    partial void OndomicilioChanged();
    partial void OnnumChanging(string value);
    partial void OnnumChanged();
    partial void OndescripCasaChanging(string value);
    partial void OndescripCasaChanged();
    partial void OntelefonoChanging(string value);
    partial void OntelefonoChanged();
    partial void OntelefonoAltChanging(string value);
    partial void OntelefonoAltChanged();
    #endregion
	
	public Cliente()
	{
		this._solicitud = new EntitySet<solicitud>(new Action<solicitud>(this.attach_solicitud), new Action<solicitud>(this.detach_solicitud));
		this._sexo = default(EntityRef<sexo>);
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idCliente", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int idCliente
	{
		get
		{
			return this._idCliente;
		}
		set
		{
			if ((this._idCliente != value))
			{
				this.OnidClienteChanging(value);
				this.SendPropertyChanging();
				this._idCliente = value;
				this.SendPropertyChanged("idCliente");
				this.OnidClienteChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nomCliente", DbType="VarChar(100)")]
	public string nomCliente
	{
		get
		{
			return this._nomCliente;
		}
		set
		{
			if ((this._nomCliente != value))
			{
				this.OnnomClienteChanging(value);
				this.SendPropertyChanging();
				this._nomCliente = value;
				this.SendPropertyChanged("nomCliente");
				this.OnnomClienteChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_apCliente", DbType="VarChar(100)")]
	public string apCliente
	{
		get
		{
			return this._apCliente;
		}
		set
		{
			if ((this._apCliente != value))
			{
				this.OnapClienteChanging(value);
				this.SendPropertyChanging();
				this._apCliente = value;
				this.SendPropertyChanged("apCliente");
				this.OnapClienteChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_amCliente", DbType="VarChar(100)")]
	public string amCliente
	{
		get
		{
			return this._amCliente;
		}
		set
		{
			if ((this._amCliente != value))
			{
				this.OnamClienteChanging(value);
				this.SendPropertyChanging();
				this._amCliente = value;
				this.SendPropertyChanged("amCliente");
				this.OnamClienteChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idSexo", DbType="Int")]
	public System.Nullable<int> idSexo
	{
		get
		{
			return this._idSexo;
		}
		set
		{
			if ((this._idSexo != value))
			{
				if (this._sexo.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnidSexoChanging(value);
				this.SendPropertyChanging();
				this._idSexo = value;
				this.SendPropertyChanged("idSexo");
				this.OnidSexoChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fechaNac", DbType="VarChar(100)")]
	public string fechaNac
	{
		get
		{
			return this._fechaNac;
		}
		set
		{
			if ((this._fechaNac != value))
			{
				this.OnfechaNacChanging(value);
				this.SendPropertyChanging();
				this._fechaNac = value;
				this.SendPropertyChanged("fechaNac");
				this.OnfechaNacChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_numIFE", DbType="VarChar(100)")]
	public string numIFE
	{
		get
		{
			return this._numIFE;
		}
		set
		{
			if ((this._numIFE != value))
			{
				this.OnnumIFEChanging(value);
				this.SendPropertyChanging();
				this._numIFE = value;
				this.SendPropertyChanged("numIFE");
				this.OnnumIFEChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_domicilio", DbType="VarChar(100)")]
	public string domicilio
	{
		get
		{
			return this._domicilio;
		}
		set
		{
			if ((this._domicilio != value))
			{
				this.OndomicilioChanging(value);
				this.SendPropertyChanging();
				this._domicilio = value;
				this.SendPropertyChanged("domicilio");
				this.OndomicilioChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_num", DbType="VarChar(100)")]
	public string num
	{
		get
		{
			return this._num;
		}
		set
		{
			if ((this._num != value))
			{
				this.OnnumChanging(value);
				this.SendPropertyChanging();
				this._num = value;
				this.SendPropertyChanged("num");
				this.OnnumChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_descripCasa", DbType="VarChar(MAX)")]
	public string descripCasa
	{
		get
		{
			return this._descripCasa;
		}
		set
		{
			if ((this._descripCasa != value))
			{
				this.OndescripCasaChanging(value);
				this.SendPropertyChanging();
				this._descripCasa = value;
				this.SendPropertyChanged("descripCasa");
				this.OndescripCasaChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_telefono", DbType="VarChar(100)")]
	public string telefono
	{
		get
		{
			return this._telefono;
		}
		set
		{
			if ((this._telefono != value))
			{
				this.OntelefonoChanging(value);
				this.SendPropertyChanging();
				this._telefono = value;
				this.SendPropertyChanged("telefono");
				this.OntelefonoChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_telefonoAlt", DbType="VarChar(100)")]
	public string telefonoAlt
	{
		get
		{
			return this._telefonoAlt;
		}
		set
		{
			if ((this._telefonoAlt != value))
			{
				this.OntelefonoAltChanging(value);
				this.SendPropertyChanging();
				this._telefonoAlt = value;
				this.SendPropertyChanged("telefonoAlt");
				this.OntelefonoAltChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Cliente_solicitud", Storage="_solicitud", ThisKey="idCliente", OtherKey="idCliente")]
	public EntitySet<solicitud> solicitud
	{
		get
		{
			return this._solicitud;
		}
		set
		{
			this._solicitud.Assign(value);
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="sexo_Cliente", Storage="_sexo", ThisKey="idSexo", OtherKey="idSexo", IsForeignKey=true)]
	public sexo sexo
	{
		get
		{
			return this._sexo.Entity;
		}
		set
		{
			sexo previousValue = this._sexo.Entity;
			if (((previousValue != value) 
						|| (this._sexo.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._sexo.Entity = null;
					previousValue.Cliente.Remove(this);
				}
				this._sexo.Entity = value;
				if ((value != null))
				{
					value.Cliente.Add(this);
					this._idSexo = value.idSexo;
				}
				else
				{
					this._idSexo = default(Nullable<int>);
				}
				this.SendPropertyChanged("sexo");
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_solicitud(solicitud entity)
	{
		this.SendPropertyChanging();
		entity.Cliente = this;
	}
	
	private void detach_solicitud(solicitud entity)
	{
		this.SendPropertyChanging();
		entity.Cliente = null;
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.modalidad")]
public partial class modalidad : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _idModalidad;
	
	private string _descripcion;
	
	private EntitySet<solicitud> _solicitud;
	
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidModalidadChanging(int value);
    partial void OnidModalidadChanged();
    partial void OndescripcionChanging(string value);
    partial void OndescripcionChanged();
    #endregion
	
	public modalidad()
	{
		this._solicitud = new EntitySet<solicitud>(new Action<solicitud>(this.attach_solicitud), new Action<solicitud>(this.detach_solicitud));
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idModalidad", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int idModalidad
	{
		get
		{
			return this._idModalidad;
		}
		set
		{
			if ((this._idModalidad != value))
			{
				this.OnidModalidadChanging(value);
				this.SendPropertyChanging();
				this._idModalidad = value;
				this.SendPropertyChanged("idModalidad");
				this.OnidModalidadChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_descripcion", DbType="VarChar(50)")]
	public string descripcion
	{
		get
		{
			return this._descripcion;
		}
		set
		{
			if ((this._descripcion != value))
			{
				this.OndescripcionChanging(value);
				this.SendPropertyChanging();
				this._descripcion = value;
				this.SendPropertyChanged("descripcion");
				this.OndescripcionChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="modalidad_solicitud", Storage="_solicitud", ThisKey="idModalidad", OtherKey="idModalidad")]
	public EntitySet<solicitud> solicitud
	{
		get
		{
			return this._solicitud;
		}
		set
		{
			this._solicitud.Assign(value);
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_solicitud(solicitud entity)
	{
		this.SendPropertyChanging();
		entity.modalidad = this;
	}
	
	private void detach_solicitud(solicitud entity)
	{
		this.SendPropertyChanging();
		entity.modalidad = null;
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.sesion")]
public partial class sesion : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _idSesion;
	
	private string _usuario;
	
	private string _contrasenia;
	
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidSesionChanging(int value);
    partial void OnidSesionChanged();
    partial void OnusuarioChanging(string value);
    partial void OnusuarioChanged();
    partial void OncontraseniaChanging(string value);
    partial void OncontraseniaChanged();
    #endregion
	
	public sesion()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idSesion", DbType="Int NOT NULL", IsPrimaryKey=true)]
	public int idSesion
	{
		get
		{
			return this._idSesion;
		}
		set
		{
			if ((this._idSesion != value))
			{
				this.OnidSesionChanging(value);
				this.SendPropertyChanging();
				this._idSesion = value;
				this.SendPropertyChanged("idSesion");
				this.OnidSesionChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_usuario", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
	public string usuario
	{
		get
		{
			return this._usuario;
		}
		set
		{
			if ((this._usuario != value))
			{
				this.OnusuarioChanging(value);
				this.SendPropertyChanging();
				this._usuario = value;
				this.SendPropertyChanged("usuario");
				this.OnusuarioChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_contrasenia", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
	public string contrasenia
	{
		get
		{
			return this._contrasenia;
		}
		set
		{
			if ((this._contrasenia != value))
			{
				this.OncontraseniaChanging(value);
				this.SendPropertyChanging();
				this._contrasenia = value;
				this.SendPropertyChanged("contrasenia");
				this.OncontraseniaChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.sexo")]
public partial class sexo : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _idSexo;
	
	private string _descripcion;
	
	private EntitySet<Cliente> _Cliente;
	
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidSexoChanging(int value);
    partial void OnidSexoChanged();
    partial void OndescripcionChanging(string value);
    partial void OndescripcionChanged();
    #endregion
	
	public sexo()
	{
		this._Cliente = new EntitySet<Cliente>(new Action<Cliente>(this.attach_Cliente), new Action<Cliente>(this.detach_Cliente));
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idSexo", DbType="Int NOT NULL", IsPrimaryKey=true)]
	public int idSexo
	{
		get
		{
			return this._idSexo;
		}
		set
		{
			if ((this._idSexo != value))
			{
				this.OnidSexoChanging(value);
				this.SendPropertyChanging();
				this._idSexo = value;
				this.SendPropertyChanged("idSexo");
				this.OnidSexoChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_descripcion", DbType="VarChar(10)")]
	public string descripcion
	{
		get
		{
			return this._descripcion;
		}
		set
		{
			if ((this._descripcion != value))
			{
				this.OndescripcionChanging(value);
				this.SendPropertyChanging();
				this._descripcion = value;
				this.SendPropertyChanged("descripcion");
				this.OndescripcionChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="sexo_Cliente", Storage="_Cliente", ThisKey="idSexo", OtherKey="idSexo")]
	public EntitySet<Cliente> Cliente
	{
		get
		{
			return this._Cliente;
		}
		set
		{
			this._Cliente.Assign(value);
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_Cliente(Cliente entity)
	{
		this.SendPropertyChanging();
		entity.sexo = this;
	}
	
	private void detach_Cliente(Cliente entity)
	{
		this.SendPropertyChanging();
		entity.sexo = null;
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.solicitud")]
public partial class solicitud : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _idSolicitud;
	
	private System.Nullable<int> _idCliente;
	
	private System.Nullable<int> _cSolicitada;
	
	private System.Nullable<int> _idModalidad;
	
	private string _fechaInicio;
	
	private string _fechaFin;
	
	private System.Nullable<decimal> _ingresoMensual;
	
	private System.Nullable<decimal> _gastoMensual;
	
	private string _descripcionCredito;
	
	private string _descripcionGarantias;
	
	private System.Nullable<decimal> _montoValuado;
	
	private System.Nullable<decimal> _creditoMaximo;
	
	private string _estatus;
	
	private EntityRef<Cliente> _Cliente;
	
	private EntityRef<modalidad> _modalidad;
	
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidSolicitudChanging(int value);
    partial void OnidSolicitudChanged();
    partial void OnidClienteChanging(System.Nullable<int> value);
    partial void OnidClienteChanged();
    partial void OncSolicitadaChanging(System.Nullable<int> value);
    partial void OncSolicitadaChanged();
    partial void OnidModalidadChanging(System.Nullable<int> value);
    partial void OnidModalidadChanged();
    partial void OnfechaInicioChanging(string value);
    partial void OnfechaInicioChanged();
    partial void OnfechaFinChanging(string value);
    partial void OnfechaFinChanged();
    partial void OningresoMensualChanging(System.Nullable<decimal> value);
    partial void OningresoMensualChanged();
    partial void OngastoMensualChanging(System.Nullable<decimal> value);
    partial void OngastoMensualChanged();
    partial void OndescripcionCreditoChanging(string value);
    partial void OndescripcionCreditoChanged();
    partial void OndescripcionGarantiasChanging(string value);
    partial void OndescripcionGarantiasChanged();
    partial void OnmontoValuadoChanging(System.Nullable<decimal> value);
    partial void OnmontoValuadoChanged();
    partial void OncreditoMaximoChanging(System.Nullable<decimal> value);
    partial void OncreditoMaximoChanged();
    partial void OnestatusChanging(string value);
    partial void OnestatusChanged();
    #endregion
	
	public solicitud()
	{
		this._Cliente = default(EntityRef<Cliente>);
		this._modalidad = default(EntityRef<modalidad>);
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idSolicitud", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int idSolicitud
	{
		get
		{
			return this._idSolicitud;
		}
		set
		{
			if ((this._idSolicitud != value))
			{
				this.OnidSolicitudChanging(value);
				this.SendPropertyChanging();
				this._idSolicitud = value;
				this.SendPropertyChanged("idSolicitud");
				this.OnidSolicitudChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idCliente", DbType="Int")]
	public System.Nullable<int> idCliente
	{
		get
		{
			return this._idCliente;
		}
		set
		{
			if ((this._idCliente != value))
			{
				if (this._Cliente.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnidClienteChanging(value);
				this.SendPropertyChanging();
				this._idCliente = value;
				this.SendPropertyChanged("idCliente");
				this.OnidClienteChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cSolicitada", DbType="Int")]
	public System.Nullable<int> cSolicitada
	{
		get
		{
			return this._cSolicitada;
		}
		set
		{
			if ((this._cSolicitada != value))
			{
				this.OncSolicitadaChanging(value);
				this.SendPropertyChanging();
				this._cSolicitada = value;
				this.SendPropertyChanged("cSolicitada");
				this.OncSolicitadaChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idModalidad", DbType="Int")]
	public System.Nullable<int> idModalidad
	{
		get
		{
			return this._idModalidad;
		}
		set
		{
			if ((this._idModalidad != value))
			{
				if (this._modalidad.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnidModalidadChanging(value);
				this.SendPropertyChanging();
				this._idModalidad = value;
				this.SendPropertyChanged("idModalidad");
				this.OnidModalidadChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fechaInicio", DbType="VarChar(50)")]
	public string fechaInicio
	{
		get
		{
			return this._fechaInicio;
		}
		set
		{
			if ((this._fechaInicio != value))
			{
				this.OnfechaInicioChanging(value);
				this.SendPropertyChanging();
				this._fechaInicio = value;
				this.SendPropertyChanged("fechaInicio");
				this.OnfechaInicioChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fechaFin", DbType="VarChar(50)")]
	public string fechaFin
	{
		get
		{
			return this._fechaFin;
		}
		set
		{
			if ((this._fechaFin != value))
			{
				this.OnfechaFinChanging(value);
				this.SendPropertyChanging();
				this._fechaFin = value;
				this.SendPropertyChanged("fechaFin");
				this.OnfechaFinChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ingresoMensual", DbType="Decimal(10,2)")]
	public System.Nullable<decimal> ingresoMensual
	{
		get
		{
			return this._ingresoMensual;
		}
		set
		{
			if ((this._ingresoMensual != value))
			{
				this.OningresoMensualChanging(value);
				this.SendPropertyChanging();
				this._ingresoMensual = value;
				this.SendPropertyChanged("ingresoMensual");
				this.OningresoMensualChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_gastoMensual", DbType="Decimal(10,2)")]
	public System.Nullable<decimal> gastoMensual
	{
		get
		{
			return this._gastoMensual;
		}
		set
		{
			if ((this._gastoMensual != value))
			{
				this.OngastoMensualChanging(value);
				this.SendPropertyChanging();
				this._gastoMensual = value;
				this.SendPropertyChanged("gastoMensual");
				this.OngastoMensualChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_descripcionCredito", DbType="VarChar(MAX)")]
	public string descripcionCredito
	{
		get
		{
			return this._descripcionCredito;
		}
		set
		{
			if ((this._descripcionCredito != value))
			{
				this.OndescripcionCreditoChanging(value);
				this.SendPropertyChanging();
				this._descripcionCredito = value;
				this.SendPropertyChanged("descripcionCredito");
				this.OndescripcionCreditoChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_descripcionGarantias", DbType="VarChar(MAX)")]
	public string descripcionGarantias
	{
		get
		{
			return this._descripcionGarantias;
		}
		set
		{
			if ((this._descripcionGarantias != value))
			{
				this.OndescripcionGarantiasChanging(value);
				this.SendPropertyChanging();
				this._descripcionGarantias = value;
				this.SendPropertyChanged("descripcionGarantias");
				this.OndescripcionGarantiasChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_montoValuado", DbType="Decimal(10,2)")]
	public System.Nullable<decimal> montoValuado
	{
		get
		{
			return this._montoValuado;
		}
		set
		{
			if ((this._montoValuado != value))
			{
				this.OnmontoValuadoChanging(value);
				this.SendPropertyChanging();
				this._montoValuado = value;
				this.SendPropertyChanged("montoValuado");
				this.OnmontoValuadoChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_creditoMaximo", DbType="Decimal(10,2)")]
	public System.Nullable<decimal> creditoMaximo
	{
		get
		{
			return this._creditoMaximo;
		}
		set
		{
			if ((this._creditoMaximo != value))
			{
				this.OncreditoMaximoChanging(value);
				this.SendPropertyChanging();
				this._creditoMaximo = value;
				this.SendPropertyChanged("creditoMaximo");
				this.OncreditoMaximoChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_estatus", DbType="VarChar(50)")]
	public string estatus
	{
		get
		{
			return this._estatus;
		}
		set
		{
			if ((this._estatus != value))
			{
				this.OnestatusChanging(value);
				this.SendPropertyChanging();
				this._estatus = value;
				this.SendPropertyChanged("estatus");
				this.OnestatusChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Cliente_solicitud", Storage="_Cliente", ThisKey="idCliente", OtherKey="idCliente", IsForeignKey=true)]
	public Cliente Cliente
	{
		get
		{
			return this._Cliente.Entity;
		}
		set
		{
			Cliente previousValue = this._Cliente.Entity;
			if (((previousValue != value) 
						|| (this._Cliente.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._Cliente.Entity = null;
					previousValue.solicitud.Remove(this);
				}
				this._Cliente.Entity = value;
				if ((value != null))
				{
					value.solicitud.Add(this);
					this._idCliente = value.idCliente;
				}
				else
				{
					this._idCliente = default(Nullable<int>);
				}
				this.SendPropertyChanged("Cliente");
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="modalidad_solicitud", Storage="_modalidad", ThisKey="idModalidad", OtherKey="idModalidad", IsForeignKey=true)]
	public modalidad modalidad
	{
		get
		{
			return this._modalidad.Entity;
		}
		set
		{
			modalidad previousValue = this._modalidad.Entity;
			if (((previousValue != value) 
						|| (this._modalidad.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._modalidad.Entity = null;
					previousValue.solicitud.Remove(this);
				}
				this._modalidad.Entity = value;
				if ((value != null))
				{
					value.solicitud.Add(this);
					this._idModalidad = value.idModalidad;
				}
				else
				{
					this._idModalidad = default(Nullable<int>);
				}
				this.SendPropertyChanged("modalidad");
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
#pragma warning restore 1591
