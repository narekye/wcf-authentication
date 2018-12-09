using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace Sample.AppServer.App_Data
{
    public class CustomValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName.Equals(password))
                throw new FaultException("cannot perform");

            // throw FaultExceptions if you want to receive error message from this call.

            // Query db to check if user with username and password exists or not
        }
    }
}