using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Google;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GoogleAuthantication : MonoBehaviour
{
    public string webClientId = "316864938596-rmg17q4onmea81si5qcim0vf8c3utrnf.apps.googleusercontent.com";

    public TextMeshProUGUI userName;
    public TextMeshProUGUI eMail;

    public string imageURL;

    public Image profilePic;

    public GameObject logInPanel;
    public GameObject profilePanel;

    private GoogleSignInConfiguration configuration;
    private SynchronizationContext mainThreadContext;

    void Awake()
    {
        configuration = new GoogleSignInConfiguration
        {
            WebClientId = webClientId,
            RequestIdToken = true
        };
        // Capture the main thread's synchronization context
        mainThreadContext = SynchronizationContext.Current;
    }

    public void OnSignIn()
    {
        GoogleSignIn.Configuration = configuration;
        GoogleSignIn.Configuration.UseGameSignIn = false;
        GoogleSignIn.Configuration.RequestIdToken = true;
        GoogleSignIn.Configuration.RequestEmail = true;

        GoogleSignIn.DefaultInstance.SignIn().ContinueWith(
          OnAuthenticationFinished, TaskScheduler.Default);
    }

    internal void OnAuthenticationFinished(Task<GoogleSignInUser> task)
    {
        if (task.IsFaulted)
        {
            using (IEnumerator<Exception> enumerator = task.Exception.InnerExceptions.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    GoogleSignIn.SignInException error = (GoogleSignIn.SignInException)enumerator.Current;
                    Debug.Log("Got Error: " + error.Status + " " + error.Message);
                }
                else
                {
                    Debug.Log("Got Unexpected Exception?!?" + task.Exception);
                }
            }
        }
        else if (task.IsCanceled)
        {
            Debug.Log("Canceled");
        }
        else
        {
            // Post UI update to the main thread
            mainThreadContext.Post(_ =>
            {
                userName.text = task.Result.DisplayName;
                eMail.text = task.Result.Email;

                imageURL = task.Result.ImageUrl.ToString();

                logInPanel.SetActive(false);
                profilePanel.SetActive(true);

                StartCoroutine(LoadProfilePic());
            }, null);

            Debug.Log("Welcome: " + task.Result.DisplayName + "!");
        }
    }

    IEnumerator LoadProfilePic()
    {
        WWW www = new WWW(imageURL);
        yield return www;

        profilePic.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
    }

    public void OnSignOut()
    {
        userName.text = "";
        eMail.text = "";

        logInPanel.SetActive(true);
        profilePanel.SetActive(false);

        GoogleSignIn.DefaultInstance.SignOut();
    }
}
