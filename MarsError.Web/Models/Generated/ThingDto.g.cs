using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Claims;

namespace MarsError.Web.Models
{
    public partial class ThingDtoGen : GeneratedDto<MarsError.Data.Models.Thing>
    {
        public ThingDtoGen() { }

        public long? ThingId { get; set; }
        public string Foo { get; set; }
        public string Bar { get; set; }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(MarsError.Data.Models.Thing obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.ThingId = obj.ThingId;
            this.Foo = obj.Foo;
            this.Bar = obj.Bar;
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(MarsError.Data.Models.Thing entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            entity.ThingId = (ThingId ?? entity.ThingId);
            entity.Foo = Foo;
            entity.Bar = Bar;
        }
    }
}
