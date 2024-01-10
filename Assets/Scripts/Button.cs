using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject[] victoryButtonLockImages;
    public void Play() => GameManager.Instance.UpdateGameState(GameManager.GameState.Play);
    public void StartGame() => SceneManager.LoadScene(1);

    public void Restart()
    {
        if (GameManager.Instance.state == GameManager.GameState.Win)GameManager.Instance.VictoryCount -= 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Play);
    }
    public void Leave() => Application.Quit();
    
    // canvası baştan yap ve dön buraya
    
    public void PlayerLevel(int lvl)
    {
        var vC =Mathf.Min(lvl, GameManager.Instance.VictoryCount);
        if (vC < lvl -1)
        {
            victoryButtonLockImages[lvl - 1].transform.DOPunchRotation(new Vector3(0, 0, 10), 2, 5);
            return;
        }
        if (GameManager.Instance.VictoryCount <3 && SceneManager.GetActiveScene().buildIndex >= lvl)
        {
            
            GameManager.Instance.VictoryCount -= 1;
        }
        SceneManager.LoadScene(lvl);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Play);
    }
}


