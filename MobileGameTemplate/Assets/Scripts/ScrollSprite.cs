using UnityEngine;
using UnityEngine.UI;

public class ScrollSprite : MonoBehaviour
{
    // Scroll main texture based on time

    public float scrollSpeed = 0.5f;
    Material rend;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        float offset = Time.deltaTime * scrollSpeed;
        rend.mainTextureOffset=new Vector2(offset, offset);
    }
}