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
    internal interface Handler
    {
        Handler setNext(Handler handler);
        void handle(string request);
    }

    internal class BaseHandler : Handler
    {
        private Handler nextHandler;

        public Handler setNext(Handler handler)
        {
            nextHandler = handler;
            return handler;
        }

        public virtual void handle(string request)
        {
            if (nextHandler != null)
            {
                nextHandler.handle(request);
            }
        }
    }


    internal class BasicSupport : BaseHandler
    {
        override
        public void handle(string request)
        {
            if (request == "basic")
            {
                Console.WriteLine("Basic support handled the request");
                return;
            }
            Console.WriteLine("Basic support can not handle the request");
            base.handle(request);
        }
    }


    internal class AdvancedSupport : BaseHandler
    {
        override
        public void handle(string request)
        {
            if (request == "Advanced")
            {
                Console.WriteLine("Advanced support handled the request");
                return;
            }
            Console.WriteLine("Advanced support can not handle the request");
            base.handle(request);
        }
    }


    internal class ExpertSupport : BaseHandler
    {
        override
        public void handle(string request)
        {
            if (request == "Expert")
            {
                Console.WriteLine("Expert support handled the request");
                return;
            }
            Console.WriteLine("Expert support can not handle the request");
            base.handle(request);
        }
    }
    public static class ChainResponsibility1
    {
        public static void main()
        {
            BasicSupport basic = new BasicSupport();
            AdvancedSupport advanced = new AdvancedSupport();
            ExpertSupport expert = new ExpertSupport();
            basic.setNext(advanced).setNext(expert);
            //basic.handle("basic");
            //basic.handle("Advanced");
            basic.handle("Expert");
            //basic.handle("random");
        }
    }
}
