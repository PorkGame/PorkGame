using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEvent : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider actualCollider;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        actualCollider = other;

    }

    public void HideObject()
    {
        GameObject acutalObject = GameObject.Find(actualCollider.gameObject.name);
        acutalObject.SetActive(false);
    }
}
