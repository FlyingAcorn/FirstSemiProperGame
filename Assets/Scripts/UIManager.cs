using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
   private Animator _myAnim;
   [SerializeField] private GameObject[] panels;
   private static readonly int Menu = Animator.StringToHash("Menu");
   private static readonly int Play = Animator.StringToHash("Play");
   private static readonly int Win = Animator.StringToHash("Win");
   private static readonly int Lose = Animator.StringToHash("Lose");
   
   private void Awake()
   {
      _myAnim = GetComponent<Animator>();
      GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
   }

   private void OnDestroy()
   {
      GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
   }

   private void GameManagerOnOnGameStateChanged(GameManager.GameState state)
   {
       foreach (var t in panels)
       {
          t.SetActive(false);
       }
       switch (state)
       {
          case GameManager.GameState.Pause:
             _myAnim.SetTrigger(Menu);
             panels[0].SetActive(true);
             break;
          case GameManager.GameState.Win:
             _myAnim.SetTrigger(Win);
             panels[1].SetActive(true);
             break;
          case GameManager.GameState.Lose:
             _myAnim.SetTrigger(Lose);
             panels[2].SetActive(true);
             break;
          case GameManager.GameState.Play:
             _myAnim.SetTrigger(Play);
             break;
          default:
             throw new ArgumentOutOfRangeException(nameof(state), state, null);
       }
   }
}
