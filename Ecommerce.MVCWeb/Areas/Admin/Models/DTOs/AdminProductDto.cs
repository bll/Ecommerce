using Ecommerce.MVCWeb.Attributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.MVCWeb.Areas.Admin.Models.DTOs
{
    public class AdminProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alanını doldurunuz.")]
        [CheckBarcodeIsExistAttribute]
        public string Barcode { get; set; }
        [Required(ErrorMessage = "{0} alanını doldurunuz.")]
        public string Name { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "{0} alanı 1 den büyük olmalıdır.")]
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
      
        [DataType(DataType.MultilineText)]
        [MaxLength(500)]
        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Lütfen bir {0} seçiniz.")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Display(Name = "Image")]
        public List<IFormFile> ProductImages { get; set; }

    }
}
