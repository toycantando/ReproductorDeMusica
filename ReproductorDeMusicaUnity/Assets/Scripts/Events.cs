using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Events : MonoBehaviour {

    //Hexa Azul Iconos: 007AFF (0,122,255,255)
    //Hexa Blanco Iconos: 8E8E93
    //Hexa Rojo Favorito: F2365C
    //Hexa Gris Favorito: B4B8BF

    private GameObject reproductorAnimate, btnHome, btnMiMusica, btnAlbumes, btnMasApps;
    private GameObject vtnHome, vtnMiMusica, vtnAlbumes, vtnAlbum, vtnReproductor, vtnBan;
    public List<GameObject> menus = new List<GameObject>();
    public List<GameObject> ventanas = new List<GameObject>();

    private void Awake()
    {
        btnHome = GameObject.Find("btnInicio");
        btnMiMusica = GameObject.Find("btnMiMusica");
        btnAlbumes = GameObject.Find("btnAlbumes");
        btnMasApps = GameObject.Find("btnMasApps");
        menus.Add(btnHome);
        menus.Add(btnMiMusica);
        menus.Add(btnAlbumes);
        menus.Add(btnMasApps);

        vtnHome = GameObject.Find("vtnHome");
        vtnMiMusica = GameObject.Find("vtnMiMusica");
        vtnAlbumes = GameObject.Find("vtnAlbumes");
        vtnAlbum = GameObject.Find("vtnAlbum");
        vtnReproductor = GameObject.Find("vtnReproductor");
        vtnBan = GameObject.Find("vtnBan");
        ventanas.Add(vtnHome);
        ventanas.Add(vtnMiMusica);
        ventanas.Add(vtnAlbumes);
        ventanas.Add(vtnAlbum);
        ventanas.Add(vtnReproductor);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void AnimacionReproductor()
    {
        if(reproductorAnimate.GetComponent<Animator>().enabled == false)
        {
            reproductorAnimate.GetComponent<Animator>().enabled = true;
        }
        else
        {
            
        }
        
    }

    public void ChangeBtn(GameObject seleccion)
    {
        for (int i = 0; i < menus.Count; i++)
        {
            menus[i].GetComponent<Image>().color = new Color32(142, 142, 147, 255);
            menus[i].transform.GetChild(0).GetComponent<Text>().color = new Color32(142, 142, 147, 255);
        }
        seleccion.GetComponent<Image>().color = new Color32(0, 122, 255, 255);
        seleccion.transform.GetChild(0).GetComponent<Text>().color = new Color32(0, 122, 255, 255);
    }

    public void ChangeVentana(GameObject seleccion)
    {
        for (int i = 0; i < ventanas.Count; i++)
        {
            ventanas[i].transform.GetChild(0).gameObject.SetActive(false);
        }
        seleccion.transform.GetChild(0).gameObject.SetActive(true);
    }

}
