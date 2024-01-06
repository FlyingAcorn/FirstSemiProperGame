using System;
using System.Collections;
using UnityEngine;

public class LeverTimer : LeverLight
{
    [SerializeField] private int timer;
    [SerializeField] private GameObject[] dissapearingObjects;
    [SerializeField] private GameObject path;
    private Coroutine _coroutine;
    public static event Action TimesUp;

    public override void Interact()
    {
        switch (leverCondition)
        {
            case true:
                StopCoroutine(_coroutine); 
                leverCondition = false;
                SetObjectsActive();
                break;
            case false:
                SetObjectsActive();
                _coroutine = StartCoroutine(Countdown());
                leverCondition = true;
                break;
        }
        LeverSwitch();
        SendEvent();
    }

    private void SetObjectsActive()
    {
        foreach (var t in dissapearingObjects)
        {
            t.SetActive(true);
        } 
    }
    
    private IEnumerator Countdown()
    {
        
        path.SetActive(false);
        yield return new WaitForSeconds(timer);
        leverCondition = false;
        LeverSwitch();
        TimesUp?.Invoke();
        SetObjectsActive();
    }
}
