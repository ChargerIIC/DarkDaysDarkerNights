using System.Collections;
using System.Collections.Generic;
using DarkDays.Enum;
using DarkDays.Player;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VR.WSA.WebCam;

public class TouchWarp : MonoBehaviour
{

    public string SceneToLoad;

    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == (int)Layers.Player)
        {
            var player = other.GetComponentInParent<PlayerController>().gameObject; //slightly less evil, still hacky
            SceneManager.LoadScene(SceneToLoad);

            var scene = SceneManager.GetSceneByName(SceneToLoad);
            player.transform.SetPositionAndRotation(new Vector3(0f,0f,0f), Quaternion.identity);
            //TODO: Load player into scene

            SceneManager.SetActiveScene(scene);
        }
    }

}
