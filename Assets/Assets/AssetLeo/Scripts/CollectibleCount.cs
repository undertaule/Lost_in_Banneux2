using UnityEngine;
using UnityEngine.UI;
public class CollectibleCount : MonoBehaviour
{
    TMPro.TMP_Text text;
    public int count;
    public GameOverScreen gameOverScreen;
    void Start() => UpdateCount();
    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();


    }
    void OnEnable() => Collectible.OnCollected += OnCollectibleCollected;
    void OnDisable() => Collectible.OnCollected -= OnCollectibleCollected;

    void OnCollectibleCollected()
    {
        count++;
        UpdateCount();
        gameOverScreen.setup(count);
    }
    void UpdateCount()
    {
        text.text = $"{count} / {Collectible.total}";
    }
}
