using Ecommerce.Core.Services;
using Ecommerce.MVCWeb.Areas.Admin.Models.DTOs;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.MVCWeb.Attributes
{
    public class CheckBarcodeIsExistAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext) {

           var productService = validationContext.GetService(typeof(IProductService)) as IProductService;

            var adminProduct = validationContext.ObjectInstance as AdminProductDto;

            if (barcodeIsExist(adminProduct, productService)) {

                return new ValidationResult("Eklemek istediğiniz barkod başka bir ürün tarafından kullanılıyor.");
            }

            return ValidationResult.Success;

        }

        private bool barcodeIsExist(AdminProductDto adminProduct, IProductService productService) {

            if (adminProduct != null && !string.IsNullOrEmpty(adminProduct.Barcode)) {
                var product = productService.SingleOrDefaultAsNoTrackingAsync(p => p.Barcode == adminProduct.Barcode).Result;

                if (product != null) {
                    if (product.Id != adminProduct.Id) {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
