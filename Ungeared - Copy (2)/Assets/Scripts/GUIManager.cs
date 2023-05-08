using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GUIManager : MonoBehaviour
{
    public static GUIManager instance;
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI gears_txt;
    [SerializeField] private TextMeshProUGUI health_txt;
    public int damage;


    private void Awake(){
            if(instance == null){
                instance = this;
                DontDestroyOnLoad(gameObject);

            }else{
                Destroy(gameObject);
            }

    }
    // Start is called before the first frame update
    void Start()
    {
        gears_txt.text = "0";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


#region Health Bar
public void UpdateHealthBar(float healthPercentage){

    healthBar.fillAmount = healthPercentage;
}

public void UpdateHealth(int health){
    health_txt.text = health.ToString();
}
#endregion

#region gears
public void setGears(int num){
gears_txt.text = num.ToString();
}
#endregion
}