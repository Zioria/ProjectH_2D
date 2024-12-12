using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UnselectButton : MonoBehaviour
{
    public void UnselectButtonAfterDelay()
    {
        StartCoroutine(UnselectAfterDelay(0.1f)); // Wait for 0.1 seconds
    }

    private IEnumerator UnselectAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        EventSystem.current.SetSelectedGameObject(null);
    }
}
