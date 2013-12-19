using System;
using OutlookSocialProvider;
using Google.GData.Client;
using Google.GData.Contacts;

namespace OpenOSC
{
  namespace Google
  {
    class Session : ISocialSession, ISocialSession2
    {
      public readonly Provider provider;
      public ContactsService contactsService;
      public RequestSettings requestSettings;

      public Session(Provider provider)
      {
        this.provider = provider;
        this.contactsService = new ContactsService(provider.applicationName);
      }

      // ----- ISocialSession -----
      public string FindPerson(string userID)
      {
        return string.Empty;
      }

      public void FollowPerson(string emailAddress)
      {
      }

      public string GetActivities(string[] emailAddresses, DateTime startTime)
      {
        return string.Empty;
      }

      public ISocialProfile GetLoggedOnUser()
      {
        return new Profile(this);
      }

      public string GetLogonUrl()
      {
        return string.Empty;
      }

      public string GetNetworkIdentifier()
      {
        return provider.SocialNetworkName;
      }

      public ISocialPerson GetPerson(string userID)
      {
        return new Person(this);
      }

      public string LoggedOnUserID
      {
        get
        {
          return contactsService.Credentials.Username;
        }
      }

      public string LoggedOnUserName
      {
        get
        {
          return contactsService.Credentials.Username;
        }
      }

      public void Logon(string userName, string password)
      {
        contactsService.setUserCredentials(userName, password);
        requestSettings = new RequestSettings(provider.applicationName, contactsService.Credentials);
      }

      public void LogonWeb(string connectIn, out string connectOut)
      {
        connectOut = string.Empty;
      }

      public string SiteUrl
      {
        set
        {
        }
      }

      public void UnFollowPerson(string userID)
      {
      }

      // ----- ISocialSession2 -----
      public void FollowPersonEx(string[] emailAddresses, string displayName)
      {
      }

      public string GetActivitiesEx(string[] hashedAddresses, DateTime startTime)
      {
        return string.Empty;
      }

      public string GetPeopleDetails(string personsAddresses)
      {
        return string.Empty;
      }

      public void LogonCached(string connectIn, string userName, string password, out string connectOut)
      {
        connectOut = string.Empty;
      }
    }
  }
}
