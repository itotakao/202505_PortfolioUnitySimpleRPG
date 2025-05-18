using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEffect : MonoBehaviour
{
    [SerializeField]
    private Text valueText;

    void Start()
    {
        StartCoroutine(CoStart());
    }

    public void Initialize(int value, Vector3 spawnPoint)
    {
        valueText.text = $"{value}";
        valueText.rectTransform.localPosition = spawnPoint;
    }

    IEnumerator CoStart()
    {
        var currentColor = valueText.color;
        valueText.color = new Color(currentColor.r, currentColor.g, currentColor.b, 1);

        var popupAnimationTimeSec = 1.0f;
        var currentAlpha = 1.0f;

        valueText.color = new Color(currentColor.r, currentColor.g, currentColor.b, currentAlpha);

        new WaitForSeconds(popupAnimationTimeSec);

        while (true)
        {
            valueText.color = new Color(currentColor.r, currentColor.g, currentColor.b, currentAlpha);

            yield return null;

            currentAlpha -= (Time.deltaTime / popupAnimationTimeSec);
            if (currentAlpha <= 0)
            {
                break;
            }
        }

        Destroy(gameObject);
    }
}
