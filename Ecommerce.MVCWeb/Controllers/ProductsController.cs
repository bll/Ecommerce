using AutoMapper;
using Ecommerce.Core.Services;
using Ecommerce.MVCWeb.Models.DTOs;
using Ecommerce.MVCWeb.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.MVCWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper) {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index() {
            var products = await _productService.GetProductsWithRelationsAsync();
            ProductViewModel viewModel = new ProductViewModel {
                Products = _mapper.Map<IEnumerable<ProductDto>>(products)
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Detail(int id) {
            var product = await _productService.GetProductWithImagesByIdAsync(id);
            if (product == null) {
                return RedirectToAction("Index", "Home");
            }

            ProductDetailViewModel viewModel = new ProductDetailViewModel {
                Product = _mapper.Map<ProductDto>(product)
            };
            return View(viewModel);
        }

    }
}