using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class EnemyBase : MonoBehaviour
{
    [SerializeField] float _health;
    private InputAction touchPressAction;
    public Sprite _idle, _hurt;
    protected abstract void OnHit();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if (touchPressAction.WasPerformedThisFrame())
        {
            Debug.Log("touchPress was performed");
            GetComponent<SpriteRenderer>().sprite = _hurt;

        }
    }
}
