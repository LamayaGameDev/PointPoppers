using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
public class PlayfabManager : MonoBehaviour
{
    public int MaxResultsCount = 10;
    string loggedInPlayfabId;
    public InputField nameInput;
    public GameObject nameWindow;
    public GameObject leaderboardWindow;
    [Header("UI")]
    public Text messageText;
    public InputField emailInput;
    public InputField passwordInput;
    
    // Start is called before the first frame update
    void Start()
    {
        Login();
       nameWindow.SetActive(false);
       leaderboardWindow.SetActive(false);
        messageText.text = " ";
    }


    public void RegisterButton()
    {
        if (passwordInput.text.Length < 6)
        {
            messageText.text = "Password must be 6+ characters!";
            
            return;
        }
        var request = new RegisterPlayFabUserRequest
        {
            
            Email = emailInput.text,
            Password = passwordInput.text,
            RequireBothUsernameAndEmail = false,
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);

    }

    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        messageText.text = "Registered and logged in!";
       
    }

    public void LoginButton()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = emailInput.text,
            Password = passwordInput.text,

        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnSuccess, OnError);
    }
    public void ResetPasswordButton()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = emailInput.text,
            TitleId = "BB0CB",
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }

    public void OnPasswordReset(SendAccountRecoveryEmailResult result)
    {
        {
            messageText.text = "Password reset email sent!";
        }
    }
    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams {
                GetPlayerProfile = true
            }






        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);

                

   
    }

  
     public void SubmitNameButton()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameInput.text,
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
    }
    public GameObject userPanel;
    public GameObject overPanel;
    public void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result) {
        Debug.Log("name succesfuly changed");
        leaderboardWindow.SetActive(true);
    }
   

   
    


    void OnSuccess(LoginResult result)
    {
        //messageText.text = "Logged in!";
        loggedInPlayfabId = result.PlayFabId;
        messageText.text = "Logged in!";
        Debug.Log("Succesful login or acoutn created");
        string name = null;
       

     if (result.InfoResultPayload.PlayerProfile != null) 
        name = result.InfoResultPayload.PlayerProfile.DisplayName;
     if (name == null) 
        nameWindow.SetActive(true);
     else
         leaderboardWindow.SetActive(true);
            nameWindow.SetActive(false);

    }

    void OnError(PlayFabError error)

    {
        Debug.Log("ERROR whilel oggin in or cretaing acc");
        Debug.Log(error.GenerateErrorReport());
        messageText.text = error.ErrorMessage;
    }
    public void SendLeaderboard(int score)
    {
        List<StatisticUpdate> stats = new List<StatisticUpdate>();
        stats.Add(new StatisticUpdate
        {
            StatisticName = "Buckets made",
            Value = score
        });

        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = stats
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Succesful leaderboard sent!");
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Buckets made",
            MaxResultsCount = 10

        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }
   
    public GameObject rowPrefab;
    public Transform rowsParent;
    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        // Remove all rows from the leaderboard
        foreach (Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }

        // Iterate over each leaderboard entry
            foreach (var item in result.Leaderboard)
            {
                // Instantiate a new row for the leaderboard
                GameObject newGo = Instantiate(rowPrefab, rowsParent);

                // Get the Text components in the new row
                Text[] texts = newGo.GetComponentsInChildren<Text>();

            
            
                    texts[0].text = (item.Position + 1).ToString();
                    texts[1].text = item.DisplayName;
                    texts[2].text = item.StatValue.ToString();
                    if (item.PlayFabId == loggedInPlayfabId)
                    {
                    texts[0].color = Color.green;
                    texts[1].color = Color.green;
                    texts[2].color = Color.green;
                    }

        }
    }
    public void GetLeaderboardAroundPlayer()
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "Buckets made",
            MaxResultsCount = 9

        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLeaderboardAroundPlayerGet, OnError);
    }
    void OnLeaderboardAroundPlayerGet(GetLeaderboardAroundPlayerResult result)
    {
        // Remove all rows from the leaderboard
        foreach (Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }

        // Iterate over each leaderboard entry
        foreach (var item in result.Leaderboard)
        {
            // Instantiate a new row for the leaderboard
            GameObject newGo = Instantiate(rowPrefab, rowsParent);

            // Get the Text components in the new row
            Text[] texts = newGo.GetComponentsInChildren<Text>();



            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();

            if (item.PlayFabId == loggedInPlayfabId)
            {
                texts[0].color = Color.green;
                texts[1].color = Color.green;
                texts[2].color = Color.green;
            }


        }
    }

}
