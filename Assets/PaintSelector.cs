using UnityEngine;
using UnityEngine.Events;

public class PaintSelector : MonoBehaviour
{
    public PaintScript paint;

    public void Select()
    {
        var color = this.GetComponent<MeshRenderer>().material.color;
        paint.brushMat.color = color;
        
        this.transform.localScale = Vector3.one;
        
        this.GetComponent<Animator>().SetInteger("sel", 1);
    }

    public void Deselect()
    {
        this.GetComponent<Animator>().SetInteger("sel", 0);
    }
}
