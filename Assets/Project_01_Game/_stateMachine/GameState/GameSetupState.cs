using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetupState : State
{
    private GameFSM _stateMachine;
    private GameController _controller;

    // this our 'constructor', called when this state is created
    public GameSetupState(GameFSM stateMachine, GameController controller)
    {
        // hold on to our parameters in our class variables for reuse 
        _stateMachine = stateMachine;
        _controller = controller;
    }

    public override void Enter()
    {
        base.Enter();

        Debug.Log("STATE: Game Setup");
        Debug.Log("Load Save Data");
        Debug.Log("Spawn Units");
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
         _stateMachine.ChangeState(_stateMachine.PlayState);
    }
}
