using ANBCNews.DataAccessLayer.Comment;
using ANBCNews.DataAccessLayer.Master;
using ANBCNews.Model;
using ANBCNews.Model.Comment;
using ANBCNews.Model.Master;
using System;
using System.Collections.Generic;

namespace ANBCNews.BusinessLayer.Master
{
    public class CommentDetails
    {

        public DBResponse SaveComment(CommentEntity objComment)
        {
            CommentDataAccess objDataAccess = new CommentDataAccess();
            return objDataAccess.SaveComment(objComment);
        } 

    }
}
