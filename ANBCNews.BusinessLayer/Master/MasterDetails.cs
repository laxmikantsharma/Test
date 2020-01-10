using ANBCNews.DataAccessLayer.Master;
using ANBCNews.Model.Master;
using System;
using System.Collections.Generic;

namespace ANBCNews.BusinessLayer.Master
{
    public class MasterDetails
    {

        public IEnumerable<MasterImageType> GetImageType()
        {
            CommentAccess objDataAccess = new CommentAccess();
            return objDataAccess.GetImageType();
        }

        public IEnumerable<MasterNewsType> GetNewsType()
        {
            CommentAccess objDataAccess = new CommentAccess();
            return objDataAccess.GetNewsType();
        }

    }
}
