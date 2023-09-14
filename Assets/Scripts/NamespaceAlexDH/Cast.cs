using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Cast : MonoBehaviour
{
    public static bool LoockOther<T>(out T[] component, Vector3 pos, float radius, LayerMask layerMask)
    {
        Collider[] colliderHits = Physics.OverlapSphere(pos, radius, layerMask);

        List<T> ob = new List<T>();

        for (int i = 0; i < colliderHits.Length; i++)
        {
            if (colliderHits[i].transform.TryGetComponent(out T te))
            {
                ob.Add(te);
            }
        }
        if (ob.Count > 0)
        {
            component = ob.ToArray();
            return true;
        }
        else
        {
            component = null;
        }

        return false;
    }
}
