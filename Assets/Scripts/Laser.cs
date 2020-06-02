using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject firePref;   // GameObject que se instancia posteriormente
    public Transform spawnLaser;  // Sitio donde instanciar el GameObject posteriormente
    public Sprite naveFire;       // Sprite de la nave mejorada
    private Sprite miNave;        // Sprite original de la nave

    void OnEnable()
    {
        miNave = gameObject.GetComponent<SpriteRenderer>().sprite;    // Guaradamos el sprite de la nave
        gameObject.GetComponent<SpriteRenderer>().sprite = naveFire;  // Ponemos el sprite de la nave  mejorada
    } // Se activa el activar el script

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.instance.GetJugando()) // En el caso de darle al spacebar
        {                                                                         // y estar jugando
            Instantiate<GameObject>(firePref, spawnLaser); // Instancia un Fire en el lugar del spawn
        }
    }

    private void OnDisable()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = miNave; // Ponemos la nave original guardada anteriormente
    } // Se activa al desactivar el script
}
