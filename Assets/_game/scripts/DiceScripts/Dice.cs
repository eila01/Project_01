using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Dice : MonoBehaviour
{
    public int defenseNumber = 0;
    [SerializeField] public TextMeshProUGUI diceDefenseText;

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
      //if (defenseNumber <=)
    }
    public void RollDefenseDices()
    {
        StartCoroutine("RollDefenceDice");
    }
    private IEnumerator RollDefenceDice()
    {
        // variable containing random dice side number
        int randomDiceSide = 0;

        // final dice side that is read that the end
        //int finalSide = 0;

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

        /*
         finalSide = randomDiceSide + 1;
        diceDefenseText.text = "Defense: " + finalSide;
         */

        // assign final side value
        defenseNumber = randomDiceSide + 1;
        diceDefenseText.text = "Defense: " + defenseNumber;
        //defenseNumber = finalSide;
        //defenseNumber - SlimeDice.slimePower;
        // show final dice side
        Debug.Log(defenseNumber);
    }



}
