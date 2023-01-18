using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager: MonoBehaviour
{
    public GameObject menuPrincipal;
    public GameObject MenuGameOver;
    //Lista de Objetos Letra (Alfabeto)
    public GameObject letraA;
    public GameObject letraB;
    public GameObject letraC;
    public GameObject letraD;
    public GameObject letraE;
    public GameObject letraF;
    public GameObject letraG;
    public GameObject letraH;
    public GameObject letraI;
    public GameObject letraJ;
    public GameObject letraK;
    public GameObject letraL;
    public GameObject letraM;
    public GameObject letraN;
    public GameObject letraO;
    public GameObject letraP;
    public GameObject letraQ;
    public GameObject letraR;
    public GameObject letraS;
    public GameObject letraT;
    public GameObject letraU;
    public GameObject letraV;
    public GameObject letraW;
    public GameObject letraX;
    public GameObject letraY;
    public GameObject letraZ;
    //Declarar start en Falso
    public bool start = false;
    public float velocidad = 2;
    public GameObject col;
    public GameObject obstaculo1;
    public Renderer fondo;
    public bool gameOver = false;
    public List<GameObject> cols;
    public List<GameObject> obstaculo;
    public List<GameObject> letras;
    // Start is called before the first frame update
    void Start()
    {
        //Crear mapa con 2 1columnas del suelo
        for(int i=0;i<30;i++)
        {
            cols.Add(Instantiate(col, new Vector2(-10 + i, -3), Quaternion.identity));
        }
        obstaculo.Add(Instantiate(obstaculo1, new Vector2(14, -2), Quaternion.identity));
        //Agregar todas las letras
        letras.Add(Instantiate(letraA, new Vector2(10, 1), Quaternion.identity));
        letras.Add(Instantiate(letraB, new Vector2(20, 1), Quaternion.identity));
        letras.Add(Instantiate(letraC, new Vector2(24, 1), Quaternion.identity));
        letras.Add(Instantiate(letraD, new Vector2(30, 1), Quaternion.identity));
        letras.Add(Instantiate(letraE, new Vector2(36, 1), Quaternion.identity));
        letras.Add(Instantiate(letraF, new Vector2(42, 1), Quaternion.identity));
        letras.Add(Instantiate(letraG, new Vector2(50, 1), Quaternion.identity));
        letras.Add(Instantiate(letraH, new Vector2(54, 1), Quaternion.identity));
        letras.Add(Instantiate(letraI, new Vector2(58, 1), Quaternion.identity));
        letras.Add(Instantiate(letraJ, new Vector2(66, 1), Quaternion.identity));
        letras.Add(Instantiate(letraK, new Vector2(72, 1), Quaternion.identity));
        letras.Add(Instantiate(letraL, new Vector2(78, 1), Quaternion.identity));
        letras.Add(Instantiate(letraM, new Vector2(82, 1), Quaternion.identity));
        letras.Add(Instantiate(letraN, new Vector2(88, 1), Quaternion.identity));
        letras.Add(Instantiate(letraO, new Vector2(92, 1), Quaternion.identity));
        letras.Add(Instantiate(letraP, new Vector2(98, 1), Quaternion.identity));
        letras.Add(Instantiate(letraQ, new Vector2(102, 1), Quaternion.identity));
        letras.Add(Instantiate(letraR, new Vector2(108, 1), Quaternion.identity));
        letras.Add(Instantiate(letraS, new Vector2(112, 1), Quaternion.identity));
        letras.Add(Instantiate(letraT, new Vector2(120, 1), Quaternion.identity));
        letras.Add(Instantiate(letraU, new Vector2(124, 1), Quaternion.identity));
        letras.Add(Instantiate(letraV, new Vector2(130, 1), Quaternion.identity));
        letras.Add(Instantiate(letraW, new Vector2(136, 1), Quaternion.identity));
        letras.Add(Instantiate(letraX, new Vector2(142, 1), Quaternion.identity));
        letras.Add(Instantiate(letraY, new Vector2(150, 1), Quaternion.identity));
        letras.Add(Instantiate(letraZ, new Vector2(156, 1), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        if (start == false)
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                start = true;
            }
        }

        if (start == true && gameOver==true)
        {
            MenuGameOver.SetActive(true);
            if (Input.GetKeyDown(KeyCode.A))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }


        //Compara si el juego sea activo e inicia el movimiento de los mapas
        if (start==true && gameOver==false)
        {
            menuPrincipal.SetActive(false);
            //Rotación del Fondo, en este caso las Nubes y Cielo
            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f, 0) * Time.deltaTime;

            for (int i = 0; i < cols.Count; i++)
            {
                if (cols[i].transform.position.x <= -10)
                {
                    cols[i].transform.position = new Vector3(10, -3, 0);
                }
                cols[i].transform.position = cols[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }

            for (int i = 0; i < obstaculo.Count; i++)
            {
                if (obstaculo[i].transform.position.x <= -10)
                {
                    float randomObs = Random.Range(12, 14);
                    obstaculo[i].transform.position = new Vector3(randomObs, -2, 0);
                }
                obstaculo[i].transform.position = obstaculo[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }
            //Bucle y Movimiento de las letras
            for (int i = 0; i < letras.Count; i++)
            {
                if (letras[i].transform.position.x <= -80)
                {
                    letras[i].transform.position = new Vector3(10, 1, 0);
                }
                letras[i].transform.position = letras[i].transform.position + new Vector3(-1, 0, 0) * Time.deltaTime * velocidad;
            }
        }
    }
}
