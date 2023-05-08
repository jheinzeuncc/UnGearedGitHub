using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    [Header ("UI Elements")]
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject playerUI;
    [SerializeField] private GameObject upgradesUI;
    [SerializeField] private GameObject playerController;

    [Header ("Upgrades")]
    [SerializeField] private GameObject attackDamageText;
    [SerializeField] private GameObject attackSpeedText;
    [SerializeField] private GameObject healthText;
    [SerializeField] private GameObject currentGearText;

    
    private bool bought;
    private int attackCost;
    private int attackSpeedCost;
    private int healthCost;
    // Start is called before the first frame update
    void Start()
    {
         pauseMenuUI.SetActive(false);
         playerUI.SetActive(true);
         upgradesUI.SetActive(false);
         attackCost = 1;
         attackSpeedCost =1;
         healthCost =1;
         
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            }else{
                Pause();
            }
        }
        
    }

    #region PauseMenu
    public void Pause(){
        print("paused");
        pauseMenuUI.SetActive(true);
        playerUI.SetActive(false);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        GameIsPaused = true;
    }
    public void Resume(){
        print("unpaused");
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        playerUI.SetActive(true);
        upgradesUI.SetActive(false);
        Time.timeScale = 1f;
        
        GameIsPaused = false;
    }

    public void Upgrades(){
         pauseMenuUI.SetActive(false);
         updateGears();
          upgradesUI.SetActive(true);

    }

    public void Quit(){
        print("Quit");
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;

    }
    #endregion

    #region upgrades
    public void upgradeAttack(){
        bought = playerController.GetComponent<FPSController>().buyUpgrade(attackCost);
        if(bought == true){
             playerController.GetComponent<FPSController>().increaseAttack();
            attackCost = attackCost +1;
            updateGears();
            print("I have money");
            
        }
        else{
            print("I iz broke");
        }
    }

   public void upgradeAttackSpeed(){
        bought = playerController.GetComponent<FPSController>().buyUpgrade(attackSpeedCost);
        if(bought == true){
             playerController.GetComponent<playerShooting>().increaseAttackSpeed();
            attackSpeedCost = attackSpeedCost +1;
            updateGears();
            print("I have money");
            
        }
        else{
            print("I iz broke");
        }
    }

   public void upgradeHealth(){
        bought = playerController.GetComponent<FPSController>().buyUpgrade(healthCost);
        if(bought == true){
             playerController.GetComponent<FPSController>().increaseHealth();
            healthCost = healthCost +1;
            updateGears();
            print("I have money");
            
        }
        else{
            print("I iz broke");
        }
    }


    public void updateGears(){
        currentGearText.GetComponent<TextMeshProUGUI>().text = playerController.GetComponent<FPSController>().gears.ToString();
        attackDamageText.GetComponent<TextMeshProUGUI>().text = attackCost.ToString();
        attackSpeedText.GetComponent<TextMeshProUGUI>().text = attackSpeedCost.ToString();
        healthText.GetComponent<TextMeshProUGUI>().text = healthCost.ToString();
    }
    

    #endregion
}
