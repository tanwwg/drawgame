using System.Collections.Generic;
using UnityEngine;

public class SetupColors : MonoBehaviour
{
    public PaintSelector prefab;
    public Transform prefabParent;

    public Vector3 xVec;
    public Vector3 yVec;

    public Color[] colors;

    public List<PaintSelector> fabs;

    

    public void Start()
    {
        for (var i = 0; i < colors.Length; i++)
        {
            var fab = Instantiate(prefab, prefabParent);
            fab.gameObject.SetActive(true);

            var x = i % 2;
            var y = i / 2;
            fab.transform.localPosition = xVec * x + yVec * y;
            fab.Setup(colors[i]);
            
            fabs.Add(fab);
        }
        fabs[1].Select();
    }

    public void Deselect()
    {
        foreach (var f in fabs) f.Deselect();
    }

    public void SetScale(Vector3 v)
    {
        this.transform.localScale = v;
    }
}
