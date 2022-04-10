﻿using Business.Models;
using Business.Services.Bases;
using Microsoft.AspNetCore.Mvc;

namespace MvcWebUI.Controllers
{
    public class KategorilerController : Controller
    {
        private readonly IKategoriService _kategoriService;

        public KategorilerController(IKategoriService kategoriService)
        {
            _kategoriService = kategoriService;
        }

        public IActionResult Index() // ~/Kategoriler/Index ---> local host
        {
            List<KategoriModel> model = _kategoriService.Query().ToList();
            //return new ViewResult();
            return View(model); // Views/Kategoriler/Index.cshtml
        }
        [HttpGet]
        public IActionResult OlusturGetir()
        {
            return View("OlusturHtml");
        }
        [HttpPost]
        public IActionResult OlusturGonder(string Adi, string Aciklamasi)
        {
            KategoriModel model = new KategoriModel()
            {
                Adi = Adi,
                Aciklamasi = Aciklamasi
            };
            var result = _kategoriService.Add(model);
            if (result.IsSuccessful)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("Hata", result.Message);
        }
        public IActionResult Edit(int? id) // Kategoriler/Edit/1
        {
            if (id == null)
                return View("Hata", "Id gereklidir");
            KategoriModel model = _kategoriService.Query().SingleOrDefault(k => k.Id == id);
            if (model == null)
                return View("Hata", "Kategori bulunamadı!");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(KategoriModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _kategoriService.Update(model);
                if (result.IsSuccessful)
                    return RedirectToAction(nameof(Index));
                ModelState.AddModelError("", result.Message);
            }
            return View(model);
        }

        /*
        IActionResult
        ActionResult
        ViewResult (View() ContentResult (Content()) EmptyResult FileContentResult(File()) HttpResults JavaScriptResults (JavaScript()) JsonResult (Json()) RedirectResults
         */
        public ContentResult GetHtmlContent()
        {
            return Content("<b><i>Content result.</i></b>", "text/html");
        }

        public ActionResult GetKategorilerXmlContent()
        {
            string xml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>";
            xml += "<KategoriModels>";
            xml += "<KategoriModel>";
            xml += "<Id>" + 1 + "</Id>";
            xml += "<Adi>" + "Laptop" + "</Adi>";
            xml += "<Aciklamasi>" + "Dizüstü Bilgisayarlar" + "</Aciklamasi>";
            xml += "</KategoriModel>";
            xml += "</KategoriModels>";
            return Content(xml, "application/xml");
        }

        public string GetString()
        {
            return "String.";
        }

        public EmptyResult GetEmpty()
        {
            return new EmptyResult();
        }
    }
}