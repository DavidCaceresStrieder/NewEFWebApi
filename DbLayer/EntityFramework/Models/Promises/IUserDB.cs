using ModelsLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModelsLayer.Models.Promises
{
    public interface IUserDB : EFPromise<User>
    {
    }
}
