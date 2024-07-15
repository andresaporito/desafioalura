using Desafio.Alura.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.Alura.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutomationController(IAutomationService automationService) : Controller
    {
        private IAutomationService _automationService { get; set; } = automationService;

        [HttpPost]
        [Route("run")]
        public IActionResult RunAutomation()
        {
            _automationService.RunAutomation();
            return Ok();
        }

        [HttpGet]
        [Route("get")]
        public IActionResult Get()
        {
            var result = _automationService.GetAll();
            return Ok(result);
        }
    }
}
