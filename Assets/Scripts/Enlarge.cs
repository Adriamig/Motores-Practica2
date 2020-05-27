using UnityEngine;

public class Enlarge : MonoBehaviour
{
    private Vector3 miNave, naveLarga, hijosSin;
    private float scale = 1.25f;

    private void OnEnable()
    {
        miNave = naveLarga = transform.localScale;
        naveLarga.x *= scale;
        hijosSin.x = miNave.x / scale;
        transform.localScale = naveLarga;
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).localScale = hijosSin;
    }

    private void OnDisable()
    {
        transform.localScale = miNave;
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).localScale = miNave;
    }
   
}
