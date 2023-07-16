using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFloor : MonoBehaviour
{
    //Å@âÒì]ë¨ìx
    private float _rotationSpeed = 30f;
    private RectTransform rectTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb.mass > 2)
            {
                Debug.Log(rb.mass);
                float rotationAmount = _rotationSpeed * Time.deltaTime;
                rectTransform.Rotate(Vector3.forward, rotationAmount);
            }
        }
    }
}
