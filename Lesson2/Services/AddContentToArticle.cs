using Interfaces;
using System;

namespace Services
{
    public class AddContentToArticle : IAddContent
    {
        public void Add()
        {
            Console.WriteLine("Add Content To Article");
        }
    }
}