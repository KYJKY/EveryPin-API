using Entites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.Exceptions;

public sealed class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(string userEmail)
        : base($"Email [{userEmail}]에 해당하는 유저 정보가 데이터베이스에 존재하지 않습니다.")
    {
        
    }
}
