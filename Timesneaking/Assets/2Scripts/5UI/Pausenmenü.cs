using UnityEngine;

public class Pausenmenü : MonoBehaviour
{
    /*
     * Ultimate Game UI -> Asset evlt. ansehen
     */

    #region Variables
    [SerializeField] GameObject pausenmenue;
    [SerializeField] KeyCode pauseKey = KeyCode.Escape;

    private bool isPausiert = false;
    public static Pausenmenü instance;
    #endregion

    #region Unity Methods

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        pausenmenue.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(pauseKey))
        {
            if(isPausiert)
            {
                fortsetzen();
            }
            else
            {
                pausieren();
            }
        }
    }
	
	#endregion

    public void pausieren()
    {
        pausenmenue.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        isPausiert = true;
    }

    public void fortsetzen()
    {
        pausenmenue.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        isPausiert = false;
    }

    public void zurueckZumHauptmenue()
    {
        Time.timeScale = 1f;
        //SceneController.Load(SceneController.Scene.Hauptmenue);
    }

    public void spielBeenden()
    {
        Application.Quit();
    }

    public void optionen()
    {

    }

    public bool getIsPausiert()
    {
        return isPausiert;
    }
}
