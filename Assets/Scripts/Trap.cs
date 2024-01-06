using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Animator _myAnim;
    [SerializeField] private float delayTime;
    private static readonly int TrapActive = Animator.StringToHash("Active");
    private void Start()
    {
        _myAnim = GetComponent<Animator>();
        StartCoroutine(Delay());
    }
    
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime +3);
            _myAnim.SetTrigger(TrapActive);
    }
}
