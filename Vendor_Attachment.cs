//using System;
//using System.Data;
//namespace SAP_Vendor
//{
//	public partial class Vendor_Attachment
//	{
//		public Vendor_Attachment()
//		{
//		}
//		protected string _ID = string.Empty;
//		public string ID
//		{
//			get
//			{
//				return _ID;
//			}
//			set
//			{
//				_ID = value;
//			}
//		}
//		public const string P_ID = "ID";
//		protected string _Request_ID = string.Empty;
//		public string Request_ID
//		{
//			get
//			{
//				return _Request_ID;
//			}
//			set
//			{
//				_Request_ID = value;
//			}
//		}
//		public const string P_Request_ID = "Request_ID";
//		protected string _FileName = string.Empty;
//		public string FileName
//		{
//			get
//			{
//				return _FileName;
//			}
//			set
//			{
//				_FileName = value;
//			}
//		}
//		public const string P_FileName = "FileName";
//		public Vendor_Attachment(DataRow obj)
//		{
//			try
//			{
//				if (obj == null)
//					return;
//				if (obj.Table.Columns.Contains(P_ID))
//					ID = obj[P_ID].ToString();
//				if (obj.Table.Columns.Contains(P_Request_ID))
//					Request_ID = obj[P_Request_ID].ToString();
//				if (obj.Table.Columns.Contains(P_FileName))
//					FileName = obj[P_FileName].ToString();
//			}
//			catch (Exception ex)
//			{
//				throw new Exception(ex.Message);
//			}
//		}
//	}
//}