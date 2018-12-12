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
        public System.Collections.Generic.ICollection<MarsError.Web.Models.ChildDtoGen> Children { get; set; }

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
            var propValChildren = obj.Children;
            if (propValChildren != null && (tree == null || tree[nameof(this.Children)] != null))
            {
                this.Children = propValChildren
                    .AsQueryable().OrderBy("Name ASC").AsEnumerable<MarsError.Data.Models.Child>()
                    .Select(f => f.MapToDto<MarsError.Data.Models.Child, ChildDtoGen>(context, tree?[nameof(this.Children)])).ToList();
            }
            else if (propValChildren == null && tree?[nameof(this.Children)] != null)
            {
                this.Children = new ChildDtoGen[0];
            }

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
