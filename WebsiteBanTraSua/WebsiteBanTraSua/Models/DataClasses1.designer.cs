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

namespace WebsiteBanTraSua.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="QLBanTraSua")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertBILL(BILL instance);
    partial void UpdateBILL(BILL instance);
    partial void DeleteBILL(BILL instance);
    partial void InsertBILLDETAIL(BILLDETAIL instance);
    partial void UpdateBILLDETAIL(BILLDETAIL instance);
    partial void DeleteBILLDETAIL(BILLDETAIL instance);
    partial void InsertCATEGORY(CATEGORY instance);
    partial void UpdateCATEGORY(CATEGORY instance);
    partial void DeleteCATEGORY(CATEGORY instance);
    partial void InsertCONTACT(CONTACT instance);
    partial void UpdateCONTACT(CONTACT instance);
    partial void DeleteCONTACT(CONTACT instance);
    partial void InsertCUSTOMER(CUSTOMER instance);
    partial void UpdateCUSTOMER(CUSTOMER instance);
    partial void DeleteCUSTOMER(CUSTOMER instance);
    partial void InsertPRODUCT(PRODUCT instance);
    partial void UpdatePRODUCT(PRODUCT instance);
    partial void DeletePRODUCT(PRODUCT instance);
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["QLBanTraSuaConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<BILL> BILLs
		{
			get
			{
				return this.GetTable<BILL>();
			}
		}
		
		public System.Data.Linq.Table<BILLDETAIL> BILLDETAILs
		{
			get
			{
				return this.GetTable<BILLDETAIL>();
			}
		}
		
		public System.Data.Linq.Table<CATEGORY> CATEGORies
		{
			get
			{
				return this.GetTable<CATEGORY>();
			}
		}
		
		public System.Data.Linq.Table<CONTACT> CONTACTs
		{
			get
			{
				return this.GetTable<CONTACT>();
			}
		}
		
		public System.Data.Linq.Table<CUSTOMER> CUSTOMERs
		{
			get
			{
				return this.GetTable<CUSTOMER>();
			}
		}
		
		public System.Data.Linq.Table<PRODUCT> PRODUCTs
		{
			get
			{
				return this.GetTable<PRODUCT>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.BILL")]
	public partial class BILL : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _maHD;
		
		private string _userName;
		
		private System.Nullable<System.DateTime> _ngayMua;
		
		private System.Nullable<decimal> _tongTien;
		
		private System.Nullable<System.DateTime> _ngayHenGiao;
		
		private System.Nullable<System.DateTime> _ngayThanhToan;
		
		private System.Nullable<System.DateTime> _ngayGiaoHang;
		
		private EntitySet<BILLDETAIL> _BILLDETAILs;
		
		private EntityRef<CUSTOMER> _CUSTOMER;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnmaHDChanging(int value);
    partial void OnmaHDChanged();
    partial void OnuserNameChanging(string value);
    partial void OnuserNameChanged();
    partial void OnngayMuaChanging(System.Nullable<System.DateTime> value);
    partial void OnngayMuaChanged();
    partial void OntongTienChanging(System.Nullable<decimal> value);
    partial void OntongTienChanged();
    partial void OnngayHenGiaoChanging(System.Nullable<System.DateTime> value);
    partial void OnngayHenGiaoChanged();
    partial void OnngayThanhToanChanging(System.Nullable<System.DateTime> value);
    partial void OnngayThanhToanChanged();
    partial void OnngayGiaoHangChanging(System.Nullable<System.DateTime> value);
    partial void OnngayGiaoHangChanged();
    #endregion
		
		public BILL()
		{
			this._BILLDETAILs = new EntitySet<BILLDETAIL>(new Action<BILLDETAIL>(this.attach_BILLDETAILs), new Action<BILLDETAIL>(this.detach_BILLDETAILs));
			this._CUSTOMER = default(EntityRef<CUSTOMER>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maHD", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int maHD
		{
			get
			{
				return this._maHD;
			}
			set
			{
				if ((this._maHD != value))
				{
					this.OnmaHDChanging(value);
					this.SendPropertyChanging();
					this._maHD = value;
					this.SendPropertyChanged("maHD");
					this.OnmaHDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_userName", DbType="Char(50)")]
		public string userName
		{
			get
			{
				return this._userName;
			}
			set
			{
				if ((this._userName != value))
				{
					if (this._CUSTOMER.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnuserNameChanging(value);
					this.SendPropertyChanging();
					this._userName = value;
					this.SendPropertyChanged("userName");
					this.OnuserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ngayMua", DbType="Date")]
		public System.Nullable<System.DateTime> ngayMua
		{
			get
			{
				return this._ngayMua;
			}
			set
			{
				if ((this._ngayMua != value))
				{
					this.OnngayMuaChanging(value);
					this.SendPropertyChanging();
					this._ngayMua = value;
					this.SendPropertyChanged("ngayMua");
					this.OnngayMuaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tongTien", DbType="Money")]
		public System.Nullable<decimal> tongTien
		{
			get
			{
				return this._tongTien;
			}
			set
			{
				if ((this._tongTien != value))
				{
					this.OntongTienChanging(value);
					this.SendPropertyChanging();
					this._tongTien = value;
					this.SendPropertyChanged("tongTien");
					this.OntongTienChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ngayHenGiao", DbType="Date")]
		public System.Nullable<System.DateTime> ngayHenGiao
		{
			get
			{
				return this._ngayHenGiao;
			}
			set
			{
				if ((this._ngayHenGiao != value))
				{
					this.OnngayHenGiaoChanging(value);
					this.SendPropertyChanging();
					this._ngayHenGiao = value;
					this.SendPropertyChanged("ngayHenGiao");
					this.OnngayHenGiaoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ngayThanhToan", DbType="Date")]
		public System.Nullable<System.DateTime> ngayThanhToan
		{
			get
			{
				return this._ngayThanhToan;
			}
			set
			{
				if ((this._ngayThanhToan != value))
				{
					this.OnngayThanhToanChanging(value);
					this.SendPropertyChanging();
					this._ngayThanhToan = value;
					this.SendPropertyChanged("ngayThanhToan");
					this.OnngayThanhToanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ngayGiaoHang", DbType="Date")]
		public System.Nullable<System.DateTime> ngayGiaoHang
		{
			get
			{
				return this._ngayGiaoHang;
			}
			set
			{
				if ((this._ngayGiaoHang != value))
				{
					this.OnngayGiaoHangChanging(value);
					this.SendPropertyChanging();
					this._ngayGiaoHang = value;
					this.SendPropertyChanged("ngayGiaoHang");
					this.OnngayGiaoHangChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="BILL_BILLDETAIL", Storage="_BILLDETAILs", ThisKey="maHD", OtherKey="maHD")]
		public EntitySet<BILLDETAIL> BILLDETAILs
		{
			get
			{
				return this._BILLDETAILs;
			}
			set
			{
				this._BILLDETAILs.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CUSTOMER_BILL", Storage="_CUSTOMER", ThisKey="userName", OtherKey="userName", IsForeignKey=true)]
		public CUSTOMER CUSTOMER
		{
			get
			{
				return this._CUSTOMER.Entity;
			}
			set
			{
				CUSTOMER previousValue = this._CUSTOMER.Entity;
				if (((previousValue != value) 
							|| (this._CUSTOMER.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._CUSTOMER.Entity = null;
						previousValue.BILLs.Remove(this);
					}
					this._CUSTOMER.Entity = value;
					if ((value != null))
					{
						value.BILLs.Add(this);
						this._userName = value.userName;
					}
					else
					{
						this._userName = default(string);
					}
					this.SendPropertyChanged("CUSTOMER");
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
		
		private void attach_BILLDETAILs(BILLDETAIL entity)
		{
			this.SendPropertyChanging();
			entity.BILL = this;
		}
		
		private void detach_BILLDETAILs(BILLDETAIL entity)
		{
			this.SendPropertyChanging();
			entity.BILL = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.BILLDETAILS")]
	public partial class BILLDETAIL : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _maHD;
		
		private string _maSP;
		
		private System.Nullable<int> _soLuong;
		
		private EntityRef<BILL> _BILL;
		
		private EntityRef<PRODUCT> _PRODUCT;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnmaHDChanging(int value);
    partial void OnmaHDChanged();
    partial void OnmaSPChanging(string value);
    partial void OnmaSPChanged();
    partial void OnsoLuongChanging(System.Nullable<int> value);
    partial void OnsoLuongChanged();
    #endregion
		
		public BILLDETAIL()
		{
			this._BILL = default(EntityRef<BILL>);
			this._PRODUCT = default(EntityRef<PRODUCT>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maHD", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int maHD
		{
			get
			{
				return this._maHD;
			}
			set
			{
				if ((this._maHD != value))
				{
					if (this._BILL.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnmaHDChanging(value);
					this.SendPropertyChanging();
					this._maHD = value;
					this.SendPropertyChanged("maHD");
					this.OnmaHDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maSP", DbType="Char(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string maSP
		{
			get
			{
				return this._maSP;
			}
			set
			{
				if ((this._maSP != value))
				{
					if (this._PRODUCT.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnmaSPChanging(value);
					this.SendPropertyChanging();
					this._maSP = value;
					this.SendPropertyChanged("maSP");
					this.OnmaSPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_soLuong", DbType="Int")]
		public System.Nullable<int> soLuong
		{
			get
			{
				return this._soLuong;
			}
			set
			{
				if ((this._soLuong != value))
				{
					this.OnsoLuongChanging(value);
					this.SendPropertyChanging();
					this._soLuong = value;
					this.SendPropertyChanged("soLuong");
					this.OnsoLuongChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="BILL_BILLDETAIL", Storage="_BILL", ThisKey="maHD", OtherKey="maHD", IsForeignKey=true)]
		public BILL BILL
		{
			get
			{
				return this._BILL.Entity;
			}
			set
			{
				BILL previousValue = this._BILL.Entity;
				if (((previousValue != value) 
							|| (this._BILL.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._BILL.Entity = null;
						previousValue.BILLDETAILs.Remove(this);
					}
					this._BILL.Entity = value;
					if ((value != null))
					{
						value.BILLDETAILs.Add(this);
						this._maHD = value.maHD;
					}
					else
					{
						this._maHD = default(int);
					}
					this.SendPropertyChanged("BILL");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PRODUCT_BILLDETAIL", Storage="_PRODUCT", ThisKey="maSP", OtherKey="maSP", IsForeignKey=true)]
		public PRODUCT PRODUCT
		{
			get
			{
				return this._PRODUCT.Entity;
			}
			set
			{
				PRODUCT previousValue = this._PRODUCT.Entity;
				if (((previousValue != value) 
							|| (this._PRODUCT.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._PRODUCT.Entity = null;
						previousValue.BILLDETAILs.Remove(this);
					}
					this._PRODUCT.Entity = value;
					if ((value != null))
					{
						value.BILLDETAILs.Add(this);
						this._maSP = value.maSP;
					}
					else
					{
						this._maSP = default(string);
					}
					this.SendPropertyChanged("PRODUCT");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CATEGORY")]
	public partial class CATEGORY : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _maLoai;
		
		private string _tenLoai;
		
		private EntitySet<PRODUCT> _PRODUCTs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnmaLoaiChanging(string value);
    partial void OnmaLoaiChanged();
    partial void OntenLoaiChanging(string value);
    partial void OntenLoaiChanged();
    #endregion
		
		public CATEGORY()
		{
			this._PRODUCTs = new EntitySet<PRODUCT>(new Action<PRODUCT>(this.attach_PRODUCTs), new Action<PRODUCT>(this.detach_PRODUCTs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maLoai", DbType="Char(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string maLoai
		{
			get
			{
				return this._maLoai;
			}
			set
			{
				if ((this._maLoai != value))
				{
					this.OnmaLoaiChanging(value);
					this.SendPropertyChanging();
					this._maLoai = value;
					this.SendPropertyChanged("maLoai");
					this.OnmaLoaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tenLoai", DbType="NVarChar(MAX)")]
		public string tenLoai
		{
			get
			{
				return this._tenLoai;
			}
			set
			{
				if ((this._tenLoai != value))
				{
					this.OntenLoaiChanging(value);
					this.SendPropertyChanging();
					this._tenLoai = value;
					this.SendPropertyChanged("tenLoai");
					this.OntenLoaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CATEGORY_PRODUCT", Storage="_PRODUCTs", ThisKey="maLoai", OtherKey="maLoai")]
		public EntitySet<PRODUCT> PRODUCTs
		{
			get
			{
				return this._PRODUCTs;
			}
			set
			{
				this._PRODUCTs.Assign(value);
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
		
		private void attach_PRODUCTs(PRODUCT entity)
		{
			this.SendPropertyChanging();
			entity.CATEGORY = this;
		}
		
		private void detach_PRODUCTs(PRODUCT entity)
		{
			this.SendPropertyChanging();
			entity.CATEGORY = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CONTACT")]
	public partial class CONTACT : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _userName;
		
		private string _mess;
		
		private EntityRef<CUSTOMER> _CUSTOMER;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnuserNameChanging(string value);
    partial void OnuserNameChanged();
    partial void OnmessChanging(string value);
    partial void OnmessChanged();
    #endregion
		
		public CONTACT()
		{
			this._CUSTOMER = default(EntityRef<CUSTOMER>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_userName", DbType="Char(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string userName
		{
			get
			{
				return this._userName;
			}
			set
			{
				if ((this._userName != value))
				{
					if (this._CUSTOMER.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnuserNameChanging(value);
					this.SendPropertyChanging();
					this._userName = value;
					this.SendPropertyChanged("userName");
					this.OnuserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mess", DbType="NVarChar(MAX)")]
		public string mess
		{
			get
			{
				return this._mess;
			}
			set
			{
				if ((this._mess != value))
				{
					this.OnmessChanging(value);
					this.SendPropertyChanging();
					this._mess = value;
					this.SendPropertyChanged("mess");
					this.OnmessChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CUSTOMER_CONTACT", Storage="_CUSTOMER", ThisKey="userName", OtherKey="userName", IsForeignKey=true)]
		public CUSTOMER CUSTOMER
		{
			get
			{
				return this._CUSTOMER.Entity;
			}
			set
			{
				CUSTOMER previousValue = this._CUSTOMER.Entity;
				if (((previousValue != value) 
							|| (this._CUSTOMER.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._CUSTOMER.Entity = null;
						previousValue.CONTACT = null;
					}
					this._CUSTOMER.Entity = value;
					if ((value != null))
					{
						value.CONTACT = this;
						this._userName = value.userName;
					}
					else
					{
						this._userName = default(string);
					}
					this.SendPropertyChanged("CUSTOMER");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CUSTOMER")]
	public partial class CUSTOMER : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _userName;
		
		private string _pass;
		
		private string _hoTen;
		
		private string _soDT;
		
		private string _diaChi;
		
		private string _email;
		
		private EntitySet<BILL> _BILLs;
		
		private EntityRef<CONTACT> _CONTACT;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnuserNameChanging(string value);
    partial void OnuserNameChanged();
    partial void OnpassChanging(string value);
    partial void OnpassChanged();
    partial void OnhoTenChanging(string value);
    partial void OnhoTenChanged();
    partial void OnsoDTChanging(string value);
    partial void OnsoDTChanged();
    partial void OndiaChiChanging(string value);
    partial void OndiaChiChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    #endregion
		
		public CUSTOMER()
		{
			this._BILLs = new EntitySet<BILL>(new Action<BILL>(this.attach_BILLs), new Action<BILL>(this.detach_BILLs));
			this._CONTACT = default(EntityRef<CONTACT>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_userName", DbType="Char(50) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string userName
		{
			get
			{
				return this._userName;
			}
			set
			{
				if ((this._userName != value))
				{
					this.OnuserNameChanging(value);
					this.SendPropertyChanging();
					this._userName = value;
					this.SendPropertyChanged("userName");
					this.OnuserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pass", DbType="Char(50)")]
		public string pass
		{
			get
			{
				return this._pass;
			}
			set
			{
				if ((this._pass != value))
				{
					this.OnpassChanging(value);
					this.SendPropertyChanging();
					this._pass = value;
					this.SendPropertyChanged("pass");
					this.OnpassChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_hoTen", DbType="NVarChar(MAX)")]
		public string hoTen
		{
			get
			{
				return this._hoTen;
			}
			set
			{
				if ((this._hoTen != value))
				{
					this.OnhoTenChanging(value);
					this.SendPropertyChanging();
					this._hoTen = value;
					this.SendPropertyChanged("hoTen");
					this.OnhoTenChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_soDT", DbType="Char(10)")]
		public string soDT
		{
			get
			{
				return this._soDT;
			}
			set
			{
				if ((this._soDT != value))
				{
					this.OnsoDTChanging(value);
					this.SendPropertyChanging();
					this._soDT = value;
					this.SendPropertyChanged("soDT");
					this.OnsoDTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_diaChi", DbType="NVarChar(MAX)")]
		public string diaChi
		{
			get
			{
				return this._diaChi;
			}
			set
			{
				if ((this._diaChi != value))
				{
					this.OndiaChiChanging(value);
					this.SendPropertyChanging();
					this._diaChi = value;
					this.SendPropertyChanged("diaChi");
					this.OndiaChiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="Char(90)")]
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
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CUSTOMER_BILL", Storage="_BILLs", ThisKey="userName", OtherKey="userName")]
		public EntitySet<BILL> BILLs
		{
			get
			{
				return this._BILLs;
			}
			set
			{
				this._BILLs.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CUSTOMER_CONTACT", Storage="_CONTACT", ThisKey="userName", OtherKey="userName", IsUnique=true, IsForeignKey=false)]
		public CONTACT CONTACT
		{
			get
			{
				return this._CONTACT.Entity;
			}
			set
			{
				CONTACT previousValue = this._CONTACT.Entity;
				if (((previousValue != value) 
							|| (this._CONTACT.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._CONTACT.Entity = null;
						previousValue.CUSTOMER = null;
					}
					this._CONTACT.Entity = value;
					if ((value != null))
					{
						value.CUSTOMER = this;
					}
					this.SendPropertyChanged("CONTACT");
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
		
		private void attach_BILLs(BILL entity)
		{
			this.SendPropertyChanging();
			entity.CUSTOMER = this;
		}
		
		private void detach_BILLs(BILL entity)
		{
			this.SendPropertyChanging();
			entity.CUSTOMER = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.PRODUCTS")]
	public partial class PRODUCT : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _maSP;
		
		private string _tenSP;
		
		private string _maLoai;
		
		private System.Nullable<decimal> _gia;
		
		private string _gioiThieu;
		
		private string _hinhAnh;
		
		private System.Nullable<int> _soLuongTon;
		
		private EntitySet<BILLDETAIL> _BILLDETAILs;
		
		private EntityRef<CATEGORY> _CATEGORY;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnmaSPChanging(string value);
    partial void OnmaSPChanged();
    partial void OntenSPChanging(string value);
    partial void OntenSPChanged();
    partial void OnmaLoaiChanging(string value);
    partial void OnmaLoaiChanged();
    partial void OngiaChanging(System.Nullable<decimal> value);
    partial void OngiaChanged();
    partial void OngioiThieuChanging(string value);
    partial void OngioiThieuChanged();
    partial void OnhinhAnhChanging(string value);
    partial void OnhinhAnhChanged();
    partial void OnsoLuongTonChanging(System.Nullable<int> value);
    partial void OnsoLuongTonChanged();
    #endregion
		
		public PRODUCT()
		{
			this._BILLDETAILs = new EntitySet<BILLDETAIL>(new Action<BILLDETAIL>(this.attach_BILLDETAILs), new Action<BILLDETAIL>(this.detach_BILLDETAILs));
			this._CATEGORY = default(EntityRef<CATEGORY>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maSP", DbType="Char(10) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string maSP
		{
			get
			{
				return this._maSP;
			}
			set
			{
				if ((this._maSP != value))
				{
					this.OnmaSPChanging(value);
					this.SendPropertyChanging();
					this._maSP = value;
					this.SendPropertyChanged("maSP");
					this.OnmaSPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_tenSP", DbType="NVarChar(MAX)")]
		public string tenSP
		{
			get
			{
				return this._tenSP;
			}
			set
			{
				if ((this._tenSP != value))
				{
					this.OntenSPChanging(value);
					this.SendPropertyChanging();
					this._tenSP = value;
					this.SendPropertyChanged("tenSP");
					this.OntenSPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_maLoai", DbType="Char(10)")]
		public string maLoai
		{
			get
			{
				return this._maLoai;
			}
			set
			{
				if ((this._maLoai != value))
				{
					if (this._CATEGORY.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnmaLoaiChanging(value);
					this.SendPropertyChanging();
					this._maLoai = value;
					this.SendPropertyChanged("maLoai");
					this.OnmaLoaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_gia", DbType="Money")]
		public System.Nullable<decimal> gia
		{
			get
			{
				return this._gia;
			}
			set
			{
				if ((this._gia != value))
				{
					this.OngiaChanging(value);
					this.SendPropertyChanging();
					this._gia = value;
					this.SendPropertyChanged("gia");
					this.OngiaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_gioiThieu", DbType="NVarChar(MAX)")]
		public string gioiThieu
		{
			get
			{
				return this._gioiThieu;
			}
			set
			{
				if ((this._gioiThieu != value))
				{
					this.OngioiThieuChanging(value);
					this.SendPropertyChanging();
					this._gioiThieu = value;
					this.SendPropertyChanged("gioiThieu");
					this.OngioiThieuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_hinhAnh", DbType="NVarChar(MAX)")]
		public string hinhAnh
		{
			get
			{
				return this._hinhAnh;
			}
			set
			{
				if ((this._hinhAnh != value))
				{
					this.OnhinhAnhChanging(value);
					this.SendPropertyChanging();
					this._hinhAnh = value;
					this.SendPropertyChanged("hinhAnh");
					this.OnhinhAnhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_soLuongTon", DbType="Int")]
		public System.Nullable<int> soLuongTon
		{
			get
			{
				return this._soLuongTon;
			}
			set
			{
				if ((this._soLuongTon != value))
				{
					this.OnsoLuongTonChanging(value);
					this.SendPropertyChanging();
					this._soLuongTon = value;
					this.SendPropertyChanged("soLuongTon");
					this.OnsoLuongTonChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="PRODUCT_BILLDETAIL", Storage="_BILLDETAILs", ThisKey="maSP", OtherKey="maSP")]
		public EntitySet<BILLDETAIL> BILLDETAILs
		{
			get
			{
				return this._BILLDETAILs;
			}
			set
			{
				this._BILLDETAILs.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CATEGORY_PRODUCT", Storage="_CATEGORY", ThisKey="maLoai", OtherKey="maLoai", IsForeignKey=true)]
		public CATEGORY CATEGORY
		{
			get
			{
				return this._CATEGORY.Entity;
			}
			set
			{
				CATEGORY previousValue = this._CATEGORY.Entity;
				if (((previousValue != value) 
							|| (this._CATEGORY.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._CATEGORY.Entity = null;
						previousValue.PRODUCTs.Remove(this);
					}
					this._CATEGORY.Entity = value;
					if ((value != null))
					{
						value.PRODUCTs.Add(this);
						this._maLoai = value.maLoai;
					}
					else
					{
						this._maLoai = default(string);
					}
					this.SendPropertyChanged("CATEGORY");
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
		
		private void attach_BILLDETAILs(BILLDETAIL entity)
		{
			this.SendPropertyChanging();
			entity.PRODUCT = this;
		}
		
		private void detach_BILLDETAILs(BILLDETAIL entity)
		{
			this.SendPropertyChanging();
			entity.PRODUCT = null;
		}
	}
}
#pragma warning restore 1591
