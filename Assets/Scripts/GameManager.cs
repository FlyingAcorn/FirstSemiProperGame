using System;
using DG.Tweening;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public static event Action<GameState> OnGameStateChanged;
    private int _victoryCount;
    public int VictoryCount
    {
        get => _victoryCount;
         set
        {
            _victoryCount = Mathf.Min(3, value);
                Debug.Log(VictoryCount);
        }
    }
    public enum GameState
    {
        Play,
        Pause,
        Lose,
        Win,
    }
    public GameState state;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            if (state is GameState.Win or GameState.Lose ) return;
            UpdateGameState(state == GameState.Pause ? GameState.Play : GameState.Pause);
        }
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;
        var uiManager = UIManager.Instance;
        var cameraManager = CameraManager.Instance;
        uiManager.CloseAllPanels();
        if (newState == GameState.Pause)
        {
            uiManager.Pause();
            cameraManager.Pause();
        }
        else if (newState == GameState.Play) cameraManager.Playing();
        else if (newState == GameState.Lose)
        {
            DOVirtual.DelayedCall(2, uiManager.Failure);
            cameraManager.Failure();
        }
        else if (newState == GameState.Win)
        {
            VictoryCount += 1;
            DOVirtual.DelayedCall(2, uiManager.Succeed);
            cameraManager.Succeed();
        } 
        else throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        OnGameStateChanged?.Invoke(newState);
    }
}
