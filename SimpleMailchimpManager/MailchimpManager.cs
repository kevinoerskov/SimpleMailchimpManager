using SimpleMailchimpManager.Action;
using System.Linq;

namespace SimpleMailchimpManager
{
    public class MailchimpManager
    {
        private readonly string _apiKey;
        private readonly string _datacenterCode;

        public ListAction ListAction(string listId) => new ListAction(_apiKey, _datacenterCode, listId);

        public MailchimpManager(string apiKey)
        {
            _apiKey = apiKey;
            _datacenterCode = apiKey.Split('-').Last();
        }
    }
}