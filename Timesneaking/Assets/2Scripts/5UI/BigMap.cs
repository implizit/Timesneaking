using UnityEngine;

public class BigMap : MonoBehaviour
{
    #region Variables
    [SerializeField] GameObject bigmapcam;
    [SerializeField] GameObject bigmapUI;
    [SerializeField] KeyCode bigMapKey = KeyCode.M;

    private bool isAktiv = false;
    #endregion

    #region Unity Methods

    private void Awake()
    {
        setBigMapActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(bigMapKey))
        {
            setBigMapActive(!isAktiv);
        }
    }
	
	#endregion
	
	#region Regular Methods
	void setBigMapActive(bool active)
    {
        isAktiv = active;
        bigmapcam.GetComponent<Camera>().enabled = isAktiv;
        bigmapUI.SetActive(isAktiv);

    }
	#endregion
	
}
