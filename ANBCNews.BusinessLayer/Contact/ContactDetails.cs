using ANBCNews.DataAccessLayer.Comment;
using ANBCNews.DataAccessLayer.Master;
using ANBCNews.Model;
using ANBCNews.Model.Contact;
using ANBCNews.Model.Master;
using System;
using System.Collections.Generic;

namespace ANBCNews.BusinessLayer.Master
{
    public class ContactDetails
    {

        public DBResponse SaveContact(ContactEntity objContact)
        {
            ContactDataAccess objDataAccess = new ContactDataAccess();
            return objDataAccess.SaveContact(objContact);
        } 

    }
}
