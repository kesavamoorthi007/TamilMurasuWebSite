﻿using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.Data;
using TamilMurasuWebsite.Interface;
using TamilMurasuWebsite.Models;
using TamilMurasuWebsite.Services;

namespace TamilMurasuWebsite.Controllers
{
	public class IndiaNewsController : Controller
	{
		IIndiaNewsService IndiaNewsService;
		IConfiguration? _configuratio;
		private string? _connectionString;
		public IndiaNewsController(IIndiaNewsService _IndiaNewsService, IConfiguration _configuratio)
		{
			IndiaNewsService = _IndiaNewsService;
			_connectionString = _configuratio.GetConnectionString("MySqlConnection");
		}
		public IActionResult IndiaNews()
		{
			IndiaNews br = new IndiaNews();

			List<India> TData = new List<India>();
			India tda = new India();

			DataTable dt1 = new DataTable();
			dt1 = IndiaNewsService.GetIndiaNews();
			for (int i = 0; i < dt1.Rows.Count; i++)
			{
				tda = new India();
				tda.News_head1 = dt1.Rows[i]["NT_Head"].ToString();
				tda.News_des = dt1.Rows[i]["N_Description"].ToString();
				tda.News_image = dt1.Rows[i]["S_Image"].ToString();
				tda.News_date = dt1.Rows[i]["AddedDateFormatted"].ToString();
				tda.N_id = dt1.Rows[i]["N_Id"].ToString();
				TData.Add(tda);

			}
			br.Indialst = TData;
			return View(br);
		}
		public IActionResult IndiaNewsDeatils(string id)
		{
			IndiaNews br = new IndiaNews();

			List<IndiaNewsDeatils> TData1 = new List<IndiaNewsDeatils>();
			IndiaNewsDeatils tda1 = new IndiaNewsDeatils();

			DataTable dt2 = new DataTable();
			dt2 = IndiaNewsService.GetIndiaNewsDeatils(id);
			for (int i = 0; i < dt2.Rows.Count; i++)
			{
				tda1 = new IndiaNewsDeatils();
				tda1.News_head1_d = dt2.Rows[i]["NT_Head"].ToString();
				tda1.News_des_d = dt2.Rows[i]["N_Description"].ToString();
				tda1.News_image_d = dt2.Rows[i]["S_Image"].ToString();
				tda1.News_date_d = dt2.Rows[i]["AddedDateFormatted"].ToString();
				tda1.N_id_d = dt2.Rows[i]["N_Id"].ToString();
				TData1.Add(tda1);

			}
			br.IndiaNewsDeatilslist = TData1;
			return View(br);
		}
	}
}
