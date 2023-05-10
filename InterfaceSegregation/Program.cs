namespace InterfaceSegregation
{
    internal class Program
    {
        public class Document
        {

        }

        public interface IMachine
        {
            void Print(Document document);
            void Scan(Document document);
            void Fax(Document document);
        }


        public interface IPrinter
        {
            void Print(Document document);
        }

        public interface IScanner
        {
            void Scan(Document document);
        }

        public interface IFax
        {
            void Fax(Document document);
        }

        public interface IMultiFUnctionalDevice: IScanner, IPrinter, IFax
        {
        }

        public class MultiFUnctionalMachine: IMultiFUnctionalDevice
        {
            private readonly IPrinter _printer;
            private readonly IScanner _scanner;

            public MultiFUnctionalMachine(IPrinter printer, IScanner scanner)
            {
                _printer = printer;
                _scanner = scanner;
            }

            void IFax.Fax(Document document)
            {
            }

            void IPrinter.Print(Document document)
            {
                _printer.Print(document);
            }

            void IScanner.Scan(Document document)
            {
                _scanner.Scan(document);
            }
        }

        public class MultifunctionalPrinter : IMachine
        {
            void IMachine.Fax(Document document)
            {
                //
            }

            void IMachine.Print(Document document)
            {
                //
            }

            void IMachine.Scan(Document document)
            {
                //
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}