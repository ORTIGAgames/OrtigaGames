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

   public void guardar(){

       Baneo ban = new Baneo();
       ban.ID = idIF.text;
       ban.motivo = motIF.text;
       ban.comentario = comIF.text;

        string json = JsonUtility.ToJson(ban, true);
        File.WriteAllText(Application.dataPath + "/Baneo.txt", json);
   }

   public void cargar(){
       string json = File.ReadAllText(Application.dataPath + "/Baneo.txt");
       Baneo ban = JsonUtility.FromJson<Baneo>(json);

       idIF.text = ban.ID;
       motIF.text = ban.motivo;
       comIF.text = ban.comentario;

   }
}
