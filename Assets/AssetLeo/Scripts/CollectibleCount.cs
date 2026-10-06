using UnityEngine;

public class CollectibleCount : MonoBehaviour
{
    TMPro.TMP_Text text;
    public int count;
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
    }
    void UpdateCount()
    {
        text.text = $"{count} / {Collectible.total}";
    }
}
