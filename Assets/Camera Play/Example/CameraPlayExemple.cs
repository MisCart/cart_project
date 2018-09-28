////////////////////////////////////////////
///// CameraPlay - by VETASOFT 2018    /////
////////////////////////////////////////////

using UnityEngine;
using System.Collections;

public class CameraPlayExemple : MonoBehaviour
{
    public TextMesh TextName;
    public TextMesh TextDescription;
    public TextMesh TextNameFX;
    public TextMesh TextPress;
    public GameObject TurnONOFF;
    public GameObject NightTurnONOFF;
    public Camera othercamera;
    public int CurrentFX = 0;
    public int NightVisionFX = 0;
    public int DrunkFX = 0;

    private int TotalFX = 33 + 1;

    void Start()
    {
        CurrentFX = 0;
        ChangeText();
    }

    void ChangeText()
    {
        if (CurrentFX < 0) CurrentFX = TotalFX - 1;
        if (CurrentFX >= TotalFX) CurrentFX = 0;
        if (CurrentFX == 0) TextName.text = "- Click anywhere on the screen -";
        if (CurrentFX == 1) TextName.text = "- Turn On / Off -";
        if (CurrentFX == 2) TextName.text = "- Click anywhere on the screen -";
        if (CurrentFX == 3) TextName.text = "- Turn On / Off -";
        if (CurrentFX == 1) TextPress.text = " Change Night Vision Type\nPress 0 to 9";
        if (CurrentFX == 3) TextPress.text = " Change Drunk Type\nPress 0 to 9";
        if (CurrentFX == 4) TextName.text = "- Click anywhere on the screen -";
        if (CurrentFX == 5) TextName.text = "- Click anywhere on the screen -";
        if (CurrentFX == 6) TextName.text = "- Click anywhere on the screen -";
        if (CurrentFX == 7) TextName.text = "- Click anywhere on the screen -";
        if (CurrentFX == 8) TextName.text = "- Turn On / Off -";
        if (CurrentFX == 9) TextName.text = "- Click anywhere on the screen -";
        if (CurrentFX == 10) TextName.text = "- Click anywhere on the screen -";
        if (CurrentFX == 11) TextName.text = "- Turn On / Off -";
        if (CurrentFX == 12) TextName.text = "- Click anywhere on the screen -";
        if (CurrentFX == 13) TextName.text = "- Click anywhere on the screen -";
        if (CurrentFX == 14) TextName.text = "- Click anywhere on the screen -";
        if (CurrentFX == 15) TextName.text = "- Turn On / Off -";
        if (CurrentFX == 16) TextName.text = "- Turn On / Off -";
        if (CurrentFX == 17) TextName.text = "- Turn On / Off -";
        if (CurrentFX == 18) TextName.text = "- Turn On / Off -";
        if (CurrentFX == 19) TextName.text = "- Turn On / Off -";
        if (CurrentFX == 20) TextName.text = "- Turn On / Off -";
        if (CurrentFX == 21) TextName.text = "- Click anywhere on the screen -";
        if (CurrentFX == 22) TextName.text = "- Click anywhere on the screen -";
        if (CurrentFX == 23) TextName.text = "- Click anywhere on the screen -";
        if (CurrentFX == 24) TextName.text = "- Click anywhere on the screen -";
        if (CurrentFX == 25) TextName.text = "- Click anywhere on the screen -";
        if (CurrentFX == 26) TextName.text = "- Click anywhere on the screen -";
        if (CurrentFX == 27) TextName.text = "- Click anywhere on the screen -";
        if (CurrentFX == 28) TextName.text = "- Turn On / Off -";
        if (CurrentFX == 29) TextName.text = "- Click anywhere on the screen -";
        if (CurrentFX == 30) TextName.text = "- Click anywhere on the screen -";
        if (CurrentFX == 31) TextName.text = "- Turn On / Off -";
        if (CurrentFX == 32) TextName.text = "- Click anywhere on the screen -";
        if (CurrentFX == 33) TextName.text = "- Click anywhere on the screen -";
        NightTurnONOFF.SetActive(false);
        TurnONOFF.SetActive(false);
        DrunkFX = 0;
        NightVisionFX = 9;
    }
    void Off_Filter()
    {
        CameraPlay.NightVision_OFF(0.5f);
        CameraPlay.Drunk_OFF(0.5f);
        CameraPlay.SniperScope_OFF();
        CameraPlay.BlackWhite_OFF();
        CameraPlay.FlyVision_OFF();
        CameraPlay.Fade_OFF();
        CameraPlay.Pixel_OFF();
        CameraPlay.Colored_OFF();
        CameraPlay.Thermavision_OFF();
        CameraPlay.Infrared_OFF();
        CameraPlay.WidescreenH_OFF();
        CameraPlay.RainDrop_OFF();
        CameraPlay.Inverse_OFF();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Off_Filter();
            TextName.text = " ";
            TextDescription.text = " ";
            CurrentFX--;
            ChangeText();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Off_Filter();
            TextName.text = " ";
            TextDescription.text = " ";
            CurrentFX++;
            ChangeText();
        }

        //////////////////////////////////////////// 0 = DROP WATER
        if (CurrentFX == 0)
        {
            TextNameFX.text = "Drop Water";

            TextDescription.text = "Add a Water Drop to the current camera,\n and remove it automatically after the animation is finished.";
            if (Input.GetMouseButtonDown(0))
            {
                float mx = Input.mousePosition.x / Screen.width;
                float my = Input.mousePosition.y / Screen.height;
                CameraPlay.DropWater(mx, my, 1.5f, 2f);
                TextName.text = "CameraPlay.DropWater(" + mx.ToString("F2") + "f," + (1 - my).ToString("F2") + "f,1.5f,2f);";
            }
        }

        //////////////////////////////////////////// 1 = Night Vision
        if (CurrentFX == 1)
        {
            TextNameFX.text = "Night Vision";
            TextDescription.text = "Add a night vision FX to the current camera,\n Turn On or Off, change animation time and more.";
            TurnONOFF.SetActive(true);
            NightTurnONOFF.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Alpha0)) NightVisionFX = 0;
            if (Input.GetKeyDown(KeyCode.Alpha1)) NightVisionFX = 1;
            if (Input.GetKeyDown(KeyCode.Alpha2)) NightVisionFX = 2;
            if (Input.GetKeyDown(KeyCode.Alpha3)) NightVisionFX = 3;
            if (Input.GetKeyDown(KeyCode.Alpha4)) NightVisionFX = 4;
            if (Input.GetKeyDown(KeyCode.Alpha5)) NightVisionFX = 5;
            if (Input.GetKeyDown(KeyCode.Alpha6)) NightVisionFX = 6;
            if (Input.GetKeyDown(KeyCode.Alpha7)) NightVisionFX = 7;
            if (Input.GetKeyDown(KeyCode.Alpha8)) NightVisionFX = 8;
            if (Input.GetKeyDown(KeyCode.Alpha9)) NightVisionFX = 9;

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                if (NightVisionFX == 1) CameraPlay.NightVision_ON(CameraPlay.NightVision_Preset.Night_Vision_Classic, 1);
                if (NightVisionFX == 2) CameraPlay.NightVision_ON(CameraPlay.NightVision_Preset.Night_Vision_Full, 1);
                if (NightVisionFX == 3) CameraPlay.NightVision_ON(CameraPlay.NightVision_Preset.Night_Vision_Dark, 1);
                if (NightVisionFX == 4) CameraPlay.NightVision_ON(CameraPlay.NightVision_Preset.Night_Vision_Sharp, 1);
                if (NightVisionFX == 5) CameraPlay.NightVision_ON(CameraPlay.NightVision_Preset.Night_Vision_BlueSky, 1);
                if (NightVisionFX == 6) CameraPlay.NightVision_ON(CameraPlay.NightVision_Preset.Night_Vision_Low_Light, 1);
                if (NightVisionFX == 7) CameraPlay.NightVision_ON(CameraPlay.NightVision_Preset.Night_Vision_Pinky, 1);
                if (NightVisionFX == 8) CameraPlay.NightVision_ON(CameraPlay.NightVision_Preset.Night_Vision_RedBurn, 1);
                if (NightVisionFX == 9) CameraPlay.NightVision_ON(CameraPlay.NightVision_Preset.Night_Vision_PurpleShadow, 1);

                if (NightVisionFX == 0) TextName.text = "CameraPlay.NightVision_ON(CameraPlay.NightVision_Preset.Night_Vision_FX,1);";
                if (NightVisionFX == 1) TextName.text = "CameraPlay.NightVision_ON(CameraPlay.NightVision_Preset.Night_Vision_Classic,1);";
                if (NightVisionFX == 2) TextName.text = "CameraPlay.NightVision_ON(CameraPlay.NightVision_Preset.Night_Vision_Full,1);";
                if (NightVisionFX == 3) TextName.text = "CameraPlay.NightVision_ON(CameraPlay.NightVision_Preset.Night_Vision_Dark,1);";
                if (NightVisionFX == 4) TextName.text = "CameraPlay.NightVision_ON(CameraPlay.NightVision_Preset.Night_Vision_Sharp,1);";
                if (NightVisionFX == 5) TextName.text = "CameraPlay.NightVision_ON(CameraPlay.NightVision_Preset.Night_Vision_BlueSky,1);";
                if (NightVisionFX == 6) TextName.text = "CameraPlay.NightVision_ON(CameraPlay.NightVision_Preset.Night_Vision_Low_Light,1);";
                if (NightVisionFX == 7) TextName.text = "CameraPlay.NightVision_ON(CameraPlay.NightVision_Preset.Night_Vision_Pinky,1);";
                if (NightVisionFX == 8) TextName.text = "CameraPlay.NightVision_ON(CameraPlay.NightVision_Preset.Night_Vision_RedBurn,1);";
                if (NightVisionFX == 9) TextName.text = "CameraPlay.NightVision_ON(CameraPlay.NightVision_Preset.Night_Vision_PurpleShadow,1);";
            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                CameraPlay.NightVision_OFF(0.5f);
                TextName.text = "CameraPlay.NightVision_OFF(0.5f);";
            }
        }
        //////////////////////////////////////////// 2 = Earth Quake
        if (CurrentFX == 2)
        {
            TextNameFX.text = "Earth Quake / Shake";
            TextDescription.text = "Add a Earth Quake / Shake effect to the camera\n and remove it automatically after the animation is finished.";
            if (Input.GetMouseButtonDown(0))
            {
                CameraPlay.EarthQuakeShake(2,30, 2);
                TextName.text = "CameraPlay.EarthQuakeShake(2,30,2);";
            }
        }

        //////////////////////////////////////////// 3 = Drunks
        if (CurrentFX == 3)
        {
            TextNameFX.text = "Drunk";
            TextDescription.text = "Add a Drunk FX to the current camera,\n Turn On or Off, change animation time and more.";
            TurnONOFF.SetActive(true);
            NightTurnONOFF.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Alpha0)) DrunkFX = 0;
            if (Input.GetKeyDown(KeyCode.Alpha1)) DrunkFX = 1;
            if (Input.GetKeyDown(KeyCode.Alpha2)) DrunkFX = 2;
            if (Input.GetKeyDown(KeyCode.Alpha3)) DrunkFX = 3;
            if (Input.GetKeyDown(KeyCode.Alpha4)) DrunkFX = 4;
            if (Input.GetKeyDown(KeyCode.Alpha5)) DrunkFX = 5;
            if (Input.GetKeyDown(KeyCode.Alpha6)) DrunkFX = 6;
            if (Input.GetKeyDown(KeyCode.Alpha7)) DrunkFX = 7;
            if (Input.GetKeyDown(KeyCode.Alpha8)) DrunkFX = 8;
            if (Input.GetKeyDown(KeyCode.Alpha9)) DrunkFX = 9;

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (DrunkFX == 0) CameraPlay.Drunk_ON(CameraPlay.Drunk_Preset.Default, 1);
                if (DrunkFX == 1) CameraPlay.Drunk_ON(CameraPlay.Drunk_Preset.Drunk_A_Lot, 1);
                if (DrunkFX == 2) CameraPlay.Drunk_ON(CameraPlay.Drunk_Preset.Drunk_Vodka, 1);
                if (DrunkFX == 3) CameraPlay.Drunk_ON(CameraPlay.Drunk_Preset.Drunk_Poison, 1);
                if (DrunkFX == 4) CameraPlay.Drunk_ON(CameraPlay.Drunk_Preset.Drunk_Yellow, 1);
                if (DrunkFX == 5) CameraPlay.Drunk_ON(CameraPlay.Drunk_Preset.Drunk_Dark, 1);
                if (DrunkFX == 6) CameraPlay.Drunk_ON(CameraPlay.Drunk_Preset.Drunk_Cold, 1);
                if (DrunkFX == 7) CameraPlay.Drunk_ON(CameraPlay.Drunk_Preset.Drunk_Burn, 1);
                if (DrunkFX == 8) CameraPlay.Drunk_ON(CameraPlay.Drunk_Preset.Drunk_Blood, 1);
                if (DrunkFX == 9) CameraPlay.Drunk_ON(CameraPlay.Drunk_Preset.Drunk_To_Much, 1);

                if (DrunkFX == 0) TextName.text = "CameraPlay.Drunk_ON(CameraPlay.Drunk_Preset.Default,1);";
                if (DrunkFX == 1) TextName.text = "CameraPlay.Drunk_ON(CameraPlay.Drunk_Preset.Drunk_A_Lot,1);";
                if (DrunkFX == 2) TextName.text = "CameraPlay.Drunk_ON(CameraPlay.Drunk_Preset.Drunk_Vodka,1);";
                if (DrunkFX == 3) TextName.text = "CameraPlay.Drunk_ON(CameraPlay.Drunk_Preset.Drunk_Poison,1);";
                if (DrunkFX == 4) TextName.text = "CameraPlay.Drunk_ON(CameraPlay.Drunk_Preset.Drunk_Yellow,1);";
                if (DrunkFX == 5) TextName.text = "CameraPlay.Drunk_ON(CameraPlay.Drunk_Preset.Drunk_Dark,1);";
                if (DrunkFX == 6) TextName.text = "CameraPlay.Drunk_ON(CameraPlay.Drunk_Preset.Drunk_Cold,1);";
                if (DrunkFX == 7) TextName.text = "CameraPlay.Drunk_ON(CameraPlay.Drunk_Preset.Drunk_Burn,1);";
                if (DrunkFX == 8) TextName.text = "CameraPlay.Drunk_ON(CameraPlay.Drunk_Preset.Drunk_Blood,1);";
                if (DrunkFX == 9) TextName.text = "CameraPlay.Drunk_ON(CameraPlay.Drunk_Preset.Drunk_To_Much,1);";

            }

            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                CameraPlay.Drunk_OFF(0.5f);
                TextName.text = "CameraPlay.Drunk_OFF(0.5f);";
            }
        }

        //////////////////////////////////////////// 4 = Blur
        if (CurrentFX == 4)
        {
            TextNameFX.text = "Blur";
            TextDescription.text = "Add a Blur to the current camera,\n and remove it automatically after the animation is finished.";
            if (Input.GetMouseButtonDown(0))
            {
                CameraPlay.Blur(5f);
                TextName.text = "CameraPlay.Blur(5f); // 5 Seconds";
            }
        }
        //////////////////////////////////////////// 5 = Noise
        if (CurrentFX == 5)
        {
            TextNameFX.text = "Noise";

            TextDescription.text = "Add a Noise to the current camera,\n and remove it automatically after the animation is finished.";
            if (Input.GetMouseButtonDown(0))
            {
                CameraPlay.Noise(3f);
                TextName.text = "CameraPlay.Noise(3f); // 3 Seconds";
            }
        }
        //////////////////////////////////////////// 6 = Radial
        if (CurrentFX == 6)
        {
            TextNameFX.text = "Radial";

            TextDescription.text = "Add a Radial to the current camera,\n and remove it automatically after the animation is finished.";
            if (Input.GetMouseButtonDown(0))
            {
                TextName.text = "CameraPlay.Radial(4f); // 4 Seconds";
                float mx = Input.mousePosition.x / Screen.width;
                float my = Input.mousePosition.y / Screen.height;
                CameraPlay.Radial(mx, my, 2f, 0.25f);
                TextName.text = "CameraPlay.Radial(" + mx.ToString("F2") + "f," + (1 - my).ToString("F2") + "f,2f,0.25f);";
            }
        }
        //////////////////////////////////////////// 7 = Manga Flash
        if (CurrentFX == 7)
        {
            TextNameFX.text = "Manga Flash";

            TextDescription.text = "Add a Manga Flash to the current camera,\n and remove it automatically after the animation is finished.";
            if (Input.GetMouseButtonDown(0))
            {
                TextName.text = "CameraPlay.MangaFlash(4f); // 4 Seconds";
                float mx = Input.mousePosition.x / Screen.width;
                float my = Input.mousePosition.y / Screen.height;
                CameraPlay.MangaFlash(mx, my, 2f, 5, new Color(1, 1, 1, 1));
                TextName.text = "CameraPlay.MangaFlash(" + mx.ToString("F2") + "f," + (1 - my).ToString("F2") + "f,2f,0.25f);";
            }
        }

        //////////////////////////////////////////// 8 = Sniper Scope
        if (CurrentFX == 8)
        {
            TextNameFX.text = "Sniper Scope";
            TextDescription.text = "Add a Sniper Scope to the current camera,\n Turn On or Off, change animation time and more.";
            TurnONOFF.SetActive(true);

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                CameraPlay.SniperScope_ON();
                TextName.text = "CameraPlay.SniperScope_ON();";
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                CameraPlay.SniperScope_OFF();
                TextName.text = "CameraPlay.SniperScope_OFF();";
            }
        }
        //////////////////////////////////////////// 9 = Black & White
        if (CurrentFX == 9)
        {
            TextNameFX.text = "Black & White";
            TextDescription.text = "Turn Black & White to the current camera,\n Turn On or Off, change animation time and more.";
            TurnONOFF.SetActive(true);

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                CameraPlay.BlackWhite_ON();
                TextName.text = "CameraPlay.BlackWhite_ON();";
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                CameraPlay.BlackWhite_OFF();
                TextName.text = "CameraPlay.BlackWhite_OFF();";
            }
        }
        //////////////////////////////////////////// 10 = Pitch
        if (CurrentFX == 10)
        {
            TextNameFX.text = "Pitch";

            TextDescription.text = "Add a Pitch effect to the current camera,\n and remove it automatically after the animation is finished.";
            if (Input.GetMouseButtonDown(0))
            {
                float mx = Input.mousePosition.x / Screen.width;
                float my = Input.mousePosition.y / Screen.height;
                CameraPlay.Pitch(mx, my, 4f, 1.5f);
                TextName.text = "CameraPlay.Pitch(" + mx.ToString("F2") + "f," + (1 - my).ToString("F2") + "f,4f, 1.5f);";

            }
        }
        //////////////////////////////////////////// 11 = Fly Vision
        if (CurrentFX == 11)
        {
            TextNameFX.text = "Fly Vision";
            TextDescription.text = "Turn Fly Vision to the current camera,\n Turn Fly Vision to On or Off";
            TurnONOFF.SetActive(true);

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                CameraPlay.FlyVision_ON();
                TextName.text = "CameraPlay.FlyVision_ON();";
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                CameraPlay.FlyVision_OFF();
                TextName.text = "CameraPlay.FlyVision_OFF();";
            }
        }
        //////////////////////////////////////////// 12 = Fish Eye
        if (CurrentFX == 12)
        {
            TextNameFX.text = "Fish Eye";

            TextDescription.text = "Add a Fish Eye effect to the current camera,\n and remove it automatically after the animation is finished.";
            if (Input.GetMouseButtonDown(0))
            {
                float mx = Input.mousePosition.x / Screen.width;
                float my = Input.mousePosition.y / Screen.height;
                CameraPlay.FishEye(mx, my, 4f, 0.5f);
                TextName.text = "CameraPlay.FishEye(" + mx.ToString("F2") + "f," + (1 - my).ToString("F2") + "f,4f, 0.5f);";

            }
        }
        //////////////////////////////////////////// 13 = Glitch
        if (CurrentFX == 13)
        {
            TextNameFX.text = "Glitch";
            TextDescription.text = "Add a Glitch to the current camera,\n and remove it automatically after the animation is finished.";
            if (Input.GetMouseButtonDown(0))
            {
                CameraPlay.Glitch(1f);
                TextName.text = "CameraPlay.Glitch(1f); // 1 Second";
            }
        }
        //////////////////////////////////////////// 14 = Glitch 2
        if (CurrentFX == 14)
        {
            TextNameFX.text = "Glitch 2";
            TextDescription.text = "Add a Glitch2 FX to the current camera,\n and remove it automatically after the animation is finished.";
            if (Input.GetMouseButtonDown(0))
            {
                CameraPlay.Glitch2(2f);
                TextName.text = "CameraPlay.Glitch2(2f); // 2 Second";
            }
        }
        //////////////////////////////////////////// 15 = Fade
        if (CurrentFX == 15)
        {
            TextNameFX.text = "Fade";
            TextDescription.text = "Turn Fade to the current camera,\n Turn On or Off, change animation time and more.";
            TurnONOFF.SetActive(true);

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                CameraPlay.Fade_ON(Color.black, 1);
                TextName.text = "CameraPlay.Fade_ON(Color.black,1);";
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                CameraPlay.Fade_OFF();
                TextName.text = "CameraPlay.Fade_OFF();";
            }
        }
        //////////////////////////////////////////// 16 = Pixel
        if (CurrentFX == 16)
        {
            TextNameFX.text = "Pixel";
            TextDescription.text = "Turn Pixel to the current camera,\n Turn On or Off, change animation time and more.";
            TurnONOFF.SetActive(true);

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                CameraPlay.Pixel_ON(12, 1);
                TextName.text = "CameraPlay.Pixel_ON(12,1);";
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                CameraPlay.Pixel_OFF();
                TextName.text = "CameraPlay.Pixel_OFF();";
            }
        }
        //////////////////////////////////////////// 17 = Colored
        if (CurrentFX == 17)
        {
            TextNameFX.text = "Colored";
            TextDescription.text = "Turn Colored to the current camera,\n Turn On or Off, change animation time and more.";
            TurnONOFF.SetActive(true);

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                CameraPlay.Colored_ON(Color.magenta, 1);
                TextName.text = "CameraPlay.Colored_ON(Color.magenta,1);";
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                CameraPlay.Colored_OFF();
                TextName.text = "CameraPlay.Colored_OFF();";
            }
        }
        //////////////////////////////////////////// 18 = Thermavision
        if (CurrentFX == 18)
        {
            TextNameFX.text = "Thermavision";
            TextDescription.text = "Turn Thermavision to the current camera,\n Turn On or Off, change animation time and more.";
            TurnONOFF.SetActive(true);

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                CameraPlay.Thermavision_ON();
                TextName.text = "CameraPlay.Thermavision_ON();";
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                CameraPlay.Thermavision_OFF();
                TextName.text = "CameraPlay.Thermavision_OFF();";
            }
        }
        //////////////////////////////////////////// 19 = Infrared
        if (CurrentFX == 19)
        {
            TextNameFX.text = "Infrared";
            TextDescription.text = "Turn Infrared to the current camera,\n Turn On or Off, change animation time and more.";
            TurnONOFF.SetActive(true);

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                CameraPlay.Infrared_ON();
                TextName.text = "CameraPlay.Infrared_ON();";
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                CameraPlay.Infrared_OFF();
                TextName.text = "CameraPlay.Infrared_OFF();";
            }
        }
        //////////////////////////////////////////// 20 = WidescreenH
        if (CurrentFX == 20)
        {
            TextNameFX.text = "Wide Screen Horizontal";
            TextDescription.text = "Turn Wide Screen to the current camera,\n Turn On or Off, change animation time and more.";
            TurnONOFF.SetActive(true);

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                CameraPlay.WidescreenH_ON(Color.black, 1);
                TextName.text = "CameraPlay.WidescreenH_ON(Color.black,1);";
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                CameraPlay.WidescreenH_OFF();
                TextName.text = "CameraPlay.WidescreenH_OFF();";
            }
        }
        //////////////////////////////////////////// 21 = HIT
        if (CurrentFX == 21)
        {
            TextNameFX.text = "Hit";
            TextDescription.text = "Add a Hit to the current camera,\n and remove it automatically after the animation is finished.";
            if (Input.GetMouseButtonDown(0))
            {
                CameraPlay.Hit(Color.red, 0.5f);
                TextName.text = "CameraPlay.Hit(Color.red, 0.5f); // 0.5 Second";
            }
        }
        //////////////////////////////////////////// 22 = Chromatical
        if (CurrentFX == 22)
        {
            TextNameFX.text = "Chromatical";
            TextDescription.text = "Add a Chromatical to the current camera,\n and remove it automatically after the animation is finished.";
            if (Input.GetMouseButtonDown(0))
            {
                CameraPlay.Chromatical(1f);
                TextName.text = "CameraPlay.Chromatical(1f); // 1 Second";
            }
        }
        //////////////////////////////////////////// 23 = Flash Light
        if (CurrentFX == 23)
        {
            TextNameFX.text = "FlashLight";
            TextDescription.text = "Add a FlashLight to the current camera,\n and remove it automatically after the animation is finished.";
            if (Input.GetMouseButtonDown(0))
            {
                CameraPlay.FlashLight(Color.white, 0.5f);
                TextName.text = "CameraPlay.FlashLight(Color.white,0.5f); // 0.5 Second";
            }
        }
        //////////////////////////////////////////// 24 = Zoom
        if (CurrentFX == 24)
        {
            TextNameFX.text = "Zoom";

            TextDescription.text = "Add a Zoom effect to the current camera,\n and remove it automatically after the animation is finished.";
            if (Input.GetMouseButtonDown(0))
            {
                float mx = Input.mousePosition.x / Screen.width;
                float my = Input.mousePosition.y / Screen.height;
                CameraPlay.Zoom(mx, my, 2f, 0.5f);
                TextName.text = "CameraPlay.Zoom(" + mx.ToString("F2") + "f," + (1 - my).ToString("F2") + "f,2f, 0.5f);";

            }
        }
        //////////////////////////////////////////// 25 = Glitch 3
        if (CurrentFX == 25)
        {
            TextNameFX.text = "Glitch 3";
            TextDescription.text = "Add a Glitch3 FX to the current camera,\n and remove it automatically after the animation is finished.";
            if (Input.GetMouseButtonDown(0))
            {
                CameraPlay.Glitch3(2f);
                TextName.text = "CameraPlay.Glitch3(2f); // 2 Second";
            }
        }
        //////////////////////////////////////////// 26 = Bullet Hole
        if (CurrentFX == 26)
        {
            TextNameFX.text = "Bullet Hole";

            TextDescription.text = "Add a Bullet Hole effect to the current camera,\n and remove it automatically after the animation is finished.";
            if (Input.GetMouseButtonDown(0))
            {
                float mx = Input.mousePosition.x / Screen.width;
                float my = Input.mousePosition.y / Screen.height;
                CameraPlay.BulletHole(mx, my, 2f, 0.5f);
                TextName.text = "CameraPlay.BulletHole(" + mx.ToString("F2") + "f," + (1 - my).ToString("F2") + "f,2f, 0.5f);";

            }
        }
        //////////////////////////////////////////// 27 = Blood Hit
        if (CurrentFX == 27)
        {
            TextNameFX.text = "Blood Hit";

            TextDescription.text = "Add a Blood Hit effect to the current camera,\n and remove it automatically after the animation is finished.";
            if (Input.GetMouseButtonDown(0))
            {
                CameraPlay.BloodHit(2f, 0.5f);
                TextName.text = "CameraPlay.BloodHit(2f, 0.5f);";

            }
        }
        //////////////////////////////////////////// 28 = Rain Drop
        if (CurrentFX == 28)
        {
            TextNameFX.text = "Rain Drop";
            TextDescription.text = "Turn Rain Drop to the current camera,\n Turn Fly Vision to On or Off";
            TurnONOFF.SetActive(true);

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                CameraPlay.RainDrop_ON(2);
                TextName.text = "CameraPlay.RainDrop_ON();";
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                CameraPlay.RainDrop_OFF();
                TextName.text = "CameraPlay.RainDrop_OFF();";
            }
        }
        //////////////////////////////////////////// 29 = ShockWave
        if (CurrentFX == 29)
        {
            TextNameFX.text = "Shock Wave";

            TextDescription.text = "Add a Shock Wave to the current camera,\n and remove it automatically after the animation is finished.";
            if (Input.GetMouseButtonDown(0))
            {
                float mx = Input.mousePosition.x / Screen.width;
                float my = Input.mousePosition.y / Screen.height;
                CameraPlay.Shockwave(mx, my, 1.5f, 2f);
                TextName.text = "CameraPlay.Shockwave(" + mx.ToString("F2") + "f," + (1 - my).ToString("F2") + "f,1.5f,2f);";
            }
        }
        //////////////////////////////////////////// 30 = Fade In Out
        if (CurrentFX == 30)
        {
            TextNameFX.text = "Fade In Out";

            TextDescription.text = "Add a Fade In Out to the current camera,\n and remove it automatically after the animation is finished.";
            if (Input.GetMouseButtonDown(0))
            {
                CameraPlay.FadeInOut(Color.blue, 3f);
                TextName.text = " CameraPlay.FadeInOut(Color.blue, 3f); // 3 Seconds with color blue";
            }
        }
        //////////////////////////////////////////// 31 = Inverse Color
        if (CurrentFX == 31)
        {
            TextNameFX.text = "Inverse Color";
            TextDescription.text = "Turn Inverse Color to the current camera,\n Turn Inverse to On or Off";
            TurnONOFF.SetActive(true);

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                CameraPlay.Inverse_ON(2);
                TextName.text = "CameraPlay.Inverse_ON(2); // 2 secondes";
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                CameraPlay.Inverse_OFF();
                TextName.text = " CameraPlay.Inverse_OFF();";
            }
        }
        //////////////////////////////////////////// 32 = Pinch
        if (CurrentFX == 32)
        {
            TextNameFX.text = "Pinch";

            TextDescription.text = "Add a Pinch to the current camera,\n and remove it automatically after the animation is finished.";
            if (Input.GetMouseButtonDown(0))
            {
                float mx = Input.mousePosition.x / Screen.width;
                float my = Input.mousePosition.y / Screen.height;
                CameraPlay.Pinch(mx, my, 1f, 1.5f);
                TextName.text = "CameraPlay.Pinch(" + mx.ToString("F2") + "f," + (1 - my).ToString("F2") + "f,1f,1.5f);";
            }
        }

        //////////////////////////////////////////// 33 = X Ray
        if (CurrentFX == 33)
        {
            TextNameFX.text = "X Ray light";

            TextDescription.text = "Add a X Ray light to the current camera,\n and remove it automatically after the animation is finished.";
            if (Input.GetMouseButtonDown(0))
            {
                float mx = Input.mousePosition.x / Screen.width;
                float my = Input.mousePosition.y / Screen.height;
                CameraPlay.XRay(mx, my, 2f, 5, new Color(1, 1, 0, 1), 16);
                TextName.text = "CameraPlay.XRay(" + mx.ToString("F2") + "f," + (1 - my).ToString("F2") + ", 2f, 5, new Color(1, 1, 0, 1), 16);";
            }
        }
    }
}
