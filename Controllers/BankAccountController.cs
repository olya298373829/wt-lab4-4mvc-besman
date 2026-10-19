using Microsoft.AspNetCore.Mvc;
using wt_lab4_4mvc_besman.Models;

namespace wt_lab4_4mvc_besman.Controllers;

public class BankAccountController : Controller
{
    // Данные хранятся в памяти приложения (по условиям лабы БД не используется)
    private static readonly List<BankAccount> accounts = new()
    {
        new BankAccount { Id = 1, Owner = "Иванов И.И.", AccountNumber = "BY01 1111 2222 3333", Balance = 1500.50m, Currency = "BYN", IsActive = true },
        new BankAccount { Id = 2, Owner = "Петров П.П.", AccountNumber = "BY02 4444 5555 6666", Balance = 320.00m, Currency = "BYN", IsActive = true },
        new BankAccount { Id = 3, Owner = "Сидорова А.А.", AccountNumber = "BY03 7777 8888 9999", Balance = 0.00m, Currency = "BYN", IsActive = false },
        new BankAccount { Id = 4, Owner = "Бесман О.С.", AccountNumber = "BY04 1234 5678 9012", Balance = 1000.00m, Currency = "BYN", IsActive = true }
    };

    // GET: /BankAccount
    public IActionResult Index()
    {
        return View(accounts);
    }

    // GET: /BankAccount/Details/5
    public IActionResult Details(int id)
    {
        var account = accounts.FirstOrDefault(a => a.Id == id);
        if (account == null)
        {
            return NotFound();
        }
        return View(account);
    }

    // GET: /BankAccount/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: /BankAccount/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(BankAccount account)
    {
        if (ModelState.IsValid)
        {
            account.Id = accounts.Count > 0 ? accounts.Max(a => a.Id) + 1 : 1;
            accounts.Add(account);
            return RedirectToAction(nameof(Index));
        }
        return View(account);
    }
}