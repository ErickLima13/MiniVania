using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    private void Update()
    {
        GetComponent<CanvasGroup>().alpha += Time.deltaTime * 0.5f;
    }
}
