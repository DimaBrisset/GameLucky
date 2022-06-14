using NaughtyAttributes;
using UnityEngine;

public class Test : MonoBehaviour
{
   public GameObject go;
   public MonoBehaviour mono;

   [Button()]
   public void TurnOnGo()
   {
      go.SetActive(true);
   }
   
   
   [Button()]
   public void TurnOfGo()
   {
      go.SetActive(false);
   }
   [Button()]
   public void TurnOnMono()
   {
      mono.enabled = true;
   }
   
   [Button()]
   public void TurnofMono()
   {  mono.enabled = false;
      
   }
   
}
