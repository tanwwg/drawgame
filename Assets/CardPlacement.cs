using TMPro;
using UnityEngine;

public class CardPlacement : MonoBehaviour
{
    public TMP_Text text;
    public MeshRenderer meshRenderer;
    public AudioSource audioSource;

    public void Setup(CardData data)
    {
        this.text.text = data.title;
        this.meshRenderer.material.mainTexture = data.texture;
        this.audioSource.clip = data.sound;
    }
}
