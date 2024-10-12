using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text jugador1Text;
    [SerializeField] private TMP_Text jugador2Text;

    [SerializeField] private Transform jugador1Transform;
    [SerializeField] private Transform jugador2Transform;
    [SerializeField] private Transform bolaTransform;

    private int jugador1Puntuacion;
    private int jugador2Puntuacion;

    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    public void jugador1Puntua()
    {
        jugador1Puntuacion++;
        jugador1Text.text = jugador1Puntuacion.ToString();

    
        if (jugador1Puntuacion == 10)
        {
         
            SceneManager.LoadScene("GameOver");
        }
    }

    public void jugador2Puntua()
    {
        jugador2Puntuacion++;
        jugador2Text.text = jugador2Puntuacion.ToString();

      
        if (jugador2Puntuacion == 10)
        {
            
            SceneManager.LoadScene("GameOver");
        }
    }

    public void Restart()
    {
        jugador1Transform.position = new Vector2(jugador1Transform.position.x, 0);
        jugador2Transform.position = new Vector2(jugador2Transform.position.x, 0);
        bolaTransform.position = new Vector2(0, 0);
    }
}
