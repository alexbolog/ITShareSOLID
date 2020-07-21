using System;
using System.Collections.Generic;
using System.Text;

namespace SolidDemo.InterfaceSegregation
{
    internal class OkIS
    {
        internal interface IPrinter
        {
            void Print(string text);
        }

        internal interface IScanner
        {
            string Scan();
        }

        internal interface IXerox
        {
            void Copy(int count);
        }
        // IPrinter printer = new AdvancedPrinter();
        // IScanner scanner = new AdvancedPrinter();
        internal class AdvancedPrinter : IPrinter, IScanner, IXerox
        {
            public void Print(string text) => Console.WriteLine("Printed document");

            public string Scan() => "Scanned text";

            public void Copy(int count) => Console.WriteLine("Copied document for {count} times");
        }

        internal class BasicPrinter : IPrinter
        {
            public void Print(string text) => Console.WriteLine("Printed document");
        }
    }
}
