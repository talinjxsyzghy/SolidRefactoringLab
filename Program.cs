using System;

namespace SolidRefactoringLab
{
    public interface IReportFormatter
    {
        void FormatReport();
    }

    public class PdfFormatter : IReportFormatter
    {
        public void FormatReport() => Console.WriteLine("Formatting report as a PDF...");
    }

    public class WordFormatter : IReportFormatter
    {
        public void FormatReport() => Console.WriteLine("Formatting report as a Word Document...");
    }

    public class PlainTextFormatter : IReportFormatter
    {
        public void FormatReport() => Console.WriteLine("Formatting report as plain text...");
    }

    public class ReportSaver
    {
        public void SaveToFile(string filename)
        {
            Console.WriteLine($"Saving report data to {filename}...");
        }
    }

    public class ReportManager
    {
        private readonly IReportFormatter _formatter;
        public string ReportData { get; set; }
        
        public ReportManager(IReportFormatter formatter)
        {
            _formatter = formatter;
        }

        public void GenerateReport()
        {
            _formatter.FormatReport();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IReportFormatter formatter = new PdfFormatter();

            ReportManager manager = new ReportManager(formatter);
            manager.GenerateReport();
            
            ReportSaver saver = new ReportSaver();
            saver.SaveToFile("Q1_Report.pdf");
        }
    }
}