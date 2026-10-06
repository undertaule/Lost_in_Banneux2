using UnityEngine;
using UnityEngine.UI;
public class GameOverScreen : MonoBehaviour
{

    public Text pointText;
    public void setup(int score)
    {
        gameObject.SetActive(true);
        pointText.text = score.ToString() + " Fries";
        
    }
    
}
