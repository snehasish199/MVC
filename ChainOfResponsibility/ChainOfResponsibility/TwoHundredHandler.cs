using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility
{
   public class TwoHundredHandler:Handler
    {
        public override void dispatchRs(long requestedAmount)
        {
            long numberofNotesToBeDispatched = requestedAmount / 200;
            if (numberofNotesToBeDispatched > 0)
            {
                if (numberofNotesToBeDispatched > 1)
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Two hundred notes are dispatched by TwoHunddredHandler");
                }
                else
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Two hundred notes are dispatched by TwoHunddredHandler");
                }
            }
            long pendingAmountToBeProcessed = requestedAmount % 200;
            if (pendingAmountToBeProcessed > 0)
            {
                rsHandler.dispatchRs(pendingAmountToBeProcessed);
            }
        }
    }

}
