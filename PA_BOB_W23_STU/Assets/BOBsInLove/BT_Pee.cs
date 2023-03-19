using UnityEngine;
using BTs;

[CreateAssetMenu(fileName = "BT_Pee", menuName = "Behaviour Trees/BT_Pee", order = 1)]
public class BT_Pee : BehaviourTree
{
   

     // construtor
    public BT_Pee()  {

       
        /* Receive BT parameters and set them. Remember all are of type string */
    }
    
    public override void OnConstruction()
    {
        

        root = new Sequence(
        new ACTION_Speak("Gotta take a leak..."),
        new ACTION_Arrive("theToilet", "1.0"),
        new LambdaAction(() =>
        {

            gameObject.GetComponent<BOB_Blackboard>().CloseDoor();
            return Status.SUCCEEDED;

        }),
        new ACTION_WaitForSeconds("4"),
        new LambdaAction(() =>
        {

            gameObject.GetComponent<BOB_Blackboard>().OpenDoor();
            return Status.SUCCEEDED;

        }),
        new ACTION_Speak("Oh!!! I needed this"),
        new ACTION_WaitForSeconds("2"),
        new ACTION_Quiet(),
        new LambdaAction(() =>
        {

            gameObject.GetComponent<BOB_Blackboard>().PeeAlarmOff();
            return Status.SUCCEEDED;

        })
        );
    }
}
