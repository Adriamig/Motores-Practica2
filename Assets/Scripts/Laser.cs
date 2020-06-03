using UnityEngine;

public class Laser : MonoBehaviour
{
    // GameObject que se instancia posteriormente.
    public GameObject firePref;

    // Sitio donde instanciar el GameObject posteriormente.
    public Transform spawnLaser;

    // Sprite de la nave mejorada.
    public Sprite naveFire;

    // Sprite original de la nave.
    private Sprite miNave;

    // Se activa el activar el script.
    void OnEnable()
    {
        // Guardamos el sprite de la nave.
        miNave = gameObject.GetComponent<SpriteRenderer>().sprite;

        // Ponemos el sprite de la nave  mejorada.
        gameObject.GetComponent<SpriteRenderer>().sprite = naveFire;
    }

    void Update()
    {
        // En el caso de darle al spacebar y estar jugando,
        if (Input.GetKeyDown(KeyCode.Space) && GameManager.instance.GetJugando()) 
        {
             // instancia un Fire en el lugar del spawn.
             Instantiate<GameObject>(firePref, spawnLaser);
        }
    }

    // Se activa al desactivar el script.
    private void OnDisable()
    {
        // Ponemos la nave original guardada anteriormente.
        gameObject.GetComponent<SpriteRenderer>().sprite = miNave;
    }
}
