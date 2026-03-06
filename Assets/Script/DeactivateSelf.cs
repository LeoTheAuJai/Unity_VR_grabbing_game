
using System.Collections;
using UnityEngine;

public class DeactivateSelf : MonoBehaviour
{
    IEnumerator DelayedMethod()
    {
        yield return new WaitForSeconds(2f); // 2-second delay
        // Code to execute after delay
        Debug.Log("2 seconds have passed!");
    }
    private void Update()
    {
        DelayedMethod();
        gameObject.SetActive(false);
    }
}