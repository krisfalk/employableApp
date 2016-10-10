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
        private ApplicationDbContext db = new ApplicationDbContext();
        public FileWriter(CreateViewModel resume, ApplicationUser user)
        {
            string path = "C://Users//Kristofer//Documents//GitHub//employableApp//resumeKRIS.docx";
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(path, WordprocessingDocumentType.Document))
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
        public void WriteFirstSection(Body body, CreateViewModel resume, ApplicationUser user)
        {
            string houseNumber = resume.HouseNumber;
            string street = resume.Street;
            string city = resume.City;
            string state = resume.State;
            int zip = resume.ZipCode;
            string aptNumber = resume.AptNumber;
            
            Paragraph paraOne = body.AppendChild(new Paragraph());
            Paragraph paraTwo = body.AppendChild(new Paragraph());
            Run run = paraOne.AppendChild(new Run());
            RunProperties runOnePr = new RunProperties(
                new RunFonts()
                {
                    Ascii = "Comic Sans"
                });
            //run.PrependChild<RunProperties>(runOnePr);
            run.AppendChild(new Text(user.FirstName + " " + user.LastName));

            //RunProperties runTwoPr = new RunProperties();
            Run runTwo = paraTwo.AppendChild(new Run());
            //runTwo.PrependChild<RunProperties>(runTwoPr);
            runTwo.AppendChild(new Text("Email: " + user.Email));

            Paragraph paraThree = body.AppendChild(new Paragraph());
            Run runThree = paraThree.AppendChild(new Run());
            runThree.AppendChild(new Text(houseNumber + " " + aptNumber + " " + street + ","));

            Paragraph paraFour = body.AppendChild(new Paragraph());
            Run runFour = paraFour.AppendChild(new Run());
            runFour.AppendChild(new Text(city + ", " + state + " " + zip));

            Paragraph paraFive = body.AppendChild(new Paragraph());
            Run runFive = paraFive.AppendChild(new Run());
            runFive.AppendChild(new Text("Experience:"));
            Paragraph paraSix = body.AppendChild(new Paragraph());
            Run runSix = paraSix.AppendChild(new Run());
            runSix.AppendChild(new Text(resume.JobExperienceOne));
            Paragraph paraSeven = body.AppendChild(new Paragraph());
            Run runSeven = paraSeven.AppendChild(new Run());
            runSeven.AppendChild(new Text(resume.JobExperienceTwo));
            Paragraph paraEight = body.AppendChild(new Paragraph());
            Run runEight = paraEight.AppendChild(new Run());
            runEight.AppendChild(new Text(resume.JobExperienceThree));

            Paragraph paraNine = body.AppendChild(new Paragraph());
            Run runNine = paraNine.AppendChild(new Run());
            runNine.AppendChild(new Text("Schooling:"));
            Paragraph paraTen = body.AppendChild(new Paragraph());
            Run runTen = paraTen.AppendChild(new Run());
            runTen.AppendChild(new Text("High School: " + resume.HighSchool));
            Paragraph paraEleven = body.AppendChild(new Paragraph());
            Run runEleven = paraEleven.AppendChild(new Run());
            runEleven.AppendChild(new Text("College: " + resume.College));
            Paragraph paraTwelve = body.AppendChild(new Paragraph());
            Run runTwelve = paraTwelve.AppendChild(new Run());
            runTwelve.AppendChild(new Text("Other Schooling: " + resume.OtherSchooling));

            Paragraph paraThirteen = body.AppendChild(new Paragraph());
            Run runThirteen = paraThirteen.AppendChild(new Run());
            runThirteen.AppendChild(new Text("Skills: " + resume.Skills));

            Paragraph paraFourteen = body.AppendChild(new Paragraph());
            Run runFourteen = paraFourteen.AppendChild(new Run());
            runFourteen.AppendChild(new Text("References:"));

            Paragraph paraFifteen = body.AppendChild(new Paragraph());
            Run runFifteen = paraFifteen.AppendChild(new Run());
            runFifteen.AppendChild(new Text(resume.ReferenceOne));

            Paragraph paraSixteen = body.AppendChild(new Paragraph());
            Run runSixteen = paraSixteen.AppendChild(new Run());
            runSixteen.AppendChild(new Text(resume.ReferenceTwo));

            Paragraph paraSeventeen = body.AppendChild(new Paragraph());
            Run runSeventeen = paraSeventeen.AppendChild(new Run());
            runSeventeen.AppendChild(new Text(resume.ReferenceThree));


        }
    }
}
