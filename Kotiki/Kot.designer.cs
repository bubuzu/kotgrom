﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kotiki
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="kotgrom")]
	public partial class KotDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertAdvert(Advert instance);
    partial void UpdateAdvert(Advert instance);
    partial void DeleteAdvert(Advert instance);
    #endregion
		
		public KotDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["kotgromConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public KotDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public KotDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public KotDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public KotDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<Advert> Adverts
		{
			get
			{
				return this.GetTable<Advert>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spAddUser")]
		public ISingleResult<spAddUserResult> spAddUser([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="BigInt")] System.Nullable<long> vkid, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="BigInt")] System.Nullable<long> fbid, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(256)")] string name, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(256)")] string token)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), vkid, fbid, name, token);
			return ((ISingleResult<spAddUserResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spGetUser")]
		public ISingleResult<User> spGetUser([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="UniqueIdentifier")] System.Nullable<System.Guid> sessid, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> uid)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), sessid, uid);
			return ((ISingleResult<User>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spAddAdvert")]
		public int spAddAdvert([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> uid, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="UniqueIdentifier")] System.Nullable<System.Guid> sessid, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(50)")] string phone, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(50)")] string email, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(128)")] string city, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(128)")] string description, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(MAX)")] string photos)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), uid, sessid, phone, email, city, description, photos);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spGetCat")]
		public ISingleResult<spGetCatResult> spGetCat([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> aid)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), aid);
			return ((ISingleResult<spGetCatResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spUpdateAdvert")]
		public int spUpdateAdvert([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> aid, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> uid, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="UniqueIdentifier")] System.Nullable<System.Guid> sessid, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(50)")] string phone, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(50)")] string email, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(128)")] string city, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(128)")] string description, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(MAX)")] string photos, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Bit")] System.Nullable<bool> closed, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Bit")] System.Nullable<bool> deleted)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), aid, uid, sessid, phone, email, city, description, photos, closed, deleted);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spGetCats")]
		public ISingleResult<spGetCatsResult> spGetCats([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> page, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> uid, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="NVarChar(15)")] string qtype)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), page, uid, qtype);
			return ((ISingleResult<spGetCatsResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.spGetCat2")]
		public ISingleResult<spGetCat2Result> spGetCat2([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> aid)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), aid);
			return ((ISingleResult<spGetCat2Result>)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _uid;
		
		private System.Guid _sessid;
		
		private System.Nullable<long> _vkid;
		
		private System.Nullable<long> _fbid;
		
		private string _name;
		
		private System.Nullable<System.DateTime> _cdate;
		
		private string _token;
		
		private System.Nullable<bool> _admin;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnuidChanging(int value);
    partial void OnuidChanged();
    partial void OnsessidChanging(System.Guid value);
    partial void OnsessidChanged();
    partial void OnvkidChanging(System.Nullable<long> value);
    partial void OnvkidChanged();
    partial void OnfbidChanging(System.Nullable<long> value);
    partial void OnfbidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OncdateChanging(System.Nullable<System.DateTime> value);
    partial void OncdateChanged();
    partial void OntokenChanging(string value);
    partial void OntokenChanged();
    partial void OnadminChanging(System.Nullable<bool> value);
    partial void OnadminChanged();
    #endregion
		
		public User()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_uid", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int uid
		{
			get
			{
				return this._uid;
			}
			set
			{
				if ((this._uid != value))
				{
					this.OnuidChanging(value);
					this.SendPropertyChanging();
					this._uid = value;
					this.SendPropertyChanged("uid");
					this.OnuidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sessid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid sessid
		{
			get
			{
				return this._sessid;
			}
			set
			{
				if ((this._sessid != value))
				{
					this.OnsessidChanging(value);
					this.SendPropertyChanging();
					this._sessid = value;
					this.SendPropertyChanged("sessid");
					this.OnsessidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_vkid", DbType="BigInt")]
		public System.Nullable<long> vkid
		{
			get
			{
				return this._vkid;
			}
			set
			{
				if ((this._vkid != value))
				{
					this.OnvkidChanging(value);
					this.SendPropertyChanging();
					this._vkid = value;
					this.SendPropertyChanged("vkid");
					this.OnvkidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fbid", DbType="BigInt")]
		public System.Nullable<long> fbid
		{
			get
			{
				return this._fbid;
			}
			set
			{
				if ((this._fbid != value))
				{
					this.OnfbidChanging(value);
					this.SendPropertyChanging();
					this._fbid = value;
					this.SendPropertyChanged("fbid");
					this.OnfbidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="NVarChar(256) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cdate", DbType="DateTime")]
		public System.Nullable<System.DateTime> cdate
		{
			get
			{
				return this._cdate;
			}
			set
			{
				if ((this._cdate != value))
				{
					this.OncdateChanging(value);
					this.SendPropertyChanging();
					this._cdate = value;
					this.SendPropertyChanged("cdate");
					this.OncdateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_token", DbType="NVarChar(256) NOT NULL", CanBeNull=false)]
		public string token
		{
			get
			{
				return this._token;
			}
			set
			{
				if ((this._token != value))
				{
					this.OntokenChanging(value);
					this.SendPropertyChanging();
					this._token = value;
					this.SendPropertyChanged("token");
					this.OntokenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_admin", DbType="Bit")]
		public System.Nullable<bool> admin
		{
			get
			{
				return this._admin;
			}
			set
			{
				if ((this._admin != value))
				{
					this.OnadminChanging(value);
					this.SendPropertyChanging();
					this._admin = value;
					this.SendPropertyChanged("admin");
					this.OnadminChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Advert")]
	public partial class Advert : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _aid;
		
		private int _uid;
		
		private string _phone;
		
		private string _email;
		
		private string _city;
		
		private string _description;
		
		private string _photos;
		
		private System.DateTime _cdate;
		
		private bool _closed;
		
		private bool _deleted;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnaidChanging(int value);
    partial void OnaidChanged();
    partial void OnuidChanging(int value);
    partial void OnuidChanged();
    partial void OnphoneChanging(string value);
    partial void OnphoneChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OncityChanging(string value);
    partial void OncityChanged();
    partial void OndescriptionChanging(string value);
    partial void OndescriptionChanged();
    partial void OnphotosChanging(string value);
    partial void OnphotosChanged();
    partial void OncdateChanging(System.DateTime value);
    partial void OncdateChanged();
    partial void OnclosedChanging(bool value);
    partial void OnclosedChanged();
    partial void OndeletedChanging(bool value);
    partial void OndeletedChanged();
    #endregion
		
		public Advert()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_aid", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int aid
		{
			get
			{
				return this._aid;
			}
			set
			{
				if ((this._aid != value))
				{
					this.OnaidChanging(value);
					this.SendPropertyChanging();
					this._aid = value;
					this.SendPropertyChanged("aid");
					this.OnaidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_uid", DbType="Int NOT NULL")]
		public int uid
		{
			get
			{
				return this._uid;
			}
			set
			{
				if ((this._uid != value))
				{
					this.OnuidChanging(value);
					this.SendPropertyChanging();
					this._uid = value;
					this.SendPropertyChanged("uid");
					this.OnuidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phone", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string phone
		{
			get
			{
				return this._phone;
			}
			set
			{
				if ((this._phone != value))
				{
					this.OnphoneChanging(value);
					this.SendPropertyChanging();
					this._phone = value;
					this.SendPropertyChanged("phone");
					this.OnphoneChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_city", DbType="NVarChar(128) NOT NULL", CanBeNull=false)]
		public string city
		{
			get
			{
				return this._city;
			}
			set
			{
				if ((this._city != value))
				{
					this.OncityChanging(value);
					this.SendPropertyChanging();
					this._city = value;
					this.SendPropertyChanged("city");
					this.OncityChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="NVarChar(1024) NOT NULL", CanBeNull=false)]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this.OndescriptionChanging(value);
					this.SendPropertyChanging();
					this._description = value;
					this.SendPropertyChanged("description");
					this.OndescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_photos", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string photos
		{
			get
			{
				return this._photos;
			}
			set
			{
				if ((this._photos != value))
				{
					this.OnphotosChanging(value);
					this.SendPropertyChanging();
					this._photos = value;
					this.SendPropertyChanged("photos");
					this.OnphotosChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cdate", DbType="DateTime NOT NULL")]
		public System.DateTime cdate
		{
			get
			{
				return this._cdate;
			}
			set
			{
				if ((this._cdate != value))
				{
					this.OncdateChanging(value);
					this.SendPropertyChanging();
					this._cdate = value;
					this.SendPropertyChanged("cdate");
					this.OncdateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_closed", DbType="Bit NOT NULL")]
		public bool closed
		{
			get
			{
				return this._closed;
			}
			set
			{
				if ((this._closed != value))
				{
					this.OnclosedChanging(value);
					this.SendPropertyChanging();
					this._closed = value;
					this.SendPropertyChanged("closed");
					this.OnclosedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_deleted", DbType="Bit NOT NULL")]
		public bool deleted
		{
			get
			{
				return this._deleted;
			}
			set
			{
				if ((this._deleted != value))
				{
					this.OndeletedChanging(value);
					this.SendPropertyChanging();
					this._deleted = value;
					this.SendPropertyChanged("deleted");
					this.OndeletedChanged();
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
	
	public partial class spAddUserResult
	{
		
		private int _uid;
		
		private System.Guid _sessid;
		
		private string _token;
		
		public spAddUserResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_uid", DbType="Int NOT NULL")]
		public int uid
		{
			get
			{
				return this._uid;
			}
			set
			{
				if ((this._uid != value))
				{
					this._uid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sessid", DbType="UniqueIdentifier NOT NULL")]
		public System.Guid sessid
		{
			get
			{
				return this._sessid;
			}
			set
			{
				if ((this._sessid != value))
				{
					this._sessid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_token", DbType="NVarChar(256) NOT NULL", CanBeNull=false)]
		public string token
		{
			get
			{
				return this._token;
			}
			set
			{
				if ((this._token != value))
				{
					this._token = value;
				}
			}
		}
	}
	
	public partial class spGetCatResult
	{
		
		private int _aid;
		
		private int _uid;
		
		private string _phone;
		
		private string _email;
		
		private string _city;
		
		private string _description;
		
		private string _photos;
		
		private System.DateTime _cdate;
		
		private bool _closed;
		
		private bool _deleted;
		
		public spGetCatResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_aid", DbType="Int NOT NULL")]
		public int aid
		{
			get
			{
				return this._aid;
			}
			set
			{
				if ((this._aid != value))
				{
					this._aid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_uid", DbType="Int NOT NULL")]
		public int uid
		{
			get
			{
				return this._uid;
			}
			set
			{
				if ((this._uid != value))
				{
					this._uid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phone", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string phone
		{
			get
			{
				return this._phone;
			}
			set
			{
				if ((this._phone != value))
				{
					this._phone = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this._email = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_city", DbType="NVarChar(128) NOT NULL", CanBeNull=false)]
		public string city
		{
			get
			{
				return this._city;
			}
			set
			{
				if ((this._city != value))
				{
					this._city = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="NVarChar(128) NOT NULL", CanBeNull=false)]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this._description = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_photos", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string photos
		{
			get
			{
				return this._photos;
			}
			set
			{
				if ((this._photos != value))
				{
					this._photos = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cdate", DbType="DateTime NOT NULL")]
		public System.DateTime cdate
		{
			get
			{
				return this._cdate;
			}
			set
			{
				if ((this._cdate != value))
				{
					this._cdate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_closed", DbType="Bit NOT NULL")]
		public bool closed
		{
			get
			{
				return this._closed;
			}
			set
			{
				if ((this._closed != value))
				{
					this._closed = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_deleted", DbType="Bit NOT NULL")]
		public bool deleted
		{
			get
			{
				return this._deleted;
			}
			set
			{
				if ((this._deleted != value))
				{
					this._deleted = value;
				}
			}
		}
	}
	
	public partial class spGetCatsResult
	{
		
		private int _aid;
		
		private int _uid;
		
		private string _phone;
		
		private string _email;
		
		private string _city;
		
		private string _description;
		
		private string _photos;
		
		private System.DateTime _cdate;
		
		private bool _closed;
		
		private bool _deleted;
		
		private System.Nullable<long> _position;
		
		private System.Nullable<int> _total;
		
		private System.Nullable<int> _cats;
		
		public spGetCatsResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_aid", DbType="Int NOT NULL")]
		public int aid
		{
			get
			{
				return this._aid;
			}
			set
			{
				if ((this._aid != value))
				{
					this._aid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_uid", DbType="Int NOT NULL")]
		public int uid
		{
			get
			{
				return this._uid;
			}
			set
			{
				if ((this._uid != value))
				{
					this._uid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phone", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string phone
		{
			get
			{
				return this._phone;
			}
			set
			{
				if ((this._phone != value))
				{
					this._phone = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this._email = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_city", DbType="NVarChar(128) NOT NULL", CanBeNull=false)]
		public string city
		{
			get
			{
				return this._city;
			}
			set
			{
				if ((this._city != value))
				{
					this._city = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="NVarChar(128) NOT NULL", CanBeNull=false)]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this._description = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_photos", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string photos
		{
			get
			{
				return this._photos;
			}
			set
			{
				if ((this._photos != value))
				{
					this._photos = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cdate", DbType="DateTime NOT NULL")]
		public System.DateTime cdate
		{
			get
			{
				return this._cdate;
			}
			set
			{
				if ((this._cdate != value))
				{
					this._cdate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_closed", DbType="Bit NOT NULL")]
		public bool closed
		{
			get
			{
				return this._closed;
			}
			set
			{
				if ((this._closed != value))
				{
					this._closed = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_deleted", DbType="Bit NOT NULL")]
		public bool deleted
		{
			get
			{
				return this._deleted;
			}
			set
			{
				if ((this._deleted != value))
				{
					this._deleted = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_position", DbType="BigInt")]
		public System.Nullable<long> position
		{
			get
			{
				return this._position;
			}
			set
			{
				if ((this._position != value))
				{
					this._position = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_total", DbType="Int")]
		public System.Nullable<int> total
		{
			get
			{
				return this._total;
			}
			set
			{
				if ((this._total != value))
				{
					this._total = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cats", DbType="Int")]
		public System.Nullable<int> cats
		{
			get
			{
				return this._cats;
			}
			set
			{
				if ((this._cats != value))
				{
					this._cats = value;
				}
			}
		}
	}
	
	public partial class spGetCat2Result
	{
		
		private int _aid;
		
		private int _uid;
		
		private string _phone;
		
		private string _email;
		
		private string _city;
		
		private string _description;
		
		private string _photos;
		
		private System.DateTime _cdate;
		
		private bool _closed;
		
		private bool _deleted;
		
		private string _name;
		
		public spGetCat2Result()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_aid", DbType="Int NOT NULL")]
		public int aid
		{
			get
			{
				return this._aid;
			}
			set
			{
				if ((this._aid != value))
				{
					this._aid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_uid", DbType="Int NOT NULL")]
		public int uid
		{
			get
			{
				return this._uid;
			}
			set
			{
				if ((this._uid != value))
				{
					this._uid = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_phone", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string phone
		{
			get
			{
				return this._phone;
			}
			set
			{
				if ((this._phone != value))
				{
					this._phone = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this._email = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_city", DbType="NVarChar(128) NOT NULL", CanBeNull=false)]
		public string city
		{
			get
			{
				return this._city;
			}
			set
			{
				if ((this._city != value))
				{
					this._city = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_description", DbType="NVarChar(128) NOT NULL", CanBeNull=false)]
		public string description
		{
			get
			{
				return this._description;
			}
			set
			{
				if ((this._description != value))
				{
					this._description = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_photos", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string photos
		{
			get
			{
				return this._photos;
			}
			set
			{
				if ((this._photos != value))
				{
					this._photos = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_cdate", DbType="DateTime NOT NULL")]
		public System.DateTime cdate
		{
			get
			{
				return this._cdate;
			}
			set
			{
				if ((this._cdate != value))
				{
					this._cdate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_closed", DbType="Bit NOT NULL")]
		public bool closed
		{
			get
			{
				return this._closed;
			}
			set
			{
				if ((this._closed != value))
				{
					this._closed = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_deleted", DbType="Bit NOT NULL")]
		public bool deleted
		{
			get
			{
				return this._deleted;
			}
			set
			{
				if ((this._deleted != value))
				{
					this._deleted = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="NVarChar(256) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this._name = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
