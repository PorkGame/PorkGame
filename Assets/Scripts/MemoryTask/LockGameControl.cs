using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockGameControl : MonoBehaviour
{
    public List<int> lockNumbers;
    public static System.Random rnd = new System.Random();
    private List<GameObject> locks = new List<GameObject> { };

    void Start()
    {
        locks.Add(GameObject.Find("Lock1"));
        locks.Add(GameObject.Find("Lock2"));
        locks.Add(GameObject.Find("Lock3"));
        locks.Add(GameObject.Find("Lock4"));
        GenerateLockNumbers();
    }

    public List<int> GenerateLockNumbers()
    {
        List<int> numbers = new List<int> { };
        for (int i = 0; i < locks.Count; i++)
        {
            int nb = rnd.Next(0, 9);

            numbers.Add(nb);
            Debug.Log(nb);
        }
        lockNumbers = numbers;
        return numbers;
    }

    public void CheckLocks()
    {
        for (int i = 0; i < locks.Count; i++)
        {
            if (locks[i].GetComponent<Lock>().number != lockNumbers[i])
                return;
        }

        SceneManager.UnloadSceneAsync("LockGame");
    }

    void Update()
    {
        CheckLocks();
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
