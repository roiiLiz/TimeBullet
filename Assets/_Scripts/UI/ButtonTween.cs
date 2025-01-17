using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonTween : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private AnimationCurve easeCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);
    [SerializeField] private float duration = 0.2f;
    [SerializeField] private Vector3 highlightScale = new Vector3(1.1f, 1.1f, 1f);
    private Vector3 defaultScale;
    
    private void Start()
    {
        defaultScale = transform.localScale;
    }

    private void OnDisable()
    {
        transform.localScale = defaultScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StartCoroutine(BeginTween(defaultScale, highlightScale, duration));
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StartCoroutine(BeginTween(highlightScale, defaultScale, duration));
    }

    private IEnumerator BeginTween(Vector3 from, Vector3 to, float duration)
    {
        float i = 0.0f;
        float lerpRate = (1.0f / duration);

        while (i < 1.0f)
        {
            i += Time.unscaledDeltaTime * lerpRate;
            transform.localScale = Vector3.Lerp(from, to, easeCurve.Evaluate(i));
            yield return null;
        }
    }
}
