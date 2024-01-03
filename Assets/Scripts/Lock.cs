using UnityEngine;
using DG.Tweening;

public class Lock : MonoBehaviour
{
    [SerializeField] private int requiredNumber;
    [SerializeField] private SpriteRenderer mySprite;
     

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
    }
    
    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
    }
    private void GameManagerOnOnGameStateChanged(GameManager.GameState state)
    {
        if (state == GameManager.GameState.Win && GameManager.Instance.victoryCount >= requiredNumber)
        {
            Invoke("FadeOut",2);
        }
    }

    private void FadeOut()
    {
        mySprite.DOFade(0, 2);
        transform.DOPunchRotation(new Vector3(0, 0, 10), 2, 5);
    }
}
