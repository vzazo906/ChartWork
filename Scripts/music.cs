using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class music : MonoBehaviour
{
    public static music audioSource;
    private void Awake()
    {
        if (audioSource != null)
        {
            Destroy(gameObject);
        }
        else
        {
            audioSource = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
