using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : EnemyBase
{
    // public Sprite sprSlime;

    private void Update()
    {
        
    }
    protected override void OnHit()
    {
        GetComponent<SpriteRenderer>().sprite = _hurt;
        //throw new System.NotImplementedException();
    }
}
