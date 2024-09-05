using UnityEngine;

public class BehaviourHandler : MonoBehaviour
{
    private void BasicAttack() // Left Button [Mouse]
    {
        Debug.Log("Basic Attack");
    }

    private void AdvancedAttack() // Right Button [Mouse]
    {
        Debug.Log("Advanced Attack");
    }

    private void ChangeWeapon(int _value) // Q-E
    {
        //inputPool.isQPressed = false;
        //inputPool.isEPressed = false;
        Debug.Log(_value);
    }

    private void DeadEye() // Left Shift
    {
        Debug.Log("DeadEyed");
    }

}
