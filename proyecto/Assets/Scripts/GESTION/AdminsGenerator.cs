using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class AdminsGenerator : MonoBehaviour
{
    public TMP_InputField idIF;
    public TMP_InputField userIF;
    public TMP_InputField contraIF;
    public Text usuarios;

    public void guardar()
    {

        Admin ad = new Admin();
        ad.ID = idIF.text;
        ad.usuario = userIF.text;
        ad.contraseña = contraIF.text;

        string json = JsonUtility.ToJson(ad, true);
        File.WriteAllText(Application.dataPath + "/Admins.txt", json);
    }

    public void cargar()
    {
        string json = File.ReadAllText(Application.dataPath + "/Admins.txt");
        Admin ad = JsonUtility.FromJson<Admins>(json);
        usuarios.text += ad.ID + ad.usuario;
    }
}
