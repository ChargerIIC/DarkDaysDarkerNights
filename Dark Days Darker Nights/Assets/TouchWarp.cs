using System.Collections;
using System.Collections.Generic;
using DarkDays.Enum;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VR.WSA.WebCam;

public class TouchWarp : MonoBehaviour
{

    public string SceneToLoad;

    protected void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == (int)Layers.Player)
        {
            var player = other.gameObject;
            var scene = SceneManager.GetSceneByName(SceneToLoad);
            player.transform.position.Set(0f,0f,0f);
            SceneManager.MoveGameObjectToScene(player, scene);
            //TODO: Load player into scene
            SceneManager.LoadScene(scene.name);
        }
    }
}
