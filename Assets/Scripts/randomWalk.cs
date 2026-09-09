using TMPro;
//using Unity.VectorGraphics;
using UnityEngine;
//using UnityEngine.Rendering.LookDev;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class randomWalk : MonoBehaviour
{
    // Start is called on1ce before the first execution of Update after the MonoBehaviour is created
    
    static int size = 40;
    int[,] map = new int[size, size];
    string m = " ";
    GameObject block;

    int Pc = 5;
    int Pr = 5;
    Vector2Int pos = new Vector2Int(size/2,size/2);
    int dir;
    //Vector2Int dir = new Vector2Int(1,0);
    //
    // 0-iz 1-de 2-ar 3-ab
    int random;
    int random2;

    Vector2Int roomSize = new Vector2Int(0,0);

    //public int iter = 5;

    public TMP_InputField sizemap;
    public TMP_InputField itr;
    //public Button button;

    string t;
    string t2;
    int s=size;
    [SerializeReference] private int iteration=30;

    public int dungeonSize = 1;
    void reload()
    {
        SceneManager.LoadScene("SampleScene");
        //Start();
        //t = sizemap.text;
        //t2 = itr.text;


        /*iteration = 5;
        s = 20;
        if (int.TryParse(t, out int result))
        {
            s = result;
        }
        if (int.TryParse(t2, out int result2))
        {
            iteration = result2;
        }
        map = new int[s, s];
        */
    }
    void Start()
    {
        //button.onClick.AddListener(reload);
        


        block = (GameObject)Resources.Load("Square");
        
    }
    public void gen(int itera,int seed)
    {
        Random.InitState(seed);
        dir = Random.Range(0, 4);
        randoW(s, itera);
    }
    void randoW(int sizem, int itera)
    {                
        int mappp=sizem;
        for (int i = 0; i < mappp; i++)
        {
            for (int j = 0; j < mappp; j++)
            {
                map[i, j] = 0;
                m += map[i, j];
                //Instantiate(block,new Vector3(i,j),Quaternion.identity);
            }
            //m += "\n";

        }
        //Debug.Log(m);
        map[pos.x, pos.y] = 1;
        int c = 0;
        while (c < itera)
        {
            Debug.Log("Iteración: " + c + " Posición: " + pos + " Dirección: " + dir);
            Debug.Log("Iteraciones totales: " + itera);
            //int olddir = dir;
            //dir = Random.Range(0, 4);
            /*while (dir==olddir)
            {
                dir = Random.Range(0, 4);
            }*/
            if (dir == 0)
            {
                if (pos.x > 0)
                    pos.x -= 1;
            }
            else if (dir == 1)
            {
                if (pos.x < mappp-1)
                    pos.x += 1;
            }
            if (dir == 2)
            {
                if (pos.y > 0)
                    pos.y -= 1;
            }
            else if (dir == 3)
            {
                if (pos.y < mappp-1)
                    pos.y += 1;
            }

            Debug.Log(pos);
            map[pos.x, pos.y] = 1;

            random = (int)Random.Range(0, 100);
            if (random < Pc)
            {
                int olddir = dir;
                dir = Random.Range(0, 4);
                while (dir==olddir)
                {
                    dir=Random.Range(0, 4);
                }
                Pc = 0;
            }
            else
            {
                Pc += 5;
            }
            random2 = (int)Random.Range(0, 100);
            //sala
            if (random2 < Pr)
            {
                roomSize = new Vector2Int(Random.Range(3, 8), Random.Range(3, 8));
                for (int i = 0; i < roomSize.x; i++)
                {
                    for (int j = 0; j < roomSize.y; j++)
                    {
                        if (pos.x+i>mappp-1|| pos.y + j > mappp-1)
                        {

                        }
                        else
                        {
                            map[pos.x + i, pos.y + j] = 1;
                        }
                            
                    }
                }
                Pr = 0;
            }
            else
            {
                Pr += 5;
            }
            c++;
        }

        //bloques
        for (int i = 0; i < mappp; i++)
        {
            for (int j = 0; j < mappp; j++)
            {
                //map[i, j] = 0;
                //m += map[i, j];
                if (map[i, j] == 0)
                {
                    //GameObject Ins = Instantiate(block, new Vector3(i, j), Quaternion.identity);
                    //Ins.GetComponent<SpriteRenderer>().color = Color.white;
                    //Ins.GetComponent<MeshRenderer>().material.color = Color.white;
                    //Ins.transform.SetParent(transform, false);
                }
                else
                {
                    
                    GameObject Ins = Instantiate(block, new Vector3(i, j), Quaternion.identity);
                    Ins.GetComponent<MeshRenderer>().material.color = Color.gray;
                    Ins.transform.SetParent(transform, false);
                    Ins.transform.localScale = new Vector3(1,1,dungeonSize);
                }

            }
            //m += "\n";

        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            reload();
        }
    }
}
