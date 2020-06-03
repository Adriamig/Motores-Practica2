using UnityEngine;

public class Enlarge : MonoBehaviour
{
    private Vector3 miNave, naveLarga, hijosSin;
    private float scale = 25f;

    // Al activarse el script.
    private void OnEnable()
    {
        // Damos el valor actual de la nave a los dos vectores.
        miNave = naveLarga = hijosSin = transform.localScale;

        // Alargamos el valor de la x del vector.
        naveLarga.x = miNave.x + (naveLarga.x * scale) / 100f;

        // Acortamos el valor de la x del vector.
        hijosSin.x = miNave.x - (naveLarga.x * scale) / 100f;

        // Actualizamos el valor de la nave para que se alargue.
        transform.localScale = naveLarga;

        // Al haber alargado la nave, alargamos los hijos
        // también, con lo que reducimos su tamaño.
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).localScale = hijosSin;
    }
    // Al desactivarse el script.
    private void OnDisable()
    {
        // Devolvemos el valor original de la nave y de los hijos.
        transform.localScale = miNave;                    
        for (int i = 0; i < transform.childCount; i++)    
            transform.GetChild(i).localScale = miNave;
    } 
   
}
