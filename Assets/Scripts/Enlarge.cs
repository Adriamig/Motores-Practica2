using UnityEngine;

public class Enlarge : MonoBehaviour
{
    private Vector3 miNave, naveLarga, hijosSin;
    private float scale = 1.25f;

    private void OnEnable()
    {
        miNave = naveLarga = transform.localScale;        // Damos el valor actual de la nave a los dos vectores
        naveLarga.x *= scale;                             // Alargamos el valor de la x del vector
        hijosSin.x = miNave.x / scale;                    // Acortamos el valor de la x del vector
        transform.localScale = naveLarga;                 // Actualizamos el valor de la nave para que se alargue
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).localScale = hijosSin;  // Al haber alargado la nave los hijos tambien,
                                                          // con lo que reducimos su tamaño
    } // Al activarse el script

    private void OnDisable()
    {
        transform.localScale = miNave;                    // Devolvemos el valor original de la nave
        for (int i = 0; i < transform.childCount; i++)    //  y de los hijos
            transform.GetChild(i).localScale = miNave;
    } // Al desactivarse el script
   
}
