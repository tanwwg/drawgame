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
        paint.brushMat.color = color;
        paint.brushMat.SetFloat("_Radius", brushSize);
        
        this.GetComponent<Animator>().SetInteger("sel", 1);
    }

    public void Deselect()
    {
        this.GetComponent<Animator>().SetInteger("sel", 0);
    }
}
