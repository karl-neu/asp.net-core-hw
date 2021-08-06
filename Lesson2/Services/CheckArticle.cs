using Interfaces;
using System;

namespace Services
{
    public class CheckArticle : ICheck
    {
        public void Check()
        {
            Console.WriteLine("Check Article");
        }
    }
}