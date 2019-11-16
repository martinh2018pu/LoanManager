using LoanManager.DataAccess;
using LoanManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoanManager.Controllers
{
    public class LoansController : Controller
    {
        public readonly LoansRepository _loansRepository;

        public LoansController()
        {
            _loansRepository = new LoansRepository();
        }

        // GET: Loans
        public ActionResult Index()
        {
            List<Loan> loans = _loansRepository.GetAll();
            return View(loans);
        }

        public ActionResult Create()
        {
            Loan model = new Loan();
            model.ReceivedOn = DateTime.Now;

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Loan model)
        {
            TryUpdateModel(model);

            var currentLoans = _loansRepository.GetAll().Where(l => l.EGN == model.EGN).ToList();

            var currentLoansAmount = model.Amount;

            foreach (Loan oneLoan in currentLoans)
            {
                currentLoansAmount += oneLoan.Amount;
            }

            if (currentLoansAmount > 10000)
            {
                ModelState.AddModelError("Amount", "You cannot get loan, because all your loans exceed 10 000Lev BGN!");
                //ViewBag.ErrorMessage = "You cannot get loan, because all your loans exceed 10 000Lev BGN!";
                return View(model);
            }

            if (ModelState.IsValid)
            {
                model.ReceivedOn = DateTime.Now;

                _loansRepository.Save(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            Loan model = _loansRepository.Get(id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Loan model)
        {
            TryUpdateModel(model);

            if (ModelState.IsValid)
            {
                _loansRepository.Save(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            _loansRepository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
