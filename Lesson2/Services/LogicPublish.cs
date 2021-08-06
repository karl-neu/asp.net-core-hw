using Interfaces;

namespace Services
{
    public class LogicPublish : ILogicPublish
    {
        private readonly IAddContent _addContent;
        private readonly ICheck _check;
        private readonly IPublish _publish;
        private ITempStorage _tempStorage;

        public LogicPublish(IAddContent addContent, ICheck check, IPublish publish, ITempStorage tempStorage)
        {
            _addContent = addContent;
            _check = check;
            _publish = publish;
            _tempStorage = tempStorage;
        }
        public void Publish()
        {
            _tempStorage.AddArticleInfo();
            _addContent.Add();
            _check.Check();
            _publish.Publish();
        }
    }
}