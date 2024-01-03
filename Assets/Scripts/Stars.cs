using DG.Tweening;
using UnityEngine;

public class Stars : MonoBehaviour
{
    [SerializeField] private int requiredNumber;
    [SerializeField]  private SpriteRenderer mySprite;

    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
    }
    // awake yanlızca bir kere cağırılıyor diye dotween düzgün çalışmıyor
    // onu ref alarak çözebilirsin yada kurcala lock scriptide aynı durumdan muzdarip
    
    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
    }
    private void GameManagerOnOnGameStateChanged(GameManager.GameState state)
    {
        if (state == GameManager.GameState.Win && GameManager.Instance.victoryCount >= requiredNumber)
        {
            Invoke("FadeIn",4);
        }
    }

    private void FadeIn()
    {
        Debug.Log("kek");
        mySprite.DOFade(1, 2);
        transform.DOPunchRotation(new Vector3(0, 0, -10f), 2, 5);
    }
}
