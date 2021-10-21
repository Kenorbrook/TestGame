using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diff : MonoBehaviour
{
    public Image[] DiffButt;
    private void Start()
    {
        if (Difficult.diffNow == Difficult.diff.Easy)
            diffBut(0);
        else if (Difficult.diffNow == Difficult.diff.Normal)
            diffBut(1);
        else
            diffBut(2);
    }
    public void diffBut(int i)
    {
        for (int j = 0; j < DiffButt.Length; j++)
        {
            if (i != j)
            {
                DiffButt[j].color = new Color(DiffButt[j].color.r, DiffButt[j].color.g, DiffButt[j].color.b, 1f);
            }
            else
            {
                DiffButt[j].color = new Color(DiffButt[j].color.r, DiffButt[j].color.g, DiffButt[j].color.b, 0.5f);
            }
        }
        switch (i)
        {
            case 0:
                Difficult.diffNow = Difficult.diff.Easy;
                break;
            case 1:
                Difficult.diffNow = Difficult.diff.Normal;
                break;
            case 2:
                Difficult.diffNow = Difficult.diff.Hard;
                break;
            default:
                break;
        }
    }
}
