using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameSparks;
using GameSparks.Core;
using GameSparks.Api;
using GameSparks.Api.Requests;


public class AuthenticatePlayer : MonoBehaviour
{

    public void AuthenticatePlayerButton()
    {        
        string userName = GameObject.Find("/UICanvas/RegistrationPanel/RegistrationUserName").GetComponent<InputField>().text;
        string password = GameObject.Find("/UICanvas/RegistrationPanel/RegistrationPassword").GetComponent<InputField>().text;

        if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
        {
            Debug.Log("Must have a userName and password to login...");
        }
        else
        {
            Debug.Log("Authenticating player..");
            new GameSparks.Api.Requests.AuthenticationRequest ()                
                .SetUserName(userName)
                .SetPassword(password)
                .Send((response) =>
                {
                    Debug.Log("Sending authentication request..");
                    if (!response.HasErrors)
                    {
                        Debug.Log("Player authenticated -\n User Name: " + response.DisplayName);
                    }
                    else
                    {
                        Debug.Log("Error authenticating player: " + response.Errors.JSON.ToString());

                    }
                });
        }
    }
}




