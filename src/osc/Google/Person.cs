using System;
using System.Collections.Generic;

using OutlookSocialProvider;

using Google.Contacts;
using Google.GData.Contacts;
using Google.GData.Extensions;
using Google.GData.Client;

namespace OpenOSC
{
  namespace Google
  {
    class Person : ISocialPerson
    {
      public readonly Session session;

      public Person(Session session)
      {
        this.session = session;
      }

      public string GetActivities(DateTime startTime)
      {
        return string.Empty;
      }

      public string GetDetails()
      {
        return string.Empty;
      }

      public string GetFriendsAndColleagues()
      {
        ContactsRequest contectsRequest = new ContactsRequest(session.requestSettings);
        Feed<Contact> contacts = contectsRequest.GetContacts();
        contacts.AutoPaging = true;

        List<personType> friends = new List<personType>();
        foreach(Contact contact in contacts.Entries)
        {
          personType friend = new personType();

          friend.userID = contact.Id;
          friend.firstName = contact.Name.GivenName;
          friend.lastName = contact.Name.FamilyName;
          friend.fullName = contact.Name.FullName;
          friend.title = contact.Title;
          // friend.nickname
          // friend.fileAs
          // friend.company
          // friend.anniversary
          // friend.anniversarySpecified
          // friend.birthday
          // friend.birthdaySpecified
          if (contact.Emails.Count > 0)
            friend.emailAddress = contact.Emails[0].Address;
          if (contact.Emails.Count > 1)
            friend.emailAddress2 = contact.Emails[1].Address;
          if (contact.Emails.Count > 2)
            friend.emailAddress3 = contact.Emails[2].Address;
          // friend.webProfilePage
          if (contact.Phonenumbers.Count > 0)
            friend.phone = contact.Phonenumbers[0].Value;
          // friend.cell
          // friend.homePhone
          // friend.workPhone
          // friend.address
          // friend.city
          // friend.state
          // friend.countryOrRegion
          // friend.zip
          // friend.relationship
          // friend.creationTime
          // friend.creationTimeSpecified
          // friend.lastModificationTime
          // friend.lastModificationTimeSpecified
          // friend.expirationTime
          // friend.expirationTimeSpecified
          // friend.gender
          // friend.index
          // friend.indexSpecified
          // friend.pictureUrl
          // friend.friendStatus

          friends.Add(friend);
        }

        friends friendList = new friends();
        friendList.person = friends.ToArray();

        return Helper.xmlToString(friendList);
      }

      public string[] GetFriendsAndColleaguesIDs()
      {
        return null;
      }

      public byte[] GetPicture()
      {
        return null;
      }

      public string GetStatus()
      {
        return string.Empty;
      }
    }
  }
}
