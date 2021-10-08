using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MuteControl : MonoBehaviour, IPointerClickHandler
{

    public Sprite MuteIcon, UnmuteIcon;
    public static bool musicIsMuted = false;

    void Awake()
    {
        this.transform.GetComponent<UnityEngine.UI.Image>().sprite = UnmuteIcon;

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)) { musicIsMuted = !musicIsMuted; }

        if (musicIsMuted) { this.transform.GetComponent<UnityEngine.UI.Image>().sprite = MuteIcon; }
        else this.transform.GetComponent<UnityEngine.UI.Image>().sprite = UnmuteIcon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.GetComponent<UnityEngine.UI.Image>().sprite == UnmuteIcon) { musicIsMuted = true; } else musicIsMuted = false;
    }

}
