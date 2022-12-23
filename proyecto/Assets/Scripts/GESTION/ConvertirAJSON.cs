using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class ConvertirAJSON : MonoBehaviour
{
    public TMP_InputField idIF;
    public TMP_InputField motIF;
    public TMP_InputField comIF;
    public Text usuarios;

    public TMP_InputField IIDIF;
    public TMP_InputField motivIF;
    public TMP_InputField desIF;
    public Text bans;

    public GameObject Admins;
    public GameObject Bans;

    public void guardar(){

       Baneo ban = new Baneo();
       ban.ID = idIF.text;
       ban.motivo = motIF.text;
       ban.comentario = comIF.text;

        string json = JsonUtility.ToJson(ban, true);
        File.WriteAllText(Application.dataPath + "/Admin"+BetweenScenesControler.admins+ ".txt", json);
        BetweenScenesControler.admins++;
        Bans.SetActive(true);
        Admins.SetActive(false);
   }

   public void cargar(){
        for(int i=0; i < BetweenScenesControler.admins; i++)
        {
            string json = File.ReadAllText(Application.dataPath + "/Admin"+i+ ".txt");
            Baneo ban = JsonUtility.FromJson<Baneo>(json);

            usuarios.text += "ID: "+ban.ID + " User: "+ban.motivo+"\n";
        }
       
       

   }
    public void guardarBan()
    {

        Baneo ban = new Baneo();
        ban.ID = IIDIF.text;
        ban.motivo = motivIF.text;
        ban.comentario = desIF.text;

        string json = JsonUtility.ToJson(ban, true);
        File.WriteAllText(Application.dataPath + "/Baneo" + BetweenScenesControler.bans + ".txt", json);
        BetweenScenesControler.bans++;
    }

    public void cargarBans()
    {
        for (int i = 0; i < BetweenScenesControler.bans; i++)
        {
            string json = File.ReadAllText(Application.dataPath + "/Baneo" + i + ".txt");
            Baneo ban = JsonUtility.FromJson<Baneo>(json);

            bans.text += "ID: " + ban.ID + "\n Motivo: " + ban.motivo + "\n Comentario: " + ban.comentario+"\n";
        }

    }
    public void volver()
    {
        Bans.SetActive(false);
        Admins.SetActive(true);
    }
}
