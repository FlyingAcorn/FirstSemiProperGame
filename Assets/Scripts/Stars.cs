using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Stars : MonoBehaviour
{
    [SerializeField] private int requiredNumber;
    [SerializeField]  private Image myImage;
    private void OnEnable()
    {
        if (GameManager.Instance.VictoryCount >= requiredNumber)
        {
            DOVirtual.DelayedCall(2, FadeIn);
        }
    }
    private void FadeIn()
    {
        myImage.DOFade(1, 2);
        transform.DOPunchRotation(new Vector3(0, 0, -10f), 2, 5);
    }
}
