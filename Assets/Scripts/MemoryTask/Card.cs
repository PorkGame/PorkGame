using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    GameObject gameControl;
    GameObject numberText;
    public Button yourButton;
    public int number;
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

    public void SetNumber(int nb)
    {
        number = nb;
        numberText = getChildGameObject(this.gameObject, "Text");
        numberText.SetActive(false);
        numberText.GetComponent<Text>().text = nb.ToString();
    }

    public void Hide()
    {
        this.gameObject.GetComponent<Button>().image.color = Color.black;
        numberText.SetActive(false);
        gameControl.GetComponent<GameControl>().nbActiveCards -= 1;
        active = false;
    }

    GameObject getChildGameObject(GameObject fromGameObject, string withName)
    {
        Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>();
        foreach (Transform t in ts) if (t.gameObject.name == withName) return t.gameObject;
        return null;
    }

    public void Reveal()
    {

        this.gameObject.GetComponent<Button>().image.color = colorFace;
        numberText.SetActive(true);
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
