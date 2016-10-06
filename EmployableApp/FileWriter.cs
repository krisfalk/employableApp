using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;


namespace EmployableApp
{

    public class FileWriter
    {
        public FileWriter(List<string> resumeData)
        {
            TextWriter save = new StreamWriter("C:\\Users\\berig\\OneDrive\\DevCodeCamp Projects\\employableApp\\resume.txt");

            foreach (string data in resumeData)
            {
                save.WriteLine(data);
            }

            using (var document = WordprocessingDocument.Create(
               "C:\\Users\\berig\\OneDrive\\DevCodeCamp Projects\\employableApp\\resume.docx", WordprocessingDocumentType.Document))
            {
                document.AddMainDocumentPart();
                document.MainDocumentPart.Document = new Document(
                    new Body(new Paragraph(new Run(new Text("Hello")))));
            }
            save.Close();
        }
    }
       
    }
