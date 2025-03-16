
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;  //Peiyuan.Xu 000928128 Mohawk College Game Design 

public class FinishPoint : MonoBehaviour
{
   
    
        private void OnTriggerEnter2D(Collider2D collision)
    {
        
       
        
        if (collision.CompareTag("Player"))
        {
            // go to next level
            SceneController.instance.NextLevel();
        }

        
    }
    
}
