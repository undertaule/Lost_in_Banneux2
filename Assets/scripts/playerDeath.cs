using UnityEngine;
using UnityEngine.UI;
public class playerDeath : MonoBehaviour
{
    
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Hitbox")
        {
            Debug.Log("Game Over !");
            Time.timeScale = 0f; // Stoppe le jeu
        }
    }
    
}
