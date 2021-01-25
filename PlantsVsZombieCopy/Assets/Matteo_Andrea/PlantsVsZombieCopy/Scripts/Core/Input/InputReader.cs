using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject, GameInput.IGameplayActions
{

    // Assign delegate{} to events to initialise them with an empty delegate
    // so we can skip the null check when we use them

    // Gameplay
    public event UnityAction InteractEvent = delegate { };
    public event UnityAction CancelInteractEvent = delegate { };
    public event UnityAction<Vector2> MousePositionEvent = delegate { };



    private GameInput gameInput;



    private void OnEnable()
    {
        if (gameInput == null)
        {
            gameInput = new GameInput();
           // gameInput.Menus.SetCallbacks(this);
            gameInput.Gameplay.SetCallbacks(this);
           // gameInput.Dialogues.SetCallbacks(this);
        }

        EnableGameplayInput();
    }



    public void EnableGameplayInput()
    {
        //gameInput.Menus.Disable();
        //gameInput.Dialogues.Disable();

        gameInput.Gameplay.Enable();
    }
   

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            InteractEvent.Invoke();
    }

    public void OnCancelInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            CancelInteractEvent.Invoke();
    }

    public void OnMousePosition(InputAction.CallbackContext context)
    {
        MousePositionEvent.Invoke(context.ReadValue<Vector2>());
    }
}
