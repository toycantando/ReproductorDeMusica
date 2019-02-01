using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour {

    public AudioClip[] lista;
    public AudioSource audiosource;
    public int cancionActual;
    public Text cancionNombre, cambioNombreMini;
    private bool stop = false;
    private int fullLenghth, playTime, seconds, minutes;
    public Text tiempoClip;
    public Slider musicLength;
    private float tiempo;
    [SerializeField]
    private bool rdmActive, favoritos, playlist;

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        Cambio();
    }

    private void Update()
    {
        //tiempo = Time.deltaTime;
        if (stop)
        {
            musicLength.value += Time.deltaTime;
            if (musicLength.value >= audiosource.clip.length)
            {
                cancionActual++;
                musicLength.value = 0;
                if (cancionActual >= lista.Length)
                {
                    cancionActual = 0;
                }
                Debug.Log("Play");
                Cambio();
            }
        }
    }

    public void Cambio(int cambiarCancion = 0)
    {
        //musicLength.value = 0;
        //stop = true;
        //audiosource.Pause();
        if (audiosource.isPlaying)
        {
            cancionActual += cambiarCancion;
            if (cancionActual >= lista.Length)
            {
                cancionActual = 0;
            }
            else if (cancionActual < 0)
            {
                cancionActual = lista.Length - 1;
            }

            if (audiosource.isPlaying && cambiarCancion == 0)
            {
                return;
            }

            //if (stop)
            //{
            //    stop = false;
            //}

            //audiosource.clip = lista[cancionActual];
            cancionNombre.text = audiosource.clip.name;
            cambioNombreMini.text = audiosource.clip.name;
            musicLength.maxValue = audiosource.clip.length;
            //musicLength.value = tiempo;
            audiosource.Play();
        }
        else
        {
            cancionActual += cambiarCancion;
            if (cancionActual >= lista.Length)
            {
                cancionActual = 0;
            }
            else if (cancionActual < 0)
            {
                cancionActual = lista.Length - 1;
            }

            if (audiosource.isPlaying && cambiarCancion == 0)
            {
                return;
            }

            if (stop)
            {
                stop = false;
            }

            audiosource.clip = lista[cancionActual];
            cancionNombre.text = audiosource.clip.name;
            cambioNombreMini.text = audiosource.clip.name;
            musicLength.maxValue = audiosource.clip.length;
        }
        
    }

    public void PlayMusic()
    {
        if (audiosource.isPlaying)
        {
            PauseMusic();
            stop = false;
        }
        else if (!audiosource.isPlaying)
        {
            audiosource.Play();
            StartCoroutine("WaitForMusicEnd");
            stop = true;
        }

        //Invoke("Cambio", audiosource.clip.length);
    }

    public void PauseMusic()
    {
        audiosource.Pause();
    }

    IEnumerator WaitForMusicEnd()
    {
        while (audiosource.isPlaying)
        {
            playTime = (int)audiosource.time;
            ShowTiempoPlay();
            yield return null;
        }
    }

    void ShowTiempoPlay()
    {
        fullLenghth = (int)audiosource.clip.length;
        seconds = playTime % 60;
        minutes = (playTime / 60) % 60;
        tiempoClip.text = minutes + ":" + seconds.ToString("D2") + " / " + ((fullLenghth / 60) % 60) + ":" + (fullLenghth % 60).ToString("D2");
    }
}
