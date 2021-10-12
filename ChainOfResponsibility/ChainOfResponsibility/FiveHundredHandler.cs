using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility
{
    public class FiveHundredHandler : Handler
    {
        public override void dispatchRs(long requestedAmount)
        {
            long numberofNotesToBeDispatched = requestedAmount / 500;
            if (numberofNotesToBeDispatched > 0)
            {
                if (numberofNotesToBeDispatched > 1)
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Five hundred notes are dispatched by FiveHunddredHandler");
                }
                else
                {
                    Console.WriteLine(numberofNotesToBeDispatched + " Five hundred notes are dispatched by FiveHunddredHandler");
                }
            }
            long pendingAmountToBeProcessed = requestedAmount % 500;
            if (pendingAmountToBeProcessed > 0)
            {
                rsHandler.dispatchRs(pendingAmountToBeProcessed);
            }
        }
    }

}
