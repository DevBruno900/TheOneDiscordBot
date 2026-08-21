using DotNetEnv;
using Infra;

namespace App
{
    internal class MainClass
    {
        static void Main()
        {
            Env.Load();

            //Console.WriteLine(string.Join("\n", Data.GetQuotesByCharacterName("Gandalf")));
        }
    }
}
