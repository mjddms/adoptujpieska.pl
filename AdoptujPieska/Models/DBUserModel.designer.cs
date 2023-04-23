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
    using System.ComponentModel.DataAnnotations;

    [global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Database1")]
	public partial class DBUserModelDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertPieski(Pieski instance);
    partial void UpdatePieski(Pieski instance);
    partial void DeletePieski(Pieski instance);
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
		
		public System.Data.Linq.Table<User> User
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<Pieski> Pieski
		{
			get
			{
				return this.GetTable<Pieski>();
			}
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
    #endregion
		
		public User()
		{
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
        [DisplayName("Nazwa:")]
        [Required(ErrorMessage = "To pole nie może być puste!")]
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
        [DisplayName("Email:")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "To pole nie może być puste!")]
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
        [DisplayName("Hasło:")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "To pole nie może być puste!")]
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
    #endregion
		
		public Pieski()
		{
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
        [DisplayName("Rasa:")]
        [Required(ErrorMessage = "To pole nie może być puste!")]
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
        [DisplayName("Imie:")]
        [Required(ErrorMessage = "To pole nie może być puste!")]
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
        [DisplayName("Wwiek:")]
        [Required(ErrorMessage = "To pole nie może być puste!")]
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
        [DisplayName("Płeć:")]
        [Required(ErrorMessage = "To pole nie może być puste!")]
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
        [DisplayName("Zdjęcie:")]
        [Required(ErrorMessage = "To pole nie może być puste!")]
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
        [DisplayName("Czy jest aktywny?")]
        [Required(ErrorMessage = "To pole nie może być puste!")]
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
        [DisplayName("Czy lubi dzieci?")]
        [Required(ErrorMessage = "To pole nie może być puste!")]
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
        [DisplayName("Czy toleruje inne psy?")]
        [Required(ErrorMessage = "To pole nie może być puste!")]
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
        [DisplayName("Opis:")]
        [Required(ErrorMessage = "To pole nie może być puste!")]
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
}
#pragma warning restore 1591
