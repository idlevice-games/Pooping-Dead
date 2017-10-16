using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameSparks;
using GameSparks.Core;
using GameSparks.Api;
using GameSparks.Api.Requests;


public class RegisterPlayer : MonoBehaviour {

    public void RegisterPlayerButton()
    {
        string displayName = GameObject.Find("/UICanvas/RegistrationPanel/RegistrationDisplayName").GetComponent<InputField>().text;
        string userName = GameObject.Find("/UICanvas/RegistrationPanel/RegistrationUserName").GetComponent<InputField>().text;
        string password = GameObject.Find("/UICanvas/RegistrationPanel/RegistrationPassword").GetComponent<InputField>().text;

        if (string.IsNullOrEmpty(displayName) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
        {
            Debug.Log("Must have a displayName, userName and password to continue...");
        }
        else
        {
            Debug.Log("Registering player..");
            new GameSparks.Api.Requests.RegistrationRequest()
                .SetDisplayName(displayName)
                .SetUserName(userName)
                .SetPassword(password)
                .Send((response) =>
                {
                    Debug.Log("Sending registration request..");
                    if (!response.HasErrors)
                    {
                        Debug.Log("Player Registered \n User Name: " + response.DisplayName);
                    }
                    else
                    {
                        Debug.Log("Error registering player: " + response.Errors.JSON.ToString());

                    }
                });
        }
    }
}
    



