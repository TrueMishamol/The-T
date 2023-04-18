//Gide
    //Items resourses
    //Items usage
    //Items list
        //line 1
        //line 2
        //line 3

using UnityEngine;
using System.Collections;
using System;

public class Menu : MonoBehaviour {

    public GameObject Player;
    public GameObject Camera;
    public GameObject Spawn;
    public GUISkin GUIS;

    public bool Show = false;//
    public bool ShowEn = false;//
    public bool ShowDis = false;//

    public bool TMenu = false;//

    public bool TMultiplay = false;//

    public GameObject PlayerPrefab;
    public string ip = "0.0.0.0";//
    public string port = "00000";//
    public bool Connected;
    private GameObject TGo;
    private GameObject _go;

    public bool TInventory = false;//

    public string SText = "None";//
    public int UId;//
    public int SId;//
    public int LId;//
    public int RId;//
    public bool LUse = false;//
    public bool RUse = false;//
    public bool CUse = true;//
    public int IPage = 1;//

    //Items resourses

    public Texture2D TNone;
    public int NNone;
    public int IdNone = 0;//

    public Texture2D TLightCrystal;
    public int NLightCrystal;
    public int IdLightCrystal = 1;//
    public GameObject LightCrystal;

    public Texture2D TTestOne;
    public int NTestOne;
    public int IdTestOne = 2;//

    public Texture2D TTMatter;
    public int NTMatter;
    public int IdTMatter = 3;//

    public Texture2D TWatermelon;
    public int NWatermelon;
    public int IdWatermelon = 4;//

    public Texture2D TMarkerSetter;
    public int NMarkerSetter;
    public int IdMarkerSetter = 19;//
    public GameObject Point;

    public Texture2D TTeleporter;
    public int NTeleporter;
    public int IdTeleporter = 20;//

    void Update()
    {
        if (ShowEn)
        {
            Player.GetComponent<PlayerControlling>().enabled = false;
            Player.GetComponent<PlayerCrosshair>().enabled = false;
            Player.GetComponent<PlayerCameraRotation>().enabled = false;
            //Camera.GetComponent<PlayerCameraRotate>().enabled = false;
            Camera.GetComponent<Camera>().fieldOfView = 30;
            Show = true;
            ShowEn = false;
        }
        if (ShowDis)
        {
            Player.GetComponent<PlayerControlling>().enabled = true;
            Player.GetComponent<PlayerCrosshair>().enabled = true;
            Player.GetComponent<PlayerCameraRotation>().enabled = true;
            //Camera.GetComponent<PlayerCameraRotate>().enabled = true;
            Camera.GetComponent<Camera>().fieldOfView = 60;
            TMenu = false;
            TInventory = false;
            TMultiplay = false;
            SText = "None";
            SId = 0;
            Show = false;
            ShowDis = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Show)
            {
                ShowDis = true;
            } else {
                ShowEn = true;
                TMenu = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Show)
            {
                if (TInventory)
                {
                    ShowDis = true;
                }
            } else {
                ShowEn = true;
                TInventory = true;
            }
        }

        if (Show)
        {
            LUse = false;
            RUse = false;
       
        } else {

            if (Input.GetKey(KeyCode.Mouse0))
            {
                LUse = true;
            } else {
                LUse = false;
            }
            if (Input.GetKey(KeyCode.Mouse1))
            {
                RUse = true;
            } else {
                RUse = false;
            }
        }

        if (RUse)
        {
            UId = RId;
        } else {
            if (LUse)
            {
                UId = LId;
            } else {
                UId = 0;
                CUse = true;
            }
        }

        //Item usage

        if (UId == 1)
        {
            if (NLightCrystal > 0)
            {
                if (CUse)
                {
                    NLightCrystal = NLightCrystal - 1;
                    Instantiate(LightCrystal);
                    CUse = false;
                }
            }
        }

        if (UId == 2)
        {
            if (NTestOne > 0)
            {
                if (CUse)
                {
                    NTestOne = NTestOne - 1;
                    NLightCrystal = NLightCrystal + 3;
                    CUse = false;
                }
            }
        }

        if (UId == 4)
        {
            if (NWatermelon > 0)
            {
                if (CUse)
                {
                    NWatermelon = NWatermelon - 1;
                    CUse = false;
                }
            }
        }

        if (UId == 19)
        {
            if (NMarkerSetter > 0)
            {
                if (CUse)
                {
                    NMarkerSetter = NMarkerSetter - 1;
                    Point.transform.position = Player.transform.position;
                    CUse = false;
                }
            }
        }

        if (UId == 20)
        {
            if (NTeleporter > 0)
            {
                if (CUse)
                {
                    Player.transform.position = Point.transform.position;
                    CUse = false;
                }
            }
        }
    }

    void OnGUI()
    {
        GUI.skin = GUIS;
        if (TMenu)
        {
            GUI.Label(new Rect((Screen.width - 200) / 2, (Screen.height - 500) / 2, 200, 20), "Main menu");
            GUI.Label(new Rect((Screen.width - 300), (Screen.height - 30), 200, 20), "The T, V. 0.0.3 !ALPHA!");

            if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 210) / 2, 200, 30), "Play"))
            {
                ShowDis = true;
            }
            if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 120) / 2, 200, 30), "On spawn"))
            {
                Player.transform.position = Spawn.transform.position;
                ShowDis = true;
            }
            if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 30) / 2, 200, 30), "!Creators"))
            {

            }
            if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 60) / 2, 200, 30), "!Settings"))
            {

            }
            if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 150) / 2, 200, 30), "!Multiplay"))
            {
                TMenu = false;
                TMultiplay = true;
            }
            if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 290) / 2, 200, 30), "Exit"))
            {

                if (Connected)
                {
                    //! Obsolete
                    //Network.Disconnect(200);
                }
                else
                {
                    Application.Quit();
                }
            }
        }

        if (TInventory)
        {
            GUI.Label(new Rect((Screen.width - 200) / 2, (Screen.height - 500) / 2, 200, 20), "Inventory");

            if (GUI.Button(new Rect((Screen.width - 0) / 2, (Screen.height + 400) / 2, 200, 30), "Play"))
            {
                ShowDis = true;
            }

            if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height + 400) / 2, 100, 30), "In right hand."))
            {
                RId = SId;
            }

            if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height + 400) / 2, 100, 30), "In left hand."))
            {
                LId = SId;
            }

            GUI.Label(new Rect((Screen.width - 300) / 2, (Screen.height + 410) / 2, 200, 20), "Select:" + SText);

            if (GUI.Button(new Rect((Screen.width + 410) / 2, (Screen.height - 470) / 2, 40, 30), "<"))
            {
                if (IPage > 1)
                {
                    IPage = IPage - 1;
                } else {
                    IPage = 6;
                }
            }

            if (GUI.Button(new Rect((Screen.width + 510) / 2, (Screen.height - 470) / 2, 40, 30), ">"))
            {
                if (IPage < 6)
                {
                    IPage = IPage + 1;
                } else {
                    IPage = 1;
                }
            }

            //Item list

            if (IPage == 1)
            {
                //line 1

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                //line 2

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                //line 3

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 20; SText = "Teleporter"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 200) / 2, 50, 50), TTeleporter);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 150) / 2, 70, 20), "" + NTeleporter);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                //line 4

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                //line 5

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                //line 6

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                //line 7

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);
            }

            if (IPage == 2)
            {
                //line 1

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 4; SText = "Watermelon"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 400) / 2, 50, 50), TWatermelon);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 350) / 2, 70, 20), "" + NWatermelon);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                //line 2

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                //line 3

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                //line 4

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                //line 5

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                //line 6

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                //line 7

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);
            }

            if (IPage == 3)
            {
                //line 1

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 1; SText = "Light crystal"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 400) / 2, 50, 50), TLightCrystal);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 350) / 2, 70, 20), "" + NLightCrystal);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 3; SText = "TMatter"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 400) / 2, 50, 50), TTMatter);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 350) / 2, 70, 20), "" + NTMatter);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                //line 2

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                //line 3

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                //line 4

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                //line 5

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                //line 6

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                //line 7

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);
            }

            if (IPage == 4)
            {
                //line 1

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                //line 2

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                //line 3

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                //line 4

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                //line 5

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                //line 6

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                //line 7

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);
            }

            if (IPage == 5)
            {
                //line 1

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 2; SText = "Test one"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 400) / 2, 50, 50), TTestOne);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 350) / 2, 70, 20), "" + NTestOne);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                //line 2

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                //line 3

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                //line 4

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                //line 5

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                //line 6

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                //line 7

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);
            }

            if (IPage == 6)
            {
                //line 1

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 19; SText = "Marker Setter"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 400) / 2, 50, 50), TMarkerSetter);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 350) / 2, 70, 20), "" + NMarkerSetter);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 400) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 400) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 350) / 2, 70, 20), "" + NNone);

                //line 2

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 300) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 300) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 250) / 2, 70, 20), "" + NNone);

                //line 3

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 150) / 2, 70, 20), "" + NNone);

                //line 4

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height - 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height - 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height - 50) / 2, 70, 20), "" + NNone);

                //line 5

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height + 0) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height + 0) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height + 50) / 2, 70, 20), "" + NNone);

                //line 6

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height + 100) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height + 100) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height + 150) / 2, 70, 20), "" + NNone);

                //line 7

                if (GUI.Button(new Rect((Screen.width - 500) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 500) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 440) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 400) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 400) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 340) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 300) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 300) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 240) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 200) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 140) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width - 100) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width - 100) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width - 40) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 0) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 0) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 60) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 100) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 100) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 160) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 200) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 200) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 260) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 300) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 300) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 360) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 400) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 400) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 460) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);

                if (GUI.Button(new Rect((Screen.width + 500) / 2, (Screen.height + 200) / 2, 50, 50), ""))
                { SId = 0; SText = "None"; }
                GUI.DrawTexture(new Rect((Screen.width + 500) / 2, (Screen.height + 200) / 2, 50, 50), TNone);
                GUI.Label(new Rect((Screen.width + 560) / 2, (Screen.height + 250) / 2, 70, 20), "" + NNone);
            }
        }

        if (TMultiplay)
        {
            GUI.Label(new Rect((Screen.width - 200) / 2, (Screen.height - 500) / 2, 200, 20), "Server menu");
            GUI.Label(new Rect((Screen.width - 100) / 2, Screen.height / 2 - 60, 100, 20), "IP");
            GUI.Label(new Rect((Screen.width - 100) / 2, Screen.height / 2 - 30, 100, 20), "Port");
            ip = GUI.TextField(new Rect((Screen.width - 100) / 2 + 35, Screen.height / 2 - 60, 100, 20), ip);
            port = GUI.TextField(new Rect((Screen.width - 100) / 2 + 35, Screen.height / 2 - 30, 50, 20), port);

            if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 150) / 2, 200, 30), "Join"))
            if (GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height + 60) / 2, 200, 30), "Create"))
            {
            }

        }

    }

}

