using System.Collections;
using DG.Tweening;
using UnityEngine;

public class DissapearingBlocks : MonoBehaviour
{
    private Transform _myTransform;
    [SerializeField] private GameObject effect;
    [SerializeField] private int timer;
    private void Awake()
    {
        _myTransform = GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (!trigger.TryGetComponent(out Player _)) return;
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        _myTransform.DOShakeRotation(timer, new Vector3(0,2,0),10,randomness:90F,false);
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
        Instantiate(effect, transform.position, transform.rotation);
    }

}
