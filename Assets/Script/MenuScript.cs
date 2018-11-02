using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void OnClickMulai()
    { Application.LoadLevel("Prolog"); }

    public void OnClickBantuan()
    { Application.LoadLevel("Bantuan"); }

    public void OnClickTentang()
    { Application.LoadLevel("Tentang"); }

    public void OnClickKembali()
    { Application.LoadLevel("MainMenu"); }

    public void OnClickLanjut()
    { Application.LoadLevel("Stage1"); }

    public void Keluar()
    { Application.Quit(); }
}