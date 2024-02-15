using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SlimeDice : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI slimepowerText;
    [SerializeField] public TextMeshProUGUI slimeHealthText;
    private int slimePower;
    public int slimeHealth = 3;


    // dice array
    private Sprite[] powerDiceSides;


    private SpriteRenderer rend;

    private void Awake()
    {
        

    }

    // Initialization
    private void Start()
    {
        slimeHealthText.text = "Health " + slimeHealth;

        slimepowerText.text = "Power: " + slimePower;
        rend = GetComponent<SpriteRenderer>();

        // load dice sides to array
        powerDiceSides = Resources.LoadAll<Sprite>("PowerDiceSides/");

    }

    private void Update()
    {


      /*  if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("RollPowerDice");
            slimepowerText.text = "Power: " + slimePower;
        }*/
    }
    public void SlimeRollDice()
    {
        StartCoroutine("RollPowerDice");
        slimepowerText.text = "Power: " + slimePower;
    }
    public IEnumerator RollPowerDice()
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
            rend.sprite = powerDiceSides[randomDiceSide];

            // pause
            yield return new WaitForSeconds(0.05f);
        }

        // assign final side value
        finalSide = randomDiceSide + 1;
        //slimePower = finalSide;
        slimepowerText.text = "Power: " + finalSide;
        // show final dice side
        Debug.Log(finalSide);
    }
}
