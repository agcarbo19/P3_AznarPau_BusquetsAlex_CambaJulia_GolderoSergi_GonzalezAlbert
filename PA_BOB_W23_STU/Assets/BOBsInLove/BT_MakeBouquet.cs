using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_MakeBouquet", menuName = "Behaviour Trees/BT_MakeBouquet", order = 1)]
public class BT_MakeBouquet : BehaviourTree
{
    

     // construtor
    public BT_MakeBouquet()  { 
        /* Receive BT parameters and set them. Remember all are of type string */
    }
    
    public override void OnConstruction()
    { 

        DynamicSelector dynamicSelector = new DynamicSelector();
        dynamicSelector.AddChild( new CONDITION_EnoughFlowers (),
            new  LambdaAction(() =>
            {
                gameObject.GetComponent<BOB_Blackboard>().ActivateBouquet();
                return Status.SUCCEEDED;
            })

            );

        dynamicSelector.AddChild(new CONDITION_AlwaysTrue(),
        CreateInstance<BT_PickAndPee>() 
             
            );

        root = dynamicSelector;



    }
}
