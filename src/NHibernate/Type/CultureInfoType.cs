using System;
using System.Data;
using System.Globalization;

using NHibernate.SqlTypes;

namespace NHibernate.Type {

	/// <summary>
	/// CultureInfoType for using a System.Globalization.CultureInfo an the 
	/// culture name (not the Culture ID) is stored in the DB.
	/// </summary>
	public class CultureInfoType : ImmutableType, ILiteralType {

		internal CultureInfoType(StringSqlType sqlType) : base(sqlType) {
		}

		public override object Get(IDataReader rs, int index) {
			string str = (string) NHibernate.String.Get(rs, index);
			if (str == null) {
				return null;
			}
			else {
				return new CultureInfo(str);
			}
		}

		public override object Get(IDataReader rs, string name) {
			return Get(rs, rs.GetOrdinal(name));
		}

		public override void Set(IDbCommand cmd, object value, int index) {
			NHibernate.String.Set(cmd, ((CultureInfo)value).Name, index);
		}
	
		public override string ToXML(object value) {
			return ((CultureInfo)value).Name;
		}
	
		public override System.Type ReturnedClass {
			get { return typeof(CultureInfo); }
		}
	
		public override bool Equals(object x, object y) {
			return (x==y); //???
		}
	
		public override string Name {
			get { return "CultureInfo"; }
		}

		public string ObjectToSQLString(object value) {
			return ( (ILiteralType) NHibernate.String ).ObjectToSQLString( value.ToString() );
		}
	}
}