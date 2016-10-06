using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using EmployableApp.Models;


namespace EmployableApp
{

    public class FileWriter
    {
        public FileWriter(Resume resume, ApplicationUser user)
        {

                using (WordprocessingDocument wordDocument = WordprocessingDocument.Create("C:\\Users\\berig\\OneDrive\\DevCodeCamp Projects\\employableApp\\resume2.docx", WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                    // Create the document structure and add some text.
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());

                    //Run run = paragraph.AppendChild(new Run());
                    //run.AppendChild(new Text("Specifies a unique identifier used to track the editing session when the run was deleted from the main document. All rsid * attributes throughout this document with the same value, if present, shall indicate that those regions were modified during the same editing session (time between subsequent save actions). A producer can choose to increment the revision save ID value to indicate subsequent editing sessions to indicate the order of the modifications relative to other modifications in this document. The possible values for this attribute are defined by the ST_LongHexNumber simple type(§17.18.50)."));
                    //Run run2 = paragraph.AppendChild(new Run());
                    //run2.AppendChild(new RunProperties(new Border()));
                    //run2.AppendChild(new Text("blah blah"));
                    
                //string filename = "C:\\Users\\berig\\OneDrive\\DevCodeCamp Projects\\employableApp\\resume2.docx";
                //SetRunFont(filename);

                WriteFirstSection(body, resume, user);
                wordDocument.Close();
            }

      
        }
        public static void SetRunFont(string fileName)
        {
            using (WordprocessingDocument package = WordprocessingDocument.Open(fileName, true))
            {
                // Set the font to Arial to the first Run.
                // Use an object initializer for RunProperties and rPr.
                RunProperties rPr = new RunProperties(
                    new RunFonts()
                    {
                        Ascii = "Comic Sans"
                    });

                Run run = package.MainDocumentPart.Document.Descendants<Run>().First();
                run.PrependChild<RunProperties>(rPr);

                // Save changes to the MainDocumentPart part.
                package.MainDocumentPart.Document.Save();
            }
        }
        public void WriteFirstSection(Body body, Resume resume, ApplicationUser user)
        {
            Paragraph paraOne = body.AppendChild(new Paragraph());
            Paragraph paraTwo = body.AppendChild(new Paragraph());
            Run run = paraOne.AppendChild(new Run());
            RunProperties runOnePr = new RunProperties(
                new RunFonts()
                {
                    Ascii = "Comic Sans"
                });
            run.PrependChild<RunProperties>(runOnePr);
            run.AppendChild(new Text(user.FirstName + " " + user.LastName));
            RunProperties runTwoPr = new RunProperties();
            Run runTwo = paraTwo.AppendChild(new Run());
            runTwo.PrependChild<RunProperties>(runTwoPr);
            runTwo.AppendChild(new Text(user.Email));
        }
    }
}
