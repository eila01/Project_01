using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Units : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI HealthText;

    public string unitName;
    

    //public int damage;

    public int maxHP;
    public int currentHP;

    public int currentPower;
    public int currentDefense;

    public bool hasDefense;

    private int dmgAfterDef;

    private void Start()
    {
        HealthText.text = unitName + " Health: " + currentHP;
    }
    public bool TakeDamage(int dmg, int def)
    {
        Debug.Log("Take Damage happen");
       // Debug.Log("Def = " + def + " && Dmg = " + dmg);
       // Debug.Log("dmg - def = " + (dmg - def));
           //dmgAfterDef =  

        if (def >= dmg)
        {
            dmgAfterDef =  def - dmg;
            Debug.Log("Def - dmg = " + (def-dmg));
            currentHP -= dmgAfterDef;
        }
        else if (def < dmg)
        {
            dmgAfterDef = dmg - def;
            Debug.Log("Dmg - def = " + (dmg - def));
            currentHP -= dmgAfterDef;
        }
           
        
        Debug.Log("CurrentHP: " + currentHP);
        HealthText.text = unitName + " Health: " + currentHP;
        if (currentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
