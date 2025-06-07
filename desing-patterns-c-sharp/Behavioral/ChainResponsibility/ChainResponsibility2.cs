/**
 * ! Chain of Responsibility Pattern
* It is a behavioral design pattern that allows you to pass requests
* along a chain of handlers.
*
* * It is useful when you need to process data in different ways, but you don't
* * know in advance what type of processing is needed or in what order
* * but you know that it needs to be processed in a sequence.
 *
 * https://refactoring.guru/design-patterns/chain-of-responsibility
 */

namespace desing_patterns_c_sharp.Behavioral.ChainResponsibility
{
    internal interface Approver
    {
        Approver setNext(Approver handler);
        void approveRequest(int amount);
    }

    internal class BaseApprover : Approver
    {
        private Approver nextHandler;

        public Approver setNext(Approver handler)
        {
            nextHandler = handler;
            return handler;
        }

        public virtual void approveRequest(int amount)
        {
            if (nextHandler != null)
            {
                nextHandler.approveRequest(amount);
            }
            Console.WriteLine("Request could not be approved.");
        }
    }


    internal class Supervisor : BaseApprover
    {
        override
        public void approveRequest(int amount)
        {
            if (amount <= 1000)
            {
                Console.WriteLine("Application approved by Supervisor");
                return;
            }
            base.approveRequest(amount);
        }
    }


    internal class Manager : BaseApprover
    {
        override
        public void approveRequest(int amount)
        {
            if (amount <= 5000)
            {
                Console.WriteLine("Request approved by Manager");
                return;
            }
            base.approveRequest(amount);
        }
    }


    internal class Director : BaseApprover
    {
        override
        public void approveRequest(int amount)
        {
            Console.WriteLine("Request approved by Director");
        }
    }
    public static class ChainResponsibility2
    {
        public static void main()
        {
            Supervisor supervisor = new Supervisor();
            Manager manager = new Manager();
            Director director = new Director();

            // Setting up the chain of responsibility 
            supervisor.setNext(manager).setNext(director);

            // Test different purchase requests 
            Console.WriteLine("$500 purchase request:");
            supervisor.approveRequest(500);

            Console.WriteLine("\nPurchase request for $3000:");
            supervisor.approveRequest(3000);

            Console.WriteLine("\nPurchase request for $7000:");
            supervisor.approveRequest(7000);
        }
    }
}
