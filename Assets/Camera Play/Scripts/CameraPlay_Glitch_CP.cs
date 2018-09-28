////////////////////////////////////////////
///// CameraPlay - by VETASOFT 2018    /////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public partial class CameraPlay : MonoBehaviour
{

    /// <summary>
    /// Active Glitch FX. Add a Glitch effect to the current camera.
    /// </summary>
    /// <param name="Time">Set the time effect in second.</param>
    public static void Glitch(float Time)
    {
        if (CurrentCamera == null) CurrentCamera = Camera.main;
        CameraPlay_Glitch CP = CurrentCamera.gameObject.AddComponent<CameraPlay_Glitch>() as CameraPlay_Glitch;
        CP.Duration = Time;
    }
    /// <summary>
    /// Active Glitch FX. Add a Glitch effect to the current camera. By default, the timer apparition duration is set to 3 seconds.
    /// </summary>
    public static void Glitch()
    {
        if (CurrentCamera == null) CurrentCamera = Camera.main;
        CameraPlay_Glitch CP = CurrentCamera.gameObject.AddComponent<CameraPlay_Glitch>() as CameraPlay_Glitch;
        CP.Duration = 3;
    }

}