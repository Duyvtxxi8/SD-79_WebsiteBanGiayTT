﻿using AppData.IRepositories;
using AppData.Models;
using AppData.Repositories;
//using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using PdfSharpCore.Pdf;
//using TheArtOfDev.HtmlRenderer.PdfSharp;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
		private readonly IAllRepositories<Bill> _repos;
		private ShopDBContext _dbContext = new ShopDBContext();
		private DbSet<Bill> _bill;
		public BillController()
		{
			_bill = _dbContext.Bills;
			AllRepositories<Bill> all = new AllRepositories<Bill>(_dbContext, _bill);
			_repos = all;
		}
		// GET: api/<BillController>
		[HttpGet("get-bill")]
		public IEnumerable<Bill> GetAllBill()
		{
			return _repos.GetAll();
		}

		[HttpGet("find-bill")]
		public IEnumerable<Bill> GetVoucher(string code)
		{
			return _repos.GetAll().Where(x => x.BillCode == code);
		}
		[HttpPost("create-bill")]
		public string CreateBill(string BillCode, DateTime CreateDate, DateTime SuccessDate, DateTime ConfirmationDate, DateTime DeliveryDate, DateTime CancelDate, DateTime UpdateDate, DateTime PaymentDate, decimal TotalPrice, decimal ShippingCosts, decimal TotalRefundAmount, decimal TotalPriceAfterDiscount, string Note, bool IsPaid , int TransactionType, int Status, Guid CustomerID, Guid VoucherID, Guid EmployeeID, Guid PurchaseMethodID, Guid AddressID, Guid ShippingVoucherID)
		{
			Bill bill = new Bill();
			bill.BillID = Guid.NewGuid();
			bill.BillCode = BillCode;
			bill.CreateDate = CreateDate;
			bill.SuccessDate = SuccessDate;
			bill.ConfirmationDate = ConfirmationDate;
			bill.DeliveryDate = DeliveryDate;
			bill.CancelDate = CancelDate;
			bill.UpdateDate = UpdateDate;
			bill.PaymentDay = PaymentDate;
			bill.TotalPrice = TotalPrice;
			bill.ShippingCosts = ShippingCosts;
			bill.TotalRefundAmount = TotalRefundAmount;
			bill.TotalPriceAfterDiscount = TotalPriceAfterDiscount;
			bill.Note = Note;
			bill.IsPaid = IsPaid;
			bill.TransactionType = TransactionType;
			bill.Status = Status;
			bill.VoucherID = VoucherID;
			bill.EmployeeID = EmployeeID;
			bill.CustomerID = CustomerID;
			bill.PurchaseMethodID = PurchaseMethodID;
			bill.AddressID = AddressID;
			bill.ShippingVoucherID = ShippingVoucherID;
			if (_repos.AddItem(bill))
			{
				return "Thêm thành công";
			}
			else
			{
				return "Thêm thất bại";
			}
		}

		// PUT api/<BillController>/5
		[HttpPut("update-bill")]
		public string UpdateBill(Guid BillID, string BillCode, DateTime CreateDate, DateTime SuccessDate, DateTime ConfirmationDate, DateTime DeliveryDate, DateTime CancelDate, DateTime UpdateDate, DateTime PaymentDate, decimal TotalPrice, decimal ShippingCosts, decimal TotalRefundAmount, decimal TotalPriceAfterDiscount, string Note, bool IsPaid , int TransactionType, int Status, Guid CustomerID, Guid VoucherID, Guid EmployeeID, Guid PurchaseMethodID, Guid AddressID, Guid ShippingVoucherID)
		{
			var bill = _repos.GetAll().First(c => c.BillID == BillID);
			bill.BillCode = BillCode;
			bill.CreateDate = CreateDate;
			bill.SuccessDate = SuccessDate;
			bill.ConfirmationDate = ConfirmationDate;
			bill.DeliveryDate = DeliveryDate;
			bill.CancelDate = CancelDate;
			bill.UpdateDate = UpdateDate;
			bill.PaymentDay = PaymentDate;
			bill.TotalPrice = TotalPrice;
			bill.ShippingCosts = ShippingCosts;
			bill.TotalRefundAmount = TotalRefundAmount;
			bill.TotalPriceAfterDiscount = TotalPriceAfterDiscount;
			bill.Note = Note;
			bill.IsPaid = IsPaid;
			bill.TransactionType = TransactionType;
			bill.Status = Status;
			bill.CustomerID = CustomerID;
			bill.EmployeeID = EmployeeID;
			bill.PurchaseMethodID = PurchaseMethodID;
			bill.VoucherID = VoucherID;
			bill.AddressID = AddressID;
			bill.ShippingVoucherID = ShippingVoucherID;
			if (_repos.EditItem(bill))
			{
				return "Sửa thành công";
			}
			else
			{
				return "Sửa thất bại";
			}
		}

		// DELETE api/<BillController>/5
		[HttpDelete("delete-bill")]
		public bool DeleteBill(Guid id)
		{
			var role = _repos.GetAll().First(c => c.BillID == id);
			role.Status = 1;
			return _repos.EditItem(role);
		}

	}
}
