using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    GameObject card;
    List<Color> cardColors = new List<Color> { 
        new Color(138, 98, 89),
        new Color(138, 98, 89), 
        new Color(106, 138, 89),
        new Color(106, 138, 89), 
        new Color(75, 109, 126),
        new Color(75, 109, 126), 
        new Color(75, 60, 88),
        new Color(75, 60, 88),
        new Color(83, 50, 73),
        new Color(83, 50, 73),
        new Color(162, 150, 154),
        new Color(162, 150, 154)
    };
    List<int> cardNumbers = new List<int> {
        1,
        1,
        2,
        2,
        3,
        3,
        4,
        4,
        5,
        5,
        6,
        6
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
            tmp.GetComponent<Card>().SetNumber(cardNumbers[shuffleNum]);
            cards.Add(tmp);
            cardColors.RemoveAt(shuffleNum);
            cardNumbers.RemoveAt(shuffleNum);
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
        {
            SceneManager.UnloadSceneAsync("MemoryTask");
            GameVariables.animals += 1;
        }
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.UnloadSceneAsync("MemoryTask");
        }
    }

}
