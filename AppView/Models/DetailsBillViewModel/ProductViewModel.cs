﻿namespace AppView.Models.DetailsBillViewModel
{
	public class ProductViewModel
	{
        public Guid ProductID { get; set; }
        public Guid? ShoesDT_SizeId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Size { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
