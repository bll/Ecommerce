using Ecommerce.Core.Services;
using Ecommerce.MVCWeb.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.MVCWeb.Filters
{
    public class ProductNotFoundFilter : ActionFilterAttribute
    {
        private readonly IProductService _productService;

        public ProductNotFoundFilter(IProductService productService) {
            _productService = productService;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
            int id = (int)context.ActionArguments.Values.FirstOrDefault();
            var product = await _productService.GetByIdAsync(id);

            if (product != null) {
                await next();
            }
            else {
                ErrorDto errorDto = new ErrorDto();
                errorDto.Errors.Add($"{id} numaralı ürün bulunamadı.");

                context.Result = new RedirectToActionResult("Error", "Home", errorDto);
            }


        }
    }
}
