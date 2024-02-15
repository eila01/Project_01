using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Dice : MonoBehaviour
{
    // dice array
    private Sprite[] defenceDiceSides;
    //[SerializeField] public TextMeshProUGUI diceDefenseText;


    private SpriteRenderer rend;

    // Initialization
    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();

        // load dice sides to array
        defenceDiceSides = Resources.LoadAll<Sprite>("DefenceDiceSides/");
       
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("RollDefenceDice");
        }
    }

    private IEnumerator RollDefenceDice()
    {
        // variable containing random dice side number
        int randomDiceSide = 0;

        // final dice side that is read that the end
        int finalSide = 0;

        // loop to switch dice sides before final side appears
        for (int i = 0; i <= 20; i++)
        {
            // pick random calue from 0 - 4
            randomDiceSide = Random.Range(0, 4);

            // set sprite rend to the random value
            rend.sprite = defenceDiceSides[randomDiceSide];

            // pause
            yield return new WaitForSeconds(0.05f);
        }

        // assign final side value
        finalSide = randomDiceSide + 1;
       // diceDefenseText.text = "Defense: " + finalSide;

        // show final dice side
        Debug.Log(finalSide);
    }



}
