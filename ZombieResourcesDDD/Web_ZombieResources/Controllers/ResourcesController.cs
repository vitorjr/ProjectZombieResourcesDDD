using ApplicationApp.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Configuration;

namespace Web_ZombieResources.Controllers
{
    public class ResourcesController : Controller
    {
        private readonly InterfaceResourceApp _InterfaceResourceApp;

        public ResourcesController(InterfaceResourceApp InterfaceResourceApp)
        {
            _InterfaceResourceApp = InterfaceResourceApp;
        }

        // GET: Resources
        public async Task<IActionResult> Index()
        {
            return View(await _InterfaceResourceApp.List());
        }

        // GET: Resources/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _InterfaceResourceApp.GetEntityById((int)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // GET: Resources/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Resources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Observation,ResponsibleInput,ResponsibleOutput,Amount,Id,Nome")] Resource resource)
        {
            if (ModelState.IsValid)
            {
                await _InterfaceResourceApp.Add(resource);

                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        // GET: Resources/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _InterfaceResourceApp.GetEntityById((int)id);
            if (resource == null)
            {
                return NotFound();
            }
            return View(resource);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Observation,ResponsibleInput,ResponsibleOutput,Amount,Id,Nome")] Resource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _InterfaceResourceApp.Update(resource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProductExists(resource.Id))
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
            return View(resource);
        }

        // GET: Resources/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _InterfaceResourceApp.GetEntityById((int)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: Resources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resource = await _InterfaceResourceApp.GetEntityById(id);
            await _InterfaceResourceApp.Delete(resource);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProductExists(int id)
        {

            var objeto = await _InterfaceResourceApp.GetEntityById(id);

            return objeto != null;
        }
    }
}

