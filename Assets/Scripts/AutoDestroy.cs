using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float lifetime = 0.5f; // Time in seconds before the animation is destroyed

    void Start()
    {
        Destroy(gameObject, lifetime); // Automatically destroy the GameObject after the specified lifetime
    }
}

