using UnityEngine;

public class UIManager : Singleton<UIManager>
{
   [SerializeField] private GameObject[] panels;
   public void CloseAllPanels()
   {
      foreach (var t in panels)
      {
         t.SetActive(false);
      }
   }
   public void Pause() => panels[0].SetActive(true);
   public void Failure() => panels[2].SetActive(true);
   public void Succeed() => panels[1].SetActive(true);
}
