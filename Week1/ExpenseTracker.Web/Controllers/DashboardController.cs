using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Web.Services;

namespace ExpenseTracker.Web.Controllers;

public class DashboardController : Controller
{
    private readonly ApiService _api;

    public DashboardController(ApiService api)
    {
        _api = api;
    }

    public async Task<IActionResult> Index()
    {
        var userId = Guid.Parse("E37BEF66-B0BF-4106-8DC6-52B269066F27");

        var transactions = await _api.GetTransactions(userId);
        var total = await _api.GetTotal(userId);
        var categoryData = await _api.GetByCategory(userId);

        ViewBag.Total = total;
        ViewBag.CategoryData = categoryData;

        return View(transactions);
    }
}