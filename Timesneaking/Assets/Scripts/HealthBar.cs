using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	#region Variables
	public Slider slider;
	public Gradient gradient;
	public Image fill;
	#endregion
	
	#region Unity Methods
	#endregion
	
	#region Regular Methods
	public void setMaxHealth(float health)
    {
		slider.maxValue = health;
		setHealth(health);
    }

	public void setHealth(float health)
    {
		slider.value = health;
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
	#endregion
	
}
