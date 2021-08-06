using Interfaces;
using System;

namespace Services
{
    public class TempArticleStorage : ITempStorage
    {
        public void AddArticleInfo()
        {
            Console.WriteLine("Article Info saved in temp storage");
        }

        public void GetArticleInfo()
        {
            Console.WriteLine("Article Info returned");
        }
    }
}
