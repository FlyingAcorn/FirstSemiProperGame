using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] private GameObject[] victoryButtonLockSprites;
    public void Play() => GameManager.Instance.UpdateGameState(GameManager.GameState.Play);
    public void StartGame() => SceneManager.LoadScene("LVL1");
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Play);
    }
    
    public void Leave() => Application.Quit();
    
    // button manager yerine classı butun butonlara ekleyip tek ChooseLevel methoduyla yapabilirdim.
    
    public void Lvl1()
    {
        if (GameManager.Instance.victoryCount >= 0) SceneManager.LoadScene(1);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Play);
    }
    
    public void Lvl2()
    {
        if (GameManager.Instance.victoryCount >= 1) SceneManager.LoadScene(2);
        else victoryButtonLockSprites[0].transform.DOPunchRotation(new Vector3(0, 0, 10), 2, 5);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Play);
    }

    public void Lvl3()
    {
        if (GameManager.Instance.victoryCount >= 2) SceneManager.LoadScene(3);
        else victoryButtonLockSprites[1].transform.DOPunchRotation(new Vector3(0, 0, 10), 2, 5);
        GameManager.Instance.UpdateGameState(GameManager.GameState.Play);
    }
    
}
