
using UnityEngine;  //Peiyuan.Xu 000928128 Mohawk College Game Design 10009 Assignment 1

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
