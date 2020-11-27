using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    GameObject gameControl;
    public Button yourButton;
    public Color colorFace;
    public bool active;
    public bool matched;

    public void Start()
    {
        active = false;
        this.gameObject.GetComponent<Button>().image.color = Color.black;
        this.gameObject.GetComponent<Button>().onClick.AddListener(TaskOnClick);
        gameControl = GameObject.Find("GameControl");

    }

    public void Hide()
    {
        this.gameObject.GetComponent<Button>().image.color = Color.black;
        gameControl.GetComponent<GameControl>().nbActiveCards -= 1;
        active = false;
    }

    public void Reveal()
    {

        this.gameObject.GetComponent<Button>().image.color = colorFace;
        gameControl.GetComponent<GameControl>().nbActiveCards += 1;
        active = true;
    }

    public void TaskOnClick()
    {
        if (matched)
            return;
        if (active)
        {
            Hide();
        } else
        {
            gameControl.GetComponent<GameControl>().RemoveActiveCards();
            Reveal();
            gameControl.GetComponent<GameControl>().VerifyMatch();
        }
    }
}
