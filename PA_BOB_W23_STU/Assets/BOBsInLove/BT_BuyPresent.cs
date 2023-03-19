using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_BuyPresent", menuName = "Behaviour Trees/BT_BuyPresent", order = 1)]
public class BT_BuyPresent : BehaviourTree
{


    // construtor
    public BT_BuyPresent()
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

        Sequence sequence = new Sequence();
        sequence.AddChild(

            new ACTION_Arrive("theJewellery", "2")

            );




        sequence.AddChild(

            new Selector(
                new Sequence(
                    new CONDITION_InstanceNear("20", "RING", "true", "theRing"),
                    new LambdaAction(() =>
                   {
                        gameObject.GetComponent<BOB_Blackboard>().PayJewel();
                        return Status.SUCCEEDED;
                    }),

                     new LambdaAction(() =>
                     {
                         gameObject.GetComponent<BOB_Blackboard>().ActivateRing();
                         return Status.SUCCEEDED;
                     })

                    ),

                new Sequence(

                    new LambdaAction(() =>
                    {
                        gameObject.GetComponent<BOB_Blackboard>().PayJewel();
                        return Status.SUCCEEDED;
                    }),


                     new LambdaAction(() =>
                     {
                         gameObject.GetComponent<BOB_Blackboard>().ActivateNecklace();
                         return Status.SUCCEEDED;
                     })



                    )


                )

          );

        root = sequence;
    }
}
