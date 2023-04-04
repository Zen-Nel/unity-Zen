using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //static and static instance allows it to grabbed from anywhere
     public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    void Awake()
    {
        
        Instance = this;
    }

    void start()
    {

        UpdateGameState(GameState.SelectColor);
    }

    public void UpdateGameState(GameState newState)
    {

        State = newState;

        switch (newState)
        {
            case GameState.SelectColor: State = GameState.SelectColor;
                HandleSelectColor();
                break;
            case GameState.PlayerTurn: State = GameState.PlayerTurn;
                break;
            case GameState.EnemyTurn: State = GameState.EnemyTurn;
                break;
            case GameState.Victory: State = GameState.Victory;
                break;
            case GameState.Lose: State = GameState.Lose;    
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
               

        }
        OnGameStateChanged?.Invoke(newState);

    }

}
public enum GameState
    {

        SelectColor,
        PlayerTurn,
        EnemyTurn,
        Victory,
        Lose
    }