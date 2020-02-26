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
            MasterDataAccess objDataAccess = new MasterDataAccess();
            return objDataAccess.GetImageType();
        }

        public IEnumerable<MasterNewsType> GetNewsType()
        {
            MasterDataAccess objDataAccess = new MasterDataAccess();
            return objDataAccess.GetNewsType();
        }

    }
}
