using System;
using System.Collections.Generic;
using System.Text;

namespace SolidDemo.InterfaceSegregation
{
    internal class BadIS
    {
        internal interface IPrintingMachine
        {
            void Print(string text);
            string Scan();
            void Copy(int count);
        }

        internal class AdvancedPrinter : IPrintingMachine
        {
            public void Print(string text) => Console.WriteLine("Printed document");

            public string Scan() => "Scanned text";

            public void Copy(int count) => Console.WriteLine("Copied document for {count} times");
        }

        internal class BasicPrinter : IPrintingMachine
        {
            public void Print(string text) => Console.WriteLine("Printed document");

            public string Scan() => throw new NotImplementedException();

            public void Copy(int count) => throw new NotImplementedException();
        }
    }
}
