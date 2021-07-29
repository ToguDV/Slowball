using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vibrator : MonoBehaviour
{


#if UNITY_ANDROID && !UNITY_EDITOR
    public static AndroidJavaClass unityPlayer =  new AndroidJavaClass("com.unity3d.player.UnityPlayer");
    public static AndroidJavaObject currentActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
    public static AndroidJavaObject vibrator = currentActivity.Call<AndroidJavaObject>("getSystemService", "vibrator");
#else

    public static AndroidJavaClass unityPlayer;
    public static AndroidJavaObject currentActivity;
    public static AndroidJavaObject vibrator;
#endif

    public static void Vibrate(long miliseconds = 250)
    {
        if (isAndroid())
        {
            vibrator.Call("vibrate", miliseconds);
        }

        else
        {
            Handheld.Vibrate();
        }
    }

    public static void Cancel()
    {
        if (isAndroid())
        {
            vibrator.Call("cancel");
        }
    }


    public static bool isAndroid()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        return true;

#else
        return false;

#endif
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
