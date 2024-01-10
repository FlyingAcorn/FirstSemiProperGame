using UnityEngine;

public class CameraManager : Singleton<CameraManager>
{
    private Animator _myAnim;
    private static readonly int Menu = Animator.StringToHash("Menu");
    private static readonly int Play = Animator.StringToHash("Play");
    private static readonly int Win = Animator.StringToHash("Win");
    private static readonly int Lose = Animator.StringToHash("Lose");
    protected override void Awake()
    {
        _myAnim = GetComponent<Animator>();
    }
    public void Pause() => _myAnim.SetTrigger(Menu);
    public void Playing() => _myAnim.SetTrigger(Play);
    public void Failure() => _myAnim.SetTrigger(Lose);
    public void Succeed() =>_myAnim.SetTrigger(Win);
    
}
