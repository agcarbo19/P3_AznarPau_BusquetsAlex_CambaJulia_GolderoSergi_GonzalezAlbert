using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_WorkForMoney", menuName = "Behaviour Trees/BT_WorkForMoney", order = 1)]
public class BT_WorkForMoney : BehaviourTree
{


    // construtor
    public BT_WorkForMoney()
    {
        /* Receive BT parameters and set them. Remember all are of type string */
    }

    public override void OnConstruction()
    {
        /* Write here (method OnConstruction) the code that constructs the Behaviour Tree 
           Remember to set the root attribute to a proper node
           e.g.
            ...
            root = new Sequence();
            ...

          A behaviour tree can use other behaviour trees.  
      */


        RepeatUntilSuccessDecorator success = new RepeatUntilSuccessDecorator();

        success.AddChild(
            new Selector(
                new CONDITION_EnoughMoney(),

                new Sequence(
                    new ACTION_Work(),
                    new LambdaAction(() =>
                    {
                        gameObject.GetComponent<BOB_Blackboard>().GetPaid();
                        return Status.SUCCEEDED;
                    }),
                    new ACTION_Fail()

                     )
                ) 
          );

        root = success;

        /*
        Selector selector = new Selector();

        selector.AddChild(
            new CONDITION_EnoughMoney(),
            new ACTION_Speak("yastoi")
            
            );

        selector.AddChild( new Sequence(
            
            new ACTION_Work(),
            new  LambdaAction(() =>
            {
                gameObject.GetComponent<BOB_Blackboard>().GetPaid();
                return Status.SUCCEEDED;
            }),

            new ACTION_Fail()

            )
            
            );

        root = new RepeatUntilSuccessDecorator(selector);*/
    }
}
