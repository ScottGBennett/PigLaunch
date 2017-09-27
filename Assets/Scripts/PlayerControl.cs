using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //	
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            //	
        }

        if (Input.GetKey(KeyCode.Space))
        {
            switch (SceneManager.GetActiveScene().buildIndex)
            {

                case 0: SceneManager.LoadScene(1); break;
                case 1: SceneManager.LoadScene(2); break;
                case 2: SceneManager.LoadScene(3); break;
                case 3: SceneManager.LoadScene(4); break;
                case 4: SceneManager.LoadScene(0); break;
                


            }
        }
    }
}
