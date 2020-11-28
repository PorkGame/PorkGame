using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextInfo : MonoBehaviour
{
    GameObject info;
    bool isActive = true;
    // Start is called before the first frame update
    void Start()
    {
        info = GameObject.Find("MemoryTextInfo");
        this.gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
        Activation();
    }

    void Activation()
    {
        info.GetComponent<RectTransform>().SetAsLastSibling();
        info.SetActive(!isActive);
        isActive = !isActive;
    }

    void OnClick()
    {
        Activation();
    }
}
