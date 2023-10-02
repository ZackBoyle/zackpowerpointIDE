using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using Office = Microsoft.Office.Core;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace PowerPointIDE
{
    public partial class Ribbon1
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void Compile_Click(object sender, RibbonControlEventArgs e)
        {
            int status = exportCode();
            MessageBox.Show($"Compile complete with status {status}");
        }

        public static string ReplaceUnicodeQuotationMarks(string input)
        {
            string result = input.Replace("\u201C", "\"").Replace("\u201D", "\"").Replace("\u201E", "\"").Replace("\u201F", "\"").Replace("\u2033", "\"").Replace("\u2036", "\"");
            return result;
        }

        private int exportCode()
        {
            PowerPoint.Slide currentSlide = Globals.ThisAddIn.Application.ActiveWindow.View.Slide;
            string slideTitle = currentSlide.Shapes.Title.TextFrame.TextRange.Text;
            string slideText = "";

            foreach (PowerPoint.Shape shape in currentSlide.Shapes)
            {
                if (shape.HasTextFrame == Microsoft.Office.Core.MsoTriState.msoTrue && shape.Name != "Title 1")
                {
                    slideText += shape.TextFrame.TextRange.Text + Environment.NewLine;
                }
            }

            slideText = ReplaceUnicodeQuotationMarks(slideText);

            string cppDir;
            string fileName = slideTitle + ".cpp";

            using (StreamWriter sw = new StreamWriter(File.OpenWrite(fileName)))
            {
                sw.Write(slideText);
                cppDir = ((FileStream)(sw.BaseStream)).Name;
                sw.Close();
            }

            // Compile the file with g++
            Process compile = new Process();
            compile.StartInfo.FileName = "cmd.exe";
            compile.StartInfo.CreateNoWindow = false;
            compile.StartInfo.UseShellExecute = false;
            compile.StartInfo.RedirectStandardInput = true;
            compile.StartInfo.RedirectStandardOutput = true;
            compile.Start();
            compile.StandardInput.WriteLine($"g++ {fileName} -o {slideTitle}.exe");
            compile.StandardInput.Flush();
            compile.StandardInput.Close();
            string compileOutput = compile.StandardOutput.ReadToEnd();
            compile.WaitForExit();
            MessageBox.Show($"compile output: {compileOutput}");
               
            // Run the file if compiled successfully
            if (!compileOutput.Contains("error"))
            {
                Process run = new Process();
                run.StartInfo.FileName = $"{slideTitle}.exe";
                run.StartInfo.CreateNoWindow = false;
                run.StartInfo.UseShellExecute = false;
                run.StartInfo.RedirectStandardInput = true;
                run.StartInfo.RedirectStandardOutput = true;
                run.Start();
                run.StandardInput.Flush();
                run.StandardInput.Close();
                string runOutput = run.StandardOutput.ReadToEnd();
                run.WaitForExit();
                MessageBox.Show($"run output: {runOutput}");
            }

            if (slideText.Length > 0 && slideTitle.Length > 0 && cppDir != null && !compileOutput.Contains("error"))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
