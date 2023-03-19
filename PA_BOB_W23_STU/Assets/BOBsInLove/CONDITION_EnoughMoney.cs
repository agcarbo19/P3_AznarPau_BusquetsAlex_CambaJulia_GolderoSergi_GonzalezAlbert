using UnityEngine;
using BTs;

public class CONDITION_EnoughMoney : Condition
{

     

    // Constructor
    public CONDITION_EnoughMoney()  {
        
    }

    
    public override bool Check ()
    {
        /* Add your code here */
        return ((BOB_Blackboard)blackboard).EnoughMoney();
    }

}
