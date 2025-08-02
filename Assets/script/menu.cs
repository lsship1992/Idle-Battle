using System.Collections;
using System.Collections.Generic;
using System.Threading;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.Windows;



public class menu : MonoBehaviour
{
    public static menu instance;
    public InputField UsernameField;
    public InputField PassswordField;
    public InputField MailFieldLogin;
    public InputField PasswordlFieldLogin;
    public bool RegisterAll;
    public GameObject LoginNo;
    public GameObject LoginNoText;
    public GameObject NoServerSelect;
    public GameObject NoAuth;
    public GameObject RegistrationAccountInfo;
    public GameObject LoginAccountInfo;
    public Button ButtonReg;
    public Button ButtonLogin;
    public GameObject ParentServerSearch;
    public GameObject ServerSearchPrefab;
    public GameObject server;
    public GameObject login;
    public GameObject loginPanelSend;
    public GameObject ErrorGooglePlayAuth;
    public Text ErrorText;
    [SerializeField] private GameObject register;
    //[SerializeField] private Text ServerNameText;
    [SerializeField] private Text ServerNameTextLoginTo;
    public GameObject LoadPanel;
    public Image LoadSlider;
    public string ip = "109.73.206.253";
    public int port = 26951;
    public int myId = 0;
    public string nameserver = "";
    public bool IsGoust = false;
    public string IdUserGooglePlay = "";
    public bool IsGoogle = false;
    public bool IsRegister = false;

    public void LoadSceneAsync(string sceneName)
    {
        LoadPanel.SetActive(true);
        StartCoroutine(LoadSceneAsyncCoroutine(sceneName));
        
    }

    private IEnumerator LoadSceneAsyncCoroutine(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        // Ожидание завершения загрузки
        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f); // Прогресс от 0 до 1
            LoadSlider.fillAmount = progress;
            Debug.Log($"Прогресс загрузки: {progress * 100}%");
            yield return null;
        }

        Debug.Log("Сцена загружена!");
    }
    private void Start()
    {
       
        if (PlayerPrefs.HasKey("mail") && PlayerPrefs.HasKey("GameServerIp"))
        {
            if (PlayerPrefs.GetString("mail") != "" && PlayerPrefs.GetString("GameServerIp") != "")
            {
                
                Client.instance.Disconnect();
                LoadSceneAsync("Game");
                //SceneManager.LoadScene(1);
            }
        }
    }

    internal void ProcessAuthentication(SignInStatus status)
    {
        if (status == SignInStatus.Success)
        {
            IdUserGooglePlay = PlayGamesPlatform.Instance.GetUserId();
            IsGoogle = true;
            ClientSend.ServerSerch();
            server.SetActive(true);
            RegistrationAccountInfo.SetActive(true);
            Invoke("RegistrationInfo", 5);

        }
        else
        {
            
            ErrorGooglePlayAuth.SetActive(true);
            Invoke("RegisterNo", 2);
        }
    }
    
    public void GooglePlayAuthButton()
    {
        PlayGamesPlatform.Instance.Authenticate(ProcessAuthentication);
    }
    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroy object");
            Destroy(this);

        }
        
    }
    public static void AddServerSearch(int b,string _nameserver,string _ipserver)
    {
        int pozY = b * 130;
        GameObject ButtonSearch = Instantiate(menu.instance.ServerSearchPrefab);
        ButtonSearch.transform.localPosition = new Vector3(0, ButtonSearch.transform.localPosition.y - pozY, 0);
        ButtonSearch.transform.SetParent(menu.instance.ParentServerSearch.transform, false);
        foreach (Transform t in ButtonSearch.gameObject.transform.GetComponentsInChildren<Transform>())
        {
            if (t.name == "select")
            {
                t.GetComponent<ServerSearchInfo>().ip = _ipserver;
                t.GetComponent<ServerSearchInfo>()._nameserver = _nameserver;
            }
            if (t.name == "NameServer")
            {
                t.GetComponent<Text>().text = _nameserver;
            }
        }
            //Debug.Log(ButtonSearch.gameObject.transform.Find("NameServer"));
            //Debug.Log(ButtonSearch.transform.localPosition);
        
    }
    public void ServerSearchButton()
    {
        ClientSend.ServerSerch();
        server.SetActive(true);
    }
    public void GoustButton()
    {
       
        IsGoust = true;
        ClientSend.ServerSerch();
        server.SetActive(true);
        LoginAccountInfo.SetActive(true);
        Invoke("RegistrationInfo", 5);
    }
    public void RegisterButton()
    {
        if (UsernameField.text == "" || PassswordField.text == "")
        {
            LoginNoText.SetActive(true);
            Invoke("RegisterNo", 2);
        }
        else
        {
            IsRegister = true;
            ClientSend.ServerSerch();
            server.SetActive(true);
            
            Invoke("RegistrationInfo", 5);

        }
        
       
    }

    public void LoginButton()
    {
        if (MailFieldLogin.text == "" || PasswordlFieldLogin.text == "")
        {
            LoginNoText.SetActive(true);
            Invoke("RegisterNo", 2);
        }
        else
        {
            ClientSend.ServerSerch();
            server.SetActive(true);
            LoginAccountInfo.SetActive(true);
            Invoke("RegistrationInfo", 5);


            
        }
    }
    
    public void LoginMenuOpen()
    {
        register.SetActive(false);
        login.SetActive(true);
    }
    private void RegistrationInfo()
    {
        RegistrationAccountInfo.SetActive(false);
        LoginAccountInfo.SetActive(false);
        
    }
    private void RegisterNo()
    {
        LoginNo.SetActive(false);
        LoginNoText.SetActive(false);
        NoServerSelect.SetActive(false);
        NoAuth.SetActive(false);
        ErrorGooglePlayAuth.SetActive(false);
    }
    public void SelectServer()
    {
        server.SetActive(true);
        register.SetActive(false);
    }
    public void ExitMainRegister()
    {
        server.SetActive(false);
        login.SetActive(false);
        register.SetActive(true);
    }
}
