using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_PickAndPee", menuName = "Behaviour Trees/BT_PickAndPee", order = 1)]
public class BT_PickAndPee : BehaviourTree
{


    // construtor
    public BT_PickAndPee()
    {
        /* Receive BT parameters and set them. Remember all are of type string */
    }

    public override void OnConstruction()
    {
        DynamicSelector dynamicSelector = new DynamicSelector();
        dynamicSelector.AddChild(new CONDITION_NeedToPee(),
            new Sequence(


                 CreateInstance<BT_Pee>(),
                 new ACTION_RunForever()
                )

            );

        dynamicSelector.AddChild(new CONDITION_AlwaysTrue(),


            CreateInstance<BT_PickFlowers>()
            );

        root = dynamicSelector;


    }
}
