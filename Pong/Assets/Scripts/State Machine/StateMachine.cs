using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
  public enum StateType
    {
        MENU,
        PLAYING,
        RESET_POSTION,
        END_GAME, 
    }
    public Dictionary<StateType, StateBase> dictionaryState;

    private StateBase _currentState;
    public Player player;
    public float timeToStartGame = 1f;
    public static StateMachine Instance;

    private void Awake()
    {
        Instance = this;

        dictionaryState = new Dictionary<StateType, StateBase>();
        dictionaryState.Add(StateType.MENU, new StateMenu());
        dictionaryState.Add(StateType.PLAYING, new StatePlaying());
        dictionaryState.Add(StateType.RESET_POSTION, new StateResetPosition());
        dictionaryState.Add(StateType.END_GAME, new StateEndGame());

        SwitchState(StateType.MENU);
    }
    private void StartGame()
    {
        SwitchState(StateType.MENU);
    }
    public void SwitchState(StateType state)
    {
        if (_currentState != null) _currentState.OnStateExit();
        _currentState=dictionaryState[state];
        if (_currentState != null) _currentState.OnStateEnter();
    }
    private void Update()
    {
        if (_currentState != null) _currentState.OnStateStay();
        if(Input.GetKeyDown(KeyCode.O))
        {
            SwitchState(StateType.PLAYING);
        }
    }
    public void ResetPosition()
    {
        SwitchState(StateType.RESET_POSTION);
    }
}
