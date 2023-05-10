namespace SingleResponsibility
{
    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
    }

    public class Persistence
    {
        public void SaveToFile(Journal journal, string filename, bool overrite = false)
        {
            if(overrite || !File.Exists(filename))
            {
                File.WriteAllText(filename, journal.ToString());
            }
        }

    }

    internal class Demo
    {
        static void Main(string[] args)
        {
            var journal = new Journal();
            journal.AddEntry("I cried today");
            journal.AddEntry("I ate a bug");
            Console.WriteLine(journal.ToString());

            var p = new Persistence();
            var fileName = @"c:\temp\journal.txt";
            p.SaveToFile(journal, fileName, true);
            //Process.Start(fileName);
        }
    }
}