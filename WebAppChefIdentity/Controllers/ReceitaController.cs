using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppChefIdentity.Data;

namespace WebAppChefIdentity.Controllers
{
    [Authorize]
    public class ReceitaController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBlobService _blobService;
        private readonly IReceitaRepository _repository;
        public ReceitaController(AppDbContext context, IBlobService blobService, IReceitaRepository repository)
        {
            _context = context;
            _blobService = blobService;
            _repository = repository;
        }

        // GET: Receita
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAllAsync());
        }

        // GET: Receita/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _repository.GetByIdAsync(id.Value);            
            
            if (receita == null)
            {
                return NotFound();
            }

            return View(receita);
        }

        // GET: Receita/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Receita/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormCollection form, Receita receita)
        {
            if (ModelState.IsValid)
            {
                var file = form.Files.SingleOrDefault();
                var streamFile = file.OpenReadStream();
                var uriImage = await _blobService.UploadAsync(streamFile);
                receita.ImagemUri = uriImage;

                await _repository.InsertAsync(receita);

                return RedirectToAction(nameof(Index));
            }
            return View(receita);
        }

        // GET: Receita/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _repository.GetByIdAsync(id.Value);

            if (receita == null)
            {
                return NotFound();
            }
            return View(receita);
        }

        // POST: Receita/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IFormCollection form, int id, Receita receita)
        {
            if (id != receita.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var file = form.Files.SingleOrDefault();
                    var streamFile = file?.OpenReadStream();

                    if (streamFile != null)
                    {
                        var uriImage = await _blobService.UploadAsync(streamFile);
                        if (receita.ImagemUri != null)
                        {
                            await _blobService.DeleteAsync(receita.ImagemUri);
                        }

                        receita.ImagemUri = uriImage;
                    }

                    await _repository.UpdateAsync(receita);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceitaExists(receita.Id))
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
            return View(receita);
        }

        // GET: Receita/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receita = await _repository.GetByIdAsync(id.Value);
                    
            if (receita == null)
            {
                return NotFound();
            }

            return View(receita);
        }

        // POST: Receita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receita = await _repository.GetByIdAsync(id);

            await _blobService.DeleteAsync(receita.ImagemUri);
            await _repository.DeleteAsync(receita);
            
            return RedirectToAction(nameof(Index));
        }

        private bool ReceitaExists(int id)
        {
            var receita = _repository.GetByIdAsync(id).Result;

            return (receita != null);
        }
    }
}
