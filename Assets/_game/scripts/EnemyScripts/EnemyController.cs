using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    public Sprite _idle, _hurt;
    protected abstract void OnHit();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("keycode is pressed");
            GetComponent<SpriteRenderer>().sprite = _hurt;
        }
        */
    }
}
