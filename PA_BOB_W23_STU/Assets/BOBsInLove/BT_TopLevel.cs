using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_TopLevel", menuName = "Behaviour Trees/BT_TopLevel", order = 1)]
public class BT_TopLevel : BehaviourTree
{
    /* If necessary declare BT parameters here. 
       All public parameters must be of type string. All public parameters must be
       regarded as keys in/for the blackboard context.
       Use prefix "key" for input parameters (information stored in the blackboard that must be retrieved)
       use prefix "keyout" for output parameters (information that must be stored in the blackboard)

       e.g.
       public string keyDistance;
       public string keyoutObject 

       NOTICE: BT's with parameters cannot be constructed using ScriptableObject.CreateInstance<>
       An explicit constructor with new must be used. Unity will complain...
       Whenever possible, use parameter-less BT's. Use blackboard to pass information.
       TOP-level BTs (those attached to the executor) cannot have parameters
       
       In future versions, BT parameters may cease to exit

     */

    // construtor
    public BT_TopLevel()
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

        root = new Sequence( 

              CreateInstance<BT_WorkForMoney>(),
              CreateInstance<BT_MakeBouquet>(),
              CreateInstance<BT_BuyPresent>(), 
              new ACTION_Arrive("daisys"),
              new ACTION_Speak("Would you marry me?")

            );





    }
}
