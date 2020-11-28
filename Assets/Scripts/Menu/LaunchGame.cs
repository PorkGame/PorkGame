using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LaunchGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        GameVariables.score = 0;
        GameVariables.animals = 0;
        SceneManager.LoadScene("PrincipalScene");
    }
}
