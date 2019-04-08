using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class CustomNetworkManager : NetworkManager 
{
    private float nextRefreshTime;
    public Button button2;
    public GameObject panel2;
 
    public void StopHosting()
    {
        StopHost();
        Application.LoadLevel(0);
    }

    public void StartHosting()
    {
        StartMatchMaker();
        matchMaker.CreateMatch("ПОДКЛЮЧИТЬСЯ", 4, true, "", "", "", 0, 0, OnMatchCreated);
        button2.gameObject.SetActive(false);
        panel2.gameObject.SetActive(false);

      
    }

    private void OnMatchCreated(bool success, string extendedinfo, MatchInfo responsedata)
    {
        base.StartHost(responsedata);
        RefreshMatches();
    }

    private void Update()
    {
        if (Time.time >= nextRefreshTime)
        {
            RefreshMatches();
        }
    }

    private void RefreshMatches()
    {
        nextRefreshTime = Time.time + 5f;

        if (matchMaker == null)
            StartMatchMaker();

        matchMaker.ListMatches(0, 10, "", true, 0, 0, HandleListMatchesComplete);
    }

    private void HandleListMatchesComplete(bool success, string extendedinfo, List<MatchInfoSnapshot> responsedata)
    {
        AvailableMatchesList.HandleNewMatchList(responsedata);
    }

    public void JoinMatch(MatchInfoSnapshot match)
    {
        if (matchMaker == null)
            StartMatchMaker();

        matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, HandleJoinedMatch);
    }

    private void HandleJoinedMatch(bool success, string extendedinfo, MatchInfo responsedata)
    {
        StartClient(responsedata);
    }
}
