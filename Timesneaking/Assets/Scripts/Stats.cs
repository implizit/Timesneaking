using UnityEngine;

public class Stats : MonoBehaviour
{
	#region Variables
	public HealthBar healthBar;
	public int maxHealth = 1000;

	private float health;
	#endregion

	#region Unity Methods

	void Start()
    {
		setMaxHealth(maxHealth);
	}

    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Y))
		{
			changeHealth(-150);
		}
		if (Input.GetKeyDown(KeyCode.X))
		{
			changeHealth(150);
		}
	}

	private void setMaxHealth(int mh)
    {
		maxHealth = mh;
		setHealth(maxHealth);
		healthBar.setMaxHealth(maxHealth);
	}

	public void changeHealth(int amount)
	{
		health += amount;
		onHealthChanged();
	}

	private void setHealth(int value)
    {
		health = value;
		onHealthChanged();
    }

	private void onHealthChanged()
    {
		if(health <= 0)
        {
			health = 0;
			onDie();
        }
		if(health > maxHealth)
        {
			health = maxHealth;
        }
		healthBar.setHealth(health);
	}

	private void onDie()
    {
		Debug.Log("You Died");
		setHealth(maxHealth);
    }

	#endregion
	
	#region Regular Methods
		
	#endregion
	
}
