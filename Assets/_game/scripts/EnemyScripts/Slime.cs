using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : EnemyController
{
    protected override void OnHit()
    {
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("keycode is pressed");
            StartCoroutine(SpriteReaction());
        }
    }

    IEnumerator SpriteReaction()
    {
        //This is a coroutine
        GetComponent<SpriteRenderer>().sprite = _hurt; ;

        yield return new WaitForSeconds(1f);

        GetComponent<SpriteRenderer>().sprite = _idle;
    }
}
