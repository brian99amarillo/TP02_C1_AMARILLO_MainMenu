using System.Security.Principal;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Main_Menu : MonoBehaviour
{

    [Header("Main Menu Buttons")]
    [SerializeField] private Button btnPlay;         // Boton de play para cambiar la escena al juego
    [SerializeField] private Button btnSettings;    // Boton de opciones para abrir el panel de opciones desde el menu principal
    [SerializeField] private Button btnBackSettings; // Back desde settings del menu principal
    [SerializeField] private Button btnBackCreditts; // Back desde creditts del menu de pausa
    [SerializeField] private Button btnCreditts;    // Boton de creditos para abrir el panel de creditos desde el menu principal
    [SerializeField] private Button btnExit;        // Boton de salir del juego desde el menu principal

    [Header("Main Menu Pause")]
    [SerializeField] private Button btnContinue;   // Boton de continuar el juego desde el menu de pausa
    [SerializeField] private Button btnSettingsPause; // Boton de opciones desde el menu de pausa
    [SerializeField] private Button btnCredittsPause; // Boton de creditos desde el menu de pausa
    [SerializeField] private Button btnExitPause;     // Boton de salir del juego desde el menu de pausa

    [Header("Panels & Scenes")]
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject MenuPause;
    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private GameObject CredittsPanel;
    [SerializeField] private GameObject SceneGame;

    [Header("Player 1 Settings")]
    [SerializeField] private Slider Spedd_player1;
    [SerializeField] private TMP_Text textSpedd_player1;
    [SerializeField] private Movement Player1;

    [Header("Player 2 Settings")]
    [SerializeField] private Slider Spedd_player2;
    [SerializeField] private TMP_Text textSpedd_player2;
    [SerializeField] private Movement Player2;
    private bool isPause = false;

    private void Awake()  // Inicializacion de los botones y sliders
    {
        // Botones del menu principal
        btnPlay.onClick.AddListener(OnPLayButtonClicked);
        btnSettings.onClick.AddListener(OnSettingsButtonClicked);
        btnCreditts.onClick.AddListener(OnCredittsButtonClicked);
        btnExit.onClick.AddListener(OnExitButtonClicked);
        // Botones de volver
        btnBackSettings.onClick.AddListener(OnBackButtonSettingsClicked);
        btnBackCreditts.onClick.AddListener(OnBackButtonCredittsClicked); // Back de los creditos
        //Valores de speed de los player
        Spedd_player1.onValueChanged.AddListener(OnSpeedPlayer1);
        Spedd_player2.onValueChanged.AddListener(OnSpeedPlayer2);

        // Botones del menu pausa
         btnContinue.onClick.AddListener(OnContinueButtonClicked);
         btnSettingsPause.onClick.AddListener(OnSettingsPauseButtonClicked);
         btnCredittsPause.onClick.AddListener(OnCredittsPauseButtonClicked);
         btnExitPause.onClick.AddListener(OnExitPauseButtonClicked);
    }

    private void Update()       
    {
        if ((Input.GetKeyDown(KeyCode.Escape)) || Input.GetKeyDown(KeyCode.P))  // Pausa el juego al presionar la tecla Escape o P, y abre el menu de pausa
        {
            isPause = !isPause;
            MainMenu.SetActive(false);
            MenuPause.SetActive(isPause);
            Debug.Log("Pause button clicked!");
            if (isPause) 
            {
                Time.timeScale = 0; 
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }

    private void OnDestroy() // Remueve los listeners inicializados en el Awake 
    {
        // Botones del menu principal
         btnPlay.onClick.RemoveListener(OnPLayButtonClicked);
         btnSettings.onClick.RemoveListener(OnSettingsButtonClicked);
         btnCreditts.onClick.RemoveListener(OnCredittsButtonClicked);
         btnExit.onClick.RemoveListener(OnExitButtonClicked);
        // Botones de volver
        btnBackSettings.onClick.RemoveListener(OnBackButtonSettingsClicked);
        btnBackCreditts.onClick.RemoveListener(OnBackButtonCredittsClicked);
        // btnPlay.onClick.RemoveAllListeners();
         Spedd_player1.onValueChanged.RemoveListener(OnSpeedPlayer1);
         Spedd_player2.onValueChanged.RemoveListener(OnSpeedPlayer2);

        // Botones de pausa
        btnContinue.onClick.RemoveListener(OnContinueButtonClicked);
        btnSettingsPause.onClick.RemoveListener(OnSettingsPauseButtonClicked);
        btnCredittsPause.onClick.RemoveListener(OnCredittsPauseButtonClicked);
        btnExitPause.onClick.RemoveListener(OnExitPauseButtonClicked);
    }
     //Botones del Menu Principal
    private void OnPLayButtonClicked()  // Boton de play para cambiar la escena al juego
    {
        Debug.Log("Play button clicked!");
        MainMenu.SetActive(false);
        SceneGame.SetActive(true);
    }
    private void OnSettingsButtonClicked() // Abre el panel de opciones desde el menu principal
    {
        Debug.Log("Settings button clicked!");
        MainMenu.SetActive(false);
        SettingsPanel.SetActive(true);
    }
    private void OnCredittsButtonClicked() // Abre el panel de los creditos desde el menu principal
    {
        Debug.Log("Creditos button clicked!");
        MainMenu.SetActive(false);
        CredittsPanel.SetActive(true);
    }
    private void OnExitButtonClicked() // Metodo para salir del juego
    {
        Debug.Log("Exit button clicked!");
        Application.Quit();
#if UNITY_EDITOR
        // Dentro del editor: detiene el Play
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    // Botones de vuelta al menu de pausa o menu principal desde los paneles de opciones y creditos
    private void OnBackButtonSettingsClicked()  // Vuelve al menu principal o de pausa desde el panel de opciones
    {
        Debug.Log("Back button clicked!");
        if (isPause)
        {
            MenuPause.SetActive(true);
            SettingsPanel.SetActive(false);
        }
        else
        {
            MainMenu.SetActive(true);
            SettingsPanel.SetActive(false);
        }
    }
    private void OnBackButtonCredittsClicked()  // Vuelve al menu principal o de pausa desde el panel de los creditos
    {
        if (isPause)
        {
            MenuPause.SetActive(true);
            CredittsPanel.SetActive(false);
        }
        else
        {
            MainMenu.SetActive(true);
            CredittsPanel.SetActive(false);
        }
    }


    // Botones del menu de Pause
    private void OnContinueButtonClicked()  // Vuelve al juego desde el menu de pausa
    {
        Debug.Log("Contibue button clicked!");
        MenuPause.SetActive(false);
        SceneGame.SetActive(true);
        Time.timeScale = 1; // Asegura que el juego se reanude
    }
    private void OnSettingsPauseButtonClicked()    // Abre el panel de opciones desde el menu de pausa
    {
        Debug.Log("Settings button clicked!");
        MenuPause.SetActive(false);
        SettingsPanel.SetActive(true);

    }
    private void OnCredittsPauseButtonClicked()    // Abre el panel de creditos desde el menu de pausa
    {
        Debug.Log("Creditos button clicked!");
        MenuPause.SetActive(false);
        CredittsPanel.SetActive(true);
    }
    private void OnExitPauseButtonClicked() // Metodo para salir del juego desde el menu de pausa
    {
        Debug.Log("Exit button clicked!");
        Application.Quit();
        #if UNITY_EDITOR
        // Dentro del editor: detiene el Play
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }


    private void OnSpeedPlayer1(float value)
    {
       Player1.speed = value;
       textSpedd_player1.text = value.ToString("F2");
    }
    private void OnSpeedPlayer2(float value)
    {
        Player2.speed = value;
        textSpedd_player2.text = value.ToString("F2");
    }
}
