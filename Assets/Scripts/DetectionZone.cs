using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZone : MonoBehaviour
{
    public List<Collider2D> detectedColider = new List<Collider2D>();
    Collider2D col;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        detectedColider.Add(collision);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        detectedColider.Remove(collision);
    }
}
