﻿using System;
using System.Drawing;

using OutlookSocialProvider;

namespace OpenOSC
{
  namespace Google
  {
    public class Provider : ISocialProvider
    {
      public string applicationName = "Outlook Social Connector";

      public string[] DefaultSiteUrls
      {
        get
        {
          return new string[] { "http://www.google.com" };
        }
      }

      public ISocialSession GetAutoConfiguredSession()
      {
        //return OSC_E_NOT_IMPLEMENTED;
        return new Session(this);
      }

      public string GetCapabilities()
      {
        var caps = new capabilities
        {
          // OSC 1.0
          getFriends = true,
          cacheFriends = true,
          followPerson = false,
          doNotFollowPerson = false,
          getActivities = true,
          cacheActivities = false,
          dynamicActivitiesLookup = false,
          displayUrl = false,
          // useLogonWebAuth = true, 
          hideHyperlinks = false,
          supportsAutoConfigure = false,
          // contactSyncRestartInterval = 10,

          // OSC 1.1
          // dynamicActivitiesLookupEx = false,
          // dynamicContactsLookup = true,
          useLogonCached = false,
          hideRememberMyPassword = false,
          createAccountUrl = "https://accounts.google.com/SignUp",
          forgotPasswordUrl = "https://www.google.com/accounts/recovery",
          // showOnDemandActivitiesWhenMinimized = false,
          // showOnDemandContactsWhenMinimized = false,
          // hashFunction = "MD5"
        };

        return Helper.xmlToString(caps);
      }

      public ISocialSession GetSession()
      {
        return new Session(this);
      }

      public void GetStatusSettings(out string statusDefault, out int maxStatusLength)
      {
        statusDefault = string.Empty;
        maxStatusLength = 0;
      }

      public void Load(string socialProviderInterfaceVersion, string languageTag)
      {

      }

      public Guid SocialNetworkGuid
      {
        get
        {
          return new Guid("5B9CD4F5-10ED-4417-A680-BAFA268B96F3");
        }
      }

      public byte[] SocialNetworkIcon
      {
        get
        {
          return new byte[128*128*3];
        }
      }

      public string SocialNetworkName
      {
        get
        {
          return "Google";
        }
      }

      public string Version
      {
        get
        {
          return "0.1.0.0";
        }
      }
    }
  }
}
