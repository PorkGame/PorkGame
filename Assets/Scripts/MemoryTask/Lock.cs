using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lock : MonoBehaviour
{
    public int number = 0;
    public GameObject numberText;
    public GameObject up;
    public GameObject down;

    // Start is called before the first frame update
    void Start()
    {
        numberText = getChildGameObject(this.gameObject, "NumberText");
        up = getChildGameObject(this.gameObject, "Up");
        down = getChildGameObject(this.gameObject, "Down");
        up.GetComponent<Button>().onClick.AddListener(OnClickUp);
        down.GetComponent<Button>().onClick.AddListener(OnClickDown);
    }

    void OnClickUp()
    {
        number++;
        if (number > 9)
            number = 0;
        UpdateText();
    }

    void OnClickDown()
    {
        number--;
        if (number < 0)
            number = 9;
        UpdateText();
    }

    void UpdateText()
    {
        numberText.GetComponent<Text>().text = number.ToString();
    }

    GameObject getChildGameObject(GameObject fromGameObject, string withName)
    {
        Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>();
        foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
        return null;
    }
}
