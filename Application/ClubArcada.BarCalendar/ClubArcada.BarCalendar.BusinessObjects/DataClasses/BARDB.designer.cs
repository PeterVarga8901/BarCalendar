﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClubArcada.BarCalendar.BusinessObjects.DataClasses
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Runtime.Serialization;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ClubArcada.Bar_Live")]
	public partial class BARDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertWorker(Worker instance);
    partial void UpdateWorker(Worker instance);
    partial void DeleteWorker(Worker instance);
    partial void InsertShift(Shift instance);
    partial void UpdateShift(Shift instance);
    partial void DeleteShift(Shift instance);
    partial void InsertStockItem(StockItem instance);
    partial void UpdateStockItem(StockItem instance);
    partial void DeleteStockItem(StockItem instance);
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    #endregion
		
		public BARDBDataContext() : 
				base(global::ClubArcada.BarCalendar.BusinessObjects.Properties.Settings.Default.ClubArcada_Bar_LiveConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public BARDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BARDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BARDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BARDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<BusinessUnit> BusinessUnits
		{
			get
			{
				return this.GetTable<BusinessUnit>();
			}
		}
		
		public System.Data.Linq.Table<Worker> Workers
		{
			get
			{
				return this.GetTable<Worker>();
			}
		}
		
		public System.Data.Linq.Table<Shift> Shifts
		{
			get
			{
				return this.GetTable<Shift>();
			}
		}
		
		public System.Data.Linq.Table<StockItem> StockItems
		{
			get
			{
				return this.GetTable<StockItem>();
			}
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.usp_get_shifts")]
		public ISingleResult<usp_get_shiftsResult> usp_get_shifts([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")] System.Nullable<System.DateTime> date)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), date);
			return ((ISingleResult<usp_get_shiftsResult>)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.BusinessUnits")]
	[global::System.Runtime.Serialization.DataContractAttribute()]
	public partial class BusinessUnit
	{
		
		private System.Guid _BusinessUnitId;
		
		private string _Name;
		
		private System.DateTime _DateCreated;
		
		private System.Nullable<System.DateTime> _DateDeleted;
		
		public BusinessUnit()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BusinessUnitId", DbType="UniqueIdentifier NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=1)]
		public System.Guid BusinessUnitId
		{
			get
			{
				return this._BusinessUnitId;
			}
			set
			{
				if ((this._BusinessUnitId != value))
				{
					this._BusinessUnitId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=2)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateCreated", DbType="DateTime NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=3)]
		public System.DateTime DateCreated
		{
			get
			{
				return this._DateCreated;
			}
			set
			{
				if ((this._DateCreated != value))
				{
					this._DateCreated = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateDeleted", DbType="DateTime")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=4)]
		public System.Nullable<System.DateTime> DateDeleted
		{
			get
			{
				return this._DateDeleted;
			}
			set
			{
				if ((this._DateDeleted != value))
				{
					this._DateDeleted = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Workers")]
	[global::System.Runtime.Serialization.DataContractAttribute()]
	public partial class Worker : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _WorkerId;
		
		private System.Guid _BusinessUnitId;
		
		private string _FirstName;
		
		private string _LastName;
		
		private System.DateTime _DateCreated;
		
		private System.Nullable<System.DateTime> _DateDeleted;
		
		private string _ColorCode;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnWorkerIdChanging(System.Guid value);
    partial void OnWorkerIdChanged();
    partial void OnBusinessUnitIdChanging(System.Guid value);
    partial void OnBusinessUnitIdChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnDateCreatedChanging(System.DateTime value);
    partial void OnDateCreatedChanged();
    partial void OnDateDeletedChanging(System.Nullable<System.DateTime> value);
    partial void OnDateDeletedChanged();
    partial void OnColorCodeChanging(string value);
    partial void OnColorCodeChanged();
    #endregion
		
		public Worker()
		{
			this.Initialize();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WorkerId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=1)]
		public System.Guid WorkerId
		{
			get
			{
				return this._WorkerId;
			}
			set
			{
				if ((this._WorkerId != value))
				{
					this.OnWorkerIdChanging(value);
					this.SendPropertyChanging();
					this._WorkerId = value;
					this.SendPropertyChanged("WorkerId");
					this.OnWorkerIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BusinessUnitId", DbType="UniqueIdentifier NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=2)]
		public System.Guid BusinessUnitId
		{
			get
			{
				return this._BusinessUnitId;
			}
			set
			{
				if ((this._BusinessUnitId != value))
				{
					this.OnBusinessUnitIdChanging(value);
					this.SendPropertyChanging();
					this._BusinessUnitId = value;
					this.SendPropertyChanged("BusinessUnitId");
					this.OnBusinessUnitIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=3)]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=4)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateCreated", DbType="DateTime NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=5)]
		public System.DateTime DateCreated
		{
			get
			{
				return this._DateCreated;
			}
			set
			{
				if ((this._DateCreated != value))
				{
					this.OnDateCreatedChanging(value);
					this.SendPropertyChanging();
					this._DateCreated = value;
					this.SendPropertyChanged("DateCreated");
					this.OnDateCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateDeleted", DbType="DateTime")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=6)]
		public System.Nullable<System.DateTime> DateDeleted
		{
			get
			{
				return this._DateDeleted;
			}
			set
			{
				if ((this._DateDeleted != value))
				{
					this.OnDateDeletedChanging(value);
					this.SendPropertyChanging();
					this._DateDeleted = value;
					this.SendPropertyChanged("DateDeleted");
					this.OnDateDeletedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ColorCode", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=7)]
		public string ColorCode
		{
			get
			{
				return this._ColorCode;
			}
			set
			{
				if ((this._ColorCode != value))
				{
					this.OnColorCodeChanging(value);
					this.SendPropertyChanging();
					this._ColorCode = value;
					this.SendPropertyChanged("ColorCode");
					this.OnColorCodeChanged();
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
		
		private void Initialize()
		{
			OnCreated();
		}
		
		[global::System.Runtime.Serialization.OnDeserializingAttribute()]
		[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnDeserializing(StreamingContext context)
		{
			this.Initialize();
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Shifts")]
	[global::System.Runtime.Serialization.DataContractAttribute()]
	public partial class Shift : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _ShiftId;
		
		private System.Guid _WorkerId;
		
		private System.Guid _BusinessUnitId;
		
		private System.Guid _CreatedByUserId;
		
		private System.DateTime _Date;
		
		private int _ShiftType;
		
		private System.Nullable<System.DateTime> _DateCreated;
		
		private int _Duration;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnShiftIdChanging(System.Guid value);
    partial void OnShiftIdChanged();
    partial void OnWorkerIdChanging(System.Guid value);
    partial void OnWorkerIdChanged();
    partial void OnBusinessUnitIdChanging(System.Guid value);
    partial void OnBusinessUnitIdChanged();
    partial void OnCreatedByUserIdChanging(System.Guid value);
    partial void OnCreatedByUserIdChanged();
    partial void OnDateChanging(System.DateTime value);
    partial void OnDateChanged();
    partial void OnShiftTypeChanging(int value);
    partial void OnShiftTypeChanged();
    partial void OnDateCreatedChanging(System.Nullable<System.DateTime> value);
    partial void OnDateCreatedChanged();
    partial void OnDurationChanging(int value);
    partial void OnDurationChanged();
    #endregion
		
		public Shift()
		{
			this.Initialize();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShiftId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=1)]
		public System.Guid ShiftId
		{
			get
			{
				return this._ShiftId;
			}
			set
			{
				if ((this._ShiftId != value))
				{
					this.OnShiftIdChanging(value);
					this.SendPropertyChanging();
					this._ShiftId = value;
					this.SendPropertyChanged("ShiftId");
					this.OnShiftIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_WorkerId", DbType="UniqueIdentifier NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=2)]
		public System.Guid WorkerId
		{
			get
			{
				return this._WorkerId;
			}
			set
			{
				if ((this._WorkerId != value))
				{
					this.OnWorkerIdChanging(value);
					this.SendPropertyChanging();
					this._WorkerId = value;
					this.SendPropertyChanged("WorkerId");
					this.OnWorkerIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BusinessUnitId", DbType="UniqueIdentifier NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=3)]
		public System.Guid BusinessUnitId
		{
			get
			{
				return this._BusinessUnitId;
			}
			set
			{
				if ((this._BusinessUnitId != value))
				{
					this.OnBusinessUnitIdChanging(value);
					this.SendPropertyChanging();
					this._BusinessUnitId = value;
					this.SendPropertyChanged("BusinessUnitId");
					this.OnBusinessUnitIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedByUserId", DbType="UniqueIdentifier NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=4)]
		public System.Guid CreatedByUserId
		{
			get
			{
				return this._CreatedByUserId;
			}
			set
			{
				if ((this._CreatedByUserId != value))
				{
					this.OnCreatedByUserIdChanging(value);
					this.SendPropertyChanging();
					this._CreatedByUserId = value;
					this.SendPropertyChanged("CreatedByUserId");
					this.OnCreatedByUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="DateTime NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=5)]
		public System.DateTime Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this.OnDateChanging(value);
					this.SendPropertyChanging();
					this._Date = value;
					this.SendPropertyChanged("Date");
					this.OnDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShiftType", DbType="Int NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=6)]
		public int ShiftType
		{
			get
			{
				return this._ShiftType;
			}
			set
			{
				if ((this._ShiftType != value))
				{
					this.OnShiftTypeChanging(value);
					this.SendPropertyChanging();
					this._ShiftType = value;
					this.SendPropertyChanged("ShiftType");
					this.OnShiftTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateCreated", DbType="DateTime")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=7)]
		public System.Nullable<System.DateTime> DateCreated
		{
			get
			{
				return this._DateCreated;
			}
			set
			{
				if ((this._DateCreated != value))
				{
					this.OnDateCreatedChanging(value);
					this.SendPropertyChanging();
					this._DateCreated = value;
					this.SendPropertyChanged("DateCreated");
					this.OnDateCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Duration", DbType="Int NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=8)]
		public int Duration
		{
			get
			{
				return this._Duration;
			}
			set
			{
				if ((this._Duration != value))
				{
					this.OnDurationChanging(value);
					this.SendPropertyChanging();
					this._Duration = value;
					this.SendPropertyChanged("Duration");
					this.OnDurationChanged();
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
		
		private void Initialize()
		{
			OnCreated();
		}
		
		[global::System.Runtime.Serialization.OnDeserializingAttribute()]
		[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnDeserializing(StreamingContext context)
		{
			this.Initialize();
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.StockItems")]
	[global::System.Runtime.Serialization.DataContractAttribute()]
	public partial class StockItem : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _StockItemId;
		
		private System.Guid _BusinessUnitId;
		
		private string _Name;
		
		private decimal _Price;
		
		private int _OnStock;
		
		private int _Added;
		
		private int _Removed;
		
		private int _Sold;
		
		private System.DateTime _DateCreated;
		
		private System.Nullable<System.DateTime> _DateDeleted;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnStockItemIdChanging(System.Guid value);
    partial void OnStockItemIdChanged();
    partial void OnBusinessUnitIdChanging(System.Guid value);
    partial void OnBusinessUnitIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnPriceChanging(decimal value);
    partial void OnPriceChanged();
    partial void OnOnStockChanging(int value);
    partial void OnOnStockChanged();
    partial void OnAddedChanging(int value);
    partial void OnAddedChanged();
    partial void OnRemovedChanging(int value);
    partial void OnRemovedChanged();
    partial void OnSoldChanging(int value);
    partial void OnSoldChanged();
    partial void OnDateCreatedChanging(System.DateTime value);
    partial void OnDateCreatedChanged();
    partial void OnDateDeletedChanging(System.Nullable<System.DateTime> value);
    partial void OnDateDeletedChanged();
    #endregion
		
		public StockItem()
		{
			this.Initialize();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockItemId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=1)]
		public System.Guid StockItemId
		{
			get
			{
				return this._StockItemId;
			}
			set
			{
				if ((this._StockItemId != value))
				{
					this.OnStockItemIdChanging(value);
					this.SendPropertyChanging();
					this._StockItemId = value;
					this.SendPropertyChanged("StockItemId");
					this.OnStockItemIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BusinessUnitId", DbType="UniqueIdentifier NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=2)]
		public System.Guid BusinessUnitId
		{
			get
			{
				return this._BusinessUnitId;
			}
			set
			{
				if ((this._BusinessUnitId != value))
				{
					this.OnBusinessUnitIdChanging(value);
					this.SendPropertyChanging();
					this._BusinessUnitId = value;
					this.SendPropertyChanged("BusinessUnitId");
					this.OnBusinessUnitIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=3)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Price", DbType="Decimal(18,2) NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=4)]
		public decimal Price
		{
			get
			{
				return this._Price;
			}
			set
			{
				if ((this._Price != value))
				{
					this.OnPriceChanging(value);
					this.SendPropertyChanging();
					this._Price = value;
					this.SendPropertyChanged("Price");
					this.OnPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OnStock", DbType="Int NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=5)]
		public int OnStock
		{
			get
			{
				return this._OnStock;
			}
			set
			{
				if ((this._OnStock != value))
				{
					this.OnOnStockChanging(value);
					this.SendPropertyChanging();
					this._OnStock = value;
					this.SendPropertyChanged("OnStock");
					this.OnOnStockChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Added", DbType="Int NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=6)]
		public int Added
		{
			get
			{
				return this._Added;
			}
			set
			{
				if ((this._Added != value))
				{
					this.OnAddedChanging(value);
					this.SendPropertyChanging();
					this._Added = value;
					this.SendPropertyChanged("Added");
					this.OnAddedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Removed", DbType="Int NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=7)]
		public int Removed
		{
			get
			{
				return this._Removed;
			}
			set
			{
				if ((this._Removed != value))
				{
					this.OnRemovedChanging(value);
					this.SendPropertyChanging();
					this._Removed = value;
					this.SendPropertyChanged("Removed");
					this.OnRemovedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Sold", DbType="Int NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=8)]
		public int Sold
		{
			get
			{
				return this._Sold;
			}
			set
			{
				if ((this._Sold != value))
				{
					this.OnSoldChanging(value);
					this.SendPropertyChanging();
					this._Sold = value;
					this.SendPropertyChanged("Sold");
					this.OnSoldChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateCreated", DbType="DateTime NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=9)]
		public System.DateTime DateCreated
		{
			get
			{
				return this._DateCreated;
			}
			set
			{
				if ((this._DateCreated != value))
				{
					this.OnDateCreatedChanging(value);
					this.SendPropertyChanging();
					this._DateCreated = value;
					this.SendPropertyChanged("DateCreated");
					this.OnDateCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateDeleted", DbType="DateTime")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=10)]
		public System.Nullable<System.DateTime> DateDeleted
		{
			get
			{
				return this._DateDeleted;
			}
			set
			{
				if ((this._DateDeleted != value))
				{
					this.OnDateDeletedChanging(value);
					this.SendPropertyChanging();
					this._DateDeleted = value;
					this.SendPropertyChanged("DateDeleted");
					this.OnDateDeletedChanged();
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
		
		private void Initialize()
		{
			OnCreated();
		}
		
		[global::System.Runtime.Serialization.OnDeserializingAttribute()]
		[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnDeserializing(StreamingContext context)
		{
			this.Initialize();
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	[global::System.Runtime.Serialization.DataContractAttribute()]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _UserId;
		
		private string _FirstName;
		
		private string _LastName;
		
		private string _Password;
		
		private System.DateTime _DateCreated;
		
		private System.Nullable<System.DateTime> _DateDeleted;
		
		private System.Data.Linq.Binary _AvatarData;
		
		private string _ColorHex;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIdChanging(System.Guid value);
    partial void OnUserIdChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnDateCreatedChanging(System.DateTime value);
    partial void OnDateCreatedChanged();
    partial void OnDateDeletedChanging(System.Nullable<System.DateTime> value);
    partial void OnDateDeletedChanged();
    partial void OnAvatarDataChanging(System.Data.Linq.Binary value);
    partial void OnAvatarDataChanged();
    partial void OnColorHexChanging(string value);
    partial void OnColorHexChanged();
    #endregion
		
		public User()
		{
			this.Initialize();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=1)]
		public System.Guid UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=2)]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=3)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=4)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateCreated", DbType="DateTime NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=5)]
		public System.DateTime DateCreated
		{
			get
			{
				return this._DateCreated;
			}
			set
			{
				if ((this._DateCreated != value))
				{
					this.OnDateCreatedChanging(value);
					this.SendPropertyChanging();
					this._DateCreated = value;
					this.SendPropertyChanged("DateCreated");
					this.OnDateCreatedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DateDeleted", DbType="DateTime")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=6)]
		public System.Nullable<System.DateTime> DateDeleted
		{
			get
			{
				return this._DateDeleted;
			}
			set
			{
				if ((this._DateDeleted != value))
				{
					this.OnDateDeletedChanging(value);
					this.SendPropertyChanging();
					this._DateDeleted = value;
					this.SendPropertyChanged("DateDeleted");
					this.OnDateDeletedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AvatarData", DbType="VarBinary(MAX)", UpdateCheck=UpdateCheck.Never)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=7)]
		public System.Data.Linq.Binary AvatarData
		{
			get
			{
				return this._AvatarData;
			}
			set
			{
				if ((this._AvatarData != value))
				{
					this.OnAvatarDataChanging(value);
					this.SendPropertyChanging();
					this._AvatarData = value;
					this.SendPropertyChanged("AvatarData");
					this.OnAvatarDataChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ColorHex", DbType="VarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=8)]
		public string ColorHex
		{
			get
			{
				return this._ColorHex;
			}
			set
			{
				if ((this._ColorHex != value))
				{
					this.OnColorHexChanging(value);
					this.SendPropertyChanging();
					this._ColorHex = value;
					this.SendPropertyChanged("ColorHex");
					this.OnColorHexChanged();
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
		
		private void Initialize()
		{
			OnCreated();
		}
		
		[global::System.Runtime.Serialization.OnDeserializingAttribute()]
		[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
		public void OnDeserializing(StreamingContext context)
		{
			this.Initialize();
		}
	}
	
	[global::System.Runtime.Serialization.DataContractAttribute()]
	public partial class usp_get_shiftsResult
	{
		
		private System.Nullable<System.DateTime> _Date;
		
		private System.Nullable<System.Guid> _ShiftId;
		
		private System.Nullable<int> _ShiftType;
		
		private System.Nullable<int> _Duration;
		
		private string _FirstName;
		
		private string _LastName;
		
		private System.Guid _UserId;
		
		private string _ColorHex;
		
		private System.Data.Linq.Binary _AvatarData;
		
		public usp_get_shiftsResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Date", DbType="DateTime")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=1)]
		public System.Nullable<System.DateTime> Date
		{
			get
			{
				return this._Date;
			}
			set
			{
				if ((this._Date != value))
				{
					this._Date = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShiftId", DbType="UniqueIdentifier")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=2)]
		public System.Nullable<System.Guid> ShiftId
		{
			get
			{
				return this._ShiftId;
			}
			set
			{
				if ((this._ShiftId != value))
				{
					this._ShiftId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShiftType", DbType="Int")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=3)]
		public System.Nullable<int> ShiftType
		{
			get
			{
				return this._ShiftType;
			}
			set
			{
				if ((this._ShiftType != value))
				{
					this._ShiftType = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Duration", DbType="Int")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=4)]
		public System.Nullable<int> Duration
		{
			get
			{
				return this._Duration;
			}
			set
			{
				if ((this._Duration != value))
				{
					this._Duration = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=5)]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this._FirstName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=6)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this._LastName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="UniqueIdentifier NOT NULL")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=7)]
		public System.Guid UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this._UserId = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ColorHex", DbType="VarChar(50)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=8)]
		public string ColorHex
		{
			get
			{
				return this._ColorHex;
			}
			set
			{
				if ((this._ColorHex != value))
				{
					this._ColorHex = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AvatarData", DbType="VarBinary(MAX)")]
		[global::System.Runtime.Serialization.DataMemberAttribute(Order=9)]
		public System.Data.Linq.Binary AvatarData
		{
			get
			{
				return this._AvatarData;
			}
			set
			{
				if ((this._AvatarData != value))
				{
					this._AvatarData = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
