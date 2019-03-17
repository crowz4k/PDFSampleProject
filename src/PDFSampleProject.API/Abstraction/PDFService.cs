using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using RazorLight;

namespace PDFSampleProject.API.Abstraction
{
    public class PDFService : IPDFService
    {
        private readonly IRazorLightEngine _razorEngine;
        private readonly IConverter _pdfConverter;

        public PDFService(IRazorLightEngine razorEngine,IConverter pdfConverter)
        {
            _razorEngine = razorEngine;
            _pdfConverter = pdfConverter;
        }
        public async Task<byte[]> Create()
        {
            var model = Data.CarRepository.GetCars();
            var templatePath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), $"Templates/PDFTemplate.cshtml");
            string template = await _razorEngine.CompileRenderAsync(templatePath,model);

            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings() { Top = 10, Bottom = 10, Left = 10, Right = 10},
                DocumentTitle = "Simple PDF document",

            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = template,
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontName = "Arial", FontSize = 12,Line = true, Center = "Fun pdf document"},
                FooterSettings = { FontName = "Arial", FontSize = 12, Line = true, Right = "Page [page] of [toPage]" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            byte[] file = _pdfConverter.Convert(pdf);

            return file;
        }
    }
}
