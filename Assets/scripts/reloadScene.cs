using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadScene : MonoBehaviour {

	public void playAgain()
    {
        SceneManager.LoadScene("scene1");
    }

    public void backToTitle()
    {
        SceneManager.LoadScene("Title");
    }
}
