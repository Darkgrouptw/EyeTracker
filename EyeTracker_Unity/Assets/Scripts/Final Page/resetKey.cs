using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resetKey : MonoBehaviour
{
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            SceneManager.LoadSceneAsync(0);
	}
}
