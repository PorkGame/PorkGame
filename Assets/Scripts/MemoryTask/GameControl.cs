﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    GameObject card;
    List<Color> cardColors = new List<Color> { 
        Color.green, 
        Color.green, 
        Color.red, 
        Color.red, 
        Color.yellow, 
        Color.yellow, 
        Color.gray, 
        Color.gray, 
        Color.blue, 
        Color.blue,
        Color.magenta,
        Color.magenta
    };
    public static System.Random rnd = new System.Random();
    public int shuffleNum = 0;
    public List<GameObject> cards;
    public int nbActiveCards = 0;

    void Start()
    {
        float yPosition = 60f;
        float xPosition = -155f;
        for (int i = 1; i <= 12; i++)
        {
            shuffleNum = rnd.Next(0, cardColors.Count);
            var tmp = Instantiate(card, new Vector3(0, 0, 0), Quaternion.identity, GameObject.Find("GameCanvas").transform);
            tmp.transform.localPosition = new Vector3(xPosition, yPosition, 0);
            tmp.GetComponent<Card>().colorFace = cardColors[shuffleNum];
            cards.Add(tmp);
            cardColors.RemoveAt(shuffleNum);
            xPosition += 100f;
            if (i % 4 == 0)
            {
                xPosition = -155f;
                yPosition -= 100f;
            }
        }
    }

    public void RemoveActiveCards()
    {
        if (nbActiveCards < 2)
            return;
        cards.ForEach(card =>
        {
            if (card.GetComponent<Card>().active && !card.GetComponent<Card>().matched)
            {
                card.GetComponent<Card>().Hide();
            }
        });
    }

    public void VerifyMatch()
    {
        Card firstCard = null;

        cards.ForEach(card =>
        {
            Card tmp = card.GetComponent<Card>();
            if (tmp.active && !tmp.matched)
            {
                if (firstCard == null)
                    firstCard = tmp;
                else
                {
                    if (tmp.colorFace == firstCard.colorFace)
                    {
                        firstCard.matched = true;
                        tmp.matched = true;
                        nbActiveCards = 0;
                        FinishGame();
                    }
                }
            }
        });
    }

    public void FinishGame()
    {
        bool canFinish = true;
        cards.ForEach(card =>
        {
            if (!card.GetComponent<Card>().matched)
            {
                canFinish = false;
            }
        });
        if (canFinish)
            SceneManager.UnloadSceneAsync("MemoryTask");
    }
    
    private void Awake()
    {
        card = GameObject.Find("Card");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           if (SceneManager.GetSceneByName("ResumeMenu").isLoaded)
            {
                SceneManager.UnloadSceneAsync("ResumeMenu");
            }
           else
            {
                SceneManager.LoadScene("ResumeMenu", LoadSceneMode.Additive);
            }
        }
    }

}
