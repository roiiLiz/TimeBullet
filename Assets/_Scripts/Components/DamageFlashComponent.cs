using System.Collections;
using UnityEngine;

public class DamageFlashComponent : MonoBehaviour
{
    [SerializeField]
    private float flashTime = 0.25f;
    [SerializeField]
    private Color flashColor = new Color(255, 0, 0, 255);
    private Color defaultColor;
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        defaultColor = sprite.color;
    }

    public void BeginDamageFlash()
    {
        StartCoroutine(DamageFlash());
    }

    private IEnumerator DamageFlash()
    {
        // Debug.Log("Damage Flasher");
        float elapsedTime = 0f;

        while (elapsedTime < flashTime)
        {
            elapsedTime += Time.deltaTime;
            sprite.color = flashColor;

            yield return null;
        }

        sprite.color = defaultColor;
    }
}
