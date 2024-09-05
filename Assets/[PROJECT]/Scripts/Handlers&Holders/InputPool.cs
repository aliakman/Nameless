using UnityEngine;
using UnityEngine.InputSystem;
using Helpers;
using State;

public class InputPool : MonoBehaviour
{
    public Enums.InputActionMaps currentMap = Enums.InputActionMaps.None;

    private StateHandler<Enums.BehaviourStates> _stateHandler;
    private StateHandler<Enums.BehaviourStates> stateHandler { get { return _stateHandler ? _stateHandler : _stateHandler = Scripts.PlayerBehaviourStateHandler(); } }

    private ReferenceHolder _refHolder;
    private ReferenceHolder refHolder { get { return _refHolder ? _refHolder : _refHolder = stateHandler; } }

    public Vector3 movement;
    public Vector2 look;

    private bool isQPressed;
    private bool isEPressed;

    private void OnEnable()
    {
        EventManager.Scripts.InputPool += ()=> this;
    }
    private void OnDisable()
    {
        EventManager.Scripts.InputPool -= () => this;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = new Vector3(context.ReadValue<Vector2>().x - context.ReadValue<Vector2>().y, 0, context.ReadValue<Vector2>().y + context.ReadValue<Vector2>().x);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        look = context.ReadValue<Vector2>();
    }

    public void OnBasicAttack(InputAction.CallbackContext context) // Left Button [Mouse]
    {
        if (context.started)
        {
            if(stateHandler.subState == Enums.BehaviourStates.None && stateHandler.charController.isGrounded)
            {
                if(stateHandler.mainState == Enums.BehaviourStates.Move || stateHandler.mainState == Enums.BehaviourStates.Dash || /*!refHolder.weaponHolder.currentWeapon.isDelay*/stateHandler.mainState == Enums.BehaviourStates.BasicAttack)
                    stateHandler.ChangeMainState(Enums.BehaviourStates.BasicAttack);
            }
        }
        else if (context.canceled)
        {
            //if(playerBehaviourStateHandler.subState == Enums.PlayerBehaviourStates.BasicAttack)
            //{
            //    if(playerBehaviourStateHandler.mainState == Enums.PlayerBehaviourStates.Move || playerBehaviourStateHandler.mainState == Enums.PlayerBehaviourStates.Dash)
            //        playerBehaviourStateHandler.ChangeSubState(Enums.PlayerBehaviourStates.None);
            //}
        }
    }
    public void OnAdvancedAttack(InputAction.CallbackContext context) // Right Button [Mouse]
    {
        if (context.started)
        {
            if (stateHandler.subState == Enums.BehaviourStates.None && stateHandler.charController.isGrounded)
            {
                if (stateHandler.mainState == Enums.BehaviourStates.Move || stateHandler.mainState == Enums.BehaviourStates.Dash)
                    stateHandler.ChangeSubState(Enums.BehaviourStates.AdvancedAttack);
            }
        }
        else if (context.canceled)
        {
            if (stateHandler.subState == Enums.BehaviourStates.AdvancedAttack)
            {
                if (stateHandler.mainState == Enums.BehaviourStates.Move || stateHandler.mainState == Enums.BehaviourStates.Dash)
                    stateHandler.SetSubStateNone();
            }
        }
    }

    public void OnWeaponChanged(InputAction.CallbackContext context) // Q-E
    {
        if (context.ReadValue<float>() == -1 && !isQPressed)
        {
            isQPressed = true;
            isEPressed = false;
            refHolder.weaponHandler.SwitchWeapon();
        }
        else if (context.ReadValue<float>() == 1 && !isEPressed)
        {
            isQPressed = false;
            isEPressed = true;
            refHolder.weaponHandler.SwitchWeapon();
        }
    }

    public void OnJumpPressed(InputAction.CallbackContext context) // Space
    {
        if(context.started && stateHandler.mainState == Enums.BehaviourStates.Move && stateHandler.charController.isGrounded)
        {
            stateHandler.ChangeMainState(Enums.BehaviourStates.Jump);
        }
    }

    public void OnDashPressed(InputAction.CallbackContext context) // V
    {
        if(context.started)
        {
            if(stateHandler.mainState == Enums.BehaviourStates.Move || stateHandler.mainState == Enums.BehaviourStates.Jump)
                stateHandler.ChangeMainState(Enums.BehaviourStates.Dash);
        }
    }

    public void OnRepulsePressed(InputAction.CallbackContext context) // F
    {
        if (context.started && stateHandler.mainState == Enums.BehaviourStates.Move)
        {
            stateHandler.ChangeMainState(Enums.BehaviourStates.Repulse);
        }
        else if (context.canceled && stateHandler.mainState == Enums.BehaviourStates.Repulse)
        {
            stateHandler.ChangeMainState(Enums.BehaviourStates.Move);
        }
    }

    public void OnDeadEyePressed(InputAction.CallbackContext context) // Left Shift
    {
        if (context.started && stateHandler.mainState == Enums.BehaviourStates.Move)
        {

        }
    }

}
