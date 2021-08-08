using Interfaces;
using System;

namespace Services
{
    public class PublishArticle : IPublish
    {
        public void Publish()
        {
            Console.WriteLine("Publish Article");
        }
    }
}