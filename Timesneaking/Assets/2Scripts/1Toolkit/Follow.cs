using UnityEngine;

public class Follow : MonoBehaviour
{
	#region Variables
	public Transform followT;
    public bool rotateT = false;
    #endregion

    #region Regular Methods

    #endregion

    #region Unity Methods
    private void Start()
    {
        if(followT == null)
        {
            //followT = Inventory.instance.gameObject.transform;
            enabled = false;
        }
    }

    private void LateUpdate()
    {
        Vector3 newPosition = followT.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;

        if(rotateT) 
        {
            transform.rotation = Quaternion.Euler(90f, followT.eulerAngles.y, 0f);
        }
    }

    #endregion
}
