using Entities.ResquestFeatures;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.LinkModels
{
    public record lLinkParameters
    {
        public BookPrametrs BookPrametrs { get; init; }

        public HttpContext HttpContext { get; init; }
    }
}
