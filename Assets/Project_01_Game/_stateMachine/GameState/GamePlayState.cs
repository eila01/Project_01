using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public enum Battlestate {START, PLAYTURN, ENEMYTURN, WON, LOST }
public class GamePlayState : State
{
    /*
    public bool _playerWon;
    public bool _playerLost;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    
    public Transform _playerBattleStation;
    public Transform _enemyBattleStation;

    Units playerUnit;
    Units enemyUnit;

    public BattleHud playerHUD;
    public BattleHud enemyHUD;


    public Battlestate _state;

    private GameFSM _stateMachine;
    private GameController _controller;

    

    public GamePlayState(GameFSM stateMachine, GameController controller)
    {
        _stateMachine = stateMachine;
        _controller = controller;
    }

    void Start()
    {
        //_state = Battlestate.START;
       // SetupBattle();
    }

    IEnumerator SetupBattle()
    {

        //GameObject playerGo = Instantiate(playerPrefab, _playerBattleStation); ;
        //playerGo.GetComponent<Unit>();
        //Instantiate(enemyPrefab, _enemyBattleStation);

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        _state = Battlestate.PLAYTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {

    }

    void EnemyTurn()
    {

    }

    void PlayerAttack()
    {
        //bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        if (isDead)
        {
            _playerWon = true;
            _state = Battlestate.WON;
        }
        else
        {
            EnemyTurn();
            _state = Battlestate.ENEMYTURN;
            EnemyAttack();
        }
    }

    void EnemyAttack()
    {
        //playerUnit.TakeDamage(enemyUnit.damage);
    }
    public void EndTurn()
    {
        _state = Battlestate.ENEMYTURN;
        EnemyAttack();
        
        PlayerTurn();
    }

    public override void Enter()
    {
        base.Enter();
        _playerWon = false;
        _playerLost = false;
        Debug.Log("State: GamePlay");
        Debug.Log("Listen fo Player Inputs");
        Debug.Log("Display Player HUD");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void Tick()
    {
        base.Tick();
        
       // Debug.Log("Checking for Win Condition");
       // if(_playerWon == true)
       // {

       // }
       // Debug.Log("Checking for lose condition");
        //if(_playerLost == true)
       // {

       // }
    }
    */
}
