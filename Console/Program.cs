using SimpleMailchimpManager;
using SimpleMailchimpManager.Entities.Request;
using SimpleMailchimpManager.Entities.Response;
using SimpleMailchimpManager.Entities.Response.Subscriber;
using System;
using System.Collections.Generic;

namespace TestConsole
{
    class Program
    {
        private const string ApiKey = "7f881d0290f40204c3d53efbe2bc2a45-us18";
        private const string ListId = "e7f9c229b3";

        static void Main(string[] args)
        {
            //const string email = "testedwadaw321@hotmail.com";

            //var mergeVar = new MergeVar
            //{
            //    {"FNAME", "Kevin" },
            //    {"LNAME", "Anders" }
            //};

            //var response = AddSubscriber(email, mergeVar);

            //System.Console.WriteLine($"Add subscriber response: {response}.");

            PromptActionMenu();

            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }

        private static void PromptActionMenu()
        {
            Console.WriteLine("Choose an action from the list:");
            var actions = GetActions();
            PrintActionMenuOptions(actions);

            var actionNumber = ReadInputAndParseToActionNumber(actions.Length);

            actions[actionNumber].Item2.Invoke();
        }

        private static int ReadInputAndParseToActionNumber(int menuLength)
        {
            string input;
            int actionNumber;
            do
            {
                Console.Write("Action number: ");
                input = Console.ReadLine();
            } while (IsInvalidActionNumber(menuLength, input, out actionNumber));

            return actionNumber;
        }

        private static bool IsInvalidActionNumber(
            int menuLength,
            string input,
            out int actionNumber)
        {
            return !int.TryParse(input, out actionNumber) || actionNumber + 1 > menuLength;
        }

        private static void PrintActionMenuOptions(IEnumerable<Tuple<string, Action>> actions)
        {
            var index = 0;

            foreach (var action in actions)
            {
                Console.WriteLine($"{index}: {action.Item1}");
                index++;
            }
        }

        private static Tuple<string, Action>[] GetActions()
        {
            return new[]
            {
                Tuple.Create<string, Action>(nameof(AddSubscriberAction), AddSubscriberAction),
                Tuple.Create<string, Action>(nameof(ExitApplication), ExitApplication)
            };
        }

        private static void ExitApplication()
        {
            Environment.Exit(0);
        }

        private static void AddSubscriberAction()
        {

        }

        private static IApiResponse<AddSubscriberResponse> AddSubscriber(string email, MergeVar mergeVar)
        {
            var mailchimpManager = new MailchimpManager(ApiKey);

            var response = mailchimpManager.ListAction(ListId).AddSubscriber(email, mergeVar);

            return response;
        }
    }
}
