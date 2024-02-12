using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TouchTest : MonoBehaviour
{
    private PlayerInput playerInput;
    private EnemyBase enemySprite;

    private InputAction touchPositionAction;
    private InputAction touchPressAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        enemySprite = GetComponent<EnemyBase>();
        touchPressAction = playerInput.actions["TouchPress"];
        touchPositionAction = playerInput.actions["TouchPosition"];
    }

    private void OnEnable()
    {
        touchPressAction.performed += TouchPressed;
    }
    private void OnDisable()
    {
        touchPressAction.performed -= TouchPressed;

    }
    private void TouchPressed(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        Debug.Log(value);
        Vector3 position = Camera.main.ScreenToWorldPoint(touchPositionAction.ReadValue<Vector2>());
    }
    private void Update()
    {
        // touchPositionAction.ReadValue<Vector2>();
        if (touchPressAction.WasPerformedThisFrame())
        {
          //  enemySprite.
        }
        }
        }
