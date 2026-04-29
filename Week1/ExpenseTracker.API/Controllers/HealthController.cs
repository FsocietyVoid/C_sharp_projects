using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controller;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase

{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { status = "Smart Expense Tracker API is running ..." });
    }
}