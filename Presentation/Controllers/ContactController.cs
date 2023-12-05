using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Presentation.Models;
using X.PagedList;

namespace Presentation.Controllers
{
    public class ContactController : Controller
    {

        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            var value = _contactService.TGetList().ToPagedList(page, 5);
            return View(value);
        }


        public IActionResult DeleteContact(int id)
        {
            var value = _contactService.TGetById(id);
            _contactService.TDelete(value);
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult ReceiveContact(int id)
        {
            var value = _contactService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult ReceiveContact()
        {
            return View();

        }


    }
}
