using UnityEngine;
using BTs;

public class CONDITION_EnoughFlowers : Condition
{

    
    public CONDITION_EnoughFlowers()  {
         
    }
 
    public override bool Check ()
    {
        /* Add your code here */
        return ((BOB_Blackboard)blackboard).EnoughFlowers();
    }

}
