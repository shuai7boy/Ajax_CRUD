using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ContactGroup
    {
        //groupId, groupName

        private string _groupName;

        public string GroupName
        {
            get { return _groupName; }
            set { _groupName = value; }
        }
        private int _groupId;

        public int GroupId
        {
            get { return _groupId; }
            set { _groupId = value; }
        }
    }
}
