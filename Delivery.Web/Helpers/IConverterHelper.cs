using Delivery.Common.Models;
using Delivery.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.Web.Helpers
{
    public interface IConverterHelper
    {

        RepartidorResponse ToRepartidorResponse(RepartidorEntity repartidorEntity);


    }
}
