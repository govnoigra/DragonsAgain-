using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking.Match;

public class JoinButton : MonoBehaviour
{
    private Text buttonText;
    private MatchInfoSnapshot match;

   

    private void Awake()
    {
        buttonText = GetComponentInChildren<Text>();
        GetComponent<Button>().onClick.AddListener(JoinMatch);
    }

    public void Initialize(MatchInfoSnapshot match, Transform panelTransform)
    {
        this.match = match;
        buttonText.text = match.name;
        transform.SetParent(panelTransform);
        transform.localScale = Vector3.one;
        transform.localRotation = Quaternion.identity;
        transform.localPosition = Vector3.zero;
    }

    private void JoinMatch()
    {
        FindObjectOfType<CustomNetworkManager>().JoinMatch(match);
        

    }
}
