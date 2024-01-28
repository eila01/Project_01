using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class DragDropController : MonoBehaviour
{
    [SerializeField]
    private InputAction touchPress;
    // private InputAction mouseClick;
    [SerializeField]
    private float touchDragPhysicsSpeed = 10;
    [SerializeField]
    private float touchDragSpeed = .1f;
    [SerializeField]
    private Camera mainCamera;
    private Vector3 velocity = Vector3.zero;
    private WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();

    private Vector2 _screenPosition;

    private Vector3 _worldPosition;

    private Draggable _lastDraggedItem;


    private void Awake()
    {
        DragController[] controllers = FindObjectsOfType<DragController>();
        if (controllers.Length > 1)
        {
            Destroy(gameObject);
        }
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        touchPress.Enable();
        touchPress.performed += TouchPressed;
    }

    private void OnDisable()
    {
        touchPress.performed -= TouchPressed;
        touchPress.Disable();
    }

    private void TouchPressed(InputAction.CallbackContext context)
    {
        Ray ray = mainCamera.ScreenPointToRay(Touchscreen.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            // moving 3d objects
            if (hit.collider != null && (hit.collider.gameObject.CompareTag("Draggable") || hit.collider.gameObject.layer == LayerMask.NameToLayer("Draggable")))
            {
                StartCoroutine(DragUpdate(hit.collider.gameObject));
            }
        }
        // moving 2d objects
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray);
        if (hit2D.collider != null && (hit2D.collider.gameObject.CompareTag("Draggable") || hit2D.collider.gameObject.layer == LayerMask.NameToLayer("Draggable")))
        {
            StartCoroutine(DragUpdate(hit2D.collider.gameObject));
        }
    }

    private IEnumerator DragUpdate(GameObject clickedObject)
    {
        float initialDistance = Vector3.Distance(clickedObject.transform.position, mainCamera.transform.position);
        clickedObject.TryGetComponent<Rigidbody>(out var rb);
        while (touchPress.ReadValue<float>() != 0)
        {
            //         Vector3 position = Camera.main.ScreenToWorldPoint(touchPositionAction.ReadValue<Vector2>());

            Ray ray = mainCamera.ScreenPointToRay(Touchscreen.current.primaryTouch.position.ReadValue());
            if (rb != null)
            {
                Vector3 direction = ray.GetPoint(initialDistance) - clickedObject.transform.position;
                rb.velocity = direction * touchDragPhysicsSpeed;
                yield return waitForFixedUpdate;
            }
            else
            {
                clickedObject.transform.position = Vector3.SmoothDamp(clickedObject.transform.position, ray.GetPoint(initialDistance), ref velocity, touchDragSpeed);
                yield return null; 

            }
        }
    }

}
