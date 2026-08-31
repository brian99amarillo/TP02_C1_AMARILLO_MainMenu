using UnityEngine;

public class Movement : MonoBehaviour
{


    [Header("Controles de Movimiento")]
    [SerializeField] private KeyCode moveUp = KeyCode.W;
    [SerializeField] private KeyCode moveRight = KeyCode.D;
    [SerializeField] private KeyCode moveDown = KeyCode.S;
    [SerializeField] private KeyCode moveLeft = KeyCode.A;
    [SerializeField] public float speed = 1f; // visible en el Inspector


    [Header("Controles de Rotación")]
    [SerializeField] private float zRotation = 10f; // visible en el Inspector


    [Header("Controles de Color")]
    [SerializeField] private KeyCode changeColorKey = KeyCode.R; // Tecla para cambiar el color
    private SpriteRenderer sr;


    void Start()
    {
        // Obtenemos el componente SpriteRenderer del mismo objeto
        sr = GetComponent<SpriteRenderer>();

        sr.color = Color.white;
    }


    void Update()
    //Movimiento
    {
        // Corre UNA vez por frame
        float step = speed * Time.deltaTime; // Calcula el paso de movimiento basado en la velocidad y el tiempo entre frames 

        if (Input.GetKey(moveUp)) // Si la tecla W está presionada
            transform.Translate(Vector3.up * step); // Mueve el objeto hacia adelante

        if (Input.GetKey(moveDown)) // Si la tecla S está presionada
            transform.Translate(Vector3.down * step); // Mueve el objeto hacia atrás

        if (Input.GetKey(moveRight)) // Si la tecla D está presionada
            transform.Translate(Vector3.right * step); // Mueve el objeto hacia derecha

        if (Input.GetKey(moveLeft)) // Si la tecla A está presionada
            transform.Translate(Vector3.left * step); // Mueve el objeto hacia izquierda

        // Cambio de color random
        float r = Random.value;
        float g = Random.value;
        float b = Random.value;
        if (Input.GetKeyUp(changeColorKey)) // Si la tecla R está presionada cambia de color
        {
            sr.color = new Color(r, g, b);
        }


        // Rotacion 

        if (Input.GetKeyDown(KeyCode.Q)) // Si la tecla Q está presionada el objeto rota a la izquierda 
            transform.eulerAngles += new Vector3(0f, 0f, zRotation);


        if (Input.GetKeyDown(KeyCode.E)) // Si la tecla E está presionada el objeto rota a la derecha
            transform.eulerAngles += new Vector3(0f, 0f, -zRotation);
    }
}