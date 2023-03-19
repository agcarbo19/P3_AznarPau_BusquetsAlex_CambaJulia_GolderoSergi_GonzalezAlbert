using UnityEngine;
using BTs;

public class ACTION_Work : Action
{
    
     
    public ACTION_Work()  { 
        
    }

 


    private FSM_Work fsm;


    public override void OnInitialize()
    {
        /* write here the initialization code. Remember that initialization is executed once per ticking cycle */

        fsm = ScriptableObject.CreateInstance<FSM_Work>();
        fsm.Construct(gameObject);
        
        fsm.OnEnter();
    }

    public override Status OnTick ()
    {
        fsm.Update();
        if (fsm.InSuccess())
        {
            return Status.SUCCEEDED;
        }
        else if (fsm.InFailure())
        {
            return Status.FAILED;
        }

        return Status.RUNNING;

    }

    public override void OnAbort()
    {
        fsm.OnExit();
    }

}
