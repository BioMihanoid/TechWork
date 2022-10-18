using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        TransformToElephant();
        Console.WriteLine("Муха");
        Console.WriteLine("Муха");
    }

    static void TransformToElephant()
    {
        Console.WriteLine("Слон");
        Console.SetOut(new SkipOneOut());
    }

    class SkipOneOut : StringWriter
    {
        TextWriter defaultTextWriter = Console.Out;

        public override void WriteLine(string value)
        {
            Console.SetOut(defaultTextWriter);
        }
    }
}