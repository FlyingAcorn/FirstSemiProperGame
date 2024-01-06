using UnityEngine;
public class Lever : MonoBehaviour,ICollision
{
    protected Transform _myTransform;
    [SerializeField] protected bool leverCondition;
    
    private void Start()
    {
        _myTransform = GetComponent<Transform>();
    }

    public virtual void Interact()
    { 
        leverCondition = !leverCondition;
        LeverSwitch();
    }

    protected void LeverSwitch()
    {
        switch (leverCondition)
        {
            case true:
                _myTransform.transform.position = new Vector3(_myTransform.transform.position.x - 0.2f,
                    _myTransform.transform.position.y, _myTransform.position.z);
                _myTransform.transform.eulerAngles = new Vector3(0, 180);
                break;
            case false:
                _myTransform.transform.position = new Vector3(_myTransform.transform.position.x + 0.2f,
                    _myTransform.transform.position.y, _myTransform.position.z);
                _myTransform.transform.eulerAngles = new Vector3(0, 0);
                break;
        }
    }
}
