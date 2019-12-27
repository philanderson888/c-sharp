using System;
using GemBox.Pdf;
using System.Diagnostics;
using GemBox.Document;

namespace HTMLToPDF
{
    class Program
    {
        static void Main(string[] args)
        {

            GemBox.Document.ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            GemBox.Pdf.ComponentInfo.SetLicense("FREE-LIMITED-KEY");



      //      DocumentModel.Load("../../../../Html01.html").Save("Gembox01.pdf");
            DocumentModel.Load("../../../../Html02.html").Save("Gembox02.pdf");




        }
    }
}
