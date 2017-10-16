using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameSparks;
using GameSparks.Core;
using GameSparks.Platforms;
using GameSparks.Platforms.WebGL;
using GameSparks.Platforms.Native;
using GameSparks.Api;
using GameSparks.Api.Messages;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

public class GameSparksManager : MonoBehaviour {

    
    private static GameSparksManager instance = null;    


    void Awake()
    { 
        if (instance == null) // check to see if the instance has a reference
        {
            instance = this; // if not, give it a reference to this class...
            DontDestroyOnLoad(this.gameObject); // and make this object persistent as we load new scenes
        }
        else // if we already have a reference then remove the extra manager from the scene
        {
            Destroy(this.gameObject);
        }
    }
         
   
}
