﻿using Swashbuckle.Annotations;
using Swashbuckle.Annotations.AttributeTags;
using System;
using System.Web.Http;

namespace Swashbuckle.Dummy.Controllers
{
    public class ObsoletePropertiesController : ApiController
    {
        public int Create(Event @event)
        {
            throw new NotImplementedException();
        }
    }

    public class Event
    {
        [Obsolete("Switched to generated ids - consumers should only provide Name")]
        public int Id { get; set; }

        public string Name { get; set; }

        [SwaggerIgnore]
        public string PropThatShouldBeIgnored { get; set; }
    }
}