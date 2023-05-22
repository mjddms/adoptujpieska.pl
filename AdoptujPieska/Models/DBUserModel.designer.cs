﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdoptujPieska.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Database1")]
	public partial class DBUserModelDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertPhoto(Photo instance);
    partial void UpdatePhoto(Photo instance);
    partial void DeletePhoto(Photo instance);
    partial void InsertPieski(Pieski instance);
    partial void UpdatePieski(Pieski instance);
    partial void DeletePieski(Pieski instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    #endregion
		
		public DBUserModelDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBUserModelDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBUserModelDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBUserModelDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Photo> Photo
		{
			get
			{
				return this.GetTable<Photo>();
			}
		}
		
		public System.Data.Linq.Table<Pieski> Pieski
		{
			get
			{
				return this.GetTable<Pieski>();
			}
		}
		
		public System.Data.Linq.Table<User> User
		{
			get
			{
				return this.GetTable<User>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Photo")]
	public partial class Photo : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Photos;
		
		private int _IdDog;
		
		private EntityRef<Pieski> _Pieski;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnPhotosChanging(string value);
    partial void OnPhotosChanged();
    partial void OnIdDogChanging(int value);
    partial void OnIdDogChanged();
    #endregion
		
		public Photo()
		{
			this._Pieski = default(EntityRef<Pieski>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Photos", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Photos
		{
			get
			{
				return this._Photos;
			}
			set
			{
				if ((this._Photos != value))
				{
					this.OnPhotosChanging(value);
					this.SendPropertyChanging();
					this._Photos = value;
					this.SendPropertyChanged("Photos");
					this.OnPhotosChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdDog", DbType="Int NOT NULL")]
		public int IdDog
		{
			get
			{
				return this._IdDog;
			}
			set
			{
				if ((this._IdDog != value))
				{
					if (this._Pieski.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdDogChanging(value);
					this.SendPropertyChanging();
					this._IdDog = value;
					this.SendPropertyChanged("IdDog");
					this.OnIdDogChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Pieski_Photo", Storage="_Pieski", ThisKey="IdDog", OtherKey="Id", IsForeignKey=true)]
		public Pieski Pieski
		{
			get
			{
				return this._Pieski.Entity;
			}
			set
			{
				Pieski previousValue = this._Pieski.Entity;
				if (((previousValue != value) 
							|| (this._Pieski.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Pieski.Entity = null;
						previousValue.Photo.Remove(this);
					}
					this._Pieski.Entity = value;
					if ((value != null))
					{
						value.Photo.Add(this);
						this._IdDog = value.Id;
					}
					else
					{
						this._IdDog = default(int);
					}
					this.SendPropertyChanged("Pieski");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Pieski")]
	public partial class Pieski : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Rasa;
		
		private string _Imie;
		
		private System.Nullable<int> _Wiek;
		
		private System.Nullable<bool> _Plec;
		
		private string _Zdjecie;
		
		private System.Nullable<bool> _Aktywny;
		
		private System.Nullable<bool> _Lubi_dzieci;
		
		private System.Nullable<bool> _Lubi_psy;
		
		private string _Opis;
		
		private System.Nullable<int> _IdUser;
		
		private EntitySet<Photo> _Photo;
		
		private EntityRef<User> _User;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnRasaChanging(string value);
    partial void OnRasaChanged();
    partial void OnImieChanging(string value);
    partial void OnImieChanged();
    partial void OnWiekChanging(System.Nullable<int> value);
    partial void OnWiekChanged();
    partial void OnPlecChanging(System.Nullable<bool> value);
    partial void OnPlecChanged();
    partial void OnZdjecieChanging(string value);
    partial void OnZdjecieChanged();
    partial void OnAktywnyChanging(System.Nullable<bool> value);
    partial void OnAktywnyChanged();
    partial void OnLubi_dzieciChanging(System.Nullable<bool> value);
    partial void OnLubi_dzieciChanged();
    partial void OnLubi_psyChanging(System.Nullable<bool> value);
    partial void OnLubi_psyChanged();
    partial void OnOpisChanging(string value);
    partial void OnOpisChanged();
    partial void OnIdUserChanging(System.Nullable<int> value);
    partial void OnIdUserChanged();
    #endregion
		
		public Pieski()
		{
			this._Photo = new EntitySet<Photo>(new Action<Photo>(this.attach_Photo), new Action<Photo>(this.detach_Photo));
			this._User = default(EntityRef<User>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Rasa", DbType="VarChar(50)")]
		public string Rasa
		{
			get
			{
				return this._Rasa;
			}
			set
			{
				if ((this._Rasa != value))
				{
					this.OnRasaChanging(value);
					this.SendPropertyChanging();
					this._Rasa = value;
					this.SendPropertyChanged("Rasa");
					this.OnRasaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Imie", DbType="VarChar(50)")]
		public string Imie
		{
			get
			{
				return this._Imie;
			}
			set
			{
				if ((this._Imie != value))
				{
					this.OnImieChanging(value);
					this.SendPropertyChanging();
					this._Imie = value;
					this.SendPropertyChanged("Imie");
					this.OnImieChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Wiek", DbType="Int")]
		public System.Nullable<int> Wiek
		{
			get
			{
				return this._Wiek;
			}
			set
			{
				if ((this._Wiek != value))
				{
					this.OnWiekChanging(value);
					this.SendPropertyChanging();
					this._Wiek = value;
					this.SendPropertyChanged("Wiek");
					this.OnWiekChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Plec", DbType="Bit")]
		public System.Nullable<bool> Plec
		{
			get
			{
				return this._Plec;
			}
			set
			{
				if ((this._Plec != value))
				{
					this.OnPlecChanging(value);
					this.SendPropertyChanging();
					this._Plec = value;
					this.SendPropertyChanged("Plec");
					this.OnPlecChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Zdjecie", DbType="NVarChar(MAX)")]
		public string Zdjecie
		{
			get
			{
				return this._Zdjecie;
			}
			set
			{
				if ((this._Zdjecie != value))
				{
					this.OnZdjecieChanging(value);
					this.SendPropertyChanging();
					this._Zdjecie = value;
					this.SendPropertyChanged("Zdjecie");
					this.OnZdjecieChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Aktywny", DbType="Bit")]
		public System.Nullable<bool> Aktywny
		{
			get
			{
				return this._Aktywny;
			}
			set
			{
				if ((this._Aktywny != value))
				{
					this.OnAktywnyChanging(value);
					this.SendPropertyChanging();
					this._Aktywny = value;
					this.SendPropertyChanged("Aktywny");
					this.OnAktywnyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Lubi dzieci]", Storage="_Lubi_dzieci", DbType="Bit")]
		public System.Nullable<bool> Lubi_dzieci
		{
			get
			{
				return this._Lubi_dzieci;
			}
			set
			{
				if ((this._Lubi_dzieci != value))
				{
					this.OnLubi_dzieciChanging(value);
					this.SendPropertyChanging();
					this._Lubi_dzieci = value;
					this.SendPropertyChanged("Lubi_dzieci");
					this.OnLubi_dzieciChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Lubi psy]", Storage="_Lubi_psy", DbType="Bit")]
		public System.Nullable<bool> Lubi_psy
		{
			get
			{
				return this._Lubi_psy;
			}
			set
			{
				if ((this._Lubi_psy != value))
				{
					this.OnLubi_psyChanging(value);
					this.SendPropertyChanging();
					this._Lubi_psy = value;
					this.SendPropertyChanged("Lubi_psy");
					this.OnLubi_psyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Opis", DbType="NVarChar(MAX)")]
		public string Opis
		{
			get
			{
				return this._Opis;
			}
			set
			{
				if ((this._Opis != value))
				{
					this.OnOpisChanging(value);
					this.SendPropertyChanging();
					this._Opis = value;
					this.SendPropertyChanged("Opis");
					this.OnOpisChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdUser", DbType="Int")]
		public System.Nullable<int> IdUser
		{
			get
			{
				return this._IdUser;
			}
			set
			{
				if ((this._IdUser != value))
				{
					if (this._User.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdUserChanging(value);
					this.SendPropertyChanging();
					this._IdUser = value;
					this.SendPropertyChanged("IdUser");
					this.OnIdUserChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Pieski_Photo", Storage="_Photo", ThisKey="Id", OtherKey="IdDog")]
		public EntitySet<Photo> Photo
		{
			get
			{
				return this._Photo;
			}
			set
			{
				this._Photo.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Pieski", Storage="_User", ThisKey="IdUser", OtherKey="Id", IsForeignKey=true)]
		public User User
		{
			get
			{
				return this._User.Entity;
			}
			set
			{
				User previousValue = this._User.Entity;
				if (((previousValue != value) 
							|| (this._User.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._User.Entity = null;
						previousValue.Pieski.Remove(this);
					}
					this._User.Entity = value;
					if ((value != null))
					{
						value.Pieski.Add(this);
						this._IdUser = value.Id;
					}
					else
					{
						this._IdUser = default(Nullable<int>);
					}
					this.SendPropertyChanged("User");
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
		
		private void attach_Photo(Photo entity)
		{
			this.SendPropertyChanging();
			entity.Pieski = this;
		}
		
		private void detach_Photo(Photo entity)
		{
			this.SendPropertyChanging();
			entity.Pieski = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.[User]")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _USERNAME;
		
		private string _EMAIL;
		
		private string _PASSWORD;
		
		private System.Nullable<int> _ROLE;
		
		private EntitySet<Pieski> _Pieski;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnUSERNAMEChanging(string value);
    partial void OnUSERNAMEChanged();
    partial void OnEMAILChanging(string value);
    partial void OnEMAILChanged();
    partial void OnPASSWORDChanging(string value);
    partial void OnPASSWORDChanged();
    partial void OnROLEChanging(System.Nullable<int> value);
    partial void OnROLEChanged();
    #endregion
		
		public User()
		{
			this._Pieski = new EntitySet<Pieski>(new Action<Pieski>(this.attach_Pieski), new Action<Pieski>(this.detach_Pieski));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_USERNAME", DbType="VarChar(50)")]
		public string USERNAME
		{
			get
			{
				return this._USERNAME;
			}
			set
			{
				if ((this._USERNAME != value))
				{
					this.OnUSERNAMEChanging(value);
					this.SendPropertyChanging();
					this._USERNAME = value;
					this.SendPropertyChanged("USERNAME");
					this.OnUSERNAMEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EMAIL", DbType="VarChar(50)")]
		public string EMAIL
		{
			get
			{
				return this._EMAIL;
			}
			set
			{
				if ((this._EMAIL != value))
				{
					this.OnEMAILChanging(value);
					this.SendPropertyChanging();
					this._EMAIL = value;
					this.SendPropertyChanged("EMAIL");
					this.OnEMAILChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PASSWORD", DbType="VarChar(50)")]
		public string PASSWORD
		{
			get
			{
				return this._PASSWORD;
			}
			set
			{
				if ((this._PASSWORD != value))
				{
					this.OnPASSWORDChanging(value);
					this.SendPropertyChanging();
					this._PASSWORD = value;
					this.SendPropertyChanged("PASSWORD");
					this.OnPASSWORDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ROLE", DbType="Int")]
		public System.Nullable<int> ROLE
		{
			get
			{
				return this._ROLE;
			}
			set
			{
				if ((this._ROLE != value))
				{
					this.OnROLEChanging(value);
					this.SendPropertyChanging();
					this._ROLE = value;
					this.SendPropertyChanged("ROLE");
					this.OnROLEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="User_Pieski", Storage="_Pieski", ThisKey="Id", OtherKey="IdUser")]
		public EntitySet<Pieski> Pieski
		{
			get
			{
				return this._Pieski;
			}
			set
			{
				this._Pieski.Assign(value);
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
		
		private void attach_Pieski(Pieski entity)
		{
			this.SendPropertyChanging();
			entity.User = this;
		}
		
		private void detach_Pieski(Pieski entity)
		{
			this.SendPropertyChanging();
			entity.User = null;
		}
	}
}
#pragma warning restore 1591
