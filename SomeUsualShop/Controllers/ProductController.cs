using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SomeUsualShop.Infrastructure;
using SomeUsualShop.Models;
using SomeUsualShop.Models.ViewModels;

namespace SomeUsualShop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Products
                .Include(p => p.Category)
                .OrderBy(p=>p.Category.Name)
                .ThenBy(p=>p.Name);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productView)
        {
            if (ModelState.IsValid)
            {
                if (productView.ImageFile==null)
                {
                    ModelState.AddModelError("","Не выбрано изображение");
                    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name",productView.Product.CategoryId);
                    return View(productView);
                }
                else
                {
                    productView.Product.Image = ImageHelper.GetBytesFromImage(productView.ImageFile);
                }
                _context.Add(productView.Product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name",productView.Product.CategoryId);
            return View(productView);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductViewModel productView = new ProductViewModel()
            {
                Product =  await _context.Products.FindAsync(id)
            };
            if (productView.Product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", productView.Product.CategoryId);
            return View(productView);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, ProductViewModel productView)
        {
            if (id != productView.Product.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    var product = _context.Products.First(p => p.Id==id);
                    
                    product.Name = productView.Product.Name;
                    product.Price = productView.Product.Price;
                    product.Description = productView.Product.Description;
                    product.CategoryId = productView.Product.CategoryId;
                    if (productView.ImageFile != null)
                    {
                        product.Image = ImageHelper.GetBytesFromImage(productView.ImageFile);
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(productView.Product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Id", productView.Product.CategoryId);
            return View(productView);
        }
        
        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(long id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
