using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class TblArea
    {
        //contactId, contactName, cellPhone, email, groupId
        private ContactGroup _groupId;

        public ContactGroup GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _cellPhone;

        public string CellPhone
        {
            get { return _cellPhone; }
            set { _cellPhone = value; }
        }
        private string _contactName;

        public string ContactName
        {
            get { return _contactName; }
            set { _contactName = value; }
        }
        private int _contactId;

        public int ContactId
        {
            get { return _contactId; }
            set { _contactId = value; }
        }
    }
}
