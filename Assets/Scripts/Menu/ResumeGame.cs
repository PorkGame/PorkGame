﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResumeGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        SceneManager.UnloadSceneAsync("ResumeMenu");
    }
}
