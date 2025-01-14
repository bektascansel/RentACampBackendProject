﻿using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, DataContext>, IUserDal
    {
        //Bir kullanıcının rollerini çekmek istiyoruz.
        public List<OperationClaim> GetClaims(User user)
        {
            //tabloları join eder ve bize liste döner 
            using (var context=new DataContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };

                return result.ToList();
            }

          
        }
    }
}
