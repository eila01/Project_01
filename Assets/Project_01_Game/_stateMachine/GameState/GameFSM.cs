using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
[RequireComponent(typeof(GameController))]
public class GameFSM : StateMachineMB
{
    [SerializeField] public TextMeshProUGUI _gameStateText;

    private GameController _controller;

    // state variables here
    public GameSetupState SetupState { get; private set; }
    public GamePlayState PlayState { get; private set; }

    private void Awake()
    {
        _controller = GetComponent<GameController>();
        // state instance here
        SetupState = new GameSetupState(this, _controller);
       // PlayState = new GamePlayState(this, _controller);
    }

    private void Start()
    {
        ChangeState(SetupState);
    }
}
