using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BattleHud : MonoBehaviour
{
    public Text nameText;
    public Text defenseText;
    public Text powerText;
    //public int totalHP;

    public void SetHUD(Units unit)
    {
        nameText.text = unit.unitName;
        
    }
}
