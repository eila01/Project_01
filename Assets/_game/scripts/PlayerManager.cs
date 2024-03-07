using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerManager : MonoBehaviour
{
   // private int playerHealth = 5;
    [SerializeField] public TextMeshProUGUI playerHealthText;
    [SerializeField] public TextMeshProUGUI winState;
    [SerializeField] public TextMeshProUGUI loseState;


    private void Start()
    {
        //playerHealthText.text = "Health " + playerHealth;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            winState.enabled = true;
        }
    }

}
