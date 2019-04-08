using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //доступ к компонентам юай
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
   public void Restart()
    {
        SceneManager.LoadScene("Arcada", LoadSceneMode.Single); //будем загружена сцена Аркада ((если у вас несколько сцен, то используйте LoadSceneMode.Additive)), для одной сцены Single
        Time.timeScale = 1;
    }

   public void ExitGame()
    {
        Application.Quit();//выход из игры
    }

    public void RestartCampaign()
    {
        SceneManager.LoadScene("campaign", LoadSceneMode.Single); //будем загружена сцена Аркада ((если у вас несколько сцен, то используйте LoadSceneMode.Additive)), для одной сцены Single
        Time.timeScale = 1;
    }

    public void RestartCampaign2()
    {
        SceneManager.LoadScene("campaign2", LoadSceneMode.Single); //будем загружена сцена Аркада ((если у вас несколько сцен, то используйте LoadSceneMode.Additive)), для одной сцены Single
        Time.timeScale = 1;
    }
}
