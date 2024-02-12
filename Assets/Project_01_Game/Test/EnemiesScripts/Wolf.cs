using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : EnemyBase
{
   // public Sprite sprWolf;

    public void Update()
    {
        /*if (Input.GetKeyDown("K"))
        {
            GetComponent<SpriteRenderer>().sprite = _hurt;
        }*/
        //GetComponent<SpriteRenderer>().sprite = sprWolf;
    }
    protected override void OnHit()
    {
        GetComponent<SpriteRenderer>().sprite = _hurt;
        //throw new System.NotImplementedException();
    }
}
