using UnityEngine;
using UnityEngine.Events;

public class PaintSelector : MonoBehaviour
{
    public PaintScript paint;

    public MeshRenderer targetRenderer;

    public Color color;

    public float brushSize;

    public void Setup(Color color)
    {
        this.color = color;
        targetRenderer.material.color = color;
    }

    public void Select()
    {
        paint.SetBrush(color, brushSize);
        
        this.GetComponent<Animator>().SetInteger("sel", 1);
    }

    public void Deselect()
    {
        this.GetComponent<Animator>().SetInteger("sel", 0);
    }
}
