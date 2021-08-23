using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challange2_ClassLibrary
{
    public class ClaimsRepository
    {
        protected readonly Queue<Claims> _claimDirecoty = new Queue<Claims>();

        //C
        public bool AddClaim(Claims claim)
        {
            int startCount = _claimDirecoty.Count();
            _claimDirecoty.Enqueue(claim);
            return startCount < _claimDirecoty.Count();
        }

        //R
        public Queue<Claims> GetAllClaims()
        {
            return _claimDirecoty;
        }
        
       /* 
        public Claim GetclaimById(int id)
        {
            foreach (Claim item in _claimDirecoty)
            {
                if (item.ClaimId == id)
                {
                    return item;
                }
            }
            Console.WriteLine("No claim with that Id avaliable");
            return null;
        }*/

        //U
        //D
        public Claims DeleteClaim()
        {
            Claims deleteResult = _claimDirecoty.Dequeue();
            return deleteResult;
        }
    }
}
