using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility
{
   public class HundredHandler:Handler
    {
        public override void dispatchRs(long requestedAmount)
        {
            long numberofNotesToBeDispatched = requestedAmount / 100;
            if (numberofNotesToBeDispatched > 0)
            {
                if (numberofNotesToBeDispatched > 1)
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " One hundred notes are dispatched by HunddredHandler");
                }
                else
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " One hundred notes are dispatched by HundredHandler");
                }
            }
            long pendingAmountToBeProcessed = requestedAmount % 100;
            if (pendingAmountToBeProcessed > 0)
            {
                rsHandler.dispatchRs(pendingAmountToBeProcessed);
            }
        }
    }

}
