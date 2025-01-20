using UnityEngine;
using UnityEngine.UI;
//Habilita los comandos del canvas 

public class SliderVolumen : MonoBehaviour
{
    public Slider slider;
    public float sliderValue;
    public Image imagenMute;

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", 0.5f);
        //Para que se quede guardado el cambio del volumen al deseado por el jugador
        AudioListener.volume = slider.value;
        //El volumen del juego es el del slider
        RevisarSiEstoyMute();

    }

    public void ChangeSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
        RevisarSiEstoyMute();

    }

    public void RevisarSiEstoyMute()
    //Para que el icono cambie al estar silenciado el volumen o no
    {
        if (sliderValue==0)
        {
            imagenMute.enabled = true;

        }
        else
        {
            imagenMute.enabled = false;
        }
    }
}
