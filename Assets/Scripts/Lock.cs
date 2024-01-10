using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Lock : MonoBehaviour
{
    [SerializeField] private int requiredNumber;
    [SerializeField] private Image myImage;
    private void OnEnable()
    {
        if (GameManager.Instance.VictoryCount >= requiredNumber)
        {
            FadeOut();
        }
    }
    private void FadeOut()
    {
        myImage.DOFade(0, 2);
        transform.DOPunchRotation(new Vector3(0, 0, 10), 2, 5);
    }
}
