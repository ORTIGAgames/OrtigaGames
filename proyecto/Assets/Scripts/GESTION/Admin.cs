using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class Admin : MonoBehaviour
{
    [System.Serializable]
    public class Baneo{
        public int id;
        public string motivo;
        public string comentario;
    }
    [System.Serializable]
    public class listaBaneos{
        public Baneo[] Baneos;
    }

    public listaBaneos baneos = new listaBaneos();
    
    public void sacarJSON(){

        string output = JsonUtility.ToJson(baneos);
        File.WriteAllText(Application.dataPath + "/baneos.txt", output);
    }
}
