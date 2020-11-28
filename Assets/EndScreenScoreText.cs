using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenScoreText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<Text>().text = GameVariables.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
