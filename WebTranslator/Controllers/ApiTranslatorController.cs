using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTranslator.Services;

namespace WebTranslator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTranslatorController : ControllerBase
    {
        private readonly Translator _translator;

        public ApiTranslatorController(Translator translator)
        {
            _translator = translator;
        }

        [HttpGet("Translate")]
        public async Task<IActionResult> Translate( string? text, string? from, string? to)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(from) || string.IsNullOrEmpty(to))
            {
                return BadRequest("Not all parameters were sent");
            }
            
            return Ok(await _translator.TranslateAsync(text, from, to));
        }
    }
}
