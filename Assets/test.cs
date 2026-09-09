using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField seed;
    public TMP_InputField arboles;
    public TMP_InputField rwIteraciones;

    public UnityEngine.UI.Button cargar;

    public TMP_Dropdown contexto;


    public void Generar()
    {
        int arbo = int.Parse(arboles.text);
        int seed1 = int.Parse(seed.text);
        int itera = int.Parse(rwIteraciones.text);

        int context = contexto.value;
        PlayerPrefs.SetInt("context",context);

        PlayerPrefs.SetInt("arboles", arbo);
        PlayerPrefs.SetInt("seed", seed1);
        PlayerPrefs.SetInt("rwi", itera);

        

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Start()
    {
        cargar.onClick.AddListener(Generar);
        
        int seed = PlayerPrefs.GetInt("seed",12345);
        int arboles = PlayerPrefs.GetInt("arboles", 30);
        int iteracionesRW = PlayerPrefs.GetInt("rwi", 100);

        TerrainGenerator tr = FindFirstObjectByType<TerrainGenerator>();
        Debug.Log("Cargando");
        tr.GenerateTerrain();
        tr.gentree();
        tr.setseed(seed);

        LSystemTreeGenerator treegen = FindFirstObjectByType<LSystemTreeGenerator>();
        treegen.createForest(arboles);

        randomWalk rw = FindFirstObjectByType<randomWalk>();
        

        //normal
        if (PlayerPrefs.GetInt("context",0)==0)
        {
            rw.dungeonSize = 3;
        }
        else
        {
            rw.dungeonSize = 15;
        }
        rw.gen(iteracionesRW, seed);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
