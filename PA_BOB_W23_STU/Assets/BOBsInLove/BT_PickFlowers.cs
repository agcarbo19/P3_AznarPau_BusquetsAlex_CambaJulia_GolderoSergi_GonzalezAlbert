using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_PickFlowers", menuName = "Behaviour Trees/BT_PickFlowers", order = 1)]
public class BT_PickFlowers : BehaviourTree
{ 
    public BT_PickFlowers()
    { 

    }

    public override void OnConstruction()
    {
        DynamicSelector dynSel = new DynamicSelector();

        dynSel.AddChild(
            new CONDITION_InstanceNear("flowerDetectionRadius", "FLOWER", "true", "theFlower"),
            new Sequence(
                new ACTION_Arrive("theFlower", "1"),
                new ACTION_Deactivate("theFlower"),
                new LambdaAction(() =>
                {
                    gameObject.GetComponent<BOB_Blackboard>().CountFlower();
                    return Status.SUCCEEDED;
                })
               )
            );

        dynSel.AddChild(
            new CONDITION_AlwaysTrue(),
            new ACTION_CWander("ThePark", "80", "40", "0.2", "0.8")
            );

        root = new RepeatForeverDecorator(dynSel);

    }
}
