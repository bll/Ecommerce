using AutoMapper;
using Ecommerce.Core.Models;
using Ecommerce.Core.Services;
using Ecommerce.MVCWeb.Areas.Admin.Models.DTOs;
using Ecommerce.MVCWeb.Areas.Admin.Models.ViewModels;
using Ecommerce.MVCWeb.Filters;
using Ecommerce.MVCWeb.Models;
using Ecommerce.MVCWeb.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.MVCWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper,
            ICategoryService categoryService,
            IWebHostEnvironment webHostEnvironment) {
            _productService = productService;
            _mapper = mapper;
            _categoryService = categoryService;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index() {
            var products = await _productService.GetAllAsnyc();
            return View(_mapper.Map<IEnumerable<AdminProductDto>>(products));
        }

        public async Task<IActionResult> Create() {
            var createProductViewModel = new AdminCreateProductViewModel {
                Categories = await GetCategoriesAsync()
            };

            return View(createProductViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AdminCreateProductViewModel createProductViewModel) {
            if (!ModelState.IsValid) {
                return View(new AdminCreateProductViewModel { Categories = await GetCategoriesAsync() });
            }

            var product = _mapper.Map<Product>(createProductViewModel.Product);
            var uploadedImages = UploadedImages(createProductViewModel.Product.ProductImages);
            product.Image = uploadedImages.FirstOrDefault().ImageUrl.ToString();
            product.ProductImages = _mapper.Map<ICollection<ProductImage>>(uploadedImages);

            await _productService.AddAsnyc(product);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id) {
            var product = await _productService.GetByIdAsync(id);

            if (product == null) {
                return RedirectToAction("Index");

            }
            var productViewModel = new AdminUpdateProductViewModel {
                Product = _mapper.Map<AdminProductDto>(product),
                Categories = await GetCategoriesAsync()
            };

            return View(productViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AdminUpdateProductViewModel updateProductViewModel) {
            if (!ModelState.IsValid) {
                return View(new AdminUpdateProductViewModel { Categories = await GetCategoriesAsync() });
            }
            _productService.Update(_mapper.Map<Product>(updateProductViewModel.Product));

            return RedirectToAction("Index");
        }

        [ServiceFilter(typeof(ProductNotFoundFilter))]
        public async Task<IActionResult> Delete(int id) {
            var product = await _productService.GetByIdAsync(id);
            _productService.Remove(product);
            return RedirectToAction("Index");
        }

        public IActionResult Error(ErrorDto errorDto) {
            return View(new ErrorViewModel { ErrorDto = errorDto });
        }

        #region Private methods

        private async Task<IEnumerable<AdminCategoryDto>> GetCategoriesAsync() {
            var categories = await _categoryService.GetAllAsnyc();
            return _mapper.Map<IEnumerable<AdminCategoryDto>>(categories);
        }

        private List<AdminProductImageDto> UploadedImages(List<IFormFile> formFiles) {
            List<AdminProductImageDto> productImages = new List<Models.DTOs.AdminProductImageDto>();
            if (CheckImage(formFiles)) {

                foreach (var item in formFiles) {
                 
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + item.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create)) {
                        item.CopyTo(fileStream);
                    }

                    productImages.Add(new Models.DTOs.AdminProductImageDto {
                        ImageUrl = uniqueFileName
                    });
                }
            }

            return productImages;
        }
        private bool CheckImage(List<IFormFile> formFiles) {

            if (formFiles == null || !formFiles.Any()) {
                throw new Exception("Lütfen bir resim seçiniz");
            }

            return true;
        }

        #endregion
    }
}
