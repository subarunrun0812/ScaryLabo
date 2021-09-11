using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoalScript : MonoBehaviour
{

  public GameManager gameManager;
  // Start is called before the first frame update


  void Start()
  {
    gameManager.GoalTriggerText();
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      Application.Quit();
    }
  }
}
