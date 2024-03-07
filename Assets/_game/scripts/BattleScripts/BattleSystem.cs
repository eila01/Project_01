using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public enum battlestate { START, PLAYTURN, ENEMYTURN, WON, LOST }
public class BattleSystem : MonoBehaviour
{

    [SerializeField] public TextMeshProUGUI gameStateText;
    [SerializeField] public TextMeshProUGUI playerHealthText;
    [SerializeField] public TextMeshProUGUI winState;
    [SerializeField] public TextMeshProUGUI loseState;

    [SerializeField] private ParticleSystem _hurtParticle;
    [SerializeField] private AudioSource _winSound;
    [SerializeField] private AudioSource _lostSound;
    [SerializeField] private AudioSource _hurtSound;
    [SerializeField] private AudioSource _dieSound;

    public Transform _hurtPoint;

    public battlestate _state;

    public bool _playerWon;
    public bool _playerLost;

   // public GameObject playerPrefab;
    //public GameObject enemyPrefab;

    //public Transform _playerBattleStation;
   // public Transform _enemyBattleStation;

    public Units playerUnit;
    public Units enemyUnit;

    //public BattleHud playerHUD;
   //public BattleHud enemyHUD;

    public PowerDice playerPwDice;
    public Dice playerDfDice;
    public SlimeDice slimePwDice;

    public Slime slimeHurtAnimation;

    public SlimeDice slimePowerDmg;
    public Dice defenceNum;
    public PowerDice playerPowerDmg;

    private int playerDefense;

    void Start()
    {

        //slimePowerDmg = GameObject.Find("Slime").GetComponent<SlimeDice>();
        
        _state = battlestate.START;
        gameStateText.text = "GAMESTATE: START";
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {

        /*
        GameObject playerGo = Instantiate(playerPrefab, _playerBattleStation);
        playerGo.GetComponent<Units>();

        GameObject enemyGo = Instantiate(playerPrefab, _playerBattleStation);
        enemyGo.GetComponent<Units>();
        //Instantiate(enemyPrefab, _enemyBattleStation);

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);
        */
        yield return new WaitForSeconds(2f);

        _state = battlestate.PLAYTURN;
        gameStateText.text = "GAMESTATE: PLAYER TURN";
        //PlayerTurn();
    }

    void PlayerTurn()
    {

        Debug.Log("PlayerTurn");    
           // OnRollDice();
        
        
    }

    void EnemyTurn()
    {
        Debug.Log("EnemyTurn");
    }

    IEnumerator playerattack()
    {
        playerPwDice.RollPowerDices();
        playerDfDice.RollDefenseDices();
        //playerDefense = defenceNum.defenseNumber;
        playerUnit.currentDefense = defenceNum.defenseNumber;
        Debug.Log("Player roll their dice");
        yield return new WaitForSeconds(2f);
        slimeHurtAnimation.slimeHurtReaction();

        bool isDead = enemyUnit.TakeDamage(playerPowerDmg.powerNumber,0);

        if (_hurtParticle != null)
        {
            Debug.Log("play particle effect");
            // Quaternion.identity is whatever the prefab is being hit
            Instantiate(_hurtParticle, _hurtPoint.position, Quaternion.identity);
        }
        if (_hurtSound != null)
        {
            Debug.Log("play hurt Audio");
            AudioSource newSound = Instantiate(_hurtSound, transform.position, Quaternion.identity);
            Destroy(newSound.gameObject, newSound.clip.length);
        }

        if (isDead)
        {
            _playerWon = true;
            _state = battlestate.WON;
            EndBattle();
        }
        else
        {
            EnemyTurn();
            _state = battlestate.ENEMYTURN;
            gameStateText.text = "GAMESTATE: ENEMY TURN";
            StartCoroutine(EnemyAttack());
        }

    }

    /*
    void PlayerAttack()
    {
        playerDfDice.RollDefenseDices();
        playerPwDice.RollPowerDices();
        slimeHurtAnimation.slimeHurtReaction();

        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        if (_hurtParticle != null)
        {
            // Quaternion.identity is whatever the prefab is being hit
            Instantiate(_hurtParticle, _hurtPoint.position, Quaternion.identity);
        }
        if (_hurtSound != null)
        {
            AudioSource newSound = Instantiate(_hurtSound, transform.position, Quaternion.identity);
            Destroy(newSound.gameObject, newSound.clip.length);
        }

        if (isDead)
        {
            _playerWon = true;
            _state = battlestate.WON;
            gameStateText.text = "GAMESTATE: WON";
            winState.gameObject.SetActive(true);
        }
        else
        {
            EnemyTurn();
            _state = battlestate.ENEMYTURN;
            gameStateText.text = "GAMESTATE: ENEMY TURN";
            EnemyAttack();
        }
    }
    */
    IEnumerator EnemyAttack()
    {

        slimePwDice.SlimeRollDice();
        Debug.Log("slime roll dice");
        yield return new WaitForSeconds(2f);
        
       // playerUnit.currentDefense += playerDefense;
        bool playerDead =  playerUnit.TakeDamage(slimePowerDmg.slimePower, playerDfDice.defenseNumber);

        if (playerDead)
        {
            _playerLost = true;
            _state = battlestate.LOST;
            EndBattle();


            if (_dieSound != null)
            {
                AudioSource newSound = Instantiate(_dieSound, transform.position, Quaternion.identity);
                Destroy(newSound.gameObject, newSound.clip.length);
            }
        }
        else
        {
            PlayerTurn();
            _state = battlestate.PLAYTURN;
            gameStateText.text = "GAMESTATE: PLAYER TURN";
           // StartCoroutine(playerattack());
            
        }
    }
    public void EndTurn()
    {
        gameStateText.text = "GAMESTATE: ENEMY TURN";
        _state = battlestate.ENEMYTURN;
        StartCoroutine(EnemyAttack());

        _state = battlestate.PLAYTURN;
        gameStateText.text = "GAMESTATE: PLAYER TURN";
        PlayerTurn();
    }

    public void OnRollDice()
    {
       
        gameStateText.text = "GAMESTATE: PLAYER TURN";

        if (_state != battlestate.PLAYTURN)
        {
            Debug.Log("Not PlayerTurn");
            return;
        } 
        Debug.Log("RollDicePressed");
        StartCoroutine(playerattack());
        StartCoroutine(EnemyAttack());
    } 

    void EndBattle()
    {
        Debug.Log("EndBattle");
        if(_state == battlestate.WON)
        {
            Debug.Log("Player Won");
            gameStateText.text = "GAMESTATE: WON";
            winState.gameObject.SetActive(true);
            if (_hurtSound != null)
            {
                Debug.Log("play win Audio");
                AudioSource newSound = Instantiate(_winSound, transform.position, Quaternion.identity);
                Destroy(newSound.gameObject, newSound.clip.length);
            }
        }
        else if (_state == battlestate.LOST)
        {
            Debug.Log("Player Lost");
            gameStateText.text = "GAMESTATE: LOST";
            loseState.gameObject.SetActive(true);
            if (_hurtSound != null)
            {
                Debug.Log("play Lost Audio");
                AudioSource newSound = Instantiate(_lostSound, transform.position, Quaternion.identity);
                Destroy(newSound.gameObject, newSound.clip.length);
            }
        }
    }

}
