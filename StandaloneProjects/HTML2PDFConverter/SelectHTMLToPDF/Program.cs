
using SelectPdf;
using System.IO;
using NReco;
using PdfSharp;
using Codaxy;
using Codaxy.WkHtmlToPdf;
using OpenHtmlToPdf;
using OpenHtmlToPdf.WkHtmlToPdf;
using GemBox.Document;


namespace SelectHTMLToPDF
{
    class Program
    {
        static void Main(string[] args)
        {



            GemBox.Document.ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            DocumentModel.Load("../../../Html03.html").Save("Gembox03.pdf");



            // https://www.nuget.org/packages/Select.HtmlToPdf/

            // https://selectpdf.com/community-edition/

            // does not seem to do images

            var htmlstring = @"<html><body>Hello World from selectpdf.com.</body></html>";


            var converter = new HtmlToPdf();
            converter.Options.InternalLinksEnabled = true;
            converter.Options.ExternalLinksEnabled = true;
            var pdf = converter.ConvertHtmlString(htmlstring);

            pdf.Save("Output.pdf");


            var html01 = File.ReadAllText("../../../Html01.html");
            var html02 = File.ReadAllText("../../../Html02.html");
            var html03 = File.ReadAllText("../../../Html03.html");
            var html04 = File.ReadAllText("../../../Html04.html");
            var html05 = File.ReadAllText("../../../Html05.html");



            new HtmlToPdf().ConvertHtmlString(html01).Save("HtmlToPDF01.pdf");
            new HtmlToPdf().ConvertHtmlString(html02).Save("HtmlToPDF02.pdf");
            new HtmlToPdf().ConvertHtmlString(html03).Save("HtmlToPDF03.pdf");
            new HtmlToPdf().ConvertHtmlString(html04).Save("HtmlToPDF04.pdf");
            new HtmlToPdf().ConvertHtmlString(html05).Save("HtmlToPDF05.pdf");





            // NReco is not free for projects which are to be deployed
            // https://www.nrecosite.com/doc/NReco.PdfGenerator/#

            var converterNeco = new NReco.PdfGenerator.HtmlToPdfConverter();
            // file is a binary file so stream to binarystream to save
            File.WriteAllBytes("NReco01.pdf", converterNeco.GeneratePdf(html01));
            File.WriteAllBytes("NReco02.pdf", converterNeco.GeneratePdf(html02));
            File.WriteAllBytes("NReco03.pdf", converterNeco.GeneratePdf(html03));
            File.WriteAllBytes("NReco04.pdf", converterNeco.GeneratePdf(html04));
            File.WriteAllBytes("NReco05.pdf", converterNeco.GeneratePdf(html05));














            // https://www.nuget.org/packages/HtmlRenderer.PdfSharp/

            /*
            **********Welcome to the HTML Renderer PdfSharp library!*****************************************

           This library provides the ability to generate PDF documents from HTML snippets using static rendering code.
For more info see HTML Renderer on CodePlex: http://htmlrenderer.codeplex.com

            **********DEMO APPLICATION***********************************************************************

           HTML Renderer Demo application showcases HTML Renderer capabilities, use it to explore and learn
on the library: http://htmlrenderer.codeplex.com/wikipage?title=Demo%20application

            **********FEEDBACK / RELEASE NOTES***************************************************************

           If you have problems, wish to report a bug, or have a suggestion please start a thread on
           HTML Renderer discussions page: http://htmlrenderer.codeplex.com/discussions

            For full release notes and all versions see: http://htmlrenderer.codeplex.com/releases

            **********QUICK START****************************************************************************

           For more Quick Start see: https://htmlrenderer.codeplex.com/wikipage?title=Quick%20start

    */











            //iText7 : paid product  https://itextpdf.com/en/products/product-tour



            // Essential Objects : Paid product https://www.essentialobjects.com/Purchase.aspx?f=3


            // Puppeteer CSharp : Seems to need Chrome https://www.puppeteersharp.com/examples/index.html#puppeteer-sharp---examples


            // Download application https://wkhtmltopdf.org/support.html



            // Codaxy  https://github.com/codaxy/wkhtmltopdf
            // Nuget install
            // https://github.com/codaxy/wkhtmltopdf/blob/master/NuGet/Codaxy.WkHtmlToPdf/content/PdfConvert.cs





            // open html to pdf
            // https://github.com/vilppu/OpenHtmlToPdf

            File.WriteAllBytes("OpenHTMLToPDF01.pdf", Pdf.From(html01).Content());
            File.WriteAllBytes("OpenHTMLToPDF02.pdf", Pdf.From(html02).Content());
            File.WriteAllBytes("OpenHTMLToPDF03.pdf", Pdf.From(html03).Content());
            File.WriteAllBytes("OpenHTMLToPDF04.pdf", Pdf.From(html04).Content());
            File.WriteAllBytes("OpenHTMLToPDF05.pdf", Pdf.From(html05).Content());



            /*

            Here is a link to all my research
             
# HTML to PDF

[Convert HTML to PDF in .NET](https://stackoverflow.com/questions/564650/convert-html-to-pdf-in-net)

[HtmlRenderer.PdfSharp 1.5.0.6](https://www.nuget.org/packages/HtmlRenderer.PdfSharp/)

[Puppeteer Sharp](https://www.puppeteersharp.com/)

[codaxy/wkhtmltopdf](https://github.com/codaxy/wkhtmltopdf)

A month ago

[iTextSharp 5.5.7](https://www.nuget.org/packages/iTextSharp/5.5.7)

[iTextSharp-LGPL 4.1.6](https://www.nuget.org/packages/iTextSharp-LGPL/4.1.6)

# Try

3 months ago

[Select.HtmlToPdf 19.1.0](https://www.nuget.org/packages/Select.HtmlToPdf/)

3 years ago

[tuespetre/TuesPechkin](https://github.com/tuespetre/TuesPechkin)

[TuesPechkin 2.1.1](https://www.nuget.org/packages/TuesPechkin/)

5 years ago

[vilppu/OpenHtmlToPdf](https://github.com/vilppu/OpenHtmlToPdf)

[OpenHtmlToPdf 1.12.0](https://www.nuget.org/packages/OpenHtmlToPdf/)

5 yeras ago

[TimothyKhouri/WkHtmlToXDotNet](https://github.com/TimothyKhouri/WkHtmlToXDotNet)

var pdfData = HtmlToXConverter.ConvertToPdf("<h1>COOOL!</h1>");

This was created 2012

[gmanny/Pechkin](https://github.com/gmanny/Pechkin)

[NReco.PdfGenerator Class Library Documentation - Table of Content](https://www.nrecosite.com/doc/NReco.PdfGenerator/)

# Cannot use as it's a download

[HTML to PDF Converter for .NET - C#, VB.NET Samples for ASP.NET, MVC](http://www.winnovative-software.com/Html-To-Pdf-Converter.aspx)

[Let's start to convert PDF HTML XLS DOC RTF XML files using ASP.NET components.](http://www.duodimension.com/)

# Costs Money

[.NET PDF Library Licensing Terms | Iron Pdf](https://ironpdf.com/licensing/)

 
             
             */


        }
    }
}
