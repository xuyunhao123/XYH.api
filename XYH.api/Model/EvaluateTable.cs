using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Converters;
using System.Threading.Tasks;

namespace XYH.api.Model
{
	public class EvaluateTable
	{

				public int PID { get; set; }
				public DateTime PTime { get; set; }
				public string PDingdan { get; set; }
				public string PNeirong { get; set; }
	        	[JsonConverter(typeof(StringEnumConverter))]
	        	public PHuifu PHuifu { get; set; }
				[JsonConverter(typeof(StringEnumConverter))]
				public PState PState { get; set; }

			}
			public enum PState
			{
				正常 = 1,
				禁用 = 2
			}
	        public enum PHuifu
	        {
	        	已回复=1,
	        	未回复=2
	        }
	   public class Page
	   {
	    	public List<EvaluateTable> EvaluateTable { get; set; } //列表
	     	public int totalCount { get; set; } //总记录数
	     	public int totalPage { get; set; } //总页数
	     	public int currentPage { get; set; } //当前页
	   }

}
