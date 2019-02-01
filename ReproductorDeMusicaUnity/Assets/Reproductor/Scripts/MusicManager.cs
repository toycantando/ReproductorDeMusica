using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour {

    private int musicaActual = 0;
    private AudioSource audioSource;
    public AudioClip[] clipNombres;
    public Text musicaNombres;
    public Slider musicLength;
    private bool stop = false;
    private bool pause = true;
    private int fullLenghth, playTime, seconds, minutes;
    public Text tiempoClip;
    public Text btnPlay;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayMusic();    
    }

    private void Update()
    {
        if (stop)
        {
            musicLength.value += Time.deltaTime;
            if (musicLength.value >= audioSource.clip.length)
            {
                musicaActual++;
                musicLength.value = 0;
                if (musicaActual >= clipNombres.Length)
                {
                    musicaActual = 0;
                }
                    
                Play();
            }
        }
    }

    public void PlayMusic(int cambiarMusica = 0)
    {
        audioSource.Pause();
        musicaActual += cambiarMusica;
        if(musicaActual >= clipNombres.Length)
        {
            musicaActual = 0;
        }else if(musicaActual < 0)
        {
            musicaActual = clipNombres.Length - 1;
        }

        if(audioSource.isPlaying && cambiarMusica == 0)
        {
            return;
        }

        if (stop)
        {
            stop = false;
        }

        audioSource.clip = clipNombres[musicaActual];
        musicaNombres.text = audioSource.clip.name;
        musicLength.maxValue = audioSource.clip.length;
        //musicLength.value = 0;
        //audioSource.Play();
    }

    public void StopAudio()
    {
        audioSource.Stop();
        musicLength.value = 0;
        stop = true;
    }

    public void Play()
    {
        audioSource.Play();
        StartCoroutine("WaitForMusicEnd");
        stop = true;
    }

    IEnumerator WaitForMusicEnd()
    {
        while (audioSource.isPlaying)
        {
            playTime = (int)audioSource.time;
            ShowTiempoPlay();
            yield return null;
        }
    }

    void ShowTiempoPlay()
    {
        fullLenghth = (int)audioSource.clip.length;
        seconds = playTime % 60;
        minutes = (playTime / 60) % 60;
        tiempoClip.text = minutes + ":" + seconds.ToString("D2") + " / " + ((fullLenghth / 60) % 60) + ":" + (fullLenghth % 60).ToString("D2");
    }

    //public AudioClip[] listaClips;
    //public float valor;
    //private AudioSource fuenteClip;
    //public Slider musicLength;
    //private int index = 0;
    //public bool stop = false;
    //public bool pause = false;

    //public Text tituloClip;
    //public Text tiempoClip;
    //public Text btnPlay;

    //private int fullLenghth, playTime, seconds, minutes;



    // Use this for initialization
    //void Start () {
    //       fuenteClip = GetComponent<AudioSource>();
    //       fuenteClip.clip = listaClips[index];
    //       tituloClip.text = fuenteClip.clip.name;
    //}

    //   IEnumerator WaitForMusicEnd()
    //   {
    //       while (fuenteClip.isPlaying)
    //       {
    //           playTime = (int)fuenteClip.time;
    //           ShowTiempoPlay();
    //           yield return null;
    //       }
    //   }

    //   private void Update()
    //   {
    //       if (!pause)
    //       {
    //           musicLength.value += valor + Time.deltaTime;
    //       }
    //   }

    //   public void PlayMusic()
    //   {
    //       if (CheckNullSong()) return;

    //       if (!fuenteClip.isPlaying)
    //       {
    //           musicLength.maxValue = fuenteClip.clip.length;
    //           musicLength.value = 0;
    //           pause = false;
    //           ShowTiempoPlay();   
    //           fuenteClip.Play();
    //           btnPlay.text = "PAUSE";
    //           CancelInvoke("Next");
    //           Invoke("Next", fuenteClip.clip.length - fuenteClip.time + 1f);
    //       }
    //       else
    //       {
    //           pause = true;
    //           fuenteClip.Pause();
    //           btnPlay.text = "PLAY";
    //           CancelInvoke("Next");
    //       }
    //       StartCoroutine("WaitForMusicEnd");
    //   }

    //   public void Stop()
    //   {
    //       if (!fuenteClip.isPlaying)
    //       {
    //           fuenteClip.Stop();
    //           btnPlay.text = "PLAY";
    //           tiempoClip.text = "0:00 / 0:00";
    //           StartCoroutine("WaitForMusicEnd");
    //           CancelInvoke("Next");
    //       }
    //       else
    //       {
    //           fuenteClip.Stop();
    //           btnPlay.text = "PLAY";
    //           tiempoClip.text = "0:00 / 0:00";
    //           StartCoroutine("WaitForMusicEnd");
    //           CancelInvoke("Next");
    //       }   
    //   }

    //   public void Next()
    //   {
    //       //if (!fuenteClip.isPlaying)
    //       //{
    //       //    fuenteClip.clip = listaClips[++index % listaClips.Length];
    //       //    tituloClip.text = fuenteClip.clip.name;
    //       //    CancelInvoke("Next");
    //       //    Invoke("Next", fuenteClip.clip.length - fuenteClip.time + 1f);
    //       //}
    //       //else
    //       //{
    //           fuenteClip.clip = listaClips[++index % listaClips.Length];
    //           if (CheckNullSong()) return;
    //           fuenteClip.Play();
    //           tituloClip.text = fuenteClip.clip.name;
    //           CancelInvoke("Next");
    //           Invoke("Next", fuenteClip.clip.length - fuenteClip.time + 1f);
    //       //}
    //       StartCoroutine("WaitForMusicEnd");
    //   }

    //   public void Prev()
    //   {
    //       if (--index < 0) index = listaClips.Length - 1;
    //       //if (!fuenteClip.isPlaying)
    //       //{
    //       //    fuenteClip.clip = listaClips[index % listaClips.Length];
    //       //    tituloClip.text = fuenteClip.clip.name;
    //       //    CancelInvoke("Next");
    //       //}
    //       //else
    //       //{
    //           fuenteClip.clip = listaClips[index % listaClips.Length];
    //           if (CheckNullSong()) return;
    //           fuenteClip.Play();
    //           tituloClip.text = fuenteClip.clip.name;
    //           CancelInvoke("Next");
    //           Invoke("Next", fuenteClip.clip.length - fuenteClip.time + 1f);
    //       //}
    //       StartCoroutine("WaitForMusicEnd");
    //   }

    //   bool CheckNullSong()
    //   {
    //       if (fuenteClip.clip== null)
    //       {
    //           return true;
    //       }
    //       return false;
    //   }


    //   void ShowTiempoPlay()
    //   {
    //       fullLenghth = (int)fuenteClip.clip.length;
    //       seconds = playTime % 60;
    //       minutes = (playTime / 60) % 60;
    //       tiempoClip.text = minutes + ":" + seconds.ToString("D2") + " / " + ((fullLenghth / 60) % 60) + ":" + (fullLenghth % 60).ToString("D2");
    //   }












    //public void PlayMusic()
    //{
    //    btnPlay.text = "PAUSE";
    //    if (fuenteClip.isPlaying)
    //    {
    //        return;
    //    }

    //    trackCorriente--;
    //    if (trackCorriente < 0)
    //    {
    //        //musicLength.maxValue = fuenteClip.clip.length;
    //        //musicLength.value = 0;
    //        trackCorriente = listaClips.Length - 1;
    //    }
    //    StartCoroutine("WaitForMusicEnd");
    //}

    //IEnumerator WaitForMusicEnd()
    //{
    //    while (fuenteClip.isPlaying)
    //    {
    //        playTime = (int)fuenteClip.time;
    //        ShowTiempoPlay();
    //        yield return null;
    //    }
    //    NextTitle();
    //}

    //public void NextTitle()
    //{
    //    fuenteClip.Stop();
    //    trackCorriente++;
    //    if(trackCorriente > listaClips.Length - 1)
    //    {
    //        trackCorriente = 0;
    //    }
    //    fuenteClip.clip = listaClips[trackCorriente];
    //    fuenteClip.Play();

    //    ShowTituloCorriente();

    //    StartCoroutine("WaitForMusicEnd");
    //}

    //public void PreviowsTitle()
    //{
    //    fuenteClip.Stop();
    //    trackCorriente--;
    //    if (trackCorriente < 0)
    //    {
    //        trackCorriente = listaClips.Length - 1;
    //    }
    //    fuenteClip.clip = listaClips[trackCorriente];
    //    fuenteClip.Play();

    //    ShowTituloCorriente();

    //    StartCoroutine("WaitForMusicEnd");
    //}

    //public void StopMusic()
    //{
    //    StopCoroutine("WaitForMusicEnd");
    //    fuenteClip.Stop();
    //}

    //public void MuteMusic()
    //{
    //    fuenteClip.mute = !fuenteClip.mute;
    //}

    //void ShowTituloCorriente()
    //{
    //    tituloClip.text = fuenteClip.clip.name;
    //    fullLenghth = (int)fuenteClip.clip.length;
    //}

    //void ShowTiempoPlay()
    //{
    //    seconds = playTime % 60;
    //    minutes = (playTime / 60) % 60;
    //    tiempoClip.text = minutes + ":" + seconds.ToString("D2") +  "/" +  ((fullLenghth / 60) % 60) + ":" + (fullLenghth % 60).ToString("D2");
    //}

    //public void PauseMusic()
    //{
    //    if(btnPlay.text == "PAUSE")
    //    {
    //        fuenteClip.clip = listaClips[trackCorriente];
    //        fuenteClip.Pause();
    //        btnPlay.text = "PLAY";
    //    }

    //}
}
