using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBottom : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player _))
        {
            GameManager.Instance.UpdateGameState(GameManager.GameState.Lose);
        }
    }
}
