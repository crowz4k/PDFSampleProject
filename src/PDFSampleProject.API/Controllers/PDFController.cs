using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PDFSampleProject.API.Abstraction;

namespace PDFSampleProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PDFController : ControllerBase
    {
        private readonly IPDFService _pdfService;

        public PDFController(IPDFService pdfService)
        {
            _pdfService = pdfService;
        }

        [HttpGet("Create")]
        public async Task<IActionResult> CreatePdf()
        {
            var file = await _pdfService.Create();
            return File(file, "application/pdf");
        }
    }
}