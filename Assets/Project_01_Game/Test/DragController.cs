using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragController : MonoBehaviour
{

    private bool _isDragActive = false;

    private Vector2 _screenPosition;

    private Vector3 _worldPosition;

    private Draggable _lastDraggedItem;

    private PlayerInput playerInput;
    private InputAction touchPositionAction;
    private InputAction touchPressAction;
    private InputAction touchHoldAction;

    void Awake()
    {
        DragController[] controllers = FindObjectsOfType<DragController>();
        if (controllers.Length > 1)
        {
            Destroy(gameObject);
        }
        touchPressAction = playerInput.actions["TouchPress"];
        touchPositionAction = playerInput.actions["TouchPosition"];
        touchHoldAction = playerInput.actions["TouchHold"];

        // touchHoldAction.Enabled();
        touchPositionAction.performed += context => { _worldPosition = context.ReadValue<Vector2>(); };
    }

    void Update()
    {
        if(_isDragActive)
        {
            if (touchHoldAction.phase == 0)
            {
                Drop();
                return;
            }
            
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            _screenPosition = new Vector2(mousePos.x, mousePos.y);

        }
        else if (Input.touchCount > 0)
        {
            _screenPosition = Input.GetTouch(0).position;
        }
        else
        {
            return;
        }

        _worldPosition = Camera.main.ScreenToWorldPoint(_screenPosition);

        if (_isDragActive)
        {
            Drag();
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(_worldPosition, Vector2.zero);
            if (hit.collider != null)
            {
                Draggable draggable = hit.transform.GetComponent<Draggable>();
                if(draggable != null)
                {
                    _lastDraggedItem = draggable;
                    InitDrag();
                }
            }
        }

    }

    void InitDrag()
    {
        _isDragActive = true;
    }

    void Drag()
    {
        _lastDraggedItem.transform.position = new Vector2(_worldPosition.x, _worldPosition.y);
    }

    void Drop()
    {
        _isDragActive = false;
    }

}
