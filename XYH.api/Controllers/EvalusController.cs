using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XYH.api.Dal;
using XYH.api.Model;
using Newtonsoft.Json;
namespace XYH.api.Controllers
{
	[Route("api/[controller]")]
	//设置跨域处理的代理
	[ApiController]
	public class EvalusController : ControllerBase
	{
		private EInter _eInter;
		public EvalusController (EInter eInter)
		{
			_eInter = eInter;
		}
		
		[Route("/api/Getshow")]
		[HttpGet]
		//显示查询
		public IActionResult Getshow (int pageSize = 5 , int currentPage = 1)
		{
			List<EvaluateTable> list = _eInter.Getshow();
			string json = JsonConvert.SerializeObject(list);
			if (currentPage < 1)//纠正当前页少于1的情况
			{
				currentPage = 1;
			}
			var count = json.Count();
			int page;
			if (count % pageSize == 0)
			{
				page = count / pageSize;
			}
			else
			{
				page = count / pageSize + 1;
			}
			if (currentPage > page)
			{
				currentPage = page;
			}
			var p = new Page();
			p.EvaluateTable = list.Skip(( currentPage - 1 ) * pageSize).Take(pageSize).ToList();
			p.currentPage = currentPage;
			p.totalCount = count;
			p.totalPage = page;
			
			return Ok(p);
		}
	}
}
