using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_PickFlowers", menuName = "Behaviour Trees/BT_PickFlowers", order = 1)]
public class BT_PickFlowers : BehaviourTree
{

    public string TheFlower;

    public BT_PickFlowers()  
    {

    }
    
    public override void OnConstruction()
    {
        DynamicSelector dynSel = new DynamicSelector();



        dynSel.AddChild(
            new CONDITION_InstanceNear("flowerDetectionRadius", "FLOWER"),
            new Sequence(
                new ACTION_Arrive("TheFlower", "1"),
                new ACTION_Deactivate("FLOWER")         //No desactiva la flor (CHECK PLEASE)
               )
            );
        dynSel.AddChild(
            new CONDITION_AlwaysTrue(),
            new ACTION_CWander("ThePark", "80", "40", "0.2", "0.8")
            );

        root = new RepeatForeverDecorator(dynSel);  
            
    }
}
