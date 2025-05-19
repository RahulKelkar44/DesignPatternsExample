using DesignPatternExamples.Memento_Pattern;

namespace DesignPatternExamples
{
	internal class Program
	{
		static void Main(string[] args)
		{
			DocumentState state = new DocumentState();
			DocumentKeeper documentKeeper = new DocumentKeeper();
			Document doc = new();
			doc.Content = "ABC";
			doc.Save();
			doc.Content = "Rahul";
			doc.Save();
			doc.Undo();
			doc.Content = "Ram";
			doc.Undo();
            Console.WriteLine(doc.Content);
        }
	}
}