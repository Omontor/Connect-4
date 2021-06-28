using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FInalCanvasManager : MonoBehaviour
{
  public  TMP_Text title, text;

    public void changescene(int scene)
    {
        SceneManager.LoadScene(scene);

    }

}
