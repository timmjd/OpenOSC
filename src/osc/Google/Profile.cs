using System;
using OutlookSocialProvider;

namespace OpenOSC
{
  namespace Google
  {
    class Profile : Person, ISocialProfile
    {
      public Profile(Session session) : base(session)
      {
      }

      public bool[] AreFriendsOrColleagues(string[] userIDs)
      {
        return null;
      }

      public string GetActivitiesOfFriendsAndColleagues(DateTime startTime)
      {
        return string.Empty;
      }

      public void SetStatus(string status)
      {
      }
    }
  }
}
