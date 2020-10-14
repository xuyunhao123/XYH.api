using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlSugar;
using XYH.api.Model;

namespace XYH.api.Dal
{
	public class Edal: EInter
	{
		SqlSugarClient db = new SqlSugarClient(
			new ConnectionConfig
			{
				ConnectionString = @"Data Source=10.3.186.30;Initial Catalog=G6_Project;User ID=sa;Pwd = 123456",
				DbType=DbType.SqlServer,
				IsAutoCloseConnection=true,
			});
		public List<EvaluateTable> Getshow ()
		{
			return db.Queryable<EvaluateTable>().ToList();
		}
	}
}
